using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixAverage
{
    class Program
    {

        public static int[] list = new int[] { 2, 3, 5, 4, 2 };
        public static int[] listDouble1 = new int[] { 2, 3, 5, 4, 2 };

        public static decimal[] result = new decimal[5];


        public static double[] List100 = new double[100];
        public static int[] listint1000 = new int[1000];

        public static int[] listint50000 = new int[50000];
        public static int[] listint60000 = new int[60000];
        public static int[] listint70000 = new int[70000];
        public static int[] listint80000 = new int[80000];
        public static int[] listint90000 = new int[90000];
        public static int[] listint100000 = new int[100000];



        static void Main(string[] args)
        {

            List<int> Scores = new List<int> { 5, 4, 3, 2, 1 };

            Scores =  Rank(6, Scores);

            Scores = Rank(3, Scores);

            Scores = Rank(2, Scores);

            var num = 50000; var loop = 6;

            //for (int i = 0; i < 50000; i++)
            //{
            //    var ran50000 = new Random();
            //    listint50000[i] = ran50000.Next(0, 50000);
            //}
            for (int index = 0; index < loop; index++)
            {

               


                int[] list = new int[num];
                for (int i = 0; i < num; i++)
                {
                    var ran = new Random();
                    list[i] = ran.Next(0, num);
                }

                for (int j = 0; j < 5; j++)
                {
                    var startDate1 = DateTime.Now;

                    prefixAverage1(list);
                    var endDate1 = DateTime.Now;

                    var diff1 = endDate1 - startDate1;
                    Console.WriteLine(num + " " + diff1);


                    var startDate2 = DateTime.Now;

                    prefixAverage2(list);
                    var endDate2 = DateTime.Now;

                    var diff2 = endDate2 - startDate2;
                    Console.WriteLine(num + " " + diff2);
                }


                num = num + (10000);
            }



        }

        public static void Prove()
        {
            for (var i = 0; i < list.Count(); i++)
            {
                result[i] = Value(i + 1);
            }
        }

        public static decimal Value(int size)
        {
            int total = 0;
            for (var i = 0; i < size; i++)
            {
                total += list[i];
            }
            return total / (decimal)size;
        }



        public static int[] prefixAverage1(int[] x)
        {
            int n = x.Length;
            int[] a = new int[n]; // filled with zeros by default
            for (int j = 0; j < n; j++)
            {
                int total = 0; // begin computing x[0] + ... + x[j]
                for (int i = 0; i <= j; i++)
                    total += x[i];
                a[j] = total / (j + 1); // record the average
            }
            return a;
        }

        public static int[] prefixAverage2(int[] x)
        {
            int n = x.Length;
            int[] a = new int[n]; // filled with zeros by default
            int total = 0; // compute prefix sum as x[0] + x[1] + ...
            for (int j = 0; j < n; j++)
            {
                total += x[j]; // update prefix sum to include x[j]
                a[j] = total / (j + 1); // compute average based on current sum
            }
            return a;
        }


        public static List<int> Rank(int newScore, List<int> Scores)
        {
            Scores =  Scores.OrderBy(x => x).ToList();
            for (int i = 0; i < Scores.Count; i++)
            {
                if(Scores[i] < newScore)
                {
                    Scores.RemoveAt(i);
                    Scores.Add(newScore);
                    break;
                }
            }

            Scores = Scores.OrderByDescending(x=>x).ToList();

            return Scores;
        }

    }
}
