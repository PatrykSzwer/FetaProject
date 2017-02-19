using System;
using Foundation;
using UIKit;
namespace FetaProject.iOS
{
	public class ProgramTableSource : UITableViewSource
	{
		string[] ProgramList;
		string CellIdentifier = "ProgramCell";
		public ProgramTableSource(string[] items)
		{
			ProgramList = items;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			string item = ProgramList[indexPath.Row];

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

			cell.TextLabel.Text = item;

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return ProgramList.Length;
		}
	}
}
