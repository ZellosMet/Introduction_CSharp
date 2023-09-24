#define GEOMETRY
#define CHESSBOARD_EASY
#define CHESSBOARD_HARD

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Введите размер фигуры: "); n = Convert.ToInt32(Console.ReadLine());

# if GEOMETRY

            Console.WriteLine();

            //Квадрат
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (j > 1 && j < n && i > 1 && i < n) Console.Write("  ");
                    else Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //Треугольник 1
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (j > 1 && j < i && i > 1 && i < n) Console.Write("  ");                 
                    else Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //Треугольник 2
            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (j > 1 && j < i && i > 1 && i < n) Console.Write("  ");                    
                    else Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //Треугольник 3
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++) Console.Write("  "); 
                for (int k = n; k >= i; k--)
                {
                    if (k > 1 && k < n && i > 1 && i < k) Console.Write("  ");
                    else Console.Write("* ");                  
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //Треугольник 4
            for (int i = 1; i <= n; i++)
            {
                for (int j = n; j >= i; j--) Console.Write("  ");
                for (int k = 1; k <= i; k++)
                {
                    if (k > 1 && k < n && i > k && i < n) Console.Write("  ");                    
                    else Console.Write("* ");                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //Ромб
            for (int i = 1; i <= n; i++)
            {
                for (int j = n; j >= 1; j--)
                {
                    if (i == j) Console.Write("/");
                    else Console.Write(" ");                   
                }
                for (int j = 1; j <= n; j++)
                {
                    if (i == j) Console.Write("\\");                    
                    else Console.Write(" ");                   
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i == j) Console.Write("\\");                   
                    else Console.Write(" ");
                }
                for (int j = n; j >= 1; j--)
                {
                    if (i == j) Console.Write("/");                   
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //Квадрат +/-
            for (int i = 0; i < n; i++)
            { 
             for (int j = 0; j <= n; j++)
                Console.Write(((i + j) % 2 == 0 ? "+ " : "- "));
             Console.WriteLine();
            }
#endif

#if CHESSBOARD_EASY

            Console.WriteLine();
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 && j == 0) Console.Write('┌');
                    else if (i == 0 && j == n) Console.Write('┐');
                    else if (i == n && j == 0) Console.Write('└');
                    else if (i == n && j == n) Console.Write('┘');
                    else if (i == 0 || i == n) { Console.Write('─'); Console.Write('─'); }
                    else if (j == 0 || j == n) Console.Write('│');
                    else if ((i + j) % 2 == 0) { Console.Write('█'); Console.Write('█'); }
                    else { Console.Write(Convert.ToChar(32)); Console.Write(' '); }
                }
                Console.WriteLine();
            }
#endif

# if CHESSBOARD_HARD

            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        for (int l = 0; l < n; l++)
                        {
                            if ((i + k) % 2 == 0) Console.Write("* ");
                            else Console.Write("  ");
                        }
                    }
                    Console.WriteLine();
                }
            }
#endif
        }
    }
}
