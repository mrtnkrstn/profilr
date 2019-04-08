using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using Profilr.Core.ViewModels;

namespace Profilr.Droid.Views
{
    [Activity(Label = "Activity")]
    public class LandingActivity : MvxAppCompatActivity<LandingViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_landing);
        }
    }
}
