using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonSoft
{
    class Program
    {
        static void Main(string[] args)
        {

            var id = ShortId.New();
            Console.WriteLine(id);

            Stopwatch time = new Stopwatch();
            time.Start();
            HashSet<string> keys = new HashSet<string>();
            for (int i = 0; i < 10000000; i++)
            {
                if (!keys.Add(ShortId.New()))
                    throw new Exception("duplicate");


            }
            time.Stop();
            Console.WriteLine(time.Elapsed);
            Console.WriteLine("done");

            Console.Read();

        }
    }
}
