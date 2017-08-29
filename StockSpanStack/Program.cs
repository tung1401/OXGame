using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSpanStack
{
    class Program
    {
        public static int[] dayPrices = new[] { 100, 80, 60, 70, 60, 75, 85 }; // 1, 1, 1, 2, 1, 4, 6 
        static void Main(string[] args)
        {

            int[] price = { 10, 4, 5, 90, 120, 80 }; //dayPrices;// 
            int n = price.Count();  // /*price.Length*/1
            var S = new int[n];

            int run = 0;
            int dataprocess = 1;
            int take = 50000;

            List<string> tempTime = new List<string>();

            List<Trade> Trades = new List<Trade>();
            var fileName = "c://data.txt";
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    if (!s.Contains("a"))
                    {
                        var tempString = s.ToString().Split(',');
                        var trade = new Trade
                        {
                            Day = int.Parse(tempString[0]),
                            Value = int.Parse(tempString[1])
                        };
                        Trades.Add(trade);
                    }
                }
            }

            while (run < 7)
            {
                take = 50000;
                while (take <= 100000)
                {
                    var startDate = DateTime.Now;
                    Trades = Trades.OrderBy(c => Guid.NewGuid()).Take(take).ToList();
                    var ListINT = Trades.Select(x => x.Value).ToArray();
                    var intTempPrice = ListINT;
                    string total = "";
                    var index = 0;
                    var done = false;
                    var Stock = new int[intTempPrice.Length];
                    while (done == false)
                    {
                        calculateSpan(intTempPrice, intTempPrice.Length, Stock);
                     //   if (index == ListINT.Length - 1)
                     //   {
                            done = true;
                            var endDate = DateTime.Now;
                            var diff = endDate - startDate;
                            Console.WriteLine("Run: " + run + " Take: " + take + " Time: " + diff);
                            take += 10000;
                      //  }
                      //  index++;
                    }
                }
                run++;
            }





            //calculateSpan(price, n, S);
            //printArray(S, n);


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
                while (st.Any() && price[st.LastOrDefault()] <= price[i])
                {
                    st.Remove(st.LastOrDefault());
                }

                // If stack becomes empty, then price[i] is greater than all elements
                // on left of it, i.e., price[0], price[1],..price[i-1].  Else price[i]
                // is greater than elements after top of stack
                S[i] = (!st.Any()) ? (i + 1) : (i - st.LastOrDefault());

                // Push this element to stack
                st.Add(i);
            }
        }
    }
    public class Trade
    {
        public int Day { set; get; }
        public int Value { set; get; }
    }
}
