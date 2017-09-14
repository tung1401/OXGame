using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFeature
{
    class Program
    {
        public static List<Logic> listLogic = new List<Logic>();
        public static List<int> Problem = new List<int> { 1, 1, 1 }; //0 - 1
        public static List<int> StateCheck = new List<int> { 0, 0, 0 }; //0 - 1

        public static List<Logic> queue =  new List<Logic>();
        // public static

        public static int Summary = 0;
        public static void Init()
        {
            // -1 ignore
            // 0 fixed
            // 1 bug
            var logic1 = new Logic()
            {
                Index = 1,
                Score = 1,
                Condition = new List<int> { -1, -1, -1 },
                Fixing = new List<int> { -1, -1, 0 },
            };

            var logic2 = new Logic()
            {
                Index = 2,
                Score = 1,
                Condition = new List<int> { -1, -1, 0 },
                Fixing = new List<int> { -1, 0, 1 },
            };

            var logic3 = new Logic()
            {
                Index = 3,
                Score = 2,
                Condition = new List<int> { -1, 0, 0 },
                Fixing = new List<int> { 0, 1, 1 },
            };

            listLogic.Add(logic1);
            listLogic.Add(logic2);
            listLogic.Add(logic3);
        }
        public static int Deep(int problem, int condition)
        {
            if (condition == -1 && problem != -1 || condition == -1) //problem - condition == 0 ||
            {
                return 1;
            }
            else if (condition == 0 && problem == 0)
            {
                return 1;
            }
            else if (condition == 0 && problem != 0)
            {
                return 0;
            }
            return 0;
        }
        static void Main(string[] args)
        {
            var test21 = Deep(1, -1);
            var test22 = Deep(0, -1);
            var test23 = Deep(0, 0);

            var test31 = Deep(1, -1);
            var test32 = Deep(0, 0);
            var test33 = Deep(0, 0);

            Init();
            Solve();

        }

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
            //check logic 1
            var match = 0;
            var stop = listLogic.Count;
            listLogic = listLogic.OrderByDescending(x => x.Score).ToList();
            StateCheck = new List<int> { 0, 0, 0 };
            while(stop > 0)
            {
                List<MatchScore> Rate = new List<MatchScore>();
                for (var indexLogic = 0; indexLogic < listLogic.Count; indexLogic++)
                {
                    for (var i = 0; i < Problem.Count; i++)
                    {
                        match += Deep(Problem[i], listLogic[indexLogic].Condition[i]);
                        StateCheck[i] = match;
                    }

                    if (match == 3)
                    {
                        Console.WriteLine("- Use Logic:" + listLogic[indexLogic].Index + " " + Problem[0] + " " + Problem[1] + " " + Problem[2]);
                        ExculteLogic(listLogic[indexLogic]);
                        Summary += listLogic[indexLogic].Score;
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
                        queue.Add(listLogic[indexLogic]);
                        if (queue.Any())
                        {
                            var check = queue.Where(x => x.Index == 1).ToList();
                            if (check.Count() >= 2)
                            {
                                queue = new List<Logic>();
                                indexLogic += 1;
                            }
                        }

                        if (indexLogic == listLogic.Count - 1)
                        {
                            indexLogic = -1;
                        }
                    }
                }
            }
        }


        public static int Hack(int problem, int condition)
        {
            //Problem filter with Logic and give score
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
        public static void ExculteLogic(Logic logic)
        {
            for (var i = 0; i < logic.Fixing.Count; i++)
            {

                /* if (logic.Condition[i] == -1)
                {

                }*/
                if (logic.Fixing[i] == -1)
                {
                    Problem[i] = Problem[i];
                }
                else
                {
                    Problem[i] = logic.Fixing[i];
                }
            }
            //problem = -1 > problem;
            //codition = 0 >
        }

        public class MatchScore
        {
            public int Index { set; get; }
            public int Score { set; get; }
        }

        public class Logic
        {
            public int Index { set; get; }
            public int Score { set; get; }
            public List<int> Condition { set; get; }
            public List<int> Fixing { set; get; }
        }
    }
}