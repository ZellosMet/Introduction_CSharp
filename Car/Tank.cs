using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
	internal class Tank
	{
		static readonly int MIN_TANK_VOLUME = 20;
		static readonly int MAX_TANK_VOLUME = 120;

		readonly int VOLUME;
		double fuel_level;
		public double GetFuelLevel()
		{
			return fuel_level;
		}
		public void Fill(int fuel)
		{
			if (fuel_level < 0) return;
			if (fuel_level + fuel < VOLUME) fuel_level += fuel;
			else fuel_level = VOLUME;
		}
		public int GetVOLUME()
		{
			return VOLUME;
		}
		public double GiveFuel(double amount)
		{
			fuel_level -= amount;
			if (fuel_level < 0) fuel_level = 0;
			return fuel_level;
		}
		public Tank(int volume) 
		{
			if (volume < MIN_TANK_VOLUME) VOLUME = MIN_TANK_VOLUME;
			else if (volume > MAX_TANK_VOLUME) VOLUME = MAX_TANK_VOLUME;
			else VOLUME = volume;

			//Console.WriteLine("Tank is ready!");
		}

		public void Info()
		{
			Console.Write($"Volume: {VOLUME} liters; ");
			Console.WriteLine($"Fuel level: {GetFuelLevel()} liters.");
		}
	}
}
