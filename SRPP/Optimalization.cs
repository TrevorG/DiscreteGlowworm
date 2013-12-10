using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPP
{
    public class Optimalization
    {

        private Random randomizer;

        public Optimalization(){
            randomizer = new Random();
        }

        public Solution Run(State s)
        {
            Solution best = null;
            IList<Solution> solutions;
            //IList<Difference> differences = new List<Difference>(populationSize);

            solutions = Initialize(s);

            for (int i = 0; i < s.Iterations; ++i)
            {
                Evaluate(solutions, s);
                solutions = solutions.OrderByDescending(e => e.Evaluation).ToList();
                best = solutions.Last();

                LocalSearch(best, 5, s);

                //differences.Clear();
                for (int j = 0; j < s.PopulationSize - 1; ++j)
                    solutions[j].MergeWithBest(best, randomizer);


            }

            return best;

        }

        private IList<Solution> Initialize(State s)
        {
            IList<Solution> solutions = new List<Solution>();
            Solution solution;

            solutions.Add(GenerateGreedySolution(s));

            for (int i = 1; i < s.PopulationSize; ++i)
            {
                solution = new Solution(new List<City>(s.Cities));
                Shuffle(solution);
                solutions.Add(solution);
            }


            return solutions;
        }

        private void Shuffle(Solution s)
        {
            int n = s.Cities.Count;
            while (n > 1)
            {
                --n;
                int k = randomizer.Next(n + 1);
                s.SwapCities(k, n);
            }
        }

        private void Evaluate(IList<Solution> l, State state)
        {
            foreach(Solution s in l)
            {
                //s.Evaluate(state.Warehouse, state.K);
                LocalSearch(s, 5, state);
            }
        }

        private void LocalSearch(Solution s, int trials, State state)
        {
            int m, n;
            double baseEvaluation = s.Evaluate(state.Warehouse, state.K);

            for (int i = 0; i < trials; ++i)
            {
                m = randomizer.Next(s.Cities.Count);
                do{
                    n = randomizer.Next(s.Cities.Count);
                }while(m == n);
                s.SwapCities(m, n);
                if (s.Evaluate(state.Warehouse, state.K) < baseEvaluation)
                {
                    //better permutation
                    baseEvaluation = s.Evaluation;
                }
                else
                {
                    //worse permutation, we go back to previous one
                    s.SwapCities(m, n);
                    s.Evaluate(state.Warehouse, state.K);
                }
            }
        }

        public Solution GenerateGreedySolution(State s)
        {
            IList<City> sourceCities = new List<City>(s.Cities);
            IList<City> destinationList = new List<City>(s.Cities.Count);
            City previousCity = s.Warehouse;
            int k = 0;
            double minDistance;
            double currentDistance;
            int selectedCity;

            while(sourceCities.Count > 0)
            {
                ++k;
                selectedCity = 0;
                minDistance = sourceCities[0].Distance(previousCity);
                for (int j = 1; j < sourceCities.Count; ++j)
                {
                    currentDistance = sourceCities[j].Distance(previousCity);
                    if (currentDistance < minDistance)
                    {
                        minDistance = currentDistance;
                        selectedCity = j;
                    }
                }
                if (k == s.K)
                {
                    previousCity = s.Warehouse;
                    k = 0;
                }
                else
                    previousCity = sourceCities[selectedCity];

                destinationList.Add(sourceCities[selectedCity]);
                sourceCities.RemoveAt(selectedCity);
            }

            return new Solution(destinationList);
        }
    }
}
