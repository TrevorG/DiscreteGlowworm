using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPP
{
    public class State
    {
        public int K { get; private set; } 

        private IList<City> cities;

        public City Warehouse { get { return cities[0]; } }

        public State(int k, List<City> cities)
        {
            this.K = k;
            this.cities = cities;
        }

        public City GetCity(int id)
        {
            return cities[id];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(K.ToString());
            sb.AppendLine("Warehouse: " + Warehouse.ToString());
            foreach(City c in cities)
                sb.AppendLine(c.ToString());

            return sb.ToString();
        }
    }
}
