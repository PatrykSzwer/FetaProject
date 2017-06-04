using Foundation;
using System;
using UIKit;
using Google.Maps;

namespace FetaProject.iOS
{
	public partial class MapViewController : UIViewController
	{

		public override void ViewDidLoad()
		{
			map.Image = UIImage.FromBundle("Photo/Map.jpg");

		}


		public MapViewController(IntPtr handle) : base(handle)
		{

		}
	}
}