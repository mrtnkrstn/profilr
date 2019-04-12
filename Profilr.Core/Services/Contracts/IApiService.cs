using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profilr.Core.Services
{
    public interface IApiService
    {
        Task<T> GetRequestAsync<T>(string url, Dictionary<string, string> headers = null);
    }
}
