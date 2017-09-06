using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSpan
{
    class Program
    {
        public static int[] dayPrices = new[] { 100, 80, 60, 70, 60, 75, 85 };
        public static int[] corresponding = new[] { 1, 1, 1, 2, 1, 4, 6 };

        // public 

        static string diffString = string.Empty;

        static void Main(string[] args)
        {
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
                   
                    Trades = Trades.OrderBy(c => Guid.NewGuid()).Take(take).ToList();

                    var ListINT = Trades.Select(x => x.Value).ToArray();

                    string maxPrice = "100,80,60,70,60,75,85";

                    var tempPrice = maxPrice.Split(',');
                    var correspondingTemp = new int[ListINT.Length];
                    var intTempPrice = ListINT;//new int[7];
                                               //for (var c = 0; c < tempPrice.Length; c++)
                                               //{
                                               //    intTempPrice[c] = int.Parse(tempPrice[c]);
                                               //}
                    string total = "";
                    var index = 0;
                    var done = false;
                    var startDate = DateTime.Now;
                    while (done == false)
                    {
                        int count = 1;
                        var temp = intTempPrice[index];
                        for (int po = 0; po < index; po++)
                        {
                            if (temp > intTempPrice[po] && po <= index)
                            {
                                count++;
                            }
                        }
                       // total += count + ",";
                       // correspondingTemp[index] = count;
                        if (index == ListINT.Length - 1)
                        {

                            done = true;
                            var endDate = DateTime.Now;
                            var diff = endDate - startDate;
                            Console.WriteLine("Run: " + run + " Take: " + take + " Time: " + diff);
                            take += 10000;
                        }
                        index++;
                    }

                }
                //   tempTime.Add(diff.ToString());
                //   diffString = diff.ToString();

                //   Console.WriteLine(diffString);
                //   }     
                run++;
            }
        }

        public class Trade
        {
            public int Day { set; get; }
            public int Value { set; get; }
        }
    }
}
