#define BASE_ARRAY_CHECK

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Arrays
{	
	internal class Program
	{
		private static int Sum(int[] array)
		{
			return array.Sum();
		}
		private static int Sum(int[,] array)
		{
			int sum = 0;
			for (int i = 0; i < array.GetLength(0); i++)
				for (int j = 0; j < array.GetLength(1); j++)
					sum += array[i, j];
			return sum;
		}
		private static int Sum(int[][] array)
		{
			int sum = 0, total_amount = 0;
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array[i].Length; j++)
				{
					sum = array[i].Sum();
				}
				total_amount += sum;
			}
			return total_amount;
		}
		private static double AVG(int[] array)
		{

			return (double)array.Sum() / array.Length;
		}
		private static double AVG(int[,] array)
		{
			return (double)Sum(array) / array.Length;
		}
		private static double AVG(int[][] array)
		{
			int items = 0, total_items = 0;
			for (int i = 0; i < array.Length; i++)
				{ 
					for (int j = 0; j < array[i].Length; j++)
						items = array[i].Length;
					total_items += items;
				}
			return (double)Sum(array) / total_items;
		}
		private static int Max(int[] array)
		{ 
			return array.Max();
		}
		private static int Max(int[,] array)
		{
			int	max = 0;
			for (int i = 0; i < array.GetLength(0); i++)
				for (int j = 0; j < array.GetLength(1); j++)
					max = array[i, j] > max ? max = array[i, j] : max;
			return max;
		}
		private static int Max(int[][] array)
		{
			int max = 0;
			int[] max_arr = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array[i].Length; j++)
					max = array[i].Max();
				max_arr[i] = max;
			}
			return max_arr.Max();
		}
		private static int Min(int[] array)
		{
			return array.Min();
		}
		private static int Min(int[,] array)
		{
			int min = array[0,0];
			for (int i = 0; i < array.GetLength(0); i++)
				for (int j = 0; j < array.GetLength(1); j++)
					min = array[i, j] < min ? min = array[i, j] : min;
			return min;
		}
		private static int Min(int[][] array)
		{
			int min = 0;
			int[] min_arr = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array[i].Length; j++)
					min = array[i].Min();
				min_arr[i] = min;
			}
			return min_arr.Min();
		}

		static readonly string delim = "\n-------------------------------------------------------------------------\n";
		static void Main(string[] args)
		{
			Random rand = new Random(0); // Создаётся объект класса Random для генерации случайного числа. В скобках задаётся сид

#if BASE_ARRAY_CHECK

			Console.Write("Введите размер массива -> ");
			int n = Convert.ToInt32(Console.ReadLine());
			int[] array = new int[n];

			for (int i = 0; i < array.Length; i++)
				array[i] = rand.Next(100); // Задание предела для рандома

			for (int i = 0; i < array.Length; i++)
				Console.Write(array[i] + "\t");

			Console.WriteLine();
			foreach (int i in array)
				Console.Write(i + "\t");

			Console.WriteLine(delim);

			Console.Write("Введите количество строк -> ");
			int rows = Convert.ToInt32(Console.ReadLine());
			Console.Write("Введите количество столбцов -> ");
			int cols = Convert.ToInt32(Console.ReadLine());
			int[,] doubl_array = new int[rows, cols];

			for (int i = 0; i < rows; i++)
				for (int j = 0; j < cols; j++)
					doubl_array[i, j] = rand.Next(100);

			for (int i = 0; i < doubl_array.GetLength(0); i++)
			{
				for (int j = 0; j < doubl_array.GetLength(1); j++)
					Console.Write(doubl_array[i, j] + "\t");
				Console.WriteLine();
			}

			Console.WriteLine(delim);

			//Зубчатый массив - это массив массивов
			int[][] jagget_array = new int[][]
				{
					new int[]{ 3,5,8,13,21},
					new int[]{ 34,55,89},
					new int[]{ 144,233,377, 510}
				};

			for (int i = 0; i < jagget_array.Length; i++)
			{
				for (int j = 0; j < jagget_array[i].Length; j++)
					Console.Write(jagget_array[i][j] + "\t");
				Console.WriteLine();
			}

			Console.WriteLine(delim);

			int[][,] jagget_array_2 = new int[][,]
				{
					doubl_array,
					new int[,]
					{
						{ 256, 384, 512, 768 },
						{ 1024, 2048, 3072, 4096 }
					}
				};

			//Вывод зубодробительного массива
			for (int i = 0; i < jagget_array_2.Length; i++)
				for (int j = 0; j < jagget_array_2[i].GetLength(0); j++)
				{
					for (int l = 0; l < jagget_array_2[i].GetLength(1); l++)
						Console.Write(jagget_array_2[i][j, l] + "\t");
					Console.WriteLine();
				}
			Console.WriteLine();
#endif

			//Одномерный массив
			Console.WriteLine("Одномертный массив: ");
			Console.WriteLine("Сумма элементов массива: " + Sum(array));
			Console.WriteLine("Среднее-арифметическое элементов массива: " + AVG(array));
			Console.WriteLine("Максимальный элемент массива: " + Max(array));
			Console.WriteLine("Минимальный элемент массива: " + Min(array));
			Console.WriteLine(delim);

			//Двумерный массив
			Console.WriteLine("Двумерный массив: ");
			Console.WriteLine("Сумма элементов массива: " + Sum(doubl_array));
			Console.WriteLine("Среднее-арифметическое элементов массива: " + AVG(doubl_array));
			Console.WriteLine("Максимальный элемент массива: " + Max(doubl_array));
			Console.WriteLine("Минимальный элемент массива: " + Min(doubl_array));
			Console.WriteLine(delim);

			//Зубной массив
			Console.WriteLine("Зубчатый массив: ");
			Console.WriteLine("Сумма элементов массива: " + Sum(jagget_array));
			Console.WriteLine("Среднее-арифметическое элементов массива: " + AVG(jagget_array));
			Console.WriteLine("Максимальный элемент массива: " + Max(jagget_array));
			Console.WriteLine("Минимальный элемент массива: " + Min(jagget_array));
			Console.WriteLine(delim);
		}
	}
}
