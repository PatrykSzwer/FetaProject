using Android.App;
using Android.Widget;
using FetaProject.Droid.Fragments.Base;
using FetaProject.Droid.Helpers;

namespace FetaProject.Droid.Fragments
{
    public class GalleryPageFragment : BaseSlidePageFragment
    {
        private readonly Activity _context;
        public GalleryPageFragment(Activity context) : base(Resource.Layout.fragment_screen_slide_page_gallery)
        {
            _context = context;
        }

        public override void ViewInitialization()
        {
            var gallery = (Gallery)FragmentView.FindViewById(Resource.Id.gallery);
            gallery.Adapter = new ImageAdapter(_context);

            gallery.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(_context, args.Position.ToString(), ToastLength.Short).Show();
            };
        }
    }
}