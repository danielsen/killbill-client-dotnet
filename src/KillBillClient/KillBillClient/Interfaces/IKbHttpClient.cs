﻿using System.Threading.Tasks;
using KillBillClient.Configuration;
using KillBillClient.Data;
using RestSharp;

namespace KillBillClient.Interfaces
{
    public interface IKbHttpClient
    {
        KillBillConfiguration Configuration { get; }

        Task<IRestResponse> Get(string uri, RequestOptions requestOptions);

        Task<T> Get<T>(string uri, RequestOptions requestOptions)
            where T : class;

        Task<IRestResponse> Post(string uri, object body, RequestOptions requestOptions);

        Task<T> Post<T>(string uri, object body, RequestOptions requestOptions)
            where T : class;

        Task<IRestResponse> Put(string uri, object body, RequestOptions requestOptions);

        Task<T> Put<T>(string uri, object body, RequestOptions requestOptions)
            where T : class;

        // Task<T> Put<T>(string uri, object body, MultiMap<string> options, MultiMap<string> optionsForFollow, bool followLocation) where T : class;        
        // Task<T> PutAndFollow<T>(string uri, object body, MultiMap<string> options, MultiMap<string> optionsForFollow) where T : class;
        Task<IRestResponse> Delete(string uri, RequestOptions requestOptions);

        Task<IRestResponse> Delete(string uri, object body, RequestOptions requestOptions);

        // Task<IRestResponse> Delete(string uri, MultiMap<string> options);
        // Task<IRestResponse> Delete(string uri, object body, MultiMap<string> options);       
    }
}
