using System;
using System.Threading.Tasks;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Profilr.Core.ViewModels
{
    public class LandingViewModel : MvxNavigationViewModel
    {
        public LandingViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) 
            : base(logProvider, navigationService)
        {
            CurrentTime = DateTime.Now;
            AnimalImageUrl = "https://static.independent.co.uk/s3fs-public/thumbnails/image/2019/02/21/16/caters-sexy-koala-02.jpg?w968h681";
        }

        private DateTime _currentTime;
        public DateTime CurrentTime
        {
            get => _currentTime;
            set => SetProperty(ref _currentTime, value);
        }

        private string _animalImageUrl;
        public string AnimalImageUrl
        {
            get => _animalImageUrl;
            set => SetProperty(ref _animalImageUrl, value);
        }

        public override Task Initialize()
        {
            return base.Initialize();

        }
    }
}
