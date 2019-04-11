using Android.App;
using Android.OS;
using Profilr.Core.ViewModels;

namespace Profilr.Droid.Activities
{
    [Activity(Label = "Activity 4", Theme = "@style/AppTheme")]
    public class Item4Activity : BaseAppCompatActivity<Item4ViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_item4);

            SetupSupportActionBar();
        }
    }
}
