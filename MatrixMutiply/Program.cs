using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMutiply
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] metrix1 = new int[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } };
            int[,] metrix2 = new int[3, 4] { { 1, 1, 1, 1 }, { 1, 2, 3, 4 }, { 2, 3, 4, 5 } };
            int[,] metrix3 = new int[4, 1] { { 1 }, { 1 }, { 2 }, { 3 } };

            var watch12_3 = new Stopwatch();
            watch12_3.Start();
            var subMetrix12 = MultiplyMatrix(metrix1, metrix2);
            var result12_3 = MultiplyMatrix(subMetrix12, metrix3);
            watch12_3.Stop();
            Console.WriteLine("(metrix1 * metrix2) * metrix3 Time: " + watch12_3.Elapsed);

            var watch1_23 = new Stopwatch();
            watch1_23.Start();
            var subMetrix23 = MultiplyMatrix(metrix2, metrix3);
            var result1_23 = MultiplyMatrix(metrix1, subMetrix23);
            watch1_23.Stop();
            Console.WriteLine("metrix1 * (metrix2 * metrix3) Time: " + watch1_23.Elapsed);

        }

        static int[,] MultiplyMatrix(int[,] firstMetrix, int[,] secondMetrix)
        {
            int rA = firstMetrix.GetLength(0);
            int cA = firstMetrix.GetLength(1);
            int rB = secondMetrix.GetLength(0);
            int cB = secondMetrix.GetLength(1);
            int temp = 0;
            int[,] result = new int[rA, cB];
            if (cA != rB)
            {
                Console.WriteLine("matrik can't be multiplied !!");
            }
            else
            {
                for (int i = 0; i < rA; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        temp = 0;
                        for (int k = 0; k < cA; k++)
                        {
                            temp += firstMetrix[i, k] * secondMetrix[k, j];
                        }
                        result[i, j] = temp;
                    }
                }
                return result;
            }
            return null;
        }
    }
}