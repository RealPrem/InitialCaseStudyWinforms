using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialCaseStudyWinforms
{
    public class Path
    {
        public List<City> Cities = new List<City>();

        public double Distance;

        public Path()
        {
            Distance = 0;
            //loop thru all the Cities, use X Y coordinate to work out distance (Pythagoras), add them together to get total distance 
        }

    }
}