using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortId
{
    class Program
    {
        static void Main(string[] args)
        {

            var id = ShortId.New();

            //Console.WriteLine(id);

            //Stopwatch time = new Stopwatch();
            //time.Start();
            //HashSet<string> keys = new HashSet<string>();
            //for (int i = 0; i < 1000000000; i++)
            //{
            //    keys.Add(ShortId.New());
            //}
            //time.Stop();
            //Console.WriteLine(time.Elapsed);
            Console.WriteLine(id);
            Console.WriteLine("done");
            Console.Read();

        }
    }
}
