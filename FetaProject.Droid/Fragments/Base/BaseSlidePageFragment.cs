using Android.OS;
using Android.Views;

namespace FetaProject.Droid.Fragments.Base
{
    public abstract class BaseSlidePageFragment : Android.Support.V4.App.Fragment
    {
        protected View FragmentView;
        private readonly int _resourceId;

        protected BaseSlidePageFragment(int resourceId)
        {
            _resourceId = resourceId;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            FragmentView = (ViewGroup)inflater.Inflate(_resourceId, container, false);
            ViewInitialization();
            return FragmentView;
        }

        public abstract void ViewInitialization();
    }
}