using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using FetaProject.Droid.Helpers;

namespace FetaProject.Droid
{
    [Activity(Label = "FetaProject.Droid", MainLauncher = true)]
    public class MainActivity : FragmentActivity 
    {
        private static int NUM_PAGES = 5;
        private ViewPager mPager;
        private PagerAdapter mPagerAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            mPager = (ViewPager)FindViewById(Resource.Id.pager);
            mPagerAdapter = new ScreenSlidePagerAdapter(SupportFragmentManager);
            mPager.Adapter = mPagerAdapter;
            NavigationHelper.SetNavigationChange(this, mPager);
        }
        public override void OnBackPressed()
        {
            if (mPager.CurrentItem == 0)
                base.OnBackPressed();
            else
                mPager.SetCurrentItem(mPager.CurrentItem - 1, true);
        }
        private class ScreenSlidePagerAdapter : FragmentStatePagerAdapter
        {
            public override int Count => NUM_PAGES;

            public ScreenSlidePagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
            {
            }
            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                return new ScreenSlidePageFragment(position);
            }
        }
    }
}