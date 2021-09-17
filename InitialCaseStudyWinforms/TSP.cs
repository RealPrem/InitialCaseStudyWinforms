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

        Random R = new Random(5);

        public List<City> AllCities = new List<City>();

        public List<Path> Paths = new List<Path>();

        public string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public int GenerationNum = 0;
        public TSP(int n)
        {
            NumOfCities = n;
            for (int i = 0; i < n; i += 1)
            {
                string Letter = Alphabet.Substring(i, 1);
                AllCities.Add(new City(R.Next(500), R.Next(500), Letter));
            }
            //Initialized
            GenerateAllPaths();
            CalculateDistance();
            SortByDistance();

            //Evaluation
            //SortByDistance();
            //TournamentSelection(5);
            //Selection
            //SelectionTruncation(50);

            //Mutation
            //crossovercycle(Paths[0], Paths[1]);

            //Paths = CrossOver();
            //SortByDistance();

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
                    string Letter = Alphabet.Substring(R.Next(NumOfCities), 1).ToString();
                    if (Path.Contains(Letter))
                    {
                        i--;
                        continue;
                    }

                    //int SingleNumber = R.Next(0, NumOfCities);
                    //Path = Path + SingleNumber.ToString();
                    Path = Path + Letter;
                }
                if (!AllPossiblePaths.Contains(Path) && Path.Distinct().Count() == NumOfCities)
                {
                    AllPossiblePaths.Add(Path);
                }
            } while (AllPossiblePaths.Count < 100/*Factorial(NumOfCities)*/);

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
                    P.Cities.Add(AllCities.Where(C => C.Name == City).FirstOrDefault());
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
        public void SelectionTruncation(double SelectionPercent)
        {
            int PathsToKeep = Convert.ToInt32((SelectionPercent / 100) * Paths.Count());
            int PathsToKill = Paths.Count() - PathsToKeep;

            for (int i = PathsToKeep; i < Paths.Count(); i += 1)
            {
                Paths[i] = null;
            }
            for (int i = 0; i < PathsToKill; i += 1)
            {
                Paths[i + PathsToKeep] = CopyPath(Paths[i]);
            }
            //Crossover stage   
        }
        public void TournamentSelection(int PathsForTournament)
        {
            List<Path> TournamentPaths = new List<Path>();

            for(int i = 0; i < Paths.Count(); i += 1)
            {
                List<int> ArrayOfIndexs = new List<int>();

                //Getting random path indexes
                for(int x = 0; x < PathsForTournament; x += 1)
                {
                    int RandomIndex = R.Next(0, Paths.Count());
                    ArrayOfIndexs.Add(RandomIndex);
                }
                //Getting best path from random paths
                Path BestPath = Paths[ArrayOfIndexs[0]];
                for (int x = 0; x < ArrayOfIndexs.Count; x += 1)
                {
                    int CurrentIndex = ArrayOfIndexs[x];
                    if (Paths[CurrentIndex].Distance < BestPath.Distance)
                    {
                        BestPath = Paths[CurrentIndex];
                    }
                }
                TournamentPaths.Add(BestPath);
            }
            Paths = TournamentPaths;
        }
        public Path CopyPath(Path PathsToCopy)
        {
            Path NewPath = new Path();
            NewPath.Distance = PathsToCopy.Distance;

            foreach (City C in PathsToCopy.Cities)
            {
                NewPath.Cities.Add(C);
            }

            return NewPath;
        }

        /*
        public Path crossovercycle(Path parentone, Path parenttwo)
        {
            Path childpath = new Path();

            for (int i = 0; i < parentone.Cities.Count; i++)
            {
                childpath.Cities.Add(null);
            }

            childpath.Cities[0] = parentone.Cities[0];
            for (int i = 0; i < parentone.Cities.Count; i++)
            {
                string c2 = parenttwo.Cities[i].Name;

                for (int x = 0; x < parentone.Cities.Count; x++)
                {
                    string c1 = parentone.Cities[x].Name;

                    if (c2 == c1 && !childpath.Cities.Contains(parenttwo.Cities[i]))
                    {
                        childpath.Cities[x] = parenttwo.Cities[i];
                    }
                    else if (c1 == c2 && childpath.Cities.Contains(parenttwo.Cities[i]))
                    {
                        for (int y = 0; y < childpath.Cities.Count; y++)
                        {
                            if (childpath.Cities[y] == null)
                            {
                                childpath.Cities[y] = parenttwo.Cities[y];
                            }
                        }
                    }
                }
            }
            string Cities = "";
            for (int i = 0; i < childpath.Cities.Count; i += 1)
            {
                Cities = Cities + childpath.Cities[i].Name;
            }
            return childpath;
            Console.WriteLine("Hi");
        }
        */
        public Path crossovercycle(Path parentone, Path parenttwo)
        {
            Path childpath = new Path();
            for (int i = 0; i < parentone.Cities.Count; i++)
            {
                childpath.Cities.Add(new City(0, 0, "empty"));
            }
            int r1 = R.Next(NumOfCities);
            childpath.Cities[r1] = copyCity(parentone.Cities[r1]);
            string c2 = parenttwo.Cities[r1].Name;
            int x = r1;
            while (childpath.Cities.Exists(c => c.Name == "empty"))
            {
                int v = parentone.Cities.IndexOf(parentone.Cities.Where(C => C.Name == c2).FirstOrDefault());
                if (childpath.Cities.Exists(c => c.Name == c2))
                {
                    for (int y = 0; y < childpath.Cities.Count; y++)
                    {
                        if (childpath.Cities[y].Name == "empty")
                        {
                            childpath.Cities[y] = copyCity(parenttwo.Cities[y]);
                        }
                    }
                }
                else if (!childpath.Cities.Exists(c => c.Name == c2))
                {
                    childpath.Cities[v] = copyCity(parenttwo.Cities[x]);
                }
                c2 = parenttwo.Cities[v].Name;
                x = v;
            }
            string p0 = string.Join(",", Paths[0].Cities.Select(c => c.Name));
            string p1 = string.Join(",", Paths[1].Cities.Select(c => c.Name));
            string o1 = string.Join(",", childpath.Cities.Select(c => c.Name));
            bool validtour = childpath.Cities.Distinct().Count() == childpath.Cities.Count;
            //   bool haschanged = o1 != p0 && o1 != p1;          
            return childpath;
        }
        public bool IsValidBool(Path Path)
        {
            return Path.Cities.Distinct().Count() == Path.Cities.Count;
        }
        public City copyCity(City CityToCopy)
        {
            City newcity = new City(CityToCopy.X, CityToCopy.Y, CityToCopy.Name);
            return newcity;
        }

        public List<Path> CrossOver()
        {
            /*
            List<Path> ChildrenPaths = new List<Path>();
            ChildrenPaths.Add(Paths[0]);

            for (int i = 0; i < Paths.Count() - 1; i += 1)
            {
                Path ChildPath = crossovercycle(Paths[i], Paths[i+1]);
                CalculateDistance();

                ChildrenPaths.Add(ChildPath);
            }
            return ChildrenPaths;
            */
            List<Path> childrenpaths = new List<Path>();
            childrenpaths.Add(Paths[0]);
            for (int i = 0; i < Paths.Count - 1; i++)
            {
                Path childpath = crossovercycle(Paths[i], Paths[Paths.Count - i - 1]);
                int r1 = R.Next(NumOfCities);
                int r2 = R.Next(NumOfCities);
                City temp = childpath.Cities[r1];
                childpath.Cities[r1] = childpath.Cities[r2];
                childpath.Cities[r2] = temp;
                childpath.calDistance();
                childrenpaths.Add(childpath);

            }
            return childrenpaths;
        }
        public void PerformEvolution()
        {
            while (GenerationNum < 1000)
            {
                //SelectionTruncation(50);
                TournamentSelection(10);
                Paths = CrossOver();
                SortByDistance();
                GenerationNum += 1;
            }
           
        }
        public int GetNumOfGenerations()
        {
            return GenerationNum;
        }
    }
}   
