using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Profilr.Core.Models;
using Profilr.Core.Services;

namespace Profilr.Core.Managers
{
    public class SimpsonsQuoteManager : IQuoteManager
    {
        private readonly IApiService _apiService;

        public SimpsonsQuoteManager(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<Quote>> GetQuotes()
        {
            var resp = await _apiService.GetRequestAsync<List<SimpsonQuoteResponse>>("https://thesimpsonsquoteapi.glitch.me/quotes?count=10").ConfigureAwait(false);

            var mapped = resp.Select(x => new Quote 
            { 
                Text = x.Quote,
                Author = x.Character,
                ImageUrl = x.Image
            });

            return mapped.ToList();
        }

        private class SimpsonQuoteResponse
        {
            [JsonProperty("quote")]
            public string Quote { get; set; }

            [JsonProperty("character")]
            public string Character { get; set; }

            [JsonProperty("image")]
            public string Image { get; set; }
        }
    }
}
