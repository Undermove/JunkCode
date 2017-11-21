using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace KeycloakAuthRequestExample.Utils.HttpUtils
{
    public class HttpClientEx : IHttpClientEx
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IJsonSerializer serializer;
        private static readonly HttpClient client = new HttpClient();

        public HttpClientEx(IJsonSerializer serializer)
        {
            this.serializer = serializer;
        }

        public JsonResponseDetails Get(string url, TimeSpan timeout, string contentType = "application/json")
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                Task<JsonResponseDetails> getTask = DoGetJsonAsync(url, cts.Token, contentType);
                if (getTask.Wait(timeout))
                {
                    JsonResponseDetails responseDetails = getTask.Result;
                    LogResponseDetails(responseDetails);
                    return responseDetails;
                }

                cts.Cancel();
                throw new HttpClientExException(url, string.Empty, timeout);
            }
            catch (AggregateException ex)
            {
                throw new HttpClientExException(url, string.Empty, ex.Flatten());
            }
            catch (Exception ex)
            {
                throw new HttpClientExException(url, string.Empty, ex);
            }
        }

        public JsonResponseDetails Post(string url, object contentObject, TimeSpan timeout, string contentType = "application/json")
        {
            string message = null;

            try
            {
                message = serializer.Serialize(contentObject);

                CancellationTokenSource cts = new CancellationTokenSource();
                Task<JsonResponseDetails> postTask = DoPostJsonAsync(url, message, cts.Token, contentType);
                if (postTask.Wait(timeout))
                {
                    JsonResponseDetails responseDetails = postTask.Result;
                    LogResponseDetails(responseDetails);
                    return responseDetails;
                }

                cts.Cancel();
                throw new HttpClientExException(url, message, timeout);
            }
            catch (AggregateException ex)
            {
                throw new HttpClientExException(url, message, ex.Flatten());
            }
            catch (Exception ex)
            {
                throw new HttpClientExException(url, message, ex);
            }
        }

        public Task<JsonResponseDetails> PostAsync(string url, object contentObject, string contentType = "application/json")
        {
            string message = null;

            try
            {
                message = serializer.Serialize(contentObject);

                Task<JsonResponseDetails> postTask = DoPostJsonAsync(url, message, new CancellationToken(), contentType);

                return postTask
                    .ContinueWith(t => LogExceptionIfOccured(t, url, message))
                    .ContinueWith(t => LogResponseDetails(t.Result));
            }
            catch (Exception ex)
            {
                LogException(ex, url, message);
                return Task.Factory.StartNew<JsonResponseDetails>(() => { throw ex; });
            }
        }

        public Task<JsonResponseDetails> PostUrlEncodedAsync(string url, string contentObject, string contentType = "application/x-www-form-urlencoded")
        {
            try
            {
                Task<JsonResponseDetails> postTask = DoPostUrlEncodedAsync(url, contentObject, new CancellationToken(), contentType);

                return postTask
                    .ContinueWith(t => LogExceptionIfOccured(t, url, contentObject))
                    .ContinueWith(t => LogResponseDetails(t.Result));
            }
            catch (Exception ex)
            {
                LogException(ex, url, contentObject);
                return Task.Factory.StartNew<JsonResponseDetails>(() => { throw ex; });
            }
        }

        public static void WriteStandardLog(JsonResponseDetails responseDetails)
        {
            HttpResponseMessage response = responseDetails.Response;
            if (response.IsSuccessStatusCode)
            {
                logger.Debug($"Request has been sent. {responseDetails}");
            }
            else
            {
                logger.Warn($"Something went wrong during request posting. {responseDetails}");
            }
        }

        private Task<JsonResponseDetails> DoGetJsonAsync(string url, CancellationToken cancellationToken, string contentType = "application/json")
        {
            logger.Trace("Gettings JSON response from '{0}'", url);

            HttpContent httpContent = new StringContent(string.Empty);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            return client.GetAsync(url, cancellationToken)
                .ContinueWith(t => new JsonResponseDetails(t.Result, url, string.Empty), cancellationToken);
        }

        private Task<JsonResponseDetails> DoPostJsonAsync(string url, string message, CancellationToken cancellationToken, string contentType = "application/json")
        {
            logger.Trace("Posting JSON to [{0}]: `{1}`", url, message);

            HttpContent httpContent = new StringContent(message);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            return client.PostAsync(url, httpContent, cancellationToken)
                .ContinueWith(t => new JsonResponseDetails(t.Result, url, message), cancellationToken);
        }

        private Task<JsonResponseDetails> DoPostUrlEncodedAsync(string url, string message, CancellationToken cancellationToken, string contentType = "application/x-www-form-urlencoded")
        {
            logger.Trace("Posting UrlEncoded to [{0}]: `{1}`", url, message);

            HttpContent httpContent = new StringContent(message);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            return client.PostAsync(url, httpContent, cancellationToken)
                .ContinueWith(t => new JsonResponseDetails(t.Result, url, message), cancellationToken);
        }

        private static JsonResponseDetails LogExceptionIfOccured(Task<JsonResponseDetails> t, string url, string message)
        {
            if (t.IsFaulted)
            {
                // ReSharper disable once PossibleNullReferenceException
                LogException(t.Exception.Flatten(), url, message);
            }

            return t.Result;
        }

        private static void LogException(Exception exception, string url, string message)
        {
            logger.Warn(exception, "Fail to send request to [{0}]: `{1}`", url, message);
        }

        private static JsonResponseDetails LogResponseDetails(JsonResponseDetails responseDetails)
        {
            logger.Trace("Got response on request. {0}", responseDetails);
            return responseDetails;
        }
    }
}
