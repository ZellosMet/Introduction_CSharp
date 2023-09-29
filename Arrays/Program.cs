#define BASE_ARRAY_CHECK

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{	
	internal class Program
	{
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
			Console.WriteLine("Сумма элементов массива: " + array.Sum());
			Console.WriteLine("Среднее-арифметическое элементов массива: " + ((double)array.Sum()/array.Length));
			Console.WriteLine("Максимальный элемент массива: " + array.Max());
			Console.WriteLine("Минимальный элемент массива: " + array.Min());
			Console.WriteLine(delim);

			//Двумерный массив
			int sum = 0, min = doubl_array[0,0], max = 0;
			Console.WriteLine("Двумерный массив: ");
			for (int i = 0; i < doubl_array.GetLength(0); i++)
			{
				for (int j = 0; j < doubl_array.GetLength(1); j++)
				{ 
					sum += doubl_array[i,j];
					max = doubl_array[i, j] > max ? max = doubl_array[i, j] : max;
					min = doubl_array[i, j] < min ? min = doubl_array[i, j] : min;
				}
			}
			Console.WriteLine("Сумма элементов массива: " + sum);
			Console.WriteLine("Среднее-арифметическое элементов массива: " + ((double)sum/doubl_array.Length));
			Console.WriteLine("Максимальный элемент массива: " + max);
			Console.WriteLine("Минимальный элемент массива: " + min);
			Console.WriteLine(delim);

			//Зубной массив
			int total_amount = 0, item = 0, total_item = 0;
			int[] max_arr = new int[jagget_array.Length]; 
			int[] min_arr = new int[jagget_array.Length]; 
			Console.WriteLine("Зубчатый массив: ");
			for (int i = 0; i < jagget_array.Length; i++)
			{
				for (int j = 0; j < jagget_array[i].Length; j++)
				{
					sum = jagget_array[i].Sum();
					item = jagget_array[i].Length;
					max = jagget_array[i].Max();
					min = jagget_array[i].Min();
				}
				total_amount += sum;
				total_item += item;
				max_arr[i] = max;
				min_arr[i] = min;
			}
			Console.WriteLine("Сумма элементов массива: " + total_amount);
			Console.WriteLine("Среднее-арифметическое элементов массива: " + ((double)total_amount / total_item));
			Console.WriteLine("Максимальный элемент массива: " + max_arr.Max());
			Console.WriteLine("Минимальный элемент массива: " + min_arr.Min());
			Console.WriteLine(delim);
		}
	}
}
