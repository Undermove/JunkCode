namespace KeycloakAuthRequestExample.Utils.HttpUtils
{
    public interface IJsonSerializer
    {
        /// <summary>
        /// Serializes the specified object to a JSON string
        /// </summary>
        string Serialize(object contentObject);
    }
}
