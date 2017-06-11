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
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var storyboard = UIStoryboard.FromName("Main", null);
			GalleryView gallery = storyboard.InstantiateViewController("gallery") as GalleryView;
			LanguageViewControler language = storyboard.InstantiateViewController("language") as LanguageViewControler;
			ProgramNav program = storyboard.InstantiateViewController("program") as ProgramNav;
			MapViewController maps = storyboard.InstantiateViewController("maps") as MapViewController;
			PosterView about = storyboard.InstantiateViewController("about") as PosterView;



/*
			gallery.TabBarItem.Title = 
			setting.TabBarItem.Title = "SettingsTab".Translate();
			
			 "GalleryTab" = "Galeria";
			 "MapsTab" = "Mapa";
			 "AboutTab" = "O festiwalu";
			 "SettingsTab" = "Ustawienia";
			 "ProgramTab" = "Program";
			 */
			tab1 = gallery;
			tab1.Title = "GalleryTab".Translate();
			tab2 = language;
			tab2.Title = "SettingsTab".Translate();
			tab3 = program;
			tab3.Title = "ProgramTab".Translate();
			tab4 = about;
			tab4.Title = "AboutTab".Translate();
			tab5 = maps;
			tab5.Title = "MapsTab".Translate();

			var tabs = new UIViewController[] {
								tab1, tab2, tab3, tab4, tab5
						};

			ViewControllers = tabs;
		}
	}
}