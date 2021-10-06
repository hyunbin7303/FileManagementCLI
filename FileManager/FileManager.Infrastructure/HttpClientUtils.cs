using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FileManager.Infrastructure
{

    public class HttpClientUtils
    {

        private readonly string _baseUrl;
        private readonly string _apiKey;
        public async Task CallServiceAsync(string endpoint, object data)
        {
            //https://gist.github.com/brunneus/0971b9960c02c0658a3bdac47f470f4f

        }
        public async static Task<IList<T>> GetListsAsync<T>(string url, Dictionary<string, string> query, object headers = null)
        {
            var list = await url.GetJsonListAsync();
            return (IList<T>)list;
        }


        private bool IsTransientError(FlurlHttpException exception)
        {
            int[] httpStatusCodesWorthRetrying =
            {
                (int)HttpStatusCode.RequestTimeout,     // 408
                (int)HttpStatusCode.BadGateway,         // 502
                (int)HttpStatusCode.ServiceUnavailable, // 503
                (int)HttpStatusCode.GatewayTimeout      // 504
            };

            return exception.StatusCode.HasValue && httpStatusCodesWorthRetrying.Contains(exception.StatusCode.Value);
        }
    }
}
