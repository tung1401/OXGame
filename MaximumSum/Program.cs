using System;
using System.Collections.Generic;
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
        static int maxSubArraySum(int[] a, int size)
        {
            int max_so_far = 0, max_ending_here = 0,
               start = 0, end = 0, s = 0;
            int p = 0; int q = 0;
            for (int i = 0; i < size; i++)
            {
                max_ending_here += a[i];

                if (max_so_far < max_ending_here)
                {
                    max_so_far = max_ending_here;
                    start = s;
                    end = i;
                }

                if (max_ending_here < 0)
                {
                    max_ending_here = 0;
                    s = i + 1;
                }
            }
            /* cout << "Maximum contiguous sum is "
                 << max_so_far << endl;
             cout << "Starting index " << start
                 << endl << "Ending index " << end << endl;*/

            return 0;
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
                        if (sum > max)
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
