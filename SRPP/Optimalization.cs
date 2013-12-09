using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPP
{
    public class Optimalization
    {
        public Solution Run(int count, int max)
        {
            Solution best;
            Random random = new Random();
            IList<Solution> solutions;

            solutions = Initialize(count, max, random);

            return null; //hush, compiler

        }

        public IList<Solution> Initialize(int count, int max, Random rnd)
        {
            IList<Solution> solutions = new List<Solution>();
            IList<int> solution;

            for (int i = 0; i < count; ++i)
            {
                solution = Enumerable.Range(1, max).ToList();
                Shuffle(solution, rnd);
                solutions.Add(new Solution(solution));
            }


            return solutions;
        }

        private void Shuffle(IList<int> list, Random rnd)
        {
            int n = list.Count;
            while (n > 1)
            {
                --n;
                int k = rnd.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
