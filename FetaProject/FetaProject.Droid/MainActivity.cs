namespace FetaProject.Droid
{
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Widget;

    using Java.Util;

    [Activity(Label = "Feta application", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.Main);

            var engButton = this.FindViewById<Button>(Resource.Id.enButton);
            var polButton = this.FindViewById<Button>(Resource.Id.plButton);

            engButton.Click += (sender, e) => this.ChangeLanguage(Locale.Us);
            polButton.Click += (sender, e) => this.ChangeLanguage(new Locale("pl_PL", "PL"));
        }

        /// <summary>
        /// Changes application internal language.
        /// </summary>
        /// <param name="locale">
        /// The locale to be set.
        /// </param>
        private void ChangeLanguage(Locale locale)
        {
            this.Resources.Configuration.SetLocale(locale);
            this.BaseContext.Resources.UpdateConfiguration(this.Resources.Configuration, this.BaseContext.Resources.DisplayMetrics);

            // TODO: Show default application view when implemented.
            this.DisplayExampleView();
        }

        // Display example view - to be removed.
        private void DisplayExampleView()
        {
            var intent = new Intent(this, typeof(ExampleActivity));
            this.StartActivity(intent);
        }
    }
}


