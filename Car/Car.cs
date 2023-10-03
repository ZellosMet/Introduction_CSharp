using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
	internal class Car
	{
		static readonly int MAX_SPEED_LOWER_LEVEL = 30;
		static readonly int MAX_SPEED_UPPER_LEVEL = 400;

		Engine engine;
		Tank tank;
		int speed;
		int accelleration;
		readonly int MAX_SPEED;
		bool driver_inside;
		public int GetSpeed()
		{
			return speed;
		}
		public int Get_MAX_SPEED()
		{ 
			return MAX_SPEED;
		}
		public Car(double consumption, int volume, int max_speed, int accelleration = 10)
		{
			if (max_speed < MAX_SPEED_LOWER_LEVEL) MAX_SPEED = MAX_SPEED_LOWER_LEVEL;
			else if (max_speed > MAX_SPEED_UPPER_LEVEL)  MAX_SPEED = MAX_SPEED_UPPER_LEVEL;
			else MAX_SPEED = max_speed;

			engine = new Engine(consumption);
			tank = new Tank(volume);
			driver_inside = false;
			this.accelleration = accelleration;
			speed = 0;

			Console.WriteLine("Car is ready!");
		}

		public void Panel()
		{
			Console.WriteLine($"Fuel level:\t\t {tank.GetFuelLevel()} liters");
			Console.WriteLine("Engin is:\t\t" + (engine.started() ? " started" : " stoped"));
			Console.WriteLine($"Speed:\t\t\t {speed} km/h");
			Console.WriteLine($"Consumption per second:\t {engine.ConsumptionPerSecond} liters");
		}
	}
}
