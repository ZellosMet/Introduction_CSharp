//#define LOGICAL_TYPES
//#define CHARACTER_TYPES
//#define INTEGER_TYPES
#define FLOATING_TYPES

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
	internal class Program
	{
		static readonly string delim = "\n-----------------------------------------\n";
		static void Main(string[] args)
		{
#if LOGICAL_TYPES

			Console.Write("bool: ");
			Console.WriteLine(sizeof(bool) + " byte"); //Класс обвёртка Boolean.
			Console.WriteLine(true); //Числовых аналогов нету, либо true, либо false
			Console.WriteLine(true.GetType()); //GetType - возвращает типа переменной
			Console.WriteLine(delim);

#endif

#if CHARACTER_TYPES
			Console.Write("char: ");
			Console.WriteLine(sizeof(char) + " byte"); //char в C# хранит символы в Unicode, а следовательно 2 байта
			Console.WriteLine((int)(char.MinValue));
			Console.WriteLine(delim);
#endif

#if INTEGER_TYPES
			Console.WriteLine("short: ");
			Console.WriteLine(sizeof(short) + " byte");
			Console.WriteLine(short.MinValue);
			Console.WriteLine(short.MaxValue);
			Console.WriteLine(sizeof(ushort) + " byte"); // unsin short
			Console.WriteLine(delim);

			Console.WriteLine("int: ");
			Console.WriteLine(sizeof(int) + " byte");
			Console.WriteLine(int.MinValue);
			Console.WriteLine(int.MaxValue);
			Console.WriteLine(delim);

			Console.WriteLine("long: "); // Аналог LongLong C++
			Console.WriteLine(sizeof(long) + " byte");
			Console.WriteLine(long.MinValue);
			Console.WriteLine(long.MaxValue);
			Console.WriteLine(delim); 
#endif
#if FLOATING_TYPES
			Console.WriteLine("float: "); 
			Console.WriteLine(sizeof(float) + " byte"); // float занимает 4 байта и может хранить 38 знаков после запятой с точностью до 7 знаков
			Console.WriteLine(float.MinValue);
			Console.WriteLine(float.MaxValue);
			Console.WriteLine(delim);

			Console.WriteLine("double: ");
			Console.WriteLine(sizeof(double) + " byte"); // double занимает 8 байта и может хранить 308 знаков после запятой с точностью до 15 знаков
			Console.WriteLine(double.MinValue);
			Console.WriteLine(double.MaxValue);
			Console.WriteLine(delim);

			Console.WriteLine("decimal: ");
			Console.WriteLine(sizeof(decimal) + " byte"); // decimal занимает 16 байта и может хранить 28 знаков после, но обеспечивает максимальную точность дробных чисел.
			Console.WriteLine(decimal.MinValue);
			Console.WriteLine(decimal.MaxValue);
			Console.WriteLine(delim);
#endif
		}
	}
}
