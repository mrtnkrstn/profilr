using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Profilr.Core.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializer _serializer;

        private const string JsonContentType = "application/json";

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));

            _serializer = new JsonSerializer();
        }

        public Task<T> GetRequestAsync<T>(string url, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                //_httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "c932f693-6485-46f8-8c91-1c9ce21738b4");
            }

#if DEBUG
            Debug.WriteLine("Request URL:");
            Debug.WriteLine("--------------");
            Debug.WriteLine(url);
#endif

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
            return SendRequest<T>(httpRequest);
        }

        private async Task<T> SendRequest<T>(HttpRequestMessage httpRequest)
        {
            var httpResponse = await _httpClient.SendAsync(httpRequest);
            var stream = await httpResponse.Content.ReadAsStreamAsync();

#if DEBUG
            Debug.WriteLine("Response:" + httpResponse.StatusCode);
            Debug.WriteLine("---------");
            var r = new StreamReader(stream);
            var responseString = r.ReadToEnd();
            Debug.WriteLine(responseString);
            stream.Position = 0;
#endif

            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                return _serializer.Deserialize<T>(json);
            }
        }
    }
}
