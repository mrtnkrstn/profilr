using System;
using System.Collections.Generic;
using MvvmCross.ViewModels;

namespace Profilr.Core.ViewModels
{
    public class UserProfileViewModel : MvxViewModel
    {
        private string _profileImageUrl;
        public string ProfileImageUrl
        {
            get => _profileImageUrl;
            set => SetProperty(ref _profileImageUrl, value);
        }

        public double DownsampleWidth => 200d;
    }
}
