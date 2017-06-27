using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using FetaProject.Droid.Fragments;
using FetaProject.Droid.Helpers;

namespace FetaProject.Droid
{
    [Activity(Label = "FetaProject.Droid", MainLauncher = true)]
    public class MainActivity : FragmentActivity 
    {
        private ViewPager mPager;
        private PagerAdapter mPagerAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            mPager = (ViewPager)FindViewById(Resource.Id.pager);
            mPager.Adapter = new ScreenSlidePagerAdapter(SupportFragmentManager); ;
            mPager.PageScrolled += new System.EventHandler<ViewPager.PageScrolledEventArgs>((obj, t) => {
                NavigationHelper.ChangeBottomNavigationToPage(this, ((ViewPager)obj).CurrentItem);
            });
            NavigationHelper.SetNavigationChange(this, mPager);
        }
        public override void OnBackPressed()
        {
            if (mPager.CurrentItem == 0)
                base.OnBackPressed();
            else
                mPager.SetCurrentItem(mPager.CurrentItem - 1, true);
        }
    }
}