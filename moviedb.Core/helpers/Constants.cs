namespace moviedb.Core.Helpers
{
    public static class Constants
    {
        public static string BASE_REST_URL = "https://api.themoviedb.org";
        public static string BASE_REST_IMG_URL = "http://image.tmdb.org";


        public static string QUERY_STRING_API = "?api_key=";
        public static string QUERY_STRIN_LANGUAGE = "&language=en-US&page=1";

        public static string POPULAR_PATH = "/3/movie/popular";
        public static string POSTER_PATH = "/t/p/w500"; // /t/p/w500/{param}


        public static string EXTRA_MOVIE_DATA = "extra_movie_data";

    }
}
