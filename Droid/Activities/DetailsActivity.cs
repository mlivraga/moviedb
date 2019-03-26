
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using moviedb.Core.Helpers;
using moviedb.Core.Model;
using moviedb.Core.ViewModels;

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
            MyMovie currentMovie = MyApp.myMoviesViewModel.GetMovie(movieId);

            tvTitle.Text = currentMovie.title;


        }
    }
}
