using Android.Widget;
using FetaProject.Droid.Fragments.Base;

namespace FetaProject.Droid.Fragments
{
    public class ProgramPageFragment : BaseSlidePageFragment
    {

        public ProgramPageFragment() : base(Resource.Layout.fragment_screen_slide_page_program)
        {

        }

        public override void ViewInitialization()
        {
            var listview = (ListView)FragmentView.FindViewById(Resource.Id.list_view);
        }
    }
}