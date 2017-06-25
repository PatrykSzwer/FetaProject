using Android.App;
using Android.OS;
using Android.Support.V7.App;
using FetaProject.Droid.Helpers;

namespace FetaProject.Droid
{
    [Activity(Label = "FetaProject.Droid", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            NavigationHelper.SetNavigationChange(this);
        }
    }
}