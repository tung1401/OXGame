using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSum
{
    class Program
    {
        public static int[] array1 = new[] {  -2, 100, -3, 4 };
        public static int[] array2 = new[] {  3, 2, -1, 4,5 };
        public static int[] array3 = new[] {  -1, -2, -3 };
        public static int[] array4 = new[] {  -1, 2, -3 };
        public static int[] array5 = new[] {  3, -4, -1, 4, 5 };

        static void Main(string[] args)
        {
          //  List<Trade> Trades = new List<Trade>();
            var fileName = "c://mcs_test.in.txt";

            List<int> list = new List<int>();
            string result = string.Empty;
            var first = true;
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    if(s != "__" && s != "****")
                    {                      
                        if(first)
                        {
                            first = false;                     
                        }
                        else
                        {
                            list.Add(int.Parse(s));
                        }                  
                    }
                    else
                    {
                        var range = MaximumSum(list.ToArray());
                        result += range + ", ";
                        list = new List<int>();
                         first = true;
                    }
                }
            }

            Console.WriteLine(result);


            // var test = maxSubArraySum(array1);
            Console.WriteLine("** Input size array (n) **");
            var size = int.Parse(Console.ReadLine());
            if (size > 0)
            {
                var array = new int[size];
                int amount = 0;
                Console.WriteLine("\nInput data in array size (" + size + ")");
                do
                {               
                    var data = int.Parse(Console.ReadLine());
                    array[amount] = data;
                    amount++;
                }
                while (amount < size);
                Console.WriteLine("__");
                var range = MaximumSum(array);
                Console.WriteLine("\nMaximum Sum by range between " + range +"");
            }
        }
        static string maxSubArraySum(int[] a)
        {
            int max_so_far = 0, max_ending_here = 0,
               start = 0, end = 0, s = 0;
            int p = 0; int q = 0;
            for (int i = 0; i < a.Length; i++)
            {
                max_ending_here += a[i];
                if (max_so_far < max_ending_here)
                {
                    max_so_far = max_ending_here;
                    start = s;
                    end = i;
                    p = start;
                    q = end;
                }
                if (max_ending_here < 0)
                {
                    max_ending_here = 0;
                    s = i + 1;
                }
            }
            return string.Format("{0} {1}",p,q);
        }
        static string MaximumSum(int[] array)  
        {
            int p = 0; int q = 0;
            int max = 0;
            for (int start = 0; start < array.Length; start++)	
            {
                int sum = 0;
                for (int cursor = 0; cursor < array.Length - start; cursor++) // move unitll last index
                {
                    var current = start + cursor; //current position 
                    if (current < array.Length)
                    {
                        sum += array[current];
                        if (sum >= max)
                        {
                            max = sum;
                            p = start;
                            q = current;
                        }
                    }
                }
            }
            return string.Format("{0} {1}",p,q);
        }
    }
}
