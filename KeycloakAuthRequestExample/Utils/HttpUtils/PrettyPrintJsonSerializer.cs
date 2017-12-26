using Newtonsoft.Json;

namespace KeycloakAuthRequestExample.Utils.HttpUtils
{
    /// <summary>
    /// Serializes to the formatted JSON
    /// </summary>
    public class PrettyPrintJsonSerializer : IJsonSerializer
    {
        public string Serialize(object contentObject)
        {
            return JsonConvert.SerializeObject(contentObject, Formatting.Indented, CondensedJsonSerializer.CamelCasePropertyNames);
        }
    }
}
