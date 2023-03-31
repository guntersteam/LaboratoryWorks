using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork1.Models
{
    internal class Color
    {
        public void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public void Blue()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public void Yellow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}


