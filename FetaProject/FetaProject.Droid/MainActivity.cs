using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace FetaProject.Droid
{
	[Activity (Label = "FetaProject.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
    {
        
        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);


            
               var mapButton = this.FindViewById<Button> (Resource.Id.btnMap);

            mapButton.Click += (sender, e) => this.SetUpMap();
                  
        }


        public void SetUpMap()
        {
            var intent = new Intent(this, typeof(MapActivity));
            this.StartActivity(intent);
        }

        
    }
}


