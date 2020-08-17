﻿using System;
using System.Collections.Immutable;
using KillBillClient.Infrastructure.Configuration;
using KillBillClient.Infrastructure.Data;

namespace KillBillClient.Infrastructure.Api
{
    public class RequestOptions
    {
        // TODO: Fix parameter order
        public RequestOptions(
            string requestId,
            string user,
            string password,
            string comment,
            string reason,
            string createdBy,
            string tenantApiKey,
            string tenantApiSecret,
            RequestContentType contentType,
            ImmutableDictionary<string, string> headers,
            MultiMap<string> queryParams,
            bool? followLocation,
            MultiMap<string> queryParamsForFollow)
        {
            RequestId = requestId;
            User = user;
            Password = password;
            Comment = comment;
            Reason = reason;
            CreatedBy = createdBy;
            TenantApiKey = tenantApiKey;
            TenantApiSecret = tenantApiSecret;
            FollowLocation = followLocation;
            ContentType = contentType ?? RequestContentType.AsJson();
            Headers = headers ?? ImmutableDictionary<string, string>.Empty;
            QueryParams = queryParams ?? new MultiMap<string>();
            QueryParamsForFollow = queryParamsForFollow ?? new MultiMap<string>();
        }

        public string Comment { get; }

        public RequestContentType ContentType { get; }

        public string CreatedBy { get; }

        public bool? FollowLocation { get; }

        public ImmutableDictionary<string, string> Headers { get; }

        public string Password { get; }

        public MultiMap<string> QueryParams { get; }

        public MultiMap<string> QueryParamsForFollow { get; }

        public string Reason { get; }

        public string RequestId { get; }

        public string TenantApiKey { get; }

        public string TenantApiSecret { get; }

        public string User { get; }

        /// <summary>
        /// Helper method for creating a new builder.
        /// </summary>
        /// <returns>A new instance of <see cref="RequestOptionsBuilder"/>.</returns>
        public static RequestOptionsBuilder Builder()
        {
            return new RequestOptionsBuilder();
        }

        /// <summary>
        /// Helper method for creating an empty RequestOptions object based on the configuration.
        /// </summary>
        /// <param name="config">The <see cref="KillBillConfiguration"/> object containing the Kill Bill configuration.</param>
        /// <returns>An empty <see cref="RequestOptions"/> object.</returns>
        public static RequestOptions Default(KillBillConfiguration config)
        {
            return new RequestOptionsBuilder()
                .WithUser(config.HttpUser)
                .WithTenantApiKey(config.ApiKey)
                .WithTenantApiSecret(config.ApiSecret)
                .WithRequestId(Guid.NewGuid().ToString())
                .WithCreatedBy("Default User")
                .WithPassword(config.HttpPassword)
                .WithJsonContentType()
                .Build();
        }

        /// <summary>
        /// Helper method for creating an empty RequestOptions object.
        /// </summary>
        /// <returns>An empty <see cref="RequestOptions"/> object.</returns>
        public static RequestOptions Empty()
        {
            return new RequestOptionsBuilder().Build();
        }

        /// <summary>
        /// Helper method for extending the builder.
        /// </summary>
        /// <returns>A new instance of <see cref="RequestOptionsBuilder"/> containing the existing parameters of the <see cref="RequestOptions"/> object.</returns>
        public RequestOptionsBuilder Extend()
        {
            var builder = new RequestOptionsBuilder();

            foreach (var hdr in Headers)
            {
                builder.WithHeader(hdr.Key, hdr.Value);
            }

            return builder
                .WithRequestId(RequestId)
                .WithUser(User).WithPassword(Password)
                .WithCreatedBy(CreatedBy).WithReason(Reason).WithComment(Comment)
                .WithTenantApiKey(TenantApiKey).WithTenantApiSecret(TenantApiSecret)
                .WithQueryParams(QueryParams)
                .WithFollowLocation(FollowLocation).WithQueryParamsForFollow(QueryParamsForFollow);
        }

        public bool ShouldFollowLocation() => FollowLocation ?? false;
    }
}