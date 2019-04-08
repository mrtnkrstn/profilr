using System;
using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;

namespace Profilr.Droid
{
    [Activity(
        MainLauncher = true
        , NoHistory = true
        , Theme = "@style/SplashTheme"
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
        {
        }
    }
}
