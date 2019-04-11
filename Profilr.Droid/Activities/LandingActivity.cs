using System;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using Profilr.Core.ViewModels;
using Profilr.Droid.Views;
using Syncfusion.SfRadialMenu.Android;

namespace Profilr.Droid.Activities
{
    [Activity(Label="Proflr", Theme="@style/AppTheme")]
    public class LandingActivity : MvxAppCompatActivity<LandingViewModel>
    {
        private BlurringView _blurringView;
        private SfRadialMenu _radialMenu;
        private Button _menuButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_landing);

            _blurringView = (BlurringView)FindViewById(Resource.Id.blurring_view);
            var blurredView = FindViewById(Resource.Id.blurred_view);

            _blurringView.SetBlurredView(blurredView);
            _blurringView.Clickable = true;
            _blurringView.Click += BlurringView_Click;
            _blurringView.Visibility = ViewStates.Invisible;

            var frameLayout = FindViewById<FrameLayout>(Resource.Id.frameLayout1);
            frameLayout.SetBackgroundColor(Color.Black);

            _menuButton = FindViewById<Button>(Resource.Id.menu_button);
            _menuButton.Click += MenuButton_Click;

            var menuIcon = new ImageView(this)
            {
                LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent),
                Clickable = true
            };
            menuIcon.SetImageResource(Resource.Drawable.bart);
            menuIcon.SetScaleType(ImageView.ScaleType.CenterInside);
            menuIcon.Click += MenuIcon_Click;

            _radialMenu = new SfRadialMenu(this)
            {
                RimColor = Color.Transparent,
                SelectionColor = Color.Transparent,
                Visibility = ViewStates.Invisible,
                CenterButtonView = menuIcon,
                IsDragEnabled = false,
                EnableRotation = false,
                OuterRimColor = Color.Transparent,
                CenterButtonBackground = Color.Rgb(41, 146, 247),
                CenterButtonRadius = 40,
                RimRadius = 120,
                IsOpen = true
            };

            _radialMenu.Closed += RadialMenu_Closed;

            frameLayout.AddView(_radialMenu);

            var menuItem1 = CreateRadialMenuItem(Resource.Drawable.bug);
            menuItem1.ItemTapped += MenuItem1_ItemTapped;
            _radialMenu.Items.Add(menuItem1);

            var menuItem2 = CreateRadialMenuItem(Resource.Drawable.item2);
            menuItem2.ItemTapped += MenuItem2_ItemTapped;
            _radialMenu.Items.Add(menuItem2);

            var menuItem3 = CreateRadialMenuItem(Resource.Drawable.item1);
            menuItem3.ItemTapped += MenuItem3_ItemTapped;
            _radialMenu.Items.Add(menuItem3);

            var menuItem4 = CreateRadialMenuItem(Resource.Drawable.item2);
            menuItem4.ItemTapped += MenuItem4_ItemTapped;
            _radialMenu.Items.Add(menuItem4);
        }

        private SfRadialMenuItem CreateRadialMenuItem(int image)
        {
            var frameLayout = new FrameLayout(this)
            {
                LayoutParameters = new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent)
            };

            var imageView = new ImageView(this)
            {
                LayoutParameters = frameLayout.LayoutParameters
            };
            imageView.SetImageResource(image);
            imageView.SetScaleType(ImageView.ScaleType.FitXy);

            var textView = new TextView(this)
            {
                LayoutParameters = frameLayout.LayoutParameters,
                TextSize = 20,
                TextAlignment = TextAlignment.Center,
                Gravity = GravityFlags.Center
            };
            textView.SetTextColor(Color.White);

            frameLayout.AddView(imageView);
            frameLayout.AddView(textView, new ViewGroup.LayoutParams(FrameLayout.LayoutParams.MatchParent, FrameLayout.LayoutParams.MatchParent));

            var radialMenuItem = new SfRadialMenuItem(this) { View = frameLayout, ItemWidth = 50, ItemHeight = 50 };
            radialMenuItem.SetBackgroundColor(Color.Transparent);

            return radialMenuItem;
        }

        private void MenuIcon_Click(object sender, EventArgs e)
        {
            ViewModel.NavigateToUserProfile();
        }

        private void MenuItem1_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
        {
            ViewModel.NavigateToItem1();
        }

        private void MenuItem2_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
        {
            ViewModel.NavigateToItem2();
        }

        private void MenuItem3_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
        {
            ViewModel.NavigateToItem3();
        }

        private void MenuItem4_ItemTapped(object sender, RadialMenuItemTappedEventArgs e)
        {
            ViewModel.NavigateToItem4();
        }

        private void RadialMenu_Closed(object sender, ClosedEventArgs e)
        {
            _radialMenu.Visibility = ViewStates.Invisible;
            _blurringView.Visibility = ViewStates.Invisible;

            _menuButton.Enabled = true;
        }

        private void BlurringView_Click(object sender, EventArgs e)
        {
            _radialMenu.IsOpen = false;
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            _blurringView.Visibility = ViewStates.Visible;
            _radialMenu.Visibility = ViewStates.Visible;

            _radialMenu.IsOpen = true;

            _menuButton.Enabled = false;
        }
    }
}
