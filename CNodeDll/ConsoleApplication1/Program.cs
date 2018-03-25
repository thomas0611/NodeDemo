using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Helper().GetAllSites();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Name},{item.PhysicalPath},{item.Address}:{item.Port}");
            }
            Console.ReadKey();
        }
    }
}
