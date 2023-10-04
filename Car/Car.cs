using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
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
		private struct Threads
		{
			public Thread panel_thread;
			public Thread engine_idle_threads;
			public Thread free_wheeling_threads;
		}
		Threads threads;

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
			threads = new Threads();

			Console.WriteLine("Car is ready!");
		}

		public void GetIn()
		{
			driver_inside = true;
			threads.panel_thread = new Thread(Panel);
			threads.panel_thread.Start();
		}
		public void GetOut()
		{
			driver_inside = false;
			if (threads.panel_thread.IsBackground = true) threads.panel_thread.Abort();
			Console.Clear();
			Console.WriteLine("Outside");
		}
		public void Start()
		{
			if(driver_inside && tank.GetFuelLevel() != 0)
			{
				engine.Start();
				threads.engine_idle_threads = new Thread(EngineIdle);
				threads.engine_idle_threads.Start();
			}
		}
		public void Stop()
		{
			engine.Stop();
			if (threads.engine_idle_threads.IsBackground = true) threads.engine_idle_threads.Abort();
		}
		public void Control()
		{
			ConsoleKey code_key;
			do
			{
				code_key = Console.ReadKey(true).Key;

				switch(code_key)
				{
					case ConsoleKey.Escape:
						speed = 0;
						if (engine.Started()) Stop();
						GetOut();
						break;
					case ConsoleKey.Enter:
						if (driver_inside && speed == 0) GetOut();
						else if (!driver_inside && speed == 0) GetIn();
						break;
					case ConsoleKey.F:
						if (driver_inside)
						{
							Console.WriteLine("Для начала нужно выйти из машины");
							break;
						}
						int fuel;
						Console.Write("Введите объём топлива -> "); fuel = Convert.ToInt32(Console.ReadLine());
						tank.Fill(fuel);
						break;
					case ConsoleKey.I:
						if (engine.Started()) Stop();
						else Start();
						break;
					case ConsoleKey.W:
						Accellerate();
						break;
					case ConsoleKey.S:
						SlowDown();
						break;
					default:
						if (tank.GetFuelLevel() == 0) Stop();
						if (speed == 0) engine.SetConsumptionPerSecond(0);
						if(speed == 0 && threads.free_wheeling_threads.IsBackground == true) threads.free_wheeling_threads.Abort();
						break;
				}
			} while (code_key != ConsoleKey.Escape);

		}
		public void EngineIdle()
		{
			while (engine.Started() && tank.GetFuelLevel() != 0)
			{
				engine.SetConsumptionPerSecond(speed);
				tank.GiveFuel(engine.GetConsumptionPerSecond());
				Thread.Sleep(1000);
			}
		}
		public void FreeWheeling()
		{
			while(speed > 0)
			{
				Thread.Sleep(1000);
				speed--;
			}
		}

		public void Accellerate()
		{
			if(engine.Started() && driver_inside)
			{
				speed += accelleration;
				if (speed > MAX_SPEED) speed = MAX_SPEED;
				threads.free_wheeling_threads = new Thread(FreeWheeling);
				threads.free_wheeling_threads.Start();
				Thread.Sleep(1000);
			}
		}
		public void SlowDown()
		{
			if (driver_inside)
			{
				speed -= accelleration;
				if (speed < 0) speed = 0;
				Thread.Sleep(1000);				
			}
		}
		public void Panel()
		{
			while(driver_inside)
			{
				Console.Clear();
				if (tank.GetFuelLevel() < 5)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.BackgroundColor = ConsoleColor.Yellow;
					Console.Write($"Fuel level:\t\t {tank.GetFuelLevel()} liters ");
					Console.WriteLine("LOW FUEL!");
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
				}
				else Console.WriteLine($"Fuel level:\t\t {tank.GetFuelLevel()} liters");
				Console.WriteLine("Engin is:\t\t" + (engine.Started() ? " started" : " stoped"));
				Console.WriteLine($"Speed:\t\t\t {speed} km/h");
				Console.WriteLine($"Consumption per second:\t {engine.GetConsumptionPerSecond()} liters");
				Thread.Sleep(100);
			}
		}
	}
}
