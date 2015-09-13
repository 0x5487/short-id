using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortId_Dnx
{
    public class Program
    {
        public void Main(string[] args)
        {
            var id = ShortId.ShortId.New();
            
            Console.WriteLine(id);
            Console.WriteLine("done");
            Console.Read();
        }
    }
}
