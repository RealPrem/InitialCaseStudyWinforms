using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialCaseStudyWinforms
{
    public class TSP
    {
        public int NumOfCities;

        Random R = new Random(1);

        public List<City> AllCities = new List<City>();

        public List<Path> Paths = new List<Path>();

        public string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public TSP(int n)
        {
            NumOfCities = n;
            for (int i = 0; i < n; i += 1)
            {
                string Letter = Alphabet.Substring(i, 1);
                AllCities.Add(new City(R.Next(500), R.Next(500), Letter));
            }
            GenerateAllPaths();
            CalculateDistance();
            SortByDistance();
            Console.WriteLine("Hi");
        }
        public void GenerateAllPaths()
        {
            List<string> AllPossiblePaths = new List<string>();

            do
            {
                string Path = "";
                for (int i = 0; i < NumOfCities; i += 1)
                {
                    int SingleNumber = R.Next(0, NumOfCities);
                    Path = Path + SingleNumber.ToString();
                }
                int Z = Path.Distinct().Count();
                if (!AllPossiblePaths.Contains(Path) && Path.Distinct().Count() == NumOfCities)
                {
                    AllPossiblePaths.Add(Path);
                }
            } while (AllPossiblePaths.Count < 100/*Factorial(NumOfCities)*/);
         
            int X = (AllPossiblePaths.Count);
            AllPossiblePaths.Sort();
            BuildPaths(AllPossiblePaths);
        }
        public int Factorial(int Number)
        {
            int fact = 1;
            for (int i = 1; i <= Number; i++)
            {
                fact = fact * i;
            }
            return fact;
        }
        public void BuildPaths(List<string> AllPossibllePaths)
        {
            foreach (string Path in AllPossibllePaths)
            {
                Path P = new Path();
                P.Distance = 0;
                for (int i = 0; i < NumOfCities; i += 1)
                {
                    string City = Path.Substring(i, 1);
                    P.Cities.Add(AllCities.Where(C => C.Name == Alphabet.Substring(Convert.ToInt32(City), 1)).FirstOrDefault());
                }
                Paths.Add(P);
            }
        }
        public void CalculateDistance()
        {
            foreach (var Path in Paths)
            {
                for (int i = 0; i < Path.Cities.Count - 1; i += 1)
                {
                    double HorizontalDistance = Path.Cities[i].X - Path.Cities[i + 1].X;
                    double VerticalDistance = Path.Cities[i].Y - Path.Cities[i + 1].Y;
                    Path.Distance = Path.Distance + Math.Sqrt((Math.Pow(HorizontalDistance, 2) + Math.Pow(VerticalDistance, 2)));
                }
            }
        }
        public void SortByDistance()
        {
            bool Sorted = false;
            while (Sorted == false)
            {
                Sorted = true;
                for (int i = 0; i < Paths.Count - 1; i += 1)
                {
                    if (Paths[i].Distance > Paths[i + 1].Distance)
                    {
                        var Temp = Paths[i];
                        Paths[i] = Paths[i + 1];
                        Paths[i + 1] = Temp;
                        Sorted = false;
                    }
                }
            }
        }
    }
}
