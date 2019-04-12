using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Profilr.Core.Services;
using Profilr.Core.Models;

namespace Profilr.Core.Managers
{
    public class CryptoTickerManager : ICryptoTickerManager
    {
        private readonly IApiService _apiService;

        public CryptoTickerManager(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IList<CryptoPrice>> GetPrices()
        {
            var headers = new Dictionary<string, string>
            {
                { "X-CMC_PRO_API_KEY", "c932f693-6485-46f8-8c91-1c9ce21738b4" }
            };
            var resp = await _apiService.GetRequestAsync<CryptoTickerResponse>("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?start=1&limit=10&convert=USD", headers).ConfigureAwait(false);

            var mapped = resp.Data.Select(x => new CryptoPrice { Name = x.Name, Symbol = x.Symbol, Price = x.QuoteResponse.Quote.Price, DateLastUpdated = x.LastUpdated }).ToList();

            return mapped;
        }

        private class CryptoTickerResponse
        {
            [JsonProperty("status")]
            public CryptoTickerResponseStatus Status { get; set; }

            [JsonProperty("data")]
            public List<CryptoTickerResponseData> Data { get; set; }
        }

        private class CryptoTickerResponseStatus
        {
            [JsonProperty("timestamp")]
            public string TimeStamp { get; set; }

            [JsonProperty("error_code")]
            public string ErrorCode { get; set; }

            [JsonProperty("error_message")]
            public string ErrorMessage { get; set; }

            [JsonProperty("elapsed")]
            public string Elapsed { get; set; }

            [JsonProperty("credit_count")]
            public string CreditCount { get; set; }
        }

        private class CryptoTickerResponseData
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("symbol")]
            public string Symbol { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonProperty("last_updated")]
            public string LastUpdated { get; set; }

            [JsonProperty("quote")]
            public CryptoTickerResponseQuote QuoteResponse { get; set; }
        }

        private class CryptoTickerResponseQuote
        {
            [JsonProperty("USD")]
            public Quote Quote { get; set; }
        }

        private class Quote
        {
            [JsonProperty("price")]
            public decimal Price { get; set; }
        }
    }
}
