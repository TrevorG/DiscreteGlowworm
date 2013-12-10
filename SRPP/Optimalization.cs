using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPP
{
    public class Optimalization
    {
        public Solution Run(State s)
        {
            Solution best = null;
            Random random = new Random();
            IList<Solution> solutions;
            //IList<Difference> differences = new List<Difference>(populationSize);

            solutions = Initialize(s, random);

            for (int i = 0; i < s.Iterations; ++i)
            {
                Evaluate(solutions, s);
                solutions = solutions.OrderByDescending(e => e.Evaluation).ToList();
                best = solutions.Last();

                //differences.Clear();
                for (int j = 0; j < s.PopulationSize - 1; ++j)
                    solutions[j].MergeWithBest(best, random);


            }

            return best;

        }

        private IList<Solution> Initialize(State s, Random rnd)
        {
            IList<Solution> solutions = new List<Solution>();
            IList<City> solution;

            for (int i = 0; i < s.PopulationSize; ++i)
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
