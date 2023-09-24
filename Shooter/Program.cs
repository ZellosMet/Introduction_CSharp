using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int side_length = 11;            //Длина стороны игровой зоны
            int game_zone;              //Общей полощадь игровой зоны
            int player_position;        //Начальная позиция игрока(всегда в центре)
            ConsoleKey code_key;        //Код клавиши
            char symbol_void = '▒';     //Символ пустоты
            char player = '☺';          //Символ игрока
            int zone_rend_step = 0;     //Шаг отрисовки игровой зоны
            int cnt_step = 0;           //Счётчик шагов
            int cnt_shoot = 0;          //Счётчик выстрелов
            int cnt_jamp = 0;           //Счётчик прыжков
            bool end_rend = true;       //Конец отрисовки
            bool game_on = true;        //Игра включена
            bool ext_game = true;       //Выход из игры	


           // Console.WriteLine("Введите нечётное число для генерации игровой зоны(рекомендуемый диапозон от 1 до 15)");
           // side_length = Convert.ToInt32(Console.ReadLine());

           // if (side_length % 2 == 0) side_length--; //Проверка на нечётность            
            game_zone = side_length * side_length;
            player_position = game_zone / 2;

            Console.WriteLine("Игровое поле состоит из двух символов: 'О' - пустая область, 'Х' - позиция игрока");
            Console.WriteLine("Прыжок или выстрел сопровождается звуковым сигналом");
            Console.WriteLine("Управление:");
            Console.WriteLine("w - Шаг вверх");
            Console.WriteLine("s - Шаг вниз");
            Console.WriteLine("a - Шаг влево");
            Console.WriteLine("d - Шаг вправо");
            Console.WriteLine("Enter - выстрел");
            Console.WriteLine("Space - Пражок");
            Console.WriteLine("Esc - Выход");
            Console.WriteLine();

            //Цикл входа в игру
            while (ext_game)
            {
                do //Цикл отрисовки игрового поля и статистики
                {
                    while (zone_rend_step < game_zone && end_rend)
                    {
                        if (zone_rend_step % side_length == 0 && zone_rend_step != 0) Console.WriteLine();
                        if (zone_rend_step == player_position)
                        {
                            Console.Write(player);
                            zone_rend_step++;
                            if (zone_rend_step % side_length == 0 && zone_rend_step != game_zone) Console.WriteLine();
                        }
                        if (zone_rend_step != game_zone)
                        {
                            Console.Write(symbol_void);
                            zone_rend_step++;
                        }
                        else end_rend = false;                       
                    }

                    Console.WriteLine("\n");
                    game_on = true;
                    zone_rend_step = 0;
                    Console.WriteLine($"Число шагов: {cnt_step}");
                    Console.WriteLine($"Число прыжков: {cnt_jamp}");
                    Console.WriteLine($"Число выстрелов: {cnt_shoot}");

                    //******
                    //Обработчик нажатия клавиш

                    code_key = Console.ReadKey(false).Key;
                    switch (code_key)
                    {
                        case ConsoleKey.W:                        
                            Console.WriteLine();       //Шаг вверх
                            Console.Beep(150, 100);
                            if ((player_position - side_length) >= 0)
                            {
                                player_position -= side_length; 
                                cnt_step++; 
                                game_on = false;
                            }
                            else
                            {
                                player_position += game_zone - side_length; 
                                cnt_step++; 
                                game_on = false;
                            }
                            break;
                        case ConsoleKey.A: //Шаг влево
                            Console.WriteLine();       
                            Console.Beep(150, 100);
                            if ((player_position - 1) >= 0)
                            { 
                                player_position--; 
                                cnt_step++; 
                                game_on = false;                          
                            }
                            break;
                        case ConsoleKey.S: //Шаг вниз
                            Console.WriteLine();      	
                            Console.Beep(150, 100);
                            if ((player_position + side_length) < game_zone)
                            { 
                                player_position += side_length;
                                cnt_step++;
                                game_on = false;
                            }
                            else
                            { 
                                player_position -= game_zone - side_length; 
                                cnt_step++; 
                                game_on = false;                            
                            }
                            break;
                        case ConsoleKey.D: //Шаг вправо
                            Console.WriteLine();       
                            Console.Beep(150, 100);
                            if ((player_position + 1) < game_zone)
                            { 
                                player_position++; 
                                cnt_step++; 
                                game_on = false;                           
                            }
                            break;
                        case ConsoleKey.Escape: //Выход из игры
                            Console.WriteLine(); ext_game = false; 
                            game_on = false; 
                            break; 
                        case ConsoleKey.Spacebar: //Прыжок
                            Console.Beep(350, 250); 
                            cnt_jamp++; 
                            game_on = false; 
                            break; 
                        case ConsoleKey.Enter: //Выстрел
                            Console.Beep(300, 100); 
                            Console.Beep(300, 100); 
                            Console.Beep(200, 100); 
                            cnt_shoot++; 
                            game_on = false; 
                            break;
                    }
                    Console.Clear();
                    end_rend = true;
                } while (game_on);
                //*******		
            }
            //Выход
            Console.WriteLine("Game Over!");
        }
    }
}
