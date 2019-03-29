using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
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
        public ObservableCollection<MyMovie> MyMovies
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

                MyMovies.Clear();

                foreach(MyMovie current in newMovies)
                {
                    MyMovies.Add(current);
                }
            }

            Console.WriteLine("LoadMovies, end");
        }

        /// <summary>
        /// Gets the specified movie.
        /// </summary>
        /// <returns>The movie.</returns>
        /// <param name="searchID">Search identifier.</param>
        public MyMovie GetMovie(int searchID)
        {
            MyMovie wanted = null;

            foreach(MyMovie m in MyMovies)
            {
                if (m.id.Equals(searchID))
                {
                    wanted = m;
                }
            }

            return wanted;
        }


        const int _downloadImageTimeoutInSeconds = 15;
        readonly HttpClient _httpClient = new HttpClient {
            Timeout = TimeSpan.FromSeconds(_downloadImageTimeoutInSeconds)
        };

        public async Task<byte[]> DownloadImageAsync(string imageUrl)
        {
            Console.WriteLine("DownloadImageAsync {0}", imageUrl);

            try
            {
                using (var httpResponse = await _httpClient.GetAsync(imageUrl))
                {
                    if(httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        return await httpResponse.Content.ReadAsByteArrayAsync();
                    }
                    else
                    {
                        // Url is Invalid
                        return null;
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine("Dowload Image exception " + e.Message);
            }

            return null;
        }


    }
}
