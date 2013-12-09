using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPP
{
    public class Solution
    {
        public IList<City> Cities { get; private set; }

        public double Evaluation { get; private set; }

        public Solution(IList<City> list)
        {
            Cities = list;
        }

        public void Evaluate(City warehouse, int k)
        {

            int length = 0;
            var i = Cities.GetEnumerator();
            double totalLength = 0;
            City previousCity = warehouse;
            City currentCity;

            while (i.MoveNext())
            {
                currentCity = i.Current;
                totalLength += previousCity.Distance(currentCity);
                previousCity = currentCity;
                ++length;
                if (length == k)
                {
                    totalLength += previousCity.Distance(warehouse);
                    previousCity = warehouse;
                    length = 0;
                }
            }

            if (length != 0)
                totalLength += previousCity.Distance(warehouse);

            Evaluation = totalLength;
        }
    }
}
