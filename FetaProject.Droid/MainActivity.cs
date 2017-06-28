using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using FetaProject.Droid.Helpers;

namespace FetaProject.Droid
{
    [Activity(Label = "FetaProject.Droid", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        private ViewPager _mPager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            _mPager = (ViewPager)FindViewById(Resource.Id.pager);
            _mPager.Adapter = new ScreenSlidePagerAdapter(this, SupportFragmentManager); ;
            _mPager.PageScrolled += (obj, t) =>
            {
                NavigationHelper.ChangeBottomNavigationToPage(this, ((ViewPager)obj).CurrentItem);
            };

            NavigationHelper.SetNavigationChange(this, _mPager);
        }

        public override void OnBackPressed()
        {
            if (_mPager.CurrentItem == 0)
            {
                base.OnBackPressed();
            }
            else
            {
                _mPager.SetCurrentItem(_mPager.CurrentItem - 1, true);
            }
        }
    }
}