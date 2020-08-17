using System.Collections.Generic;
using System.Collections.Immutable;
using KillBillClient.Infrastructure.Data;
using ContentType = System.Net.Mime.ContentType;

namespace KillBillClient.Infrastructure.Api
{
    public class RequestContentType
    {
        private const string _json = "application/json; charset=utf-8";
        private const string _xml = "application/xml; charset=utf-8";

        private ContentType ContentType { get; }
        public bool IsJson => ContentType.ToString() == _json;
        public bool IsXml => ContentType.ToString() == _xml;

        private RequestContentType(string contentType)
        {
            ContentType = new ContentType(contentType);
        }
        
        public static RequestContentType AsJson() => new RequestContentType(_json);
        public static RequestContentType AsXml() => new RequestContentType(_xml);

        public override string ToString() => ContentType.ToString();
    }
    
    public class RequestOptionsBuilder
    {
        private string _comment;

        private RequestContentType _contentType = RequestContentType.AsJson();

        private string _createdBy;

        private bool? _followLocation;

        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();

        private string _password;

        private MultiMap<string> _queryParams = new MultiMap<string>();

        private MultiMap<string> _queryParamsForFollow = new MultiMap<string>();

        private string _reason;
        private string _requestId;

        private string _tenantApiKey;

        private string _tenantApiSecret;

        private string _user;

        public RequestOptions Build()
        {
            return new RequestOptions(_requestId, _user, _password, _comment, _reason, _createdBy, _tenantApiKey,
                _tenantApiSecret, _contentType, _headers.ToImmutableDictionary(), _queryParams, _followLocation,
                _queryParamsForFollow);
        }

        public RequestOptionsBuilder WithComment(string comment)
        {
            _comment = comment;
            return this;
        }

        public RequestOptionsBuilder WithContentType(RequestContentType contentType)
        {
            _contentType = contentType;
            return this;
        }

        public RequestOptionsBuilder WithCreatedBy(string createdBy)
        {
            _createdBy = createdBy;
            return this;
        }

        public RequestOptionsBuilder WithFollowLocation(bool? followLocation)
        {
            _followLocation = followLocation;
            return this;
        }

        public RequestOptionsBuilder WithHeader(string header, string value)
        {
            _headers.Add(header, value);
            return this;
        }

        public RequestOptionsBuilder WithJsonContentType()
        {
            _contentType = RequestContentType.AsJson();
            return this;
        }

        public RequestOptionsBuilder WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public RequestOptionsBuilder WithQueryParams(MultiMap<string> queryParams)
        {
            _queryParams = queryParams;
            return this;
        }

        public RequestOptionsBuilder WithQueryParamsForFollow(MultiMap<string> queryParamsForFollow)
        {
            _queryParamsForFollow = queryParamsForFollow;
            return this;
        }

        public RequestOptionsBuilder WithReason(string reason)
        {
            _reason = reason;
            return this;
        }

        public RequestOptionsBuilder WithRequestId(string requestId)
        {
            _requestId = requestId;
            return this;
        }

        public RequestOptionsBuilder WithTenantApiKey(string tenantApiKey)
        {
            _tenantApiKey = tenantApiKey;
            return this;
        }

        public RequestOptionsBuilder WithTenantApiSecret(string tenantApiSecret)
        {
            _tenantApiSecret = tenantApiSecret;
            return this;
        }

        public RequestOptionsBuilder WithUser(string user)
        {
            _user = user;
            return this;
        }

        public RequestOptionsBuilder WithXmlContentType()
        {
            _contentType = RequestContentType.AsXml();
            return this;
        }
    }
}