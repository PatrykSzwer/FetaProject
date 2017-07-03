using Android.Content;
using Android.Views;
using Android.Widget;

namespace FetaProject.Droid.Helpers
{
    public class ImageAdapter : BaseAdapter
    {
        private readonly Context _context;

        // references to our images
        private readonly int[] _thumbIds =
        {
            Resource.Drawable.sample_0,
            Resource.Drawable.sample_1,
            Resource.Drawable.sample_2
        };

        public ImageAdapter(Context c)
        {
            _context = c;
        }

        public override int Count => _thumbIds.Length;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        // create a new ImageView for each item referenced by the Adapter
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView i = new ImageView(_context);

            i.SetImageResource(_thumbIds[position]);
            i.LayoutParameters = new Gallery.LayoutParams(600, 2000);
            return i;
        }

    };
}