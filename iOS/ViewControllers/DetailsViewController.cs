using Foundation;
using moviedb.Core.Helpers;
using moviedb.Core.Model;
using moviedb.Core.ViewModels;
using System;
using System.Net.Mail;
using System.Net.Sockets;
using System.Threading.Tasks;
using UIKit;

namespace moviedb.iOS
{
    public partial class DetailsViewController : UIViewController
    {
        MyMovie CurrentMovie { get; set; }

        MoviesViewModel moviesViewModel = new MoviesViewModel();

        public DetailsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            TitleLabel.Text = CurrentMovie.title;
            ReleaseDateLabel.Text = CurrentMovie.release_date;
            LanguageLabel.Text = CurrentMovie.original_language;
            DescriptionLabel.Text = CurrentMovie.overview;

            DownloadImage();

        }

        public void SetTask(MyMovie movie)
        {
            CurrentMovie = movie;
        }


        private async void DownloadImage()
        {
            string uri = Constants.BASE_REST_IMG_URL + Constants.POSTER_PATH + CurrentMovie.poster_path;

            byte[] downloadImage = await moviesViewModel.DownloadImageAsync(uri);

            NSData data = NSData.FromArray(downloadImage);
            UIImage uiimage = UIImage.LoadFromData(data);
            PosterImage.Image = uiimage;

        }

    }
}