using System;

namespace KeycloakAuthRequestExample.Utils.HttpUtils
{
    public class HttpClientExException : Exception
    {
        public HttpClientExException(string url, string message, Exception innerException)
            : base($"Fail to send request to [{url}]: {message}", innerException)
        { }

        public HttpClientExException(string url, string message, TimeSpan timeout)
            : base($"Fail to send request to [{url}] within {timeout}: {message}")
        { }
    }
}
