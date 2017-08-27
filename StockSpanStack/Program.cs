using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSpanStack
{
    class Program
    {
        public static int[] dayPrices = new[] { 100, 80, 60, 70, 60, 75, 85 };
        static void Main(string[] args)
        {
            string total = "";
            var index = 0;
            var done = false;
            int[] price = { 10, 4, 5, 90, 120, 80 };
            int n = price.Count();  // /*price.Length*/1
            var S =  new int[n];


            calculateSpan(price, n, S);
            printArray(S, n);


        }

        static void printArray(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i] + " ");
            }
            //1 1 2 4 5 1
        }
        public static void calculateSpan(int[] price, int n, int[] S)
        {
            // Create a stack and push index of first element to it
            List<int> st = new List<int>();
            st.Add(0);

            // Span value of first element is always 1
            S[0] = 1;

            // Calculate span values for rest of the elements
            for (int i = 1; i < n; i++)
            {
                // Pop elements from stack while stack is not empty and top of
                // stack is smaller than price[i]
                while (st.Any() && price[st.FirstOrDefault()] <= price[i])
                {
                    st.Remove(st.FirstOrDefault());
                }

                // If stack becomes empty, then price[i] is greater than all elements
                // on left of it, i.e., price[0], price[1],..price[i-1].  Else price[i]
                // is greater than elements after top of stack
                S[i] = (!st.Any()) ? (i + 1) : (i - st.FirstOrDefault());

                // Push this element to stack
                st.Add(i);
            }
        }
    }
}
