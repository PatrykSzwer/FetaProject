using Android.Widget;
using FetaProject.Droid.Fragments.Base;
using FetaProject.Droid.Helpers;
using System;

namespace FetaProject.Droid.Fragments
{
    public class GalleryPageFragment : BaseSlidePageFragment
    {
        public GalleryPageFragment() : base(Resource.Layout.fragment_screen_slide_page_gallery)
        {
        }

        public override void ViewInitialization()
        {
            var gallery = (Gallery)FragmentView.FindViewById(Resource.Id.gallery);
            gallery.Adapter = new ImageAdapter(this.Activity);

            gallery.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(this.Activity, args.Position.ToString(), ToastLength.Short).Show();
            };

            Console.WriteLine(Resources.DisplayMetrics.WidthPixels);
            Console.WriteLine(Resources.DisplayMetrics.HeightPixels);
        }
    }
}