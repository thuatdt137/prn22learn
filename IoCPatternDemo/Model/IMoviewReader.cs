using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCPatternDemo.Model
{
    public interface IMoviewReader
    {
        List<Movie> ReadMovies();
    }
}
