using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPP
{
    public class Optimalization
    {
        public Solution Run(int populationSize, int count, State s)
        {
            Solution best;
            Random random = new Random();
            IList<Solution> solutions;

            solutions = Initialize(populationSize, s, random);

            for (int i = 0; i < count; ++i)
            {
                
            }

            return null; //hush, compiler

        }

        private IList<Solution> Initialize(int count, State s, Random rnd)
        {
            IList<Solution> solutions = new List<Solution>();
            IList<City> solution;

            for (int i = 0; i < count; ++i)
            {
                solution = new List<City>(s.Cities);
                Shuffle(solution, rnd);
                solutions.Add(new Solution(solution));
            }


            return solutions;
        }

        private void Shuffle(IList<City> list, Random rnd)
        {
            int n = list.Count;
            while (n > 1)
            {
                --n;
                int k = rnd.Next(n + 1);
                City value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void Evaluate(IList<Solution> l, State state)
        {
            foreach(Solution s in l)
            {
                s.Evaluate(state.Warehouse, state.K);
            }
        }
    }
}
