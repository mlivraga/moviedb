using Android.App;
using Android.Widget;
using Android.OS;
using moviedb.Core.ViewModels;
using moviedb.Core.Model;
using Android.Util;

namespace moviedb.Droid.Activities
{
    [Activity(Label = "Moviedb", MainLauncher = true, Icon = "@mipmap/ic_projector")]
    public class MainActivity : BaseActivity
    {
        private MoviesViewModel myMoviesViewModel;
        public MoviesViewModel MyMoviesViewModel
        {
            get { return myMoviesViewModel ?? (myMoviesViewModel = new MoviesViewModel()); }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            Log.Debug(myApp.TAG, "OnCreate");

            RetriveData();

            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Click += delegate {
                int countMovies = MyMoviesViewModel.myMovies.Count;
                if (countMovies == 0)
                    Toast.MakeText(this, "Sorry..No movies!", ToastLength.Short).Show();
                else
                    Toast.MakeText(this, "#movies " + countMovies, ToastLength.Short).Show();
            };
        }

        private async void RetriveData()
        {
            Log.Debug(myApp.TAG, "RetriveData");

            await MyMoviesViewModel.LoadMovies();
        }



    }
}

