using System;
using System.Collections.Generic;
using MvvmCross.ViewModels;

namespace Profilr.Core.ViewModels
{
    public class UserProfileViewModel : MvxViewModel
    {
        public UserProfileViewModel()
        {
            //ProfileImageUrl = "https://img.maximummedia.ie/joe_ie/eyJkYXRhIjoie1widXJsXCI6XCJodHRwOlxcXC9cXFwvbWVkaWEtam9lLm1heGltdW1tZWRpYS5pZS5zMy5hbWF6b25hd3MuY29tXFxcL3dwLWNvbnRlbnRcXFwvdXBsb2Fkc1xcXC8yMDE0XFxcLzEwXFxcL3NpbXBzb25zMS5wbmdcIixcIndpZHRoXCI6NzY3LFwiaGVpZ2h0XCI6NDMxLFwiZGVmYXVsdFwiOlwiaHR0cHM6XFxcL1xcXC93d3cuam9lLmllXFxcL2Fzc2V0c1xcXC9pbWFnZXNcXFwvam9lXFxcL25vLWltYWdlLnBuZz92PTIyXCIsXCJvcHRpb25zXCI6W119IiwiaGFzaCI6IjFiOTBhNzg4NjFhNWZkNzUyMDY2ZGQ1YTgyNjcyNGRmMzkzNWExY2YifQ==/simpsons1.png";
            //ProfileImageUrl = "http://coolspotters.com/files/photos/69395/bart-simpson-profile.png";
        }

        private string _profileImageUrl;
        public string ProfileImageUrl
        {
            get => _profileImageUrl;
            set => SetProperty(ref _profileImageUrl, value);
        }

        public double DownsampleWidth => 200d;
    }
}
