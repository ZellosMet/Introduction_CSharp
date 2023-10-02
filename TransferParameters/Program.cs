using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferParameters
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int a = 2, b= 3;
			Input(out a, out b);
			Console.WriteLine($"{a} \t {b}");
			Exchange(ref a, ref b);
			Console.WriteLine($"{a} \t {b}");
		}
		static void Input(out int a, out int b)
		{
			Console.WriteLine("Введите первое число: "); a = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите второе число: "); b = Convert.ToInt32(Console.ReadLine());
		}
		static void Exchange(ref int a, ref int b)
		{
			int buffer = a;
			a = b;
			b = buffer;
		}
	}
}
