using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication61
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the way to file");
            string filePath = Console.ReadLine();
            ParamOfTheDayManager POTDM = new ParamOfTheDayManager(filePath);
            
            Console.WriteLine("Enter the way to the out file");
            string WayOut = Console.ReadLine();
            POTDM.MakeOutFile(WayOut);


        }
    }
}
