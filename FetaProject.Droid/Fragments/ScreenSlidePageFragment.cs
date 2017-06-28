using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace FetaProject.Droid.Fragments
{
    public class ScreenSlidePageFragment : Android.Support.V4.App.Fragment
    {
        private readonly int _resourceId;
        private readonly Activity _context;

        public ScreenSlidePageFragment(Activity context, int resourceId)
        {
            _context = context;
            _resourceId = resourceId;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ViewInitialization();
            return (ViewGroup)inflater.Inflate(_resourceId, container, false);
        }

        public virtual void ViewInitialization() { }

    }
}