using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDesk.Options;
using System.Globalization;

namespace SRPP
{
    class Program
    {
        static void Main(string[] args)
        {
            double gammaParam = 1.0;
            double roParam = 0.0;
            double betaParam = 1.0;
            double sParam = 1.0;
            int popParam = 100;
            int iterParam = 300;
            String fileName = null;
            var p = new OptionSet() {
            { "g|gamma=", 
                "gamma parameter",
              v => {gammaParam = Double.Parse(v,CultureInfo.InvariantCulture);} },
            { "r|ro=", "r parameter",
              v => {roParam = Double.Parse(v,CultureInfo.InvariantCulture);} },
            { "s|sParam=", "s parameter",
              v => {sParam = Double.Parse(v,CultureInfo.InvariantCulture);} },
            { "b|beta=", "beta parameter",
              v => {betaParam = Double.Parse(v,CultureInfo.InvariantCulture);} },
            { "p|population=", "population size",
              v => {popParam = int.Parse(v,CultureInfo.InvariantCulture);} },
            { "i|iterations=", "iterations number",
              v => {iterParam = int.Parse(v,CultureInfo.InvariantCulture);} },
            };
            List<String> extra = new List<string>();
            try
            {
                extra = p.Parse(args);
                if (extra.Count() == 0)
                {
                    Console.WriteLine("File not given!");
                    return;
                }
                foreach (String str in extra)
                {
                    List<City> readCities = new List<City>();
                    int k = int.Parse(str.Split('k')[1].Substring(1));
                    Console.WriteLine("Processing file: {0} with parameters k = {1}"
                                        + " gamma = {2} beta = {3} ro = {4} s = {5}",
                                        str, k, gammaParam, betaParam, roParam, sParam);
                    int[] coords;
                    string[] fileLines;
                    fileLines = File.ReadAllLines(str);

                    for (int i = 1; i < fileLines.Length; ++i)
                    {
                        coords = fileLines[i].Split(' ').Select(s => int.Parse(s)).ToArray();
                        readCities.Add(new City(coords[0], coords[1]));
                    }

                    Console.WriteLine("Running file: {0} iterations on {1} population",
                                        iterParam,popParam);
                    State state = new State(k, readCities);
                    state.Iterations = iterParam;
                    state.PopulationSize = popParam;
                    /**
                    Solution sol = new Solution(new List<City> { readCities[0], readCities[2], readCities[1], readCities[3] });
                    Solution best = new Solution(new List<City> { readCities[0], readCities[1], readCities[2], readCities[3] });
                    Console.WriteLine(sol);
                    Console.WriteLine(best);
                    sol.MergeWithBest(best);
                    Console.WriteLine(sol);
                     */
                }
            }
            catch (OptionException e)
            {
                //don't give a fuck
            }
            Console.ReadLine();
        }
    }
}
