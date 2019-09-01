using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ConfigConsole {
    class Program {
        static void Main(string[] args) {
            //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            //var time = new DateTime(2019,12,30,12,12,12);
            //Console.WriteLine(time);
            //Console.WriteLine(time.Date);
            //var temp = time.AddMonths(1);
            //Console.WriteLine(new DateTime(temp.Year,temp.Month,1));
            //List<string> a = new List<string>() { "aa" };
            //List<string> b = new List<string>() { "aa", "bb", "cc" };
            //b.ForEach(x =>
            //{
            //    if (x == "bb")
            //    {
            //        return;
            //    }

            //    Console.WriteLine(x);
            //});
            //Console.WriteLine("===========");
            ////var xx = a.Except(b).ToList();

            //var path = $@"E:\TestData\test.xlsx";
            //var table = ExcelHelper.Read(path);
            //foreach (DataRow row in table.Rows)
            //{
            //    Console.WriteLine(row[0]);
            //    Console.WriteLine(row[1]);
            //}

            //var num = decimal.Round(2.5550m, 2, MidpointRounding.AwayFromZero);
            //Console.WriteLine(num);
            //num = decimal.Round(2.5551m, 2, MidpointRounding.AwayFromZero);
            //Console.WriteLine(num);
            //num = decimal.Round(2.555m, 2, MidpointRounding.AwayFromZero);
            //Console.WriteLine(num);
            //num = decimal.Round(2.556m, 2, MidpointRounding.AwayFromZero);
            //Console.WriteLine(num);
            var x = 3 * 39 * (decimal) (1.9 > 0 && 0.55 > 0 ? 1.9 * 0.55 : 1);
            Console.WriteLine(x);
            var xx= decimal.Round(3 * 39 * (decimal)(1.9 > 0 && 0.55 > 0 ? 1.9 * 0.55 : 1), 2, MidpointRounding.AwayFromZero);
            Console.WriteLine(xx);
            //Console.WriteLine(Math.Round(2.5550m,2,MidpointRounding.ToEven));
            //Console.WriteLine(Math.Round(2.5549m,2));
            //Console.WriteLine(Math.Round(2.5551m,2));
            //Console.WriteLine(Math.Round(2.5560m,2));

            Console.WriteLine("a:b");
        }
    }
}
