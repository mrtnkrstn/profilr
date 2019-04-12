using System;
using Acr.UserDialogs;
using Android.App;
using Android.OS;
using Android.Runtime;
using MvvmCross;
using MvvmCross.Platforms.Android;
using MvvmCross.Platforms.Android.Views;
using Profilr.Core;

namespace Profilr.Droid
{
    [Application]
    public class MainApplication : MvxAndroidApplication<Setup, App>, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        { }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
        }

        public void OnActivityStopped(Activity activity)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("ODgzNjhAMzEzNzJlMzEyZTMwSW15V1B0aGdvdE5tT3ZkWFhBUktKYitsV0hON0doWXp3Y0ZKdkMxVHJ2az0=");

            UserDialogs.Init(() => Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity);
        }
    }
}
