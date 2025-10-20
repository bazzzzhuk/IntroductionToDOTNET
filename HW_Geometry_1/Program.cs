using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Geometry_1
{
	internal class Program//В конце результат из консоли 
	{
		static void Main(string[] args)
		{
			int matrix;
			Console.Write("Введите размер стороны: ");
			int side = Convert.ToInt32(Console.ReadLine());
			//1. Квадрат (Square):
			matrix = side * side;

			for (int i = 1; i <= matrix; i++)
			{
				Console.Write("* ");
				if (i % side == 0) Console.WriteLine();
			}
			Console.WriteLine();
			//2. Треугольник (Triangle_left_down):
			int dot = 1, dots = dot;
			for (int i = 1; i <= matrix; i++)
			{
				Console.Write(dots-- > 0 ? "* " : " ");
				if (i % side == 0) { Console.WriteLine(); ; dots = dot++ + 1; }
			}
			Console.WriteLine();
			//3. Треугольник (Triangle_left_up):
			dot = side;
			dots = dot;
			for (int i = 1; i <= matrix; i++)
			{
				Console.Write(dots-- > 0 ? "* " : " ");
				if (i % side == 0) { Console.WriteLine(); ; dots = dot-- - 1; }
			}
			Console.WriteLine();
			//4. Треугольник (Triangle_right_up):
			int spc = 0, spcs = spc;
			for (int i = 1; i <= matrix; i++)
			{
				if (spcs-- > 0) Console.Write("  "); else Console.Write("* ");
				if (i % side == 0) { Console.WriteLine(); ; spcs = spc++ + 1; }
			}
			Console.WriteLine();
			//5. Треугольник (Triangle_right_down):
			spc = side - 1;
			spcs = spc;
			for (int i = 1; i <= matrix; i++)
			{
				if (spcs-- > 0) Console.Write("  "); else Console.Write("* ");
				if (i % side == 0) { Console.WriteLine(); ; spcs = spc-- - 1; }
			}
			Console.WriteLine();
			//////ROMB
			int matrix_romb = matrix * 4;//символьный размер фигуры
			int romb_line = side * 2;//одна строка
			int dot_1 = side;//положение первого слэша
			int dot_2 = dot_1 + 1;//положение второго слэша
			for (int i = 1; i <= matrix_romb; i++)//цель: решить всё одним for-ом...
			{
				if (i == (matrix_romb / 2) + 1)//переформатируем нижнюю часть ромба
				{
					dot_2 = matrix_romb / 2 + 1;
					dot_1 = dot_2 + romb_line - 1;
				}
				if (dot_1 == i && dot_1 != dot_2)//печать первого слэша, возникшую проблему с одинаковыми значениями решил костылём
				{
					Console.Write("/");
					dot_1 = dot_1 + romb_line - 1;
				}
				else if (dot_2 == i)//печать второго слэша
				{
					Console.Write("\\");
					dot_2 = dot_2 + romb_line + 1;
				}
				else Console.Write(" ");//иначе - пусто
				if (i % (side * 2) == 0) Console.WriteLine();//перевод строки
			}
			Console.WriteLine();
			/////Plus_Minus
			for (int i = 0; i < side; i++)
			{
				for (int ii = 0; ii < side; ii++)
				{
					//(i % 2 == ii % 2) ? cout << "+ " : cout << "- ";//
					Console.Write(i % 2 == ii % 2 ? "+ " : "- ");
				}
				Console.WriteLine();
				
			}
			Console.WriteLine();
			/////Chess
			Console.Write("┌"); for (int i = 0; i < side * side*2; i++)Console.Write ("─"); Console.Write("┐"); Console.WriteLine();//первая линия оконтовки
			for (int i = 0; i < side; i++)// по большим строчным квадратам
			{
				for (int ii = 0; ii < side; ii++)//по строкам квадрата
				{
				Console.Write("│");//вертикальная линия в начале
					for (int iii = 0; iii < side; iii++)//строка
					{
						for (int iiii = 0; iiii < side; iiii++) Console.Write(iii % 2 == i % 2 ? "* " : "  ");// чёрное или белое
					}
				Console.Write("│");//вертикальная линия в начале
					Console.WriteLine();
				}
			}
			Console.Write("└"); for (int i = 0; i < side *side* 2; i++)Console.Write("─"); Console.Write("┘"); Console.WriteLine();//последняя линия оконтовки
			Console.Write("┌"); for (int i = 0; i < side * 2; i++)Console.Write ("─"); Console.Write("┐"); Console.WriteLine();//первая линия оконтовки
			for (int ii = 0; ii < side; ii++)//по рядам
			{
				Console.Write("│");//вертикальная линия в начале
				for (int iii = 0; iii < side; iii++)//строка
				{
					Console.Write(iii % 2 == ii % 2 ? "██" : "\x20\x20");// квадрат или пусто
				}
				Console.Write("│");//вертикальная линия в конце
				Console.WriteLine();
			}
			Console.Write("└"); for (int i = 0; i < side * 2; i++)Console.Write("─"); Console.Write("┘");//последняя линия оконтовки
		}
	}
}
/*
 Введите размер стороны: 5
* * * * *
* * * * *
* * * * *
* * * * *
* * * * *

*
* *
* * *
* * * *
* * * * *

* * * * *
* * * *
* * *
* *
*

* * * * *
  * * * *
    * * *
      * *
        *

        *
      * *
    * * *
  * * * *
* * * * *

    /\
   /  \
  /    \
 /      \
/        \
\        /
 \      /
  \    /
   \  /
    \/

+ - + - +
- + - + -
+ - + - +
- + - + -
+ - + - +

┌──────────────────────────────────────────────────┐
│* * * * *           * * * * *           * * * * * │
│* * * * *           * * * * *           * * * * * │
│* * * * *           * * * * *           * * * * * │
│* * * * *           * * * * *           * * * * * │
│* * * * *           * * * * *           * * * * * │
│          * * * * *           * * * * *           │
│          * * * * *           * * * * *           │
│          * * * * *           * * * * *           │
│          * * * * *           * * * * *           │
│          * * * * *           * * * * *           │
│* * * * *           * * * * *           * * * * * │
│* * * * *           * * * * *           * * * * * │
│* * * * *           * * * * *           * * * * * │
│* * * * *           * * * * *           * * * * * │
│* * * * *           * * * * *           * * * * * │
│          * * * * *           * * * * *           │
│          * * * * *           * * * * *           │
│          * * * * *           * * * * *           │
│          * * * * *           * * * * *           │
│          * * * * *           * * * * *           │
│* * * * *           * * * * *           * * * * * │
│* * * * *           * * * * *           * * * * * │
│* * * * *           * * * * *           * * * * * │
│* * * * *           * * * * *           * * * * * │
│* * * * *           * * * * *           * * * * * │
└──────────────────────────────────────────────────┘
┌──────────┐
│██  ██  ██│
│  ██  ██  │
│██  ██  ██│
│  ██  ██  │
│██  ██  ██│
└──────────┘
 */
