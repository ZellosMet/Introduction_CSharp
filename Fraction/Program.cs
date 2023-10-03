using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fraction
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = 5;
			Console.Write("Введите значение первой дроби -> "); Fraction fr = new Fraction(Console.ReadLine());
			Console.Write("Введите значение второй дроби -> "); Fraction fr1 = new Fraction(Console.ReadLine());
			Console.WriteLine("!! Значение первой дроби: " + fr);			
			Console.WriteLine("!! Значение второй дроби: " + fr1);			
			Fraction fr2 = fr + fr1;
			Console.WriteLine("Сложение дробей: " + fr2);
			Fraction fr3 = fr - fr1;
			Console.WriteLine("Разность дробей: " + fr3);
			Fraction fr4 = fr1 + n;
			Console.WriteLine("Сложение дроби и переменной: " + fr4);
			fr4++;
			Console.WriteLine("Инкримент дроби: " + fr4);
			Fraction fr5 = fr * fr1;
			Console.WriteLine("Произведение дробей: " + fr5);
			Fraction fr6 = fr * n;
			Console.WriteLine("Произведение дроби и переменной: " + fr6);
			Fraction fr7 = fr / fr1;
			Console.WriteLine("Деление дробей: " + fr7);
			Fraction fr8 = fr / n;
			Console.WriteLine("Деление дроби на переменную: " + fr8);
			Console.WriteLine($"Равенство дробей {fr == fr1}");
			Console.WriteLine($"Первая дроби больше второй {fr > fr1}");
			Console.WriteLine($"Первая дроби меньше или равна второй дробей {fr <= fr1}");
			int i_fr = (int)fr;
			double d_fr = (double)fr1;
			Console.WriteLine($"Преобразование в int первой дроби {i_fr}");
			Console.WriteLine($"Преобразование в double второй дроби {d_fr}");
			Console.WriteLine("!! Значение первой дроби: " + fr);
			Console.WriteLine("!! Значение второй дроби: " + fr1);
			Fraction fr9 = new Fraction(2.5);
			Console.WriteLine($"Преобразование десятичной дроби в обыкновенную: {fr9}");
		}
	}
}
