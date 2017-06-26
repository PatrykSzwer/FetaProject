using Android.App;
using Android.OS;
using Android.Support.V7.App;
using FetaProject.Droid.Helpers;

namespace FetaProject.Droid
{
    [Activity(Label = "SettingsActivity")]
    public class SettingsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Settings);
            NavigationHelper.SetNavigationChange(this, null);
        }
    }
}
