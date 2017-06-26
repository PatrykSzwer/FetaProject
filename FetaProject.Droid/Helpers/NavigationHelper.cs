using Android.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Widget;

namespace FetaProject.Droid.Helpers
{
    internal class NavigationHelper
    {
        public static void SetNavigationChange(Activity context, ViewPager pager)
        {
            var bottomNavigation = context.FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            bottomNavigation.NavigationItemSelected += (s, e) =>
            {
                switch (e.Item.ItemId)
                {
                    case Resource.Id.bottomNav_Program:
                        Toast.MakeText(context, "Program clicked", ToastLength.Short).Show();
                        pager.CurrentItem = 0;
                        break;
                    case Resource.Id.bottomNav_About:
                        Toast.MakeText(context, "About clicked", ToastLength.Short).Show();
                        pager.CurrentItem = 1;
                        break;
                    case Resource.Id.bottomNav_Gallery:
                        Toast.MakeText(context, "Gallery clicked", ToastLength.Short).Show();
                        pager.CurrentItem = 2;
                        break;
                    case Resource.Id.bottomNav_Map:
                        Toast.MakeText(context, "Map clicked", ToastLength.Short).Show();
                        pager.CurrentItem = 3;
                        break;
                    case Resource.Id.bottomNav_Settings:
                        Toast.MakeText(context, "Settings clicked", ToastLength.Short).Show();
                        pager.CurrentItem = 4;
                        break;
                }
            };
        }
    }
}