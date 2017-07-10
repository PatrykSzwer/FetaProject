using Android.OS;
using Android.Views;

namespace FetaProject.Droid.Fragments.Base
{
    public abstract class BaseSlidePageFragment : Android.Support.V4.App.Fragment
    {
        protected View FragmentView;
        protected int ResourceId;

        protected BaseSlidePageFragment()
        {

        }

        protected BaseSlidePageFragment(int resourceId)
        {
            ResourceId = resourceId;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            FragmentView = (ViewGroup)inflater.Inflate(ResourceId, container, false);
            ViewInitialization();
            return FragmentView;
        }

        public abstract void ViewInitialization();
    }
}