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
	class Fraction
	{
		/////////////////////////////////////  ПОЛЯ  //////////////////////////////////////////////////////////
		
		int integer;
		int numerator;
		int denominator;
		
		///////////////////////////////////  ГЕТ/СЕТ  ////////////////////////////////////////////////////////		
		int Integer
		{
			get { return integer; }
			set { integer = value; }
		}
		int Numerator
		{
			get { return numerator; }
			set { numerator = value; }
		}
		int Denominator
		{
			get { return denominator; }
			set { denominator = value; }
		}

		////////////////////////////////  КОНСТРУКТОРЫ  ///////////////////////////////////////////////////////

		//Принимают дроби вида:
		//	3;
		//	3/4;
		//	2(3/4);
		//	2 3/4
		//	2,3;
		//	2.3;

		public Fraction(string value)
		{
			string[] s_value;
			if (value.Contains(',') || value.Contains('.'))
			{
				s_value = value.Split('.', ',');
				integer = Convert.ToInt32(s_value[0]);
				numerator = Convert.ToInt32(s_value[1]);
				denominator = 10 * s_value[1].Length;
				Reduce();
			}
			else
			{ 
				s_value = value.Split(' ', '/', '(', ')');
				if (s_value.Length >= 3)
				{
					integer = Convert.ToInt32(s_value[0]);
					numerator = Convert.ToInt32(s_value[1]);
					denominator = Convert.ToInt32(s_value[2]) != 0 ? Convert.ToInt32(s_value[2]) : 1;
				}
				else if (s_value.Length == 2)
				{
					numerator = Convert.ToInt32(s_value[0]);
					denominator = Convert.ToInt32(s_value[1]) != 0 ? Convert.ToInt32(s_value[1]) : 1;
				}
				else if (s_value.Length == 1)
				{
					integer = Convert.ToInt32(s_value[0]);
					denominator = 1;
				}
			}
		}
		Fraction(int integer)
		{
			Integer = integer;
			denominator = 1;
		}
		Fraction(int numerator, int denominator)
		{
			Numerator = numerator;
			Denominator = denominator;
		}
		Fraction(int integer, int numerator, int denominator)
		{
			Integer = integer;
			Numerator = numerator;
			Denominator = denominator;
		}
		Fraction(Fraction value)
		{ 
			integer = value.integer;
			numerator = value.numerator;
			denominator = value.denominator;
		}

		////////////////////////////////  МЕТОДЫ  ///////////////////////////////////////////////////////
		public void Print()
		{
			if(integer != 0 && numerator != 0 && denominator != 0)
				Console.WriteLine($"{integer} ({numerator} / {denominator})");
			else if (numerator == 0 || (numerator == 0 && denominator == 0))
				Console.WriteLine(integer);
			else if(integer == 0)
				Console.WriteLine($"{numerator} / {denominator}");			
		}
		public Fraction ToImproper()
		{
			numerator += integer * denominator;
			integer = 0;
			return this;
		}
		public Fraction ToProper()
		{
			integer += numerator / denominator;
			numerator %= denominator;
			return this;
		}
		Fraction Inverted()
		{
			Fraction inverted = new Fraction(this);
			inverted.ToImproper();
			(inverted.Numerator, inverted.Denominator) = (inverted.Denominator, inverted.Numerator);
			return inverted;
		}
		public Fraction Reduce()
		{
			if (numerator == 0) return this;
			ToProper();
			int less = numerator;
			int more = denominator;
			int rest;
			do
			{
				rest = more % less;
				more = less;
				less = rest;
			} while (rest != 0);
			numerator /= more;
			denominator /= more;
			return this;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////	
		/////////////////////////////////////////  ПЕРЕГРУЗКИ  //////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/////////////////////////////////////////////  ( + )   //////////////////////////////////////////////

		public static Fraction operator+(Fraction lvalue, Fraction rvalue)
		{
			lvalue.ToImproper();
			rvalue.ToImproper();
			Fraction tmp = new Fraction(lvalue.Numerator * rvalue.Denominator + rvalue.Numerator * lvalue.Denominator, lvalue.Denominator * rvalue.Denominator).ToProper().Reduce();
			lvalue.ToProper();
			rvalue.ToProper();
			return tmp;
		}
		public static Fraction operator+(Fraction obj, int value)
		{
			return new Fraction(obj.Integer + value, obj.Numerator, obj.Denominator).ToProper().Reduce();
		}
		public static Fraction operator ++(Fraction obj)
		{
			return new Fraction(obj.Integer++, obj.Numerator, obj.Denominator);
		}

		/////////////////////////////////////////////  ( - )  ///////////////////////////////////////////
		public static Fraction operator-(Fraction lvalue, Fraction rvalue)
		{
			lvalue.ToImproper();
			rvalue.ToImproper();
			Fraction tmp = new Fraction(lvalue.Numerator * rvalue.Denominator - rvalue.Numerator * lvalue.Denominator, lvalue.Denominator * rvalue.Denominator).ToProper().Reduce();
			if (tmp.Numerator < 0) tmp.Numerator *= -1;
			lvalue.ToProper();
			rvalue.ToProper();
			return tmp;
		}
		public static Fraction operator-(Fraction lvalue, int value)
		{
			return new Fraction(lvalue.Integer - value, lvalue.Numerator, lvalue.Denominator).ToProper().Reduce();
		}
		public static Fraction operator--(Fraction obj)
		{
			return new Fraction(obj.Integer--, obj.Numerator, obj.Denominator);
		}
		/////////////////////////////////////////////  ( * )  ///////////////////////////////////////////
		public static Fraction operator*(Fraction lvalue, Fraction rvalue)
		{
			lvalue.ToImproper();
			rvalue.ToImproper();
			Fraction tmp = new Fraction(lvalue.Numerator * rvalue.Numerator, lvalue.Denominator * rvalue.Denominator).ToProper().Reduce();
			lvalue.ToProper();
			rvalue.ToProper();
			return tmp;
		}
		public static Fraction operator*(Fraction obj, int value)
		{
			return obj * new Fraction(value);
		}
		/////////////////////////////////////////////  ( / )  ///////////////////////////////////////////
		public static Fraction operator/(Fraction lvalue, Fraction rvalue)
		{
			lvalue.ToImproper();
			rvalue.ToImproper().Inverted();
			return lvalue + rvalue;
		}
		public static Fraction operator/(Fraction obj, int value)
		{
			return obj / new Fraction(value);
		}

		/////////////////////////////////////////////  ( == / != )  ///////////////////////////////////////////
		public static bool operator ==(Fraction lvalue, Fraction rvalue)
		{
			lvalue.ToImproper();
			rvalue.ToImproper();
			bool tmp = lvalue.Numerator * rvalue.Denominator == rvalue.Numerator * lvalue.Denominator;
			lvalue.ToProper();
			rvalue.ToProper();
			return tmp;
		}		
		public static bool operator !=(Fraction lvalue, Fraction rvalue)
		{
			return !(lvalue.Numerator * rvalue.Denominator == rvalue.Numerator * lvalue.Denominator);
		}

		/////////////////////////////////////////////  ( > / < )  ///////////////////////////////////////////
		public static bool operator >(Fraction lvalue, Fraction rvalue)
		{
			lvalue.ToImproper();
			rvalue.ToImproper();
			bool tmp = lvalue.Numerator * rvalue.Denominator > rvalue.Numerator * lvalue.Denominator;
			lvalue.ToProper();
			rvalue.ToProper();
			return tmp;
		}
		public static bool operator <(Fraction lvalue, Fraction rvalue)
		{
			lvalue.ToImproper();
			rvalue.ToImproper();
			bool tmp = lvalue.Numerator * rvalue.Denominator < rvalue.Numerator * lvalue.Denominator;
			lvalue.ToProper();
			rvalue.ToProper();
			return tmp;
		}

		/////////////////////////////////////////////  ( >= / <=)  ///////////////////////////////////////////
		public static bool operator >=(Fraction lvalue, Fraction rvalue)
		{
			return !(lvalue < rvalue);
		}		
		public static bool operator <=(Fraction lvalue, Fraction rvalue)
		{
			return !(lvalue > rvalue);
		}

		public static explicit operator int(Fraction obj)
		{
			return obj.Integer;
		}
		public static explicit operator double(Fraction obj)
		{
			return obj.Integer+(double)obj.Numerator / obj.Denominator;
		}
}
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = 5;
			Console.Write("Введите значение первой дроби -> "); Fraction fr = new Fraction(Console.ReadLine());
			Console.Write("Введите значение второй дроби -> "); Fraction fr1 = new Fraction(Console.ReadLine());
			Console.Write("Значение первой дроби: "); fr.Print();
			Console.Write("Значение второй дроби: "); fr1.Print();
			Fraction fr2 = fr + fr1;
			Console.Write("Сложение дробей: "); fr2.Print();
			Fraction fr3 = fr - fr1;
			Console.Write("Разность дробей: "); fr3.Print();
			Fraction fr4 = fr1 + n;
			Console.Write("Сложение дроби и переменной: "); fr4.Print();
			fr4++;
			Console.Write("Инкримент дроби: "); fr4.Print();
			Fraction fr5 = fr * fr1;
			Console.Write("Произведение дробей: "); fr5.Print();
			Fraction fr6 = fr * n;
			Console.Write("Произведение дроби и переменной: "); fr6.Print();
			Fraction fr7 = fr / fr1;
			Console.Write("Деление дробей: "); fr7.Print();
			Fraction fr8 = fr / n;
			Console.Write("Деление дроби на переменную: "); fr8.Print();
			Console.Write("Значение первой дроби: "); fr.Print();
			Console.Write("Значение второй дроби: "); fr1.Print();
			Console.WriteLine($"Равенство дробей {fr == fr1}");
			Console.WriteLine($"Первая дроби больше второй {fr > fr1}");
			Console.WriteLine($"Первая дроби меньше или равна второй дробей {fr <= fr1}");
			int i_fr = (int)fr;
			double d_fr = (double)fr1;
			Console.WriteLine($"Преобразование в int первой дроби {i_fr}");
			Console.WriteLine($"Преобразование в double второй дроби {d_fr}");
		}
	}
}
