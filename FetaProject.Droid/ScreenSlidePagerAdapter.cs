using Android.App;
using Android.Support.V4.App;
using FetaProject.Droid.Fragments;

namespace FetaProject.Droid
{
    public class ScreenSlidePagerAdapter : FragmentStatePagerAdapter
    {
        public override int Count => 5;
        public readonly Activity _context;

        public ScreenSlidePagerAdapter(Activity context, Android.Support.V4.App.FragmentManager fm) : base(fm)
        {
            _context = context;
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0:
                    return new ProgramPageFragment(_context);
                case 1:
                    return new AboutPageFragment(_context);
                case 2:
                    return new GalleryPageFragment(_context);
                case 3:
                    return new MapPageFragment(_context);
                case 4:
                    return new SettingsPageFragment(_context);
                default:
                    return new ProgramPageFragment(_context);
            }
        }
    }
}