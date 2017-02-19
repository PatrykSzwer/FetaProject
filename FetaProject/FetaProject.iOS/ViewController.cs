using System;
using System.Collections.Generic;
using CoreGraphics;
using UIKit;

namespace FetaProject.iOS
{
	public partial class ViewController : UIViewController
	{
		UITableView table;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			var width = View.Bounds.Width;
			var height = View.Bounds.Height;

			table = new UITableView(new CGRect(0, 0, width, height));
			table.AutoresizingMask = UIViewAutoresizing.All;;
			string[] tableItems = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
			table.Source = new ProgramTableSource(tableItems);
			Add(table);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

