using Android.App;
using Android.OS;
using Profilr.Core.ViewModels;

namespace Profilr.Droid.Activities
{
    [Activity(Label = "My Fave Bug", Theme = "@style/AppTheme")]
    public class Item1Activity : BaseAppCompatActivity<Item1ViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_item1);

            SetupSupportActionBar();
        }
    }
}
