using Android.App;
using Android.Widget;
using FetaProject.Droid.Fragments.Base;

namespace FetaProject.Droid.Fragments
{
    public class ProgramPageFragment : BaseSlidePageFragment
    {
        private readonly Activity _context;
        public ProgramPageFragment(Activity context) : base(Resource.Layout.fragment_screen_slide_page_program)
        {
            _context = context;
        }
        public override void ViewInitialization()
        {
            var listview = (ListView)FragmentView.FindViewById(Resource.Id.list_view);
        }
    }
}