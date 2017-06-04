using Foundation;
using System;
using UIKit;
using FetaProject.iOS.LocalizationExtension;

namespace FetaProject.iOS
{
	public partial class TabBarViews : UITabBarController
	{
		UIViewController tab1, tab2, tab3, tab4, tab5;
		public TabBarViews(IntPtr handle) : base(handle)
		{





			var storyboard = UIStoryboard.FromName("Main", null);
			GalleryView gallery = storyboard.InstantiateViewController("gallery") as GalleryView;
			SettingsNav setting = storyboard.InstantiateViewController("setting") as SettingsNav;
			ProgramNav program = storyboard.InstantiateViewController("program") as ProgramNav;
			MapViewController maps = storyboard.InstantiateViewController("maps") as MapViewController;
			PosterView about = storyboard.InstantiateViewController("about") as PosterView;
			gallery.TabBarItem.Title = "GalleryTab".Translate();


			tab1 = gallery;
			tab2 = setting;
			tab3 = program;
			tab4 = about;
			tab5 = maps;

			var tabs = new UIViewController[] {
								tab1, tab2, tab3, tab4, tab5
						};

			ViewControllers = tabs;

		}
	}
}