
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using BottomNavigationBar;

namespace FetaProject.Droid
{
    [Activity(Label = "MapActivity")]
	public class MapActivity : AppCompatActivity, BottomNavigationBar.Listeners.IOnMenuTabClickListener
	{
		private BottomBar _bottomBar;
		private static string menuColor = "#3a3a3a";
		private static int menuItemCount = 5;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Map);
			_bottomBar = BottomBar.Attach(this, savedInstanceState);
			_bottomBar.SetItems(Resource.Menu.bottombar_menu);
			_bottomBar.SetOnMenuTabClickListener(this);

			// Setting colors for different tabs when there's more than three of them.
			// You can set colors for tabs in three different ways as shown below.

			for (int i = 0; i < menuItemCount; i++)
			{
				_bottomBar.MapColorForTab(i, menuColor);
			}
        }
        protected override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);
			// Necessary to restore the BottomBar's state, otherwise we would
			// lose the current tab on orientation change.
			_bottomBar.OnSaveInstanceState(outState);

		}

        public void OnMenuTabReSelected(int menuItemId)
        {
			if (menuItemId == Resource.Id.GalleryItem)
			{
				StartActivity(typeof(GalleryActivity));

			}
			else if (menuItemId == Resource.Id.ProgramItem)
			{
				StartActivity(typeof(MainActivity));

			}
			else if (menuItemId == Resource.Id.AboutItem)
			{
				StartActivity(typeof(AboutFestivalActivity));

			}
			else if (menuItemId == Resource.Id.SettingsItem)
			{
				StartActivity(typeof(SettingsActivity));

			}
			else if (menuItemId == Resource.Id.MapItem)
			{
				StartActivity(typeof(MapActivity));

			}
        }

        public void OnMenuTabSelected(int menuItemId)
        {
            
            
        }
    }
}
