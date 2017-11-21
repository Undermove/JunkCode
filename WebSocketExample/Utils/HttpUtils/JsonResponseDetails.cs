using System.Net.Http;

namespace KeycloakAuthRequestExample.Utils.HttpUtils
{
    /// <summary>
    /// Response on the request which <see cref="IHttpClientEx"/> has been sent
    /// along with the accompanying details
    /// </summary>
    public class JsonResponseDetails
    {
        public JsonResponseDetails(HttpResponseMessage response, string url, string request)
        {
            Response = response;
            Url = url;
            Request = request;
        }

        public HttpResponseMessage Response { get; }

        public string Url { get; }

        public string Request { get; }

        public override string ToString()
        {
            return $"Url: {Url}, StatusCode: {Response.StatusCode}, ReasonPhrase: {Response.ReasonPhrase}, ResponseContent: `{Response.Content?.ReadAsStringAsync().Result}`, Request: `{Request}`";
        }
    }
}
