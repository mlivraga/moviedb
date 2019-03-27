using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foundation;
using moviedb.Core.Model;
using UIKit;

namespace moviedb.iOS
{
    public class RootTableSource : UITableViewSource
    {
        public ObservableCollection<MyMovie> tableItems;
        readonly string cellIdentifier = "taskcell"; // set in the Storyboard

        public RootTableSource(ObservableCollection<MyMovie> items)
        {
            tableItems = items;
        }

        public override nint RowsInSection (UITableView tableview, nint section)
        {
            return tableItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellIdentifier);

            cell.TextLabel.Text = tableItems[indexPath.Row].title;

            return cell;
        }

        public MyMovie GetItem(int id)
        {
            return tableItems[id];
        }


    }
}
