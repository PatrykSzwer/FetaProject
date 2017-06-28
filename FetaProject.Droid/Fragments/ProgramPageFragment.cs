using Android.App;
using Android.Widget;
using static Android.Resource;

namespace FetaProject.Droid.Fragments
{
    public class ProgramPageFragment : ScreenSlidePageFragment
    {
        private readonly Activity _context;
        public ProgramPageFragment(Activity context) : base(context, Resource.Layout.fragment_screen_slide_page_program)
        {
            _context = context;
        }
        public override void ViewInitialization()
        {
            var listview = (ListView)_context.FindViewById(Resource.Id.list_view);
        }
    }
}