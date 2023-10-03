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
		
		public double get_DEFAULT_CONSUMPTION_PER_SECOND()
		{
			return DEFAULT_CONSUMPTION_PER_SECOND;
		}
		public double ConsumptionPerSecond
		{
			get{ return consumption_per_second; }
			set 
			{
				if (value == 0) consumption_per_second = DEFAULT_CONSUMPTION_PER_SECOND;
				else if (value < 60) consumption_per_second = DEFAULT_CONSUMPTION_PER_SECOND * 20/3;
				else if (value < 100) consumption_per_second = DEFAULT_CONSUMPTION_PER_SECOND * 14/3;
				else if (value < 140) consumption_per_second = DEFAULT_CONSUMPTION_PER_SECOND * 20/3;
				else if (value < 200) consumption_per_second = DEFAULT_CONSUMPTION_PER_SECOND * 25/3;
				else if (value < 250) consumption_per_second = DEFAULT_CONSUMPTION_PER_SECOND * 10;
			}
		}
		 public void start()
		{
			is_started = true;
		}
		public void stop()
		{
			is_started = false;
		}
		public bool started()
		{
			return is_started;
		}
		public Engine(double consumption)
		{
			if (consumption < MIN_ENGINE_CONSUMTION) DEFAULT_CONSUMPTION = MIN_ENGINE_CONSUMTION;
			else if (consumption > MAX_ENGINE_CONSUMTION) DEFAULT_CONSUMPTION = MAX_ENGINE_CONSUMTION;
			else DEFAULT_CONSUMPTION = consumption;

			ConsumptionPerSecond = 0;
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
