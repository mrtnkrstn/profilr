using System;
using System.Timers;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Profilr.Core.ViewModels
{
    public class LandingViewModel : MvxNavigationViewModel
    {
        private readonly Timer _timer;

        public LandingViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) 
            : base(logProvider, navigationService)
        {
            CurrentTime = DateTime.Now;
            ImageUrl = "https://static.independent.co.uk/s3fs-public/thumbnails/image/2019/02/21/16/caters-sexy-koala-02.jpg?w968h681";

            _timer = new Timer(1000);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private DateTime _currentTime;
        public DateTime CurrentTime
        {
            get => _currentTime;
            set => SetProperty(ref _currentTime, value);
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get => _imageUrl;
            set => SetProperty(ref _imageUrl, value);
        }

        public void NavigateToUserProfile()
        {
            NavigationService.Navigate<UserProfileViewModel>();
        }

        public void NavigateToItem1()
        {
            NavigationService.Navigate<Item1ViewModel>();
        }

        public void NavigateToItem2()
        {
            NavigationService.Navigate<Item2ViewModel>();
        }

        public void NavigateToItem3()
        {
            NavigationService.Navigate<Item3ViewModel>();
        }

        public void NavigateToItem4()
        {
            NavigationService.Navigate<Item4ViewModel>();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            CurrentTime = DateTime.Now;
        }
    }
}
