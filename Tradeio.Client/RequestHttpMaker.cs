namespace Tradeio.Client
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    /// <summary>
    /// Provides HTTP request handling functionality.
    /// </summary>
    public sealed class RequestHttpMaker : IDisposable
    {
        /// <summary>
        /// Associated HTTP client instance.
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestHttpMaker"/> class.
        /// </summary>
        public RequestHttpMaker()
        {
            ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpClientHandler handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                UseProxy = false,
            };

            this.client = new HttpClient(handler);
            this.client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-us", 1.0));
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            this.client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
        }

        /// <summary>
        /// Makes a request
        /// </summary>
        /// <param name="url">Path and query.</param>
        /// <param name="form">Write to body</param>
        /// <param name="method">Request method or null for default.</param>
        /// <param name="headers">Headers, write to request headers.</param>
        /// <returns>Raw response.</returns>
        public T MakeRequest<T>(
            string url,
            string form = null,
            string method = null,
            IDictionary<string, string> headers = null)
        {
            return JsonConvert.DeserializeObject<T>(this.MakeRequestAsync(url, form, method, headers).Result);
        }

        public async Task<T> MakeRequestAsync<T>(
            string url,
            string form = null,
            string method = null,
            IDictionary<string, string> headers = null)
        {
            return JsonConvert.DeserializeObject<T>(await this.MakeRequestAsync(url, form, method, headers));
        }

        /// <summary>
        /// Makes asynchronous request to a path on the API.
        /// </summary>
        /// <param name="url">Path and query.</param>
        /// <param name="form">Write to body</param>
        /// <param name="method">Request method or null for default.</param>
        /// <param name="headers">Headers, write to request headers.</param>
        /// <returns>Raw response.</returns>
        public async Task<string> MakeRequestAsync(
            string url,
            string form = null,
            string method = null,
            IDictionary<string, string> headers = null,
            string mediaType = null)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new Exception("Missing URL.");
            }

            Uri uri = new Uri(url);
            HttpMethod httpMethod = string.IsNullOrEmpty(method) ? HttpMethod.Get : new HttpMethod(method);

            Debug.Write($"Making {method} request to {url} form {form} mediaType {mediaType} headers {headers?.Dump()}");

            try
            {
                string responseString;
                using (HttpRequestMessage request = new HttpRequestMessage(httpMethod, uri))
                {
                    if (headers != null)
                    {
                        foreach (KeyValuePair<string, string> header in headers)
                        {
                            request.Headers.Add(header.Key, header.Value);
                        }
                    }

                    if (!string.IsNullOrEmpty(form))
                    {
                        request.Content = new StringContent(form, Encoding.UTF8);
                        if (mediaType != null)
                            request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
                    }

                    using (HttpResponseMessage response = await this.client.SendAsync(request))
                    {
                        using (HttpContent content = response.Content)
                        {
                            byte[] data = await content.ReadAsByteArrayAsync();
                            responseString = Encoding.UTF8.GetString(data);
                            Debug.Write($"Get response " + responseString);
                            if (response.StatusCode != HttpStatusCode.OK
                                && response.StatusCode != HttpStatusCode.Created)
                            {
                                responseString = !string.IsNullOrEmpty(responseString)
                                                     ? responseString
                                                     : !string.IsNullOrEmpty(response.ReasonPhrase)
                                                         ? response.ReasonPhrase
                                                         : response.StatusCode.ToString();
                                throw new Exception(responseString);
                            }
                        }
                    }
                }

                return responseString;
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException httpRequestException && httpRequestException.InnerException != null)
                {
                    throw httpRequestException.InnerException;
                }

                if (ex is AggregateException aggregateException && aggregateException.InnerException != null)
                {
                    throw aggregateException.InnerException;
                }

                throw;
            }
        }

        /// <summary>
        /// Disposes any resource being used.
        /// </summary>
        public void Dispose()
        {
            this.client?.Dispose();
        }
    }
}
