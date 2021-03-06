﻿﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;
using BottomNavigationBar;
using Android.Support.V4.Content;
using Android.Views;
using System.Collections.Generic;

namespace FetaProject.Droid
{
	[Activity(Label = "FetaProject.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, BottomNavigationBar.Listeners.IOnMenuTabClickListener
	{
		private BottomBar _bottomBar;
		private static string menuColor = "#3a3a3a";
		private static int menuItemCount = 5;
        private List<string> nItems;
        private ListView programList;
        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);


            // Set our view from the "main" layout resource
           // SetContentView(Resource.Layout.Main);

			_bottomBar = BottomBar.Attach(this, savedInstanceState);
			_bottomBar.SetItems(Resource.Menu.bottombar_menu);
			_bottomBar.SetOnMenuTabClickListener(this);

			// Setting colors for different tabs when there's more than three of them.
			// You can set colors for tabs in three different ways as shown below.

			for (int i = 0; i < menuItemCount; i++)
			{
				_bottomBar.MapColorForTab(i, menuColor);
			}

            programList = FindViewById<ListView>(Resource.Id.programLisView);
            //Table
            nItems = new List<string>();
            nItems.Add("Bob");
            nItems.Add("Tom");
            nItems.Add("(.)(.)");

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, nItems);

            programList.Adapter = adapter;
			

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

