﻿using System;
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
		public Fraction(int integer)
		{
			Integer = integer;
			denominator = 1;
		}
		public Fraction(int numerator, int denominator)
		{
			Numerator = numerator;
			Denominator = denominator;
		}
		public Fraction(int integer, int numerator, int denominator)
		{
			Integer = integer;
			Numerator = numerator;
			Denominator = denominator;
		}
		public Fraction(Fraction value)
		{ 
			this.integer = value.integer;
			this.numerator = value.numerator;
			this.denominator = value.denominator;
			Console.WriteLine(" <<<< Конструктор копирования >>>> ");
		}
		public Fraction(double value)
		{
			double precision = 5;
			Integer = (int)value;
			Numerator = Convert.ToInt32((value - (double)Integer) * Math.Pow((double)10, precision));
			Denominator = Convert.ToInt32(Math.Pow((double)10, precision));
			Reduce();
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
		//////////////////////////////  ПЕРЕГРУЗКА CONSOLE.WRITELINE()  ///////////////////////////////////////////////////////
		public override string ToString()
		{			
			string output = "";
			if (integer !=0) output += integer.ToString();
			if (numerator != 0)
			{
				if (integer != 0) output += " (";
				output += $"{numerator} / {denominator}";
				if (integer != 0) output += ")";
			}
			else if (integer == 0) output = "0";
			return output;
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////	
		/////////////////////////////////////////  ПЕРЕГРУЗКИ  //////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/////////////////////////////////////////////  ( + )   //////////////////////////////////////////////

		public static Fraction operator+(Fraction lvalue, Fraction rvalue)
		{
			Fraction ltmp = new Fraction(lvalue);
			Fraction rtmp = new Fraction(rvalue);
			ltmp.ToImproper();
			rtmp.ToImproper();
			return new Fraction(ltmp.Numerator * rtmp.Denominator + rtmp.Numerator * ltmp.Denominator, ltmp.Denominator * rtmp.Denominator).ToProper().Reduce();
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
			Fraction ltmp = new Fraction(lvalue);
			Fraction rtmp = new Fraction(rvalue);
			ltmp.ToImproper();
			rtmp.ToImproper();			
			Fraction tmp = new Fraction(ltmp.Numerator * rtmp.Denominator - rtmp.Numerator * ltmp.Denominator, ltmp.Denominator * rtmp.Denominator).ToProper().Reduce();
			if (tmp.Numerator < 0) tmp.Numerator *= -1;
			if (tmp.Denominator < 0) tmp.Denominator *= -1;
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
			Fraction ltmp = new Fraction(lvalue);
			Fraction rtmp = new Fraction(rvalue);
			ltmp.ToImproper();
			rtmp.ToImproper();
			return new Fraction(ltmp.Numerator * rtmp.Numerator, ltmp.Denominator * rtmp.Denominator).ToProper().Reduce();
		}
		public static Fraction operator*(Fraction obj, int value)
		{
			return obj * new Fraction(value);
		}
		/////////////////////////////////////////////  ( / )  ///////////////////////////////////////////
		public static Fraction operator/(Fraction lvalue, Fraction rvalue)
		{
			Fraction ltmp = new Fraction(lvalue);
			Fraction rtmp = new Fraction(rvalue);
			ltmp.ToImproper();
			rtmp.ToImproper().Inverted();
			return lvalue * rvalue;
		}
		public static Fraction operator/(Fraction obj, int value)
		{
			return obj / new Fraction(value);
		}

		/////////////////////////////////////////////  ( == / != )  ///////////////////////////////////////////
		public static bool operator ==(Fraction lvalue, Fraction rvalue)
		{
			Fraction ltmp = new Fraction(lvalue);
			Fraction rtmp = new Fraction(rvalue);
			ltmp.ToImproper();
			rtmp.ToImproper();
			return ltmp.Numerator * rtmp.Denominator == rtmp.Numerator * ltmp.Denominator;
		}		
		public static bool operator !=(Fraction lvalue, Fraction rvalue)
		{
			return !(lvalue.Numerator * rvalue.Denominator == rvalue.Numerator * lvalue.Denominator);
		}

		/////////////////////////////////////////////  ( > / < )  ///////////////////////////////////////////
		public static bool operator >(Fraction lvalue, Fraction rvalue)
		{
			Fraction ltmp = new Fraction(lvalue);
			Fraction rtmp = new Fraction(rvalue);
			ltmp.ToImproper();
			rtmp.ToImproper();
			return ltmp.Numerator * rtmp.Denominator > rtmp.Numerator * ltmp.Denominator;
		}
		public static bool operator <(Fraction lvalue, Fraction rvalue)
		{
			Fraction ltmp = new Fraction(lvalue);
			Fraction rtmp = new Fraction(rvalue);
			ltmp.ToImproper();
			rtmp.ToImproper();
			return ltmp.Numerator * rtmp.Denominator < rtmp.Numerator * ltmp.Denominator;
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

		/////////////////////////////////////////////  ПРИВЕДЕНИЕ ТИПОВ  //////////////////////////////////////
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
