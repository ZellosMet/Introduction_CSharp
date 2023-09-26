using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите выражение: "); 
            string exampel = Console.ReadLine();
            string[] slicing = exampel.Split(' ');
            double lvalue = Convert.ToDouble(slicing[0]);
            double rvalue = Convert.ToDouble(slicing[2]);

            switch (slicing[1])
            {
                case "+":
                Console.WriteLine(exampel + " = " + (lvalue + rvalue));                    
                break; 
                
                case "-":
                Console.WriteLine(exampel + " = " + (lvalue - rvalue));                    
                break;

				case "*":
				Console.WriteLine(exampel + " = " + (lvalue * rvalue));
				break;

				case "/":
				Console.WriteLine(exampel + " = " + (lvalue / rvalue));
				break;
			}
        }
    }
}
