using System.Threading.Tasks;
using MvvmCross.ViewModels;
using Profilr.Core.Managers;
using Profilr.Core.Models;
using Acr.UserDialogs;

namespace Profilr.Core.ViewModels
{
    public class Item2ViewModel : MvxViewModel
    {
        private readonly IQuoteManager _quoteManager;
        private readonly IUserDialogs _userDialogs;

        public Item2ViewModel(IQuoteManager quoteManager, IUserDialogs userDialogs)
        {
            _quoteManager = quoteManager;
            _userDialogs = userDialogs;
        }

        private MvxObservableCollection<Quote> _quotes;
        public MvxObservableCollection<Quote> Quotes
        {
            get => _quotes;
            set => SetProperty(ref _quotes, value);
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            _userDialogs.ShowLoading();

            var quotes = await _quoteManager.GetQuotes().ConfigureAwait(false);

            Quotes = new MvxObservableCollection<Quote>(quotes);

            _userDialogs.HideLoading();
        }
    }
}
