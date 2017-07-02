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
			AboutView1 about = storyboard.InstantiateViewController("about") as AboutView1;


			tab1 = program;
			tab1.Title = "ProgramTab".Translate();
			tab2 = about;
			tab2.Title = "AboutTab".Translate();
			tab3 = gallery;
			tab3.Title = "GalleryTab".Translate();
			tab4 = maps;
			tab4.Title = "MapsTab".Translate();
			tab5 = language;
			tab5.Title = "SettingsTab".Translate();

			var tabs = new UIViewController[] {
								tab1, tab2, tab3, tab4, tab5
						};

			ViewControllers = tabs;
		}
	}
}