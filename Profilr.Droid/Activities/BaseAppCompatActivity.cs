using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.ViewModels;

namespace Profilr.Droid.Activities
{
    public class BaseAppCompatActivity<TViewModel> : MvxAppCompatActivity<TViewModel> where TViewModel : MvxViewModel
    {
        protected void SetupSupportActionBar()
        {
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);

                SupportActionBar.SetHomeButtonEnabled(true);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.home:
                    OnBackPressed();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override bool OnSupportNavigateUp()
        {
            OnBackPressed();
            return base.OnSupportNavigateUp();
        }
    }
}
