using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPP
{
    public class Solution
    {
        private IList<int> ids;

        public Solution(IList<int> list)
        {
            ids = list;
        }

        public double Evaluate(State s)
        {
            int k = 0;
            var i = ids.GetEnumerator();
            double totalLength = 0;
            City previousCity = s.Warehouse;
            City currentCity;

            while (i.MoveNext())
            {
                currentCity = s.GetCity(i.Current);
                totalLength += previousCity.Distance(currentCity);
                previousCity = currentCity;
                ++k;
                if (k == s.K)
                {
                    totalLength += previousCity.Distance(s.Warehouse);
                    previousCity = s.Warehouse;
                    k = 0;
                }
            }

            if (k != 0)
                totalLength += previousCity.Distance(s.Warehouse);

            return totalLength;
        }
    }
}
