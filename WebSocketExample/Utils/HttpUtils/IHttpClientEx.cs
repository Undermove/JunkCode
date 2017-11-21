using System;
using System.Threading.Tasks;

namespace KeycloakAuthRequestExample.Utils.HttpUtils
{
    /// <summary>
    /// Can send http requests to the remote endpoints
    /// </summary>
    public interface IHttpClientEx
    {
        /// <summary>
        /// Throws <see cref="HttpClientExException"/> in case of any errors
        /// </summary>
        JsonResponseDetails Get(string url, TimeSpan timeout, string contentType = "application/json");

        /// <summary>
        /// Throws <see cref="HttpClientExException"/> in case of any errors
        /// </summary>
        JsonResponseDetails Post(string url, object contentObject, TimeSpan timeout, string contentType = "application/json");

        /// <remarks>
        /// Method itself doesn't throw exceptions in any case
        /// </remarks>
        Task<JsonResponseDetails> PostAsync(string url, object contentObject, string contentType = "application/json");
    }
}
