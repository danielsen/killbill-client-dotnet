﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KillBillClient.JSON
{
    public class JsonNetSerializationSettings : JsonSerializerSettings
    {
        public static JsonNetSerializationSettings GetDefault()
        {
            return new JsonNetSerializationSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DefaultValueHandling = DefaultValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore,
            };
        }
    }
}