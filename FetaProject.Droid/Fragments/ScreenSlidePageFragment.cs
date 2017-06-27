using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace FetaProject.Droid.Fragments
{
    public class ScreenSlidePageFragment : Fragment
    {
        private readonly int _resourceId;

        public ScreenSlidePageFragment(int resourceId)
        {
            _resourceId = resourceId;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return (ViewGroup)inflater.Inflate(_resourceId, container, false);
        }
    }
}