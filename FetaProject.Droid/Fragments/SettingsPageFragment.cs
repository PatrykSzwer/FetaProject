using Android.Content.Res;
using Android.Util;
using Android.Widget;
using FetaProject.Droid.Fragments.Base;
using Java.Util;
using System;

namespace FetaProject.Droid.Fragments
{
    public class SettingsPageFragment : BaseSlidePageFragment
    {
        public SettingsPageFragment() : base(Resource.Layout.fragment_screen_slide_page_settings)
        {
        }

        public override void ViewInitialization()
        {
            var engButton = this.FragmentView.FindViewById<Button>(Resource.Id.settingsButtonEnglish);
            var polButton = this.FragmentView.FindViewById<Button>(Resource.Id.settingsButtonPolish);

            engButton.Click += HandleEnglishClick;
            polButton.Click += HandlePolishClick;
        }

        void HandleEnglishClick(object sender, EventArgs ea)
        {
            this.SetLocale(Locale.English);
        }

        void HandlePolishClick(object sender, EventArgs ea)
        {
            this.SetLocale(new Locale("pl"));
        }

        private void SetLocale(Locale locale)
        {
            Configuration conf = Resources.Configuration;
            conf.Locale = locale;
            DisplayMetrics dm = Resources.DisplayMetrics;
            Resources.UpdateConfiguration(conf, dm);
            this.Activity.Recreate();
        }
    }
}