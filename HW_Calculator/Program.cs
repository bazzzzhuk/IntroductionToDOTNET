using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_Calculator
{
	//void Calc();
	internal class Program
	{
		static void Main(string[] args)
		{
			do
			{
				Calc();
				Console.WriteLine("Для выхода нажми \"Esc\", а для повтора - любую клавишу!");
			}while (Console.ReadKey(true).Key != ConsoleKey.Escape);
		}
		static void Calc()
		{

			int x;
			int y;
			string str;
			string str1;
			string str2;
			char[] chars = { '-', '+', '*', '/' };
			int oper;
			do
			{
				Console.Clear();
				Console.BackgroundColor = ConsoleColor.White;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.CursorVisible = false;
				Console.Write("Введите арифметическое выражение:");
				Console.ResetColor();
				Console.Write(" ");
				x = Console.CursorLeft;
				y = Console.CursorTop; 
				Console.BackgroundColor = ConsoleColor.DarkYellow;
				Console.ForegroundColor = ConsoleColor.Black;
				str = Console.ReadLine(); Console.ResetColor();
				oper = str.IndexOfAny(chars);
				if (oper == -1) continue;
				str1 = str.Substring(0, oper);
				str2 = str.Substring(oper + 1);
				if (double.TryParse(str1, out double rez) == double.TryParse(str2, out double rez2)) break;
			} while (true);
			switch (str[oper])
			{
				case '-': Console.SetCursorPosition(x+str.Length, y); Console.BackgroundColor = ConsoleColor.Red; Console.Write(" = "); Console.WriteLine(Convert.ToDouble(str1) - Convert.ToDouble(str2)); Console.ResetColor(); break;
				case '+': Console.SetCursorPosition(x + str.Length, y); Console.BackgroundColor = ConsoleColor.Red; Console.Write(" = "); Console.WriteLine(Convert.ToDouble(str1) + Convert.ToDouble(str2)); Console.ResetColor(); break;
				case '*': Console.SetCursorPosition(x + str.Length, y); Console.BackgroundColor = ConsoleColor.Red; Console.Write(" = "); Console.WriteLine(Convert.ToDouble(str1) * Convert.ToDouble(str2)); Console.ResetColor(); break;
				case '/': Console.SetCursorPosition(x + str.Length, y); Console.BackgroundColor = ConsoleColor.Red; Console.Write(" = "); Console.WriteLine(Convert.ToDouble(str1) / Convert.ToDouble(str2)); Console.ResetColor(); break;
			}
}
	}
}
