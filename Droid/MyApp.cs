using System;
using Android.App;
using moviedb.Core.ViewModels;

namespace moviedb.Droid
{
    [Application]
    public class MyApp : Application
    {
        public static string TAG = "moviedb";

        public static MoviesViewModel myMoviesViewModel = myMoviesViewModel = new MoviesViewModel();

        public MyApp(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

    }
}
