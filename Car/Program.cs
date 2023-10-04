using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//	Create Tank DONE
			//	Tank tank = new Tank(50);
			//	tank.Info();
			//	do
			//	{
			//		int fuel;
			//		Console.Write("Введите колличество заправляемого топлива -> "); fuel = Convert.ToInt32(Console.ReadLine());
			//		tank.Fill(fuel);
			//		tank.Info();
			//		tank.GiveFuel(0.003);
			//		tank.Info();
			//	} while (true);

			//	Create Engine DONE
			//	Engine engine = new Engine(8);
			//	engine.Info();

			Car car = new Car(25, 100, 300);
			//car.Panel();
			car.Control();
		}
	}
}
