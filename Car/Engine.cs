using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
	internal class Engine
	{
		static readonly int MIN_ENGINE_CONSUMTION = 3;
		static readonly int MAX_ENGINE_CONSUMTION = 30;

		readonly double DEFAULT_CONSUMPTION;
		readonly double DEFAULT_CONSUMPTION_PER_SECOND;
		double consumption_per_second;
		bool is_started;
		
		public double GetConsumptionPerSecond()
		{ 
			return consumption_per_second;	
		}	
		public void SetConsumptionPerSecond(int speed)
		{
			if (speed == 0) consumption_per_second = DEFAULT_CONSUMPTION_PER_SECOND;
			else if (speed < 60) consumption_per_second = DEFAULT_CONSUMPTION_PER_SECOND * 20 / 3;
			else if (speed < 100) consumption_per_second = DEFAULT_CONSUMPTION_PER_SECOND * 14 / 3;
			else if (speed < 140) consumption_per_second = DEFAULT_CONSUMPTION_PER_SECOND * 20 / 3;
			else if (speed < 200) consumption_per_second = DEFAULT_CONSUMPTION_PER_SECOND * 25 / 3;
			else if (speed < 250) consumption_per_second = DEFAULT_CONSUMPTION_PER_SECOND * 10;
		}
		 public void Start()
		{
			is_started = true;
		}
		public void Stop()
		{
			is_started = false;
		}
		public bool Started()
		{
			return is_started;
		}
		public Engine(double consumption)
		{
			if (consumption < MIN_ENGINE_CONSUMTION) DEFAULT_CONSUMPTION = MIN_ENGINE_CONSUMTION;
			else if (consumption > MAX_ENGINE_CONSUMTION) DEFAULT_CONSUMPTION = MAX_ENGINE_CONSUMTION;
			else DEFAULT_CONSUMPTION = consumption;

			DEFAULT_CONSUMPTION_PER_SECOND = DEFAULT_CONSUMPTION * 3e-5;

			SetConsumptionPerSecond(0);
			is_started = false;
			//Console.WriteLine("Engine is ready!");
		}

		public void Info()
		{
			Console.WriteLine($"Consuption:\t {DEFAULT_CONSUMPTION} liters per 100km.");
			Console.WriteLine($"Consuption:\t {consumption_per_second} liters per second.");

		}
	}
}
