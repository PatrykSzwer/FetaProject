
using Android.App;
using Android.OS;

namespace FetaProject.Droid
{
    [Activity(Label = "TestActivity")]
    public class ExampleActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            this.SetContentView(Resource.Layout.Example);
        }
    }
}