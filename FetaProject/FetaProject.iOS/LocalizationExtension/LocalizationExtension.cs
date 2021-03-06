﻿using Foundation;

namespace FetaProject.iOS.LocalizationExtension
{
    public static class LocalizationExtension
    {
        public static string Translate(this string translate)
        {
            var language = NSUserDefaults.StandardUserDefaults.StringForKey("language");

            if (language == null)
            {
                return NSBundle.MainBundle.LocalizedString(translate, "");
            }

            var path = NSBundle.MainBundle.PathForResource(language, "lproj");
            var languagebundle = NSBundle.FromPath(path);
            return languagebundle.LocalizedString(translate, "");
        }
    }
}