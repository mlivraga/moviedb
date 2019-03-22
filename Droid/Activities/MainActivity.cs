using Android.App;
using Android.Widget;
using Android.OS;
using moviedb.Core.ViewModels;
using moviedb.Core.Model;

namespace moviedb.Droid
{
    [Activity(Label = "Moviedb", MainLauncher = true, Icon = "@mipmap/ic_projector")]
    public class MainActivity : Activity
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

            RetriveData();

            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Click += delegate {
                if (MyMoviesViewModel.Movies.Count == 0)
                {
                    Toast.MakeText(this, "Sorry..No movies!", ToastLength.Short).Show();
                }
                else
                {
                    foreach (MyMovie m in MyMoviesViewModel.Movies)
                        Toast.MakeText(this, m.title, ToastLength.Short).Show();
                }
            };
        }

        private async void RetriveData()
        {
            await MyMoviesViewModel.LoadMovies();
        }



    }
}

