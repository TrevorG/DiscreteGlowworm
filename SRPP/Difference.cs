using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRPP
{
    public class Difference
    {
        public IList<int> Positions { get; private set; }

        public int Distance { get { return Positions.Count; } }

        public Difference(Solution from, Solution to)
        {
            var i1 = from.Cities.GetEnumerator();
            var i2 = to.Cities.GetEnumerator();
            Positions = new List<int>();

            for(int i = 0; i < from.Cities.Count; ++i)
            {
                i1.MoveNext();
                i2.MoveNext();

                if (i1.Current != i2.Current)
                {
                    Positions.Add(i);
                }
            }
        }
    }
}
