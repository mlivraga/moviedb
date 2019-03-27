using Foundation;
using moviedb.Core.Model;
using System;
using UIKit;

namespace moviedb.iOS
{
    public partial class DetailsViewController : UIViewController
    {
        MyMovie currentMovie { get; set; }

        public DetailsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            TitleLabel.Text = currentMovie.title;
            ReleaseDateLabel.Text = currentMovie.release_date;
            LanguageLabel.Text = currentMovie.original_language;
            DescriptionLabel.Text = currentMovie.overview;
        }

        public void SetTask(MyMovie task)
        {
            currentMovie = task;
        }
    }
}