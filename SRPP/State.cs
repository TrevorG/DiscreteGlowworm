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

        public IList<City> Cities { get; private set; }

        public City Warehouse { get; private set; }

        public State(int k, List<City> cities)
        {
            this.K = k;
            Cities = cities;
            Warehouse = Cities[0];
            Cities.RemoveAt(0);
        }

        public City GetCity(int id)
        {
            return Cities[id];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(K.ToString());
            sb.AppendLine("Warehouse: " + Warehouse.ToString());
            foreach(City c in Cities)
                sb.AppendLine(c.ToString());

            return sb.ToString();
        }
    }
}
