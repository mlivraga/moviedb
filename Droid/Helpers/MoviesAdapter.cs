using System.Collections.ObjectModel;
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using moviedb.Core.Helpers;
using moviedb.Core.Model;
using moviedb.Droid.Activities;

namespace moviedb.Droid.Helpers
{
    public class MoviesAdapter : RecyclerView.Adapter
    {
        ObservableCollection<MyMovie> dataset;
        readonly Activity activity;

        public MoviesAdapter(Activity activity, ObservableCollection<MyMovie> myMovies)
        {
            this.activity = activity;
            this.dataset = myMovies;
        }

        public override int ItemCount => dataset.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = dataset[position];

            var mHolder = holder as MyAdapterViewHolder;
            mHolder.Title.Text = item.title;

            mHolder.ItemView.Click += (sender, e) =>
            {
                Log.Debug(MyApp.TAG, "Item clicked, at position " + position);

                Intent intent = new Intent(activity, typeof(DetailsActivity));
                intent.SetFlags(ActivityFlags.NewTask);
                intent.PutExtra(Constants.EXTRA_MOVIE_DATA, item.id);
                activity.StartActivity(intent);
            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.simple_item;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            return new MyAdapterViewHolder(itemView);
        }

    }

    public class MyAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView Title { get; private set; }

        public MyAdapterViewHolder(View itemView): base(itemView)
        {
            Title = itemView.FindViewById<TextView>(Resource.Id.tv_first);
        }
    }
}
