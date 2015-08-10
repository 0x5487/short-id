using System;
using System.Collections.Generic;
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

            Console.WriteLine(id);

            //HashSet<string> keys = new HashSet<string>();
            //for (int i = 0; i < 10; i++)
            //{
            //    keys.Add(ShortId.New());
            //}


            Console.WriteLine("done");
            Console.Read();

        }
    }
}
