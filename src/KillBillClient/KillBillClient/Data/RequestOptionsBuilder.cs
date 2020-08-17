using System.Collections.Generic;
using System.Collections.Immutable;
using KillBillClient.Infrastructure;

namespace KillBillClient.Data
{
    public class RequestOptionsBuilder
    {
        private string _comment;

        private string _contentType = ContentType.Json;

        private string _createdBy;

        private bool? _followLocation;

        private Dictionary<string, string> _headers = new Dictionary<string, string>();

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

        public RequestOptionsBuilder WithContentType(string contentType)
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
    }
}