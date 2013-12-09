using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<City> readCities = new List<City>();
            int k;
            int[] coords;
            string[] fileLines;
            List<State> states = new List<State>();


            DirectoryInfo di = new DirectoryInfo("basic");
            var files = di.GetFiles("*", SearchOption.TopDirectoryOnly);

            foreach (FileInfo file in files)
            {
                readCities.Clear();

                fileLines = File.ReadAllLines(file.FullName);

                k = int.Parse(fileLines[0]);
                for (int i = 1; i < fileLines.Length; ++i)
                {
                    coords = fileLines[i].Split(' ').Select(s => int.Parse(s)).ToArray();
                    readCities.Add(new City(coords[0], coords[1]));
                }

                states.Add(new State(k, readCities));
            }

            Console.WriteLine(states[0].ToString());


            Console.ReadLine();
        }
    }
}
