using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPP
{
    public class City
    {
        private int x;

        private int y;

        public City(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public double Distance(City to)
        {
            return Math.Sqrt(Math.Pow(x - to.x, 2) + Math.Pow(y - to.y, 2));
        }

        public override string ToString()
        {
            return "City: " + x.ToString() + " " + y.ToString();
        }
    }
}
