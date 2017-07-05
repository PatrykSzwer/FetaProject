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
			AboutPager about = storyboard.InstantiateViewController("about") as AboutPager;


			tab1 = program;
			tab1.Title = "ProgramTab".Translate();
			tab1.TabBarItem.Image = UIImage.FromFile("Icons/program.png");
			tab2 = about;
			tab2.Title = "AboutTab".Translate();
			tab2.TabBarItem.Image = UIImage.FromFile("Icons/about.png");
			tab3 = gallery;
			tab3.Title = "GalleryTab".Translate();
			tab3.TabBarItem.Image = UIImage.FromFile("Icons/gallery.png");
			tab4 = maps;
			tab4.Title = "MapsTab".Translate();
			tab4.TabBarItem.Image = UIImage.FromFile("Icons/mapa.png");
			tab5 = language;
			tab5.Title = "SettingsTab".Translate();
			tab5.TabBarItem.Image = UIImage.FromFile("Icons/settings.png");

			var tabs = new UIViewController[] {
								tab1, tab2, tab3, tab4, tab5
						};

			ViewControllers = tabs;
		}
	}
}