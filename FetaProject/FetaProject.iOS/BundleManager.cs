using System;
using Foundation;
namespace FetaProject.iOS
{
	public class BundleManager
	{
		private NSBundle languageBundle;

		public NSBundle LanguageBundle{

			get{return languageBundle;}
			set{

				languageBundle = value;
			}



		}
		public BundleManager()
		{
			
			var path = NSBundle.MainBundle.PathForResource("Base", "lproj");
			languageBundle = new NSBundle(path);
		}
	}
}
