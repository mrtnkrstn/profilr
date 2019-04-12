using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.ViewModels;
using Profilr.Core.Managers;
using Profilr.Core.Models;

namespace Profilr.Core.ViewModels
{
    public class Item3ViewModel : MvxViewModel
    {
        private readonly ICryptoTickerManager _cryptoTickerManager;
        private readonly IUserDialogs _userDialogs;

        public Item3ViewModel(ICryptoTickerManager cryptoTickerManager, IUserDialogs userDialogs)
        {
            _cryptoTickerManager = cryptoTickerManager;
            _userDialogs = userDialogs;
        }

        private MvxObservableCollection<CryptoPrice> _prices;
        public MvxObservableCollection<CryptoPrice> Prices
        {
            get => _prices;
            set => SetProperty(ref _prices, value);
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            _userDialogs.ShowLoading();

            var prices = await _cryptoTickerManager.GetPrices().ConfigureAwait(false);

            Prices = new MvxObservableCollection<CryptoPrice>(prices);

            _userDialogs.HideLoading();
        }
    }
}
