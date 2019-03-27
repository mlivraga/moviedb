using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Util;
using Android.Widget;
using moviedb.Core.Helpers;
using moviedb.Core.Model;


namespace moviedb.Droid.Activities
{
    [Activity(Label = "DetailsActivity")]
    public class DetailsActivity : BaseActivity
    {
        TextView tvTitle;
        TextView tvReleseDate;
        TextView tvOriginalLang;
        TextView tvDescription;
        ImageView ivPoster;

        MyMovie currentMovie;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_details);

            tvTitle = FindViewById<TextView>(Resource.Id.tv_title);
            tvReleseDate = FindViewById<TextView>(Resource.Id.tv_release_date);
            tvOriginalLang = FindViewById<TextView>(Resource.Id.tv_original_language);
            tvDescription = FindViewById<TextView>(Resource.Id.tv_description);
            ivPoster = FindViewById<ImageView>(Resource.Id.iv_poster);

            int movieId = Intent.GetIntExtra(Constants.EXTRA_MOVIE_DATA, -1);
            currentMovie = MyApp.myMoviesViewModel.GetMovie(movieId);

            tvTitle.Text = currentMovie.title;
            tvReleseDate.Text = currentMovie.release_date;
            tvOriginalLang.Text = currentMovie.original_language;
            tvDescription.Text = currentMovie.overview;

            ivPoster.Click += (sender, e) =>
            {
                Toast.MakeText(this, currentMovie.title , ToastLength.Short).Show();
            };

        }

        protected override async void OnResume()
        {
            base.OnResume();

            string uri = Constants.BASE_REST_IMG_URL + Constants.POSTER_PATH + currentMovie.poster_path;

            byte[] imageResponse = await MyApp.myMoviesViewModel.DownloadImageAsync(uri);

            Bitmap movieImage = BitmapFactory.DecodeByteArray(imageResponse, 0, imageResponse.Length);

            ivPoster.SetImageBitmap(movieImage);

        }
    }
}
