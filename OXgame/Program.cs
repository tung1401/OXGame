using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OXgame
{
    class Program
    {
        public static string[] top5Score = { "?$-0", "?$-0", "?$-0", "?$-0", "?$-0" };//{ "A-2", "V-9", "?-0", "C-100", "?-0" }; //     
        public static int[] scores = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        // set o = 1
        // set x = 2
        public static bool play = true;
        public static bool playAgain = false;
        public static bool done = false;
        //positionX,Y, Score
        public static int[,] array3D = new int[3, 3];
        public static int[,] score3D = new int[3, 3];


        public static string firstUser = "o";
        public static string secondUser = "x";
        public static int turn = 0;
        public static int total = 0;


        //{ { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } } };
        // { { { 0, 0, 0 }, { 0, 0, 0 } }, { { 0, 0, 0 }, { 0, 0, 0 } } };
        static void Main(string[] args)
        {
            OrderTopScoreDesc();
            StartGame();     
        }


        static void StartGame()
        {
            while (play == true || playAgain == true)
            {
                Init();
                if (done)
                {
                    PlayAgain();
                }

                while (done == false)
                {
                    var move = string.Empty;
                    var user = firstUser;
                    var value = firstUser == "o" ? 1 : 2;
                    if (turn % 2 != 0)
                    {
                        user = secondUser;
                        value = secondUser == "o" ? 1 : 2;
                    }

                    bool inputValid = false;
                    do
                    {
                        Console.Write("{0}(A) :", user);
                        move = Console.ReadLine();
                        inputValid = CheckMoveValid(move);
                        if (!inputValid)
                        {
                            Console.WriteLine("Invalid move to position {0}, please choose again!", move);
                        }
                    }
                    while (!inputValid);

                    UpdateBoard(move, user);
                    Console.Clear();
                    DrawBoard();

                    if (play == true)
                    {
                        turn++;
                    }
                    var valid = Win(value);
                    if (valid == "o")
                    {
                        Console.WriteLine("Result: o Won with " + total + "points \n");
                        Score(total);
                        playAgain = PlayAgain();
                        done = true;
                    }
                    else if (valid == "x")
                    {
                        Console.WriteLine("Result: x Won with " + total + " points \n");
                        Score(total);
                        playAgain = PlayAgain();
                        done = true;
                    }
                    else if (valid == "d")
                    {
                        Console.WriteLine("DRAW!!! \n");
                        playAgain = PlayAgain();
                        done = true;
                    }

                    if (playAgain == true)
                    {
                        turn = 0;
                    }

                }
            }
        }

        public static bool CheckMoveValid(string value)
        {
            //check 1 - 9
            var continueCheckDigit = false;
            for (var index = 1; index <= array3D.Length; index++)
            {
                if (index.ToString() == value)
                {
                    continueCheckDigit = true;
                }
            }
            if (!continueCheckDigit)
            {
                return false;
            }
            //check not duplicate 1-9
            if (continueCheckDigit)
            {
                var v = ReturnValueInArray(value);
                if (v > 0)
                {
                    return false;
                }
            }
            return true;   
        }

        public static void Score(int total)
        {
            //find min score
            var last = top5Score[top5Score.Length - 1];
           
                var splitScore = last.Split('-');
                if (splitScore[1] != null)
                {
                    if (total > int.Parse(splitScore[1]))
                    {
                        Console.WriteLine("Congraturation!!! Your score are in top 5 player");
                        Console.Write("Input your name: ");
                        var name = Console.ReadLine();
                        top5Score[top5Score.Length - 1] = name + "-" + total;
                    }
                }
            
            OrderTopScoreDesc();
            DisplayTop5Score();
        }

        public static void DisplayTop5Score()
        {
            Console.WriteLine("-----------------------------------------------------------------------------");
            for (var index = 0; index < top5Score.Length; index++)
            {
                var splitUser = top5Score[index].Split('-');
                if (splitUser[0] != "?$")
                {
                    Console.WriteLine("No {0}. {1} Score {2} points", index + 1, splitUser[0], splitUser[1]);
                }
            }
            Console.WriteLine("-----------------------------------------------------------------------------");
        }


        public static void OrderTopScoreDesc()
        {
            if (top5Score.Length > 0)
            {
                for (var i = 0; i < top5Score.Length; i++)
                {
                    for (var j = i + 1; j < top5Score.Length; j++)
                    {
                        var temp1 = top5Score[i];
                        var temp2 = top5Score[j];
                        if (temp1 != null)
                        {
                            var slp = top5Score[i].Split('-');
                            var slp2 = top5Score[j].Split('-');
                            if (int.Parse(slp2[1]) > int.Parse(slp[1]))
                            {
                                top5Score[i] = temp2;
                                top5Score[j] = temp1;
                            }
                        }
                    }
                }
            }
        }

        static void Init()
        {
            turn = 0;
            InitBoard();
            RandomScore();
            score3D = new int[3, 3];
            int index = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    score3D[x, y] = scores[index];
                    index++;
                }
            }
        }


        static void RandomScore()
        {
            scores = scores.OrderBy(n => Guid.NewGuid()).ToArray();
        }

        static void InitBoard()
        {
            Console.WriteLine("** Tic Tac Toe: Aj. Chang **\n");
            array3D = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\t| 0 | 0 | 0 |");
                if (i < 2)
                {
                    Console.WriteLine("\t----+---+----");
                }
            }
            Console.WriteLine("");
        }

        static void DrawBoard()
        {
            Console.WriteLine("** Tic Tac Toe: Aj. Chang **\n");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\t| " + (!string.IsNullOrEmpty(WriteOX(i, 0)) ? WriteOX(i, 0) : " ") +
                    " | " + (!string.IsNullOrEmpty(WriteOX(i, 1)) ? WriteOX(i, 1) : " ") +
                    " | " + (!string.IsNullOrEmpty(WriteOX(i, 2)) ? WriteOX(i, 2) : " ") + " |");
                if (i < 2)
                {
                    Console.WriteLine("\t----+---+----");
                }
            }
            Console.WriteLine("");
        }

        static string WriteOX(int x, int y)
        {
            if (array3D[x, y] == 1)
            {
                return "o";
            }
            else if (array3D[x, y] == 2)
            {
                return "x";
            }
            return string.Empty;
        }


        static bool PlayAgain()
        {
            // ask for play again
            Console.WriteLine("Do you want to play again (y/n)?");
            var isExit = Console.ReadLine();
            if (isExit.ToLower().Equals("y"))
            {
                play = true;
                // ask for o or x first player
                bool askPlayer = false;
                while (askPlayer == false)
                {
                    Console.Clear();
                    Console.WriteLine("Who want to be first player (o/x)?");
                    var firstPlayer = Console.ReadLine();
                    if (firstPlayer.ToLower().Equals("o"))
                    {
                        askPlayer = true;
                        firstUser = "o";
                        secondUser = "x";
                        Console.Clear();
                        StartGame();
                    }
                    else if (firstPlayer.ToLower().Equals("x"))
                    {
                        askPlayer = true;
                        firstUser = "x";
                        secondUser = "o";
                        Console.Clear();
                        StartGame();
                    }
                    else if (firstPlayer.ToLower().Equals("n"))
                    {
                        askPlayer = true;
                        play = false;
                    }
                }
            }
            else if (isExit.ToLower().Equals("n"))
            {
                play = false;
            }
            return play;
        }

        static void UpdateBoard(string move, string user)
        {
            int x = 0, y = 0;
            for (int position = 1; position <= 9; position++)
            {
                if (move == position.ToString())
                {
                    array3D[x, y] = user == "o" ? 1 : 2;
                }
                y++;
                if (position % 3 == 0)
                {
                    x += 1;
                    y = 0;
                }
            }
        }

        static string Win(int value)
        {
            if (array3D[0, 0] == value && array3D[0, 1] == value && array3D[0, 2] == value)
            {
                total = 0;
                total = scores[0] + scores[1] + scores[2];
                return value == 1 ? "o" : "x";
            }

            if (turn == 9)
            {
                return "d";
            }
            return string.Empty;
        }

        public static int ReturnValueInArray(string value)
        {
            int x = 0, y = 0;
            for (int position = 1; position <= 9; position++)
            {
                if (value == position.ToString())
                {
                    return array3D[x, y];
                }
                y++;
                if (position % 3 == 0)
                {
                    x += 1;
                    y = 0;
                }
            }
            return 0;
        }
    }
}
