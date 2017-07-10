using Android.Support.V4.App;
using FetaProject.Droid.Fragments;

namespace FetaProject.Droid
{
    public class ScreenSlidePagerAdapter : FragmentStatePagerAdapter
    {
        public override int Count => 5;

        public ScreenSlidePagerAdapter(FragmentManager fm) : base(fm)
        {
        }

        public override Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0:
                    return new ProgramPageFragment();
                case 1:
                    return new AboutPageFragment();
                case 2:
                    return new GalleryPageFragment();
                case 3:
                    return new MapPageFragment();
                case 4:
                    return new SettingsPageFragment();
                default:
                    return new ProgramPageFragment();
            }
        }
    }
}