using Android.App;
using Android.OS;
using moviedb.Core.ViewModels;
using Android.Util;
using Android.Support.V7.Widget;
using moviedb.Droid.Helpers;
using System.Threading.Tasks;

namespace moviedb.Droid.Activities
{
    [Activity(Label = "Moviedb", MainLauncher = true, Icon = "@mipmap/ic_projector")]
    public class MainActivity : BaseActivity
    {
        private RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        MoviesAdapter mAdapter;

        private MoviesViewModel myMoviesViewModel;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            Log.Debug(myApp.TAG, "OnCreate");

            myMoviesViewModel = new MoviesViewModel();

            mAdapter = new MoviesAdapter(this, myMoviesViewModel.myMovies);
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mRecyclerView.SetAdapter(mAdapter);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            myMoviesViewModel.myMovies.CollectionChanged += (sender, e) =>
            {
                Log.Debug(myApp.TAG, "update data on adapter");

                mAdapter.NotifyDataSetChanged();
            };

        }

        protected override void OnResume() 
        {
            base.OnResume();

            Log.Debug(myApp.TAG, "OnResume");

            RetriveData();

        }


        private async Task RetriveData()
        {
            Log.Debug(myApp.TAG, "RetriveData");

            await myMoviesViewModel.LoadMovies();
        }


    }
}

