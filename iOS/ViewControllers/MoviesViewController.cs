using Foundation;
using moviedb.Core.Model;
using moviedb.Core.ViewModels;
using System;
using UIKit;

namespace moviedb.iOS
{
    public partial class MoviesViewController : UITableViewController
    {

        MoviesViewModel moviesViewModel = new MoviesViewModel();

        public MoviesViewController (IntPtr handle) : base (handle)
        {
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            await moviesViewModel.LoadMovies();

            TableView.Source = new RootTableSource(moviesViewModel.MyMovies);

            // fix for delay to see items
            TableView.ReloadData();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            if(segue.Identifier == "TaskSegue")
            {
                var navctlr = segue.DestinationViewController as DetailsViewController;
                if(navctlr != null)
                {
                    var source = TableView.Source as RootTableSource;
                    var rowPath = TableView.IndexPathForSelectedRow;
                    MyMovie item = source.GetItem(rowPath.Row);
                    navctlr.SetTask(item); // defined on the DetailsViewController
                }
            }
        }

    }
}