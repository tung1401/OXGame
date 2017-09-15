using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JollyJumper
{
    class Program
    {
        public static List<int> result = new List<int>();
        static void Main(string[] args)
        {
            var list = new List<int> {1,4,2,3};
            var msg2 = JollyJumper(list);
          //  var msg = CheckJumper();

        }

        public static string JollyJumper(List<int> list)
        {
            var i = 1;
            List<int> temp = list;
            foreach (var item in list)
            {              
                if (list.Any() && i < list.Count)
                {
                    var total = Math.Abs(item - temp.Skip(i).FirstOrDefault());     
                    if (result.Count > 1)
                    {
                        if (result.LastOrDefault() - total != 1)
                        {
                            return "not Jolly";
                        }
                    }
                    result.Add(total);
                }
                i++;
            }
            return " Jolly";
        }

        //public static string CheckJumper()
        //{
        //    for (int i = 1; i < data.length - 1; i++)
        //    {
        //        int diff = Math.abs(Integer.parseInt(data[i]) - Integer.parseInt(data[i + 1]));
        //        if (diff < 1 || diff >= numberOfInputs || bitSet.get(diff))
        //        {
        //            System.out.println("Not Jolly");
        //            isJolly = false;
        //            break;
        //        }
        //        bitSet.set(diff);
        //    }
        //    if (isJolly)
        //    {
        //        System.out.println("Jolly");
        //    }
        //}

    }
}
