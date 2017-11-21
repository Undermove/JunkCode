using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KeycloakAuthRequestExample.Utils.HttpUtils.Converters
{
    public class UnixDateTimeConverter : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.Integer)
            {
                throw new Exception($"Unexpected token parsing date. Expected Integer, got {reader.TokenType}.");
            }

            long seconds = (long)reader.Value;

            return DateTimeOffset.FromUnixTimeSeconds(seconds).DateTime;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long seconds;
            if (value is DateTime)
            {
                // ReSharper disable once PossibleInvalidCastException
                seconds = ((DateTimeOffset)(DateTime)value).ToUnixTimeSeconds();
            }
            else
            {
                throw new Exception("Expected date object value.");
            }
            writer.WriteValue(seconds);
        }
    }
}
