﻿using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KillBillClient.Configuration;
using KillBillClient.Data;
using KillBillClient.Extensions;
using KillBillClient.Infrastructure;
using KillBillClient.Interfaces;
using KillBillClient.JSON;
using KillBillClient.Model;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace KillBillClient.Implementations
{
    public class KillBillHttpClient : IKbHttpClient
    {
        private readonly KillBillConfiguration _config;

        public KillBillHttpClient(KillBillConfiguration config)
        {
            _config = config;
        }

        private void AddRequestBody(IRestRequest request, object body, string contentType)
        {
            switch (contentType)
            {
                case ContentType.Xml:
                    request.AddParameter("text/xml", body, ParameterType.RequestBody);
                    return;
                default:
                    try
                    {
                        request.AddBody(body);
                        return;
                    }
                    catch (Exception ex)
                    {
                        throw new KillBillClientException("Error serializing object for API request.", ex);
                    }
            }
        }

        private IRestRequest BuildRequestForFormat(string uri, Method method, string contentType)
        {
            switch (contentType)
            {
                case ContentType.Xml:
                    return new RestRequest(uri, method)
                    {
                        RequestFormat = DataFormat.Xml
                    };
                default:
                    return new RestRequest(uri, method)
                    {
                        RequestFormat = DataFormat.Json,
                        JsonSerializer = new RestSharpJsonNetSerializer()
                    };
            }
        }

        private IRestRequest BuildRequestWithHeaderAndQuery(Method method, string uri, RequestOptions requestOptions)
        {
            var request = BuildRequestForFormat(uri, method, requestOptions.ContentType);

            // Multi Tenancy Headers
            request.AddHeader(_config.HDR_API_KEY, requestOptions.TenantApiKey);
            request.AddHeader(_config.HDR_API_SECRET, requestOptions.TenantApiSecret);

            if (requestOptions.CreatedBy != null)
                request.AddHeader(_config.HDR_CREATED_BY, requestOptions.CreatedBy);

            if (requestOptions.Comment != null)
                request.AddHeader(_config.HDR_COMMENT, requestOptions.Comment);

            if (requestOptions.Reason != null)
                request.AddHeader(_config.HDR_REASON, requestOptions.Reason);

            request.AddHeader("Content-Type", requestOptions.ContentType);
            request.AddHeader("Accept", "application/json, text/html");

            foreach (var key in requestOptions.QueryParams.Keys)
                request.AddParameter(key, requestOptions.QueryParams[key].FirstOrDefault(), ParameterType.QueryString);

            return request;
        }

        private void CheckResponse<T>(IRestResponse response, out T defaultObject)
            where T : class
        {
            if (response == null)
                throw new KillBillClientException("Error calling KillBill: no response");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new KillBillClientException(response.ErrorMessage,
                    new ArgumentException("Unauthorized - did you configure your RBAC and/or tenant credentials?"));
            }

            if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.NotFound)
            {
                // Return empty list for KillBillObjects instead of null for convenience
                if (typeof(T).IsAssignableFrom(typeof(KillBillObjects<>)))
                {
                    defaultObject = Activator.CreateInstance<T>();
                    return;
                }

                defaultObject = default(T);
                return;
            }

            if (response.StatusCode >= HttpStatusCode.BadRequest && response.Content != null)
            {
                var billingException =
                    JsonConvert.DeserializeObject<BillingException>(response.Content,
                        JsonNetSerializationSettings.GetDefault());
                var message = "Error " + response.StatusCode + " from Kill Bill " + billingException.Message;
                throw new KillBillClientException(message, response.StatusCode.ToString(), billingException.Code,
                    billingException.Message);
            }

            if (response.ErrorException != null)
            {
                const string message = "An unexpected error occurred connecting with KillBill: ";
                var exception = new KillBillClientException(message, response.ErrorException);
                throw exception;
            }

            defaultObject = default(T);
        }

        private RestClient CreateClient(string baseUri, RequestOptions requestOptions)
        {
            string proxyUri = null;
            if (!string.IsNullOrEmpty(_config.ApiProxy))
            {
                proxyUri = _config.ApiProxy;
            }

            return new RestClient(baseUri)
            {
                Authenticator = new HttpBasicAuthenticator(requestOptions.User, requestOptions.Password),
                Proxy = proxyUri != null ? new WebProxy(proxyUri) : null
            };
        }

        private T DeserializeResponse<T>(IRestResponse response)
        {
            var obj = JsonConvert.DeserializeObject<T>(response.Content, JsonNetSerializationSettings.GetDefault());

            if (obj.GetType().GetInterfaces().Contains(typeof(IKillBillObjects)))
            {
                var objects = obj as IKillBillObjects;

                // Get Pagination meta data from the response headers
                if (objects == null)
                    return obj;

                var paginationCurrentOffset = response.Headers.GetValue(_config.HDR_PAGINATION_CURRENT_OFFSET);
                if (paginationCurrentOffset != null)
                    objects.PaginationCurrentOffset = paginationCurrentOffset.ToInt();

                var paginationNextOffset = response.Headers.GetValue(_config.HDR_PAGINATION_NEXT_OFFSET);
                if (paginationNextOffset != null)
                    objects.PaginationNextOffset = paginationNextOffset.ToInt();

                var paginationMaxNbRecords = response.Headers.GetValue(_config.HDR_PAGINATION_MAX_NB_RECORDS);
                if (paginationMaxNbRecords != null)
                    objects.PaginationMaxNbRecords = paginationMaxNbRecords.ToInt();

                var paginationNextPageUri = response.Headers.GetValue(_config.HDR_PAGINATION_NEXT_PAGE_URI);
                if (paginationNextPageUri != null)
                    objects.PaginationNextPageUri = paginationNextPageUri;

                objects.KillBillHttpClient = this;
            }

            return obj;
        }

        private async Task<IRestResponse> ExecuteRequest(IRestRequest request, RequestOptions requestOptions)
        {
            var baseUri = _config.ServerUrl;
            var client = CreateClient(baseUri, requestOptions);

            if (request.Resource.Contains("http"))
                throw new ArgumentException(
                    "Request.Resource should be a relative Uri (/location) and not the full Url (http, domain etc)");

            var response = await client.ExecuteTaskAsync(request);

            object defaultObject;
            CheckResponse(response, out defaultObject);

            return response;
        }

        private string GetUniqueValue(MultiMap<string> options, string key)
        {
            if (options == null || !options.Keys.Contains(key))
                return null;

            var values = options[key];

            if (values == null || values.Count == 0)
                return null;

            return values.First();
        }

        // SEND REQUEST
        // -------------------------------------------------------------------------------
        private async Task<IRestResponse> SendRequest(Method method, string uri, object body,
            RequestOptions requestOptions)
        {
            var request = BuildRequestWithHeaderAndQuery(method, uri, requestOptions);

            if (method != Method.GET || method != Method.HEAD)
            {
                if (body != null) AddRequestBody(request, body, requestOptions.ContentType);
            }

            return await ExecuteRequest(request, requestOptions);
        }

        // SEND REQUEST MAYBE FOLLOW
        // -------------------------------------------------------------------------------
        private async Task<T> SendRequestAndMaybeFollowLocation<T>(Method method, string uri, object body,
            RequestOptions requestOptions)
            where T : class
        {
            var request = BuildRequestWithHeaderAndQuery(method, uri, requestOptions);

            if (method != Method.GET || method != Method.HEAD)
            {
                if (body != null) AddRequestBody(request, body, requestOptions.ContentType);
            }

            // WHEN FollowLocation == TRUE
            if (requestOptions.FollowLocation == true)
            {
                var responseToFollow = await ExecuteRequest(request, requestOptions);

                var locationHeader = responseToFollow?.Headers.SingleOrDefault(
                    h => h.Type == ParameterType.HttpHeader && h.Name == "Location");

                if (locationHeader?.Value == null || locationHeader.Value.ToString() == string.Empty)
                    return default(T);

                var locationUri = new Uri(locationHeader.Value.ToString());

                var optionsForFollow = RequestOptions.Builder()
                    .WithUser(requestOptions.User)
                    .WithPassword(requestOptions.Password)
                    .WithTenantApiKey(requestOptions.TenantApiKey)
                    .WithTenantApiSecret(requestOptions.TenantApiSecret)
                    .WithRequestId(requestOptions.RequestId)
                    .WithFollowLocation(false)
                    .WithQueryParams(requestOptions.QueryParamsForFollow)
                    .Build();

                return await Get<T>(locationUri.PathAndQuery, optionsForFollow);
            }

            var response = await ExecuteRequest(request, requestOptions);

            // If there is no response (204) or if an object cannot be found (404), the code will return null (for single objects) or an empty list (for collections of objects).
            if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.NotFound)
            {
                // Return empty list for KillBillObjects instead of null for convenience
                return typeof(T).IsAssignableFrom(typeof(KillBillObjects<>))
                    ? Activator.CreateInstance<T>()
                    : default(T);
            }

            // If there we did not want to follow the location on a POST method, we return the default
            if (method == Method.POST && requestOptions.FollowLocation != true)
            {
                // Return empty list for KillBillObjects instead of null for convenience
                return typeof(T).IsAssignableFrom(typeof(KillBillObjects<>))
                    ? Activator.CreateInstance<T>()
                    : default(T);
            }

            var data = DeserializeResponse<T>(response);
            return data;
        }

        public KillBillConfiguration Configuration
        {
            get { return _config; }
        }

        // GET
        // -------------------------------------------------------------------------------
        public async Task<IRestResponse> Get(string uri, RequestOptions requestOptions)
        {
            return await SendRequest(Method.GET, uri, null, requestOptions);
        }

        public async Task<T> Get<T>(string uri, RequestOptions requestOptions)
            where T : class
        {
            return await SendRequestAndMaybeFollowLocation<T>(Method.GET, uri, null, requestOptions);
        }

        // POST
        // -------------------------------------------------------------------------------
        // - untyped without follow
        public async Task<IRestResponse> Post(string uri, object body, RequestOptions requestOptions)
        {
            return await SendRequest(Method.POST, uri, body, requestOptions);
        }

        public async Task<T> Post<T>(string uri, object body, RequestOptions requestOptions)
            where T : class
        {
            return await SendRequestAndMaybeFollowLocation<T>(Method.POST, uri, body, requestOptions);
        }

        // PUT
        // -------------------------------------------------------------------------------
        // - untyped without follow
        public async Task<IRestResponse> Put(string uri, object body, RequestOptions requestOptions)
        {
            return await SendRequest(Method.PUT, uri, body, requestOptions);
        }

        public async Task<T> Put<T>(string uri, object body, RequestOptions requestOptions)
            where T : class
        {
            return await SendRequestAndMaybeFollowLocation<T>(Method.PUT, uri, body, requestOptions);
        }

        // DELETE
        // -------------------------------------------------------------------------------
        // - untyped without follow
        public async Task<IRestResponse> Delete(string uri, RequestOptions requestOptions)
        {
            return await SendRequest(Method.DELETE, uri, null, requestOptions);
        }

        public async Task<IRestResponse> Delete(string uri, object body, RequestOptions requestOptions)
        {
            return await SendRequest(Method.DELETE, uri, body, requestOptions);
        }
    }
}