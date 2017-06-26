﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using FetaProject.Droid.Helpers;

namespace FetaProject.Droid
{
    [Activity(Label = "GalleryActivity")]
    public class GalleryActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Gallery);
            NavigationHelper.SetNavigationChange(this, null);
        }
    }
}
