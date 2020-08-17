using System;
using KillBillClient.Infrastructure.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KillBillClient.Infrastructure.Json
{
    public class ShortDateTimeConverter : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            return reader.TokenType == JsonToken.Null ? DateTime.MinValue : DateTime.Parse(reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value is DateTime)) return;
            var dateTime = (DateTime) value;
            writer.WriteValue(dateTime.ToDateString());
        }
    }
}