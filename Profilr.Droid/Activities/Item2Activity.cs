using Android.App;
using Android.OS;
using Profilr.Core.ViewModels;

namespace Profilr.Droid.Activities
{
    [Activity(Label = "Activity 2", Theme = "@style/AppTheme")]
    public class Item2Activity : BaseAppCompatActivity<Item2ViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_item2);

            SetupSupportActionBar();
        }
    }
}
