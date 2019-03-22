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
        private MoviesViewModel moviesViewModel;
        public MoviesViewModel MoviesViewModel
        {
            get { return moviesViewModel ?? (moviesViewModel = new MoviesViewModel()); }
        }

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            // moviesViewModel == null
            await MoviesViewModel.LoadMovies();

            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Click += delegate {
                foreach (MyMovie m in MoviesViewModel.Movies)
                {
                    Toast.MakeText(this, m.title, ToastLength.Short).Show();
                }
            };
        }



    }
}

