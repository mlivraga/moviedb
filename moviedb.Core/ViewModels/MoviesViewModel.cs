using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using moviedb.Core.Helpers;
using moviedb.Core.Model;
using Newtonsoft.Json;

namespace moviedb.Core.ViewModels
{
    public class MoviesViewModel : ViewModelBase
    {
        private ObservableCollection<MyMovie> movies = new ObservableCollection<MyMovie>();
        public ObservableCollection<MyMovie> Movies
        {
            get { return movies; }
            set { movies = value; OnPropertyChanged("movies"); }
        }

        //private MyMovie selectedPlanet;
        //public MyMovie SelectedPlanet
        //{
        //    get { return selectedPlanet; }
        //    set
        //    {
        //        selectedPlanet = value;
        //        OnPropertyChanged("selectedMovie");
        //    }
        //}

        //private ICommand loadMoviesCommand;
        //public ICommand LoadMoviesCommand
        //{
        //    get
        //    {
        //        return LoadMoviesCommand ?? (loadMoviesCommand = new Command(async () => await LoadMovies()));
        //    }
        //}

        public async Task LoadMovies()
        {
            Console.WriteLine("LoadMovies - START");

            var url = Constants.BASE_REST_URL + Constants.POPULAR_PATH + "?api_key=" + Keys.API_KEY + "&language=en-US&page=1";
            Console.WriteLine("url {0}", url);

            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(url);
                ApiMovieResponse response = JsonConvert.DeserializeObject<ApiMovieResponse>(content);

                List<MyMovie> newMovies = response.results;
                Console.WriteLine("movies tot: {0}", newMovies.Count);

                Movies.Clear();

                foreach(MyMovie current in newMovies)
                {
                    Movies.Add(current);
                    Console.WriteLine(current.title);
                }
            }

            Console.WriteLine("LoadMovies - END");
        }


        // TODO Command to load posters

        // TODO Method that download posters

    }
}
