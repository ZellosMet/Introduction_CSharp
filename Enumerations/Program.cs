using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerations
{
	internal class Program
	{
		static readonly string delim = "\n----------------------------------------------------\n";
		static void Main(string[] args)
		{
			DayOfWeek day = DayOfWeek.Friday;
			Console.WriteLine(day);

			Console.WriteLine(delim);

			string[] dayName = Enum.GetNames(typeof(DayOfWeek));
			foreach(string i in dayName)
				Console.WriteLine(i);
			
			Console.WriteLine(delim);

			DistanceFromSun dfs = DistanceFromSun.Earth;
			Console.WriteLine($"{dfs} - {dfs.GetHashCode()} km");
			string[] distNames = Enum.GetNames(typeof(DistanceFromSun));
			ulong[] distValues = (ulong[])Enum.GetValues(typeof(DistanceFromSun));
			for (int i = 0; i < distNames.Length; i++)
				Console.WriteLine($"{distNames[i]} \t {distValues[i]}");
			//Console.WriteLine((Enum.GetUnderlyingType(typeof(DistanceFromSun))).GetType());
		}
		enum DayOfWeek 
		{
			Sunday,
			Monday,
			Tuesday,
			Wednesday,
			Thursday,
			Friday,
			Saturday
		};
		enum DistanceFromSun : ulong
		{ 
			Sun = 0,
			Mercury = 57900000,
			Venus = 108200000,
			Earth = 149600000		
		}
	}
}
