using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using moviedb.Core.Model;

namespace moviedb.Droid.Helpers
{
    public class MoviesAdapter : RecyclerView.Adapter
    {
        ObservableCollection<MyMovie> dataset;
        Activity activity;

        public MoviesAdapter(Activity activity, ObservableCollection<MyMovie> myMovies)
        {
            this.activity = activity;
            this.dataset = myMovies;
        }

        public override int ItemCount => dataset.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = dataset[position];

            var currentHolder = holder as MyAdapterViewHolder;
            currentHolder.Title.Text = item.title;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.simple_item;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            return new MyAdapterViewHolder(itemView);
        }


        public void Update()
        {
            //dataset.Clear();

            //foreach(MyMovie m in data)
            //{
            //    dataset.Add(m);
            //}

            Console.WriteLine("update data on adapter");

            NotifyDataSetChanged();
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
