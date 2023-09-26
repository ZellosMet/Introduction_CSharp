using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
	internal class Program
	{
	static readonly string delim = "\n---------------------------------------------------------\n";
		static void Main(string[] args)
		{
			
			Console.WriteLine("Преобразование числа в денежный формат");
			Console.Write("Введите дробное число -> ");
			string num = Console.ReadLine();
			string[] slicing_num = num.Split('.', ',');
			Console.WriteLine(num + " грн. - это " + slicing_num[0] + " грн. " + ((Convert.ToDouble(slicing_num[1] = "," + slicing_num[1]))*100) + " коп.");
			Console.WriteLine(delim);

			Console.WriteLine("Вычисление стоимости покупки.");
			Console.WriteLine("Введите исходные данные:");
			Console.Write("Цену тетради (грн.) -> ");
			double notebook_price = Convert.ToDouble(Console.ReadLine());
			Console.Write("Количество тетрадей -> ");
			int number_of_notebook = Convert.ToInt32(Console.ReadLine());
			Console.Write("Цену карандаша (грн.) -> ");
			double pencil_price = Convert.ToDouble(Console.ReadLine());
			Console.Write("Количество карандашей -> ");
			int number_of_pencils = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Стоимость покупки: " + ((notebook_price * number_of_notebook) + (pencil_price * number_of_pencils)) + " грн.");
			Console.WriteLine(delim);

			Console.WriteLine("Вычисление стоимости покупки.");
			Console.WriteLine("Введите исходные данные:");
			Console.Write("Цену тетради (грн.) -> ");
			notebook_price = Convert.ToDouble(Console.ReadLine());
			Console.Write("Цену обложки (грн.) -> ");
			double cover_price = Convert.ToDouble(Console.ReadLine());
			Console.Write("Количество комплектов (шт.) -> ");
			int number_of_sets = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Стоимость покупки: " + ((notebook_price + cover_price) * number_of_sets) + " грн.");
			Console.WriteLine(delim);
			

			Console.WriteLine("Вычисление стоимости поездки на дачу и обратно");
			Console.Write("Расстояние до дачи (км) -> ");
			double distance = Convert.ToDouble(Console.ReadLine());
			Console.Write("Расход бензина (литров на 100 км пробега) -> ");
			double consumption = Convert.ToDouble(Console.ReadLine());
			Console.Write("Цена литра бензина (грн.) -> ");
			double oil_price = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Поездка на дачу и обратно обойдётся в " + (consumption/100*distance*oil_price*2) + " грн.");
			Console.WriteLine();
 
		}
	}
}
