using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IoCPatternDemo.Model
{
    public class JSONMovieReader : IMoviewReader
    {
        static string file = @"Data\MovieDB.json";
        static List<Movie> movieList = new List<Movie>();
        public List<Movie> ReadMovies()
        {
            var moviesText = File.ReadAllText(file);
            return JsonSerializer.Deserialize<List<Movie>>(moviesText);
        }
    }
}
