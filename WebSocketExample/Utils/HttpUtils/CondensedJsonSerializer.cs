using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KeycloakAuthRequestExample.Utils.HttpUtils
{
    /// <summary>
    /// Serializes to the JSON without line breaks and without indentation
    /// </summary>
    public class CondensedJsonSerializer : IJsonSerializer
    {
        public static readonly JsonSerializerSettings CamelCasePropertyNames = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public string Serialize(object contentObject)
        {
            return JsonConvert.SerializeObject(contentObject, CamelCasePropertyNames);
        }
    }
}
