using Android.App;
using Android.OS;
using Android.Support.V7.App;
using FetaProject.Droid.Helpers;

namespace FetaProject.Droid
{
    [Activity(Label = "AboutFestivalActivity")]
    public class AboutFestivalActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AboutFestival);
            NavigationHelper.SetNavigationChange(this);
        }
    }
}
