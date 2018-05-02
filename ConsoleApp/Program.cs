using OrderProject.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new HairController().Create(new OrderProject.Model.Hair
            {
                Width = 1,
                X1 = 1,
                X2 = 2,
                Y1 = 3,
                Y2 = 4,
            });
            Console.WriteLine("end");
            Console.ReadLine();
        }
    }
}
