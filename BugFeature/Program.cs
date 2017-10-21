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
        public static List<int> Problem = new List<int>();
        public static List<int> StateCheck = new List<int>(); //0 - 1
        public static List<Patch> AvailablePatch = new List<Patch>();
        public static List<Patch> queue = new List<Patch>();
        // public static
        public static int doStop = 0;
        public static int Summary = 0;
        static void Main(string[] args)
        {
            // Init15();
            Init11();
            //Init(); // set up patch and pre-condition
          //  for(var i = 0; i < 2; i++) { 
                Process();
            //}

        }

        public static int useIndex = 0;

        public static void Init1()
        {
            Problem = new List<int> { 1, 1, 1 };
            // -1 ignore
            // 0 fixed
            // 1 bug
            var Patch1 = new Patch()
            {
                Index = 1,
                Score = 1,
                AvailableCount = 4,
                Condition = new List<int> { -1, -1, -1 },
                Fixing = new List<int> { -1, -1, 0 },
            };

            var Patch2 = new Patch()
            {
                Index = 2,
                Score = 1,
                AvailableCount = 2,
                Condition = new List<int> { -1, -1, 0 },
                Fixing = new List<int> { -1, 0, 1 },
            };

            var Patch3 = new Patch()
            {
                Index = 3,
                Score = 2,
                AvailableCount = 1,
                Condition = new List<int> { -1, 0, 0 },
                Fixing = new List<int> { 0, 1, 1 },
            };

            listPatch.Add(Patch1);
            listPatch.Add(Patch2);
            listPatch.Add(Patch3);
        }
        public static void Init11()
        {
            Problem = new List<int> { 1, 1, 1 };
            // -1 ignore
            // 0 fixed
            // 1 bug
            var Patch1 = new Patch()
            {
                Index = 1,
                Score = 1,
                AvailableCount = 3,
                Condition = new List<int> { -1, -1, -1 },
                Fixing = new List<int> { -1, -1, 0 },
            };

            var Patch2 = new Patch()
            {
                Index = 2,
                Score = 1,
                AvailableCount = 2,
                Condition = new List<int> { -1, -1, 0 },
                Fixing = new List<int> { -1, 0, 1 },
            };

            var Patch3 = new Patch()
            {
                Index = 3,
                Score = 2,
                AvailableCount = 1,
                Condition = new List<int> { -1, 0, 0 },
                Fixing = new List<int> { 0, 1, 1 },
            };

            listPatch.Add(Patch1);
            listPatch.Add(Patch2);
            listPatch.Add(Patch3);
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
        public static void Init15()
        {
            // -1 ignore
            // 0 fixed
            // 1 bug
            Problem = new List<int>();
            for (var p = 0; p < 15; p++)
            {
                Problem.Add(1);
            }
            var indexVal = 1;
            listPatch.Add(new Patch()
            {
                Index = 1,
                Score = 10,
                Condition = new List<int> {  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,-1 },
                Fixing = new List<int> {  -1, -1, -1, -1, -1, -1,  -1, -1, -1, -1, -1, -1, -1, -1,0 },
            });
            indexVal++;

            listPatch.Add(new Patch()
            {
                Index = 2,
                Score = 10,
                Condition = new List<int> {  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0 },
                Fixing = new List<int> {  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 1 },
            });
            indexVal++;

            listPatch.Add(new Patch()
            {
                Index = 3,
                Score = 10,
                Condition = new List<int> {  -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,-1, 0 ,0},
                Fixing = new List<int> {   -1, -1, -1, -1, -1, -1,  -1, -1, -1, -1, -1, -1, 0, 1, 1 },
            });
            indexVal++;

            listPatch.Add(new Patch()
            {
                Index = 4,
                Score = 10,
                Condition = new List<int> { -1, -1, -1, -1, -1, -1, -1 -1, -1, -1, -1, -1, -1, 0, 0, 0 },
                Fixing = new List<int> { -1, -1, -1, -1, -1, -1, -1,-1, -1, -1, -1, 0, 1, 1, 1 },
            });
            //indexVal++;

            listPatch.Add(new Patch()
            {
                Index = 5,
                Score = 10,
                Condition = new List<int> { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0 },
                Fixing = new List<int> { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 1, 1, 1, 1 },
            });
            indexVal++;

            listPatch.Add(new Patch()
            {
                Index = 5,
                Score = 10,
                Condition = new List<int> { -1, -1, -1, -1, -1, -1, -1, -1, -1,-1, 0, 0, 0, 0, 0 },
                Fixing = new List<int> { -1, -1, -1, -1, -1, -1, -1,-1, -1, 0, 1, 1, 1, 1, 1 },
            });
            indexVal++;

            listPatch.Add(new Patch()
            {
                Index = 6,
                Score = 10,
                Condition = new List<int> { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,0, 0, 0, 0, 0, 0 },
                Fixing = new List<int> { -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 1,1, 1, 1, 1, 1 },
            });
            indexVal++;

            listPatch.Add(new Patch()
            {
                Index = 7,
                Score = 10,
                Condition = new List<int> { -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0 },
                Fixing = new List<int> { -1,-1, -1, -1, -1, -1, -1, -1, 0, 1, 1, 1, 1, 1 },
            });
            indexVal++;

            listPatch.Add(new Patch()
            {
                Index = 8,
                Score = 10,
                Condition = new List<int> { -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0 },
                Fixing = new List<int> { -1,-1, -1, -1, -1, -1, -1, 0, 1, 1, 1, 1, 1, 1 },
            });
            indexVal++;

            listPatch.Add(new Patch()
            {
                Index = 9,
                Score = 10,
                Condition = new List<int> {  -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0 },
                Fixing = new List<int> { -1,-1, -1, -1, -1, -1, 0, 1, 1, 1, 1, 1, 1, 1 },
            });
            indexVal++;

            listPatch.Add(new Patch()
            {
                Index = 10,
                Score = 10,
                Condition = new List<int> { -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0 },
                Fixing = new List<int> { -1, -1, -1, -1, -1, 0, 1, 1, 1, 1, 1, 1, 1, 1},
            });
            indexVal++;

            listPatch.Add(new Patch()
            {
                Index = 11,
                Score = 10,
                Condition = new List<int> {  -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                Fixing = new List<int> { -1,-1, -1, -1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            });
            indexVal++;

            listPatch.Add(new Patch()
            {
                Index = 12,
                Score = 10,
                Condition = new List<int> { -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                Fixing = new List<int> { -1,-1, -1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            });
            indexVal++;

            listPatch.Add(new Patch()
            {
                Index = 13,
                Score = 10,
                Condition = new List<int> { -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                Fixing = new List<int> { -1,-1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            });
            indexVal++;

            listPatch.Add(new Patch()
            {
                Index = 14,
                Score = 10,
                Condition = new List<int> { -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                Fixing = new List<int> { -1,0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            });
            indexVal++;




            listPatch.Add(new Patch()
            {
                Index = 15,
                Score = 10,
                Condition = new List<int> { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                Fixing = new List<int> { 0, 1,1,1,1,1,1,1,1,1,1,1,1,1 },
            }); 

            /*
            10 000000000000000 00000000000000- 
   10 00000000000000- 0000000000000-+ 
   10 0000000000000-- 000000000000-++ 
   10 000000000000--- 00000000000-+++ 
   10 00000000000---- 0000000000-++++ 
   10 0000000000----- 000000000-+++++ 
   10 000000000------ 00000000-++++++ 
   10 00000000------- 0000000-+++++++ 
   10 0000000-------- 000000-++++++++ 
   10 000000--------- 00000-+++++++++ 
   10 00000---------- 0000-++++++++++ 
   10 0000----------- 000-+++++++++++ 
   10 000------------ 00-++++++++++++ 
   10 00------------- 0-+++++++++++++ 
   10 0-------------- -++++++++++++++  


               */

        }
        public static void Init33()
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
                Fixing = new List<int> { -1, 0, 0 },
            };

            var Patch2 = new Patch()
            {
                Index = 2,
                Score = 3,
                Condition = new List<int> { -1, -1, -1 },
                Fixing = new List<int> { 0, 0, 1 },
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
        public static void Init4()
        {
            Problem = new List<int>();
            for (var p = 0; p < 3; p++)
            {
                Problem.Add(1);
            }
            var indexVal = 0;
            listPatch.Add(new Patch()
            {
                Index = 1,
                Score = 2,
                Condition = new List<int> { 1,-1,-1 },
                Fixing = new List<int> { -1, -1, 0 },
            });
            indexVal++;
            listPatch.Add(new Patch()
            {
                Index = 2,
                Score = 1,
                Condition = new List<int> { -1, -1, 0 },
                Fixing = new List<int> { 1, 0, -1 },
            });
            indexVal++;
            listPatch.Add(new Patch()
            {
                Index = 3,
                Score = 2,
                Condition = new List<int> { -1, 0, 0 },
                Fixing = new List<int> { 0, 1, 1 },
            });
            indexVal++;
            listPatch.Add(new Patch()
            {
                Index = 4,
                Score = 4,
                Condition = new List<int> { 1, -1, -1 },
                Fixing = new List<int> { 0, -1, 0 },
            });
            indexVal++;
        }

        public static List<Patch> Queue = new List<Patch>();
        public static List<int> Before = new List<int>();
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
            var availablePatch = new List<Patch>(); // find patch which can solve follow pre-condtion
            if (Queue.Any())
            {
                availablePatch = Queue;
            }
            else
            {
                availablePatch = FindSolution(allPatch);
            }

            if (availablePatch.Any())
            {
                //Find best patch by Max Score and Index
                var maxPatch = availablePatch.Where(x=>x.Index != useIndex).OrderByDescending(x => x.Score).ThenBy(x => x.Index).ToList(); //.ThenByDesc0000ending(x => x.Index)
                var bestPatch = maxPatch.FirstOrDefault();
      
                // queue keep not use,
                // if can not fix problem, use in q

                //Exculte
                Console.WriteLine("- Use Patch: " + bestPatch.Index);
                Console.WriteLine("Before Solve: " + DisplayProblem());
                ExcultePatch(bestPatch);

                ReducePatch(bestPatch);
                useIndex = bestPatch.Index;
                Summary += bestPatch.Score;
                Console.WriteLine("After Solve: " + DisplayProblem());
                Console.WriteLine(" ");

                if (availablePatch.Count > 1)
                {
                    Queue = availablePatch.Where(x => x.Index != bestPatch.Index).ToList();
                }
                if (availablePatch.Count <= 1)
                {
                    Queue = new List<Patch>();
                }

                
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
            if (condition == -1 && problem != -1 || condition == -1) 
            {
                return 1; //match
            }
            else if (condition == 0 && problem == 0)
            {
                return 1; //match
            }
            else if (condition == 1 && problem == 1)
            {
                return 1; //match
            }
            else if (condition == 0 && problem != 0)
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
            public int AvailableCount  { set; get; } 
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

        public static void ReducePatch(Patch patch)
        {
            var tempPatch = patch;         
            tempPatch.AvailableCount -= 1;
            listPatch.Remove(patch);
            if(tempPatch.AvailableCount > 0) { 
                listPatch.Add(tempPatch);
            }
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