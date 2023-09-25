//#define CONSOLE_SETTINGS
//#define CONSOLE_IN_OUT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introductio
{
    internal class Program
    {
        const string delim = "\n-----------------------------------------------------\n";
        static void Main(string[] args)
        {

#if CONSOLE_SETTINGS
            Console.Title = "Introduction to .NET"; //Задание имени консоли

            //Console.Beep(70, 2000); //Задание звукового сигнала частота/длительность

            Console.WriteLine("Hello .NET!"); //Console.Write -выводит текст в консоль. Console.WriteLine - выводит текст с переносом на следующую строку.

            Console.BackgroundColor = ConsoleColor.DarkBlue; // Задание цвета заливки текста.
            Console.SetCursorPosition(10, 10); //Задание позиции курсору, олткуда будет выводиться текст.
            Console.ForegroundColor = ConsoleColor.Red; //Задание цвета текста.
            Console.WriteLine("Cursore position check");
            Console.BackgroundColor = ConsoleColor.Black; 
#endif

#if CONSOLE_IN_OUT

            Console.Write("Введите ваше имя: ");
            string first_name = Console.ReadLine();

            Console.Write("Введите вашу фамилию: ");
            string last_name = Console.ReadLine();

            Console.Write("Введите вашь возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());

            //1) Конкатенация строк:
            Console.WriteLine("Имя: " + first_name + " фамилия: " + last_name + " возраст: " + age + " лет");

            //2) Форматирование строк:
            Console.WriteLine(string.Format("Имя: {0} фамилия: {1} возраст: {2} лет.", first_name, last_name, age));

            //3) Интерполяция строк:
            Console.WriteLine($"Имя: {{first_name}} фамилия: {last_name} возраст: {age} лет");
#endif           
        }
    }
}
