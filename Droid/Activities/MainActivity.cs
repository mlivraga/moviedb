using Android.App;
using Android.OS;
using Android.Util;
using Android.Support.V7.Widget;
using moviedb.Droid.Helpers;

namespace moviedb.Droid.Activities
{
    [Activity(Label = "Moviedb", MainLauncher = true, Icon = "@mipmap/ic_projector")]
    public class MainActivity : Activity
    {
        private RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        MoviesAdapter mAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Log.Debug(MyApp.TAG, "OnCreate");

            mAdapter = new MoviesAdapter(this, MyApp.myMoviesViewModel.MyMovies);
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mRecyclerView.SetAdapter(mAdapter);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            MyApp.myMoviesViewModel.MyMovies.CollectionChanged += (sender, e) =>
            {
                Log.Debug(MyApp.TAG, "update data on adapter");

                mAdapter.NotifyDataSetChanged();
            };

        }

        protected async override void OnResume() 
        {
            base.OnResume();

            Log.Debug(MyApp.TAG, "OnResume");

            await MyApp.myMoviesViewModel.LoadMovies();
        }

    }
}

