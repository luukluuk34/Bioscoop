using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopService
{
    public class Movie
    {
        private string Title;

        private List<MovieScreening> Screenings;


        public Movie(string title)
        {
            Title = title;
        }

        public void addScreening(MovieScreening screening)
        {
            this.Screenings.Add(screening);
        }

        public string toString()
        {
            return Title;
        }

    }
}
