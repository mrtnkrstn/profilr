using Android.App;
using Android.OS;
using Profilr.Core.ViewModels;

namespace Profilr.Droid.Activities
{
    [Activity(Label="User Profile", Theme="@style/AppTheme")]
    public class UserProfileActivity : BaseAppCompatActivity<UserProfileViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_user_profile);

            SetupSupportActionBar();
        }
    }
}
