using System.Collections.Generic;
using System.Threading.Tasks;
using Profilr.Core.Models;

namespace Profilr.Core.Managers
{
    public interface ICryptoTickerManager
    {
        Task<IList<CryptoPrice>> GetPrices();
    }
}
