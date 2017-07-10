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
            Resource.Drawable.z1,
            Resource.Drawable.z2,
            Resource.Drawable.z3,
            //Resource.Drawable.z4,
            Resource.Drawable.z5,
            Resource.Drawable.z6,
            Resource.Drawable.z7,
            Resource.Drawable.z8,
            //Resource.Drawable.z9,
            //Resource.Drawable.z10,
            //Resource.Drawable.z11,
            Resource.Drawable.z12,
            //Resource.Drawable.z13,
            //Resource.Drawable.z14,
            //Resource.Drawable.z20,
            //Resource.Drawable.z16,
            //Resource.Drawable.z17,
            //Resource.Drawable.z19,
            //Resource.Drawable.z21,
            //Resource.Drawable.z22,
            //Resource.Drawable.z23,
            Resource.Drawable.z24
            //Resource.Drawable.z26,
            //Resource.Drawable.z27

        };

        public ImageAdapter(Context context)
        {
            _context = context;
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
            i.LayoutParameters = new Gallery.LayoutParams(_context.Resources.DisplayMetrics.WidthPixels, _context.Resources.DisplayMetrics.HeightPixels);
            return i;
        }

    };
}