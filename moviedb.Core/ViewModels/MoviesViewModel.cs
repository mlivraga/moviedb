using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using moviedb.Core.Helpers;
using moviedb.Core.Model;
using Newtonsoft.Json;


namespace moviedb.Core.ViewModels
{
    public class MoviesViewModel : ViewModelBase
    {
        private ObservableCollection<MyMovie> mymovies = new ObservableCollection<MyMovie>();
        public ObservableCollection<MyMovie> myMovies
        {
            get { return mymovies; }
            set { mymovies = value; OnPropertyChanged("movies"); }
        }

        /// <summary>
        /// Loads the movies for remote service.
        /// </summary>
        /// <returns>Download new popular movies on mymovies list.</returns>
        public async Task LoadMovies()
        {
            Console.WriteLine("LoadMovies, start");

            var url = Constants.BASE_REST_URL 
                        + Constants.POPULAR_PATH 
                            + Constants.QUERY_STRING_API 
                                + Keys.API_KEY 
                                    + Constants.QUERY_STRIN_LANGUAGE;

            Console.WriteLine("LoadMovies, url {0}", url);

            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(url);
                ApiMovieResponse response = JsonConvert.DeserializeObject<ApiMovieResponse>(content);

                List<MyMovie> newMovies = response.results;
                Console.WriteLine("LoadMovies, response #movies: {0}", newMovies.Count);

                myMovies.Clear();

                foreach(MyMovie current in newMovies)
                {
                    myMovies.Add(current);
                }
            }

            Console.WriteLine("LoadMovies, end");
        }


    }
}
