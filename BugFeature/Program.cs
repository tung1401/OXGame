using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFeature
{
    class Program
    {
        public static List<Patch> listPatch = new List<Patch>();
        // public static List<int> Problem = new List<int> { 1, 1, 1 }; //0 - 1
        public static List<int> Problem = new List<int>();
        public static List<int> StateCheck = new List<int>(); //0 - 1
        public static List<Patch> AvailablePatch = new List<Patch>();
        public static List<Patch> queue = new List<Patch>();
        // public static
        public static int doStop = 0;
        public static int Summary = 0;
        static void Main(string[] args)
        {
            Init(); // set up patch and pre-condition
            Process();
        }
        public static void Init()
        {
            Problem = new List<int> { 1, 1, 1 };
            // -1 ignore
            // 0 fixed
            // 1 bug
            var Patch1 = new Patch()
            {
                Index = 1,
                Score = 1,
                Condition = new List<int> { -1, -1, -1 },
                Fixing = new List<int> { -1, -1, 0 },
            };

            var Patch2 = new Patch()
            {
                Index = 2,
                Score = 1,
                Condition = new List<int> { -1, -1, 0 },
                Fixing = new List<int> { -1, 0, 1 },
            };

            var Patch3 = new Patch()
            {
                Index = 3,
                Score = 2,
                Condition = new List<int> { -1, 0, 0 },
                Fixing = new List<int> { 0, 1, 1 },
            };

            listPatch.Add(Patch1);
            listPatch.Add(Patch2);
            listPatch.Add(Patch3);
        }
        public static void Init2()
        {
            // -1 ignore
            // 0 fixed
            // 1 bug

            Problem = new List<int> { 1, 1, 1 ,1};
            var Patch1 = new Patch()
            {
                Index = 1,
                Score = 7,
                Condition = new List<int> { -1, 0, -1, 1 },
                Fixing = new List<int> { -1, -1,-1,-1 },
            };

            listPatch.Add(Patch1);
        }
        public static void Process()
        {
            var doStop = Problem.Count;
            do
            {
                var isStop = SolveBug(listPatch);
                if (isStop)
                {
                    doStop = 0;
                    break;
                }
            }
            while (doStop == 0);
        }
        public static bool SolveBug(List<Patch> listPatch)
        {
            var allPatch = listPatch;
            var availablePatch = FindSolution(allPatch); // find patch which can solve follow pre-condtion
            if (availablePatch.Any())
            {
                //Find best patch by Max Score and Index
                var maxPatch = availablePatch.OrderByDescending(x => x.Score).ThenByDescending(x => x.Index).ToList();
                var bestPatch = maxPatch.FirstOrDefault();

                //Exculte
                Console.WriteLine("- Use Patch: " + bestPatch.Index);
                Console.WriteLine("Before Solve: " + DisplayProblem());
                ExcultePatch(bestPatch);
                Summary += bestPatch.Score;
                Console.WriteLine("After Solve: " + DisplayProblem());
                Console.WriteLine(" ");

                // if not done
                if (Stop() == 0)
                {
                    Console.WriteLine(string.Format("Fastest sequence takes {0} seconds. ", Summary));
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Bugs cannot be fixed.");
                return true;
            }
            availablePatch = new List<Patch>();
            SolveBug(listPatch);
            return false;
        }
        public static int CheckPreCondition(int problem, int condition)
        {
            if (condition == -1 && problem != -1) 
            {
                return 1; //match
            }
            else if (condition == 0 && problem == 0)
            {
                return 1; //match
            }
            else if (condition == 0 && problem == 1)
            {
                return 0; //not match
            }
            return 0; //not match
        }
        public static void ExcultePatch(Patch Patch)
        {
            for (var i = 0; i < Patch.Fixing.Count; i++)
            {
                if (Patch.Fixing[i] == -1)
                {
                    Problem[i] = Problem[i];
                }
                else
                {
                    Problem[i] = Patch.Fixing[i];
                }
            }
            //problem = -1 > problem;
            //codition = 0 >
        }     
      
       
        public static List<Patch> FindSolution(List<Patch> allPatch)
        {
            var availablePatch = new List<Patch>();
            var match = 0;
            for (var indexPatch = 0; indexPatch < allPatch.Count; indexPatch++)
            {
                for (var i = 0; i < Problem.Count; i++)
                {
                    match += CheckPreCondition(Problem[i], listPatch[indexPatch].Condition[i]);
                }
                if (match == 3)
                {
                    availablePatch.Add(listPatch[indexPatch]);
                }
                
                match = 0;
            }
            return availablePatch;
        }
        public class Patch
        {
            public int Index { set; get; }
            public int Score { set; get; }
            public List<int> Condition { set; get; }
            public List<int> Fixing { set; get; }
        }
        
        public static string DisplayProblem()
        {
            var str = string.Empty;
            for(var i = 0; i < Problem.Count; i++)
            {
                str += Problem[i] + " ";
            }
            return str;
        }




        #region OLD Code
        public static int Stop()
        {
            var total = 0;
            for (var i = 0; i < Problem.Count; i++)
            {
                total += Problem[i];

            }
            if (total == 0)
            {
                return 0;
            }
            return Problem.Count;
        }
        public static bool StateAccepted()
        {
            var total = 0;
            for (var i = 0; i < StateCheck.Count; i++)
            {
                total += StateCheck[i];

                if (total == StateCheck.Count)
                {
                    StateCheck = new List<int> { 0, 0, 0 };
                    return true;

                }
            }
            StateCheck = new List<int> { 0, 0, 0 };
            return false;
        }
        public static void Solve()
        {
            //check Patch 1
            var match = 0;
            var stop = listPatch.Count;
            listPatch = listPatch.OrderByDescending(x => x.Score).ToList(); // remove
            StateCheck = new List<int> { 0, 0, 0 };
            while (stop > 0)
            {
                List<MatchScore> Rate = new List<MatchScore>();
                for (var indexPatch = 0; indexPatch < listPatch.Count; indexPatch++)
                {
                    for (var i = 0; i < Problem.Count; i++)
                    {
                        match += CheckPreCondition(Problem[i], listPatch[indexPatch].Condition[i]);
                        StateCheck[i] = match;
                    }

                    if (match == 3)
                    {
                        Console.WriteLine("- Use Patch:" + listPatch[indexPatch].Index + " " + Problem[0] + " " + Problem[1] + " " + Problem[2]);
                        ExcultePatch(listPatch[indexPatch]);
                        Summary += listPatch[indexPatch].Score;
                        Console.WriteLine("After Exculte " + Problem[0] + " " + Problem[1] + " " + Problem[2]);
                        Console.WriteLine("Summary " + Summary);
                        Console.WriteLine(" ");
                    }
                    if (Stop() == 0)
                    {
                        stop = 0;
                        break;
                    }
                    else
                    {
                        match = 0;
                        queue.Add(listPatch[indexPatch]);
                        if (queue.Any())
                        {
                            var check = queue.Where(x => x.Index == indexPatch).ToList();
                            if (check.Count() >= 2)
                            {
                                queue = new List<Patch>();
                                indexPatch += 1;
                            }
                        }

                        if (indexPatch == listPatch.Count - 1)
                        {
                            indexPatch = -1;
                        }
                    }
                }
            }
        }
        public static int Hack(int problem, int condition)
        {
            //Problem filter with Patch and give score
            if (problem == condition)
            {
                return 1;
            }
            else if (condition == -1)
            {
                return 1;
            }
            return 0;

        }
        public class MatchScore
        {
            public int Index { set; get; }
            public int Score { set; get; }
        }
        #endregion

       
      

    }
}