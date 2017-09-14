using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFeatureTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Tree
    {
        class Program
        {
            public static List<Logic> listLogic = new List<Logic>();
            public static List<int> Problem = new List<int> { 1, 1, 1 }; //0 - 1
            public static List<int> StateCheck = new List<int> { 0, 0, 0 }; //0 - 1

            // public static

            TreeNode Current = new TreeNode();

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
            class TreeNode
            {
                public Logic Value;
                public TreeNode Left;
                public TreeNode Right;
                public TreeNode Root;
                public int? parent { get; set; }
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
            bool setRoot = false;
            TreeNode constructBalancedTree(List<Logic> values, int min, int max)
            {
                if (min == max)
                    return null;

                int median = min + (max - min) / 2;
                var tree = new TreeNode
                {
                    Value = values[median],
                    Left = constructBalancedTree(values, min, median),
                    Right = constructBalancedTree(values, median + 1, max),
                    parent = values[1].Index
                };
                //if (tree.Root == null) {
                // tree.Root = new TreeNode {
                // Value = values[median],
                // Left = null,
                // Right = null,
                // Root = null
                // };

                //}
                return tree;

            }

            TreeNode constructBalancedTree(IEnumerable<Logic> values)
            {
                return constructBalancedTree(
                values.OrderBy(x => x).ToList(), 0, values.Count());
            }

            void Run()
            {
                Init();
                TreeNode balancedTree = constructBalancedTree(listLogic, 0, 3);

                Current = balancedTree;
                // Current = Current.Left;

                Solve();

                // displayTree(balancedTree);
                // TODO: implement this!
            }

            static void Main(string[] args)
            {
                new Program().Run();
            }

            void FindCurrent()
            {
                if (Current.Left != null)
                {
                    Current = Current.Left;
                }
                else if (Current.Left == null)
                {
                    Current = Current.Right;
                }


            }

            void Solve()
            {
                //check logic 1

                bool use = false;
                var match = 0;
                var stop = 0;
                listLogic = listLogic.OrderByDescending(x => x.Score).ToList();
                StateCheck = new List<int> { 0, 0, 0 };
                do
                {

                    if (Current != null)
                    {
                        for (var i = 0; i < Problem.Count; i++)
                        {
                            match += Deep(Problem[i], listLogic[Current.Value.Index].Condition[i]);
                            StateCheck[i] = match;
                            // hack += Hack(Problem[i], listLogic[indexLogic].Condition[i]);
                            //Rate[indexLogic] = hack;
                        }

                        if (match == 3)
                        {
                            Console.WriteLine("- Use Logic:" + listLogic[Current.Value.Index].Index + " " + Problem[0] + " " + Problem[1] + " " + Problem[2]);
                            ExculteLogic(listLogic[Current.Value.Index]);
                            Summary += listLogic[Current.Value.Index].Score;
                            Console.WriteLine("After Exculte " + Problem[0] + " " + Problem[1] + " " + Problem[2]);
                            Console.WriteLine("Summary " + Summary);
                            // Exculte logic 1
                            // set Problem
                        }

                        match = 0;

                        FindCurrent();
                    }

                    //List<MatchScore> Rate = new List<MatchScore>();
                    //for (var indexLogic = 0; indexLogic < listLogic.Count; indexLogic++)
                    //{
                    // var hack = 0;
                    // /* var MatchScore = new MatchScore{
                    // Index = indexLogic + 1
                    // };*/
                    // for (var i = 0; i < Problem.Count; i++)
                    // {
                    // match += Deep(Problem[i], listLogic[indexLogic].Condition[i]);
                    // StateCheck[i] = match;
                    // // hack += Hack(Problem[i], listLogic[indexLogic].Condition[i]);
                    // //Rate[indexLogic] = hack;
                    // }
                    // // MatchScore.Score = hack;
                    // //if (hack > 0 && StateAccepted())
                    // //{
                    // // Rate.Add(MatchScore);
                    // //}

                    // if (match == 3)
                    // {
                    // Console.WriteLine("- Use Logic:" + listLogic[indexLogic].Index + " " + Problem[0] + " " + Problem[1] + " " + Problem[2]);
                    // ExculteLogic(listLogic[indexLogic]);
                    // Summary += listLogic[indexLogic].Score;
                    // Console.WriteLine("After Exculte " + Problem[0] + " " + Problem[1] + " " + Problem[2]);
                    // Console.WriteLine("Summary " + Summary);
                    // // Exculte logic 1
                    // // set Problem
                    // }

                    // match = 0;

                    // ////check logic 2

                    // ////check logic 3

                    // if (indexLogic == listLogic.Count - 1)
                    // {
                    // indexLogic = -1;
                    // }
                    //}

                    ////var rate = Rate.OrderByDescending(x => x.Score).ThenBy(x => x.Index).ToList();
                    ////var maxRate = rate.FirstOrDefault();
                    ////Console.WriteLine("- Use Logic:" + maxRate.Index + " " + Problem[0] + " " + Problem[1] + " " + Problem[2]);
                    ////ExculteLogic(listLogic[maxRate.Index]);
                    ////Console.WriteLine("After Exculte " + Problem[0] + " " + Problem[1] + " " + Problem[2]);

                    //stop = Stop();

                }
                while (stop == 0);
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

            public static void ExculteLogic(Logic logic)
            {
                for (var i = 0; i < logic.Fixing.Count; i++)
                {
                    if (logic.Fixing[i] == -1)
                    {
                        Problem[i] = Problem[i];
                    }
                    else
                    {
                        Problem[i] = logic.Fixing[i];
                    }
                }
            }
        }
    }
}
