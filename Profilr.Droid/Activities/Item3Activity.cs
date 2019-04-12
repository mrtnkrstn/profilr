using Android.App;
using Android.OS;
using Profilr.Core.ViewModels;

namespace Profilr.Droid.Activities
{
    [Activity(Label = "Cryptos", Theme = "@style/AppTheme")]
    public class Item3Activity : BaseAppCompatActivity<Item3ViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_item3);

            SetupSupportActionBar();
        }
    }
}
