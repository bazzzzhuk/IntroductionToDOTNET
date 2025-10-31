//#define STEP
#define BRACKET_CHECK_MAD

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Calc_2
{
	internal class Program
	{
		static int oper;
		static char[] chars = { '-', '+', '*', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '(', ')', ',' };
		static char[] operators = { '-', '+', '*', '/' };
		static char[] priority = { '*', '/' };
		static string str, str1, str2, str_in;
		static void Main(string[] args)
		{
			do
			{
				double rezult = Convert.ToDouble(Calc_2(Enter_expression()));//конвертирование в double решения введенного выражения
				Console.BackgroundColor = ConsoleColor.White;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine($"{rezult}  <--- Результат выражения");
				Console.ResetColor();
				Console.WriteLine("\nДля выхода нажмите Q, для повтора - любую клавишу!");
			} while (Console.ReadKey(true).Key != ConsoleKey.Q);
		}
		static string Enter_expression()//ввод выражения
		{
			//Console.Write("Введите арифметическое выражение:");
			//str = Console.ReadLine();
			//str="12345 + (5 * 2) / 2 - (12 / 3) + 678";
			str = "1+3*(12*5)*20/4-(((12/2+1)+(2*6))*10)+(12.3+(2/246))";
			str=Correct_expression(str);
			Console.BackgroundColor = ConsoleColor.DarkYellow;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.WriteLine("↓ ↓ ↓ ВЫРАЖЕНИЕ ↓ ↓ ↓");
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.WriteLine(str);
			Console.ResetColor();
			bracket_check_mad(str);
			if (security_str(str) && check_bracket(str)) return str;
			else return "0";
		}
		static bool security_str(string str)//проверка на отсутствие двух знаков подряд (минусовое значение может позже реализую)
		{
			for (int i = 0; i < str.Length - 1; i++)
			{
				if (!chars.Contains(str[i])) return Print_cerr("недопустимый символ", i);
				if (operators.Contains(str[str.Length - 1])) return Print_cerr("оператор в конце выражения", str.Length - 1);
				if (operators.Contains(str[0])) return Print_cerr("оператор в начале выражения", 0);
				if (operators.Contains(str[i]) && operators.Contains(str[i + 1])) return Print_cerr("два оператора подряд", i);
				if (str[i] == '(' && str[i + 1] == ')') return Print_cerr("неправильная последовательность скобок", i);
			}
			return true;
		}
		static string Correct_expression(string str)
		{
			str = str.Replace(" ", string.Empty);//удаляем пробелы
			str = str.Replace(".", ",");//меняем точки на запятый
			for (int i = 0; i < str.Length - 1; i++)//")(" меняет на ")*("
			{
				if (str[i] == ')' && str[i + 1] == '(') str = str.Insert(i + 1, "*");
			}
			return str;	
		}
		static bool Print_cerr(string str_cerr, int i)//после проверки, в случае ошибки, печатает текст ошибки и указатель на ошибку
		{
			Console.CursorLeft = i; Console.WriteLine("↑");
			Console.BackgroundColor = ConsoleColor.DarkRed;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine($"Проверка выражения не пройдена: {str_cerr}!");
			Console.ResetColor();
			return false;
		}
		static string Calc_2(string str)//по сути обёртка основных циклов вычислений
		{
			str = Bracket(str);
			str = Priority_in_cicle(str);
			return str;
		}		
		static string Calc(string str_in)
		{
			do//калькуляция простых выражений
			{
				oper = str_in.IndexOfAny(operators);
				if (oper == -1) break;
				str1 = str_in.Substring(0, oper);
				str2 = str_in.Substring(oper + 1);
				if (double.TryParse(str1, out double rez) == double.TryParse(str2, out double rez2)) break;
			} while (true);
			Console.Write($"{str1} {str_in[oper]} {str2} = ");
			switch (str_in[oper])
			{
				case '-': str_in = Convert.ToString(Convert.ToDouble(str1) - Convert.ToDouble(str2)); break;
				case '+': str_in = Convert.ToString(Convert.ToDouble(str1) + Convert.ToDouble(str2)); break;
				case '*': str_in = Convert.ToString(Convert.ToDouble(str1) * Convert.ToDouble(str2)); break;
				case '/': str_in = (Convert.ToDouble(str2) == 0 ? "0" : Convert.ToString(Convert.ToDouble(str1) / Convert.ToDouble(str2))); break;//деление на ноль вернёт ноль
			}
			Console.WriteLine(str_in);
			return str_in;
		}
		static string Bracket(string str)
		{
			do//проверка скобок, просчёт выражения внутри и их упрощение
			{
				int bracket1 = 0;
				int bracket2 = 0;
				bracket2 = str.IndexOf(')');
				if (bracket2 == -1) break;
				//if (bracket2 == -1) bracket2 = 0;
				bracket1 = str.LastIndexOf('(', bracket2);
				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine("Приоритет скобок:");
				Console.ResetColor();
				str_in = str.Substring(bracket1 + 1, bracket2 - bracket1 - 1);
				str = str.Remove(bracket1, bracket2 - bracket1 + 1);
				str = str.Insert(bracket1, Priority_in_cicle(str_in));
				Console.WriteLine(str);
			} while (true);
			return str;
		}
		static bool check_bracket(string str)//проверка на равное количество скобок
		{
			int bracket1 = 0;
			int bracket2 = 0;
			do
			{
				bracket1 = str.IndexOf('(', bracket1);
				bracket2 = str.IndexOf(')', bracket2);
				if (bracket1 == -1 ^ bracket2 == -1) { return Print_cerr("Количество скобок не равное", (bracket2 == -1 ? bracket1 : bracket2)); }
				else if (bracket1 == -1 && bracket2 == -1)
				{
					Console.ForegroundColor = ConsoleColor.DarkGray;
					Console.WriteLine("Кол-во скобок равноe!");
					Console.ResetColor();
					return true;
				}
				if (bracket2 < bracket1) return Print_cerr("неправильное расположение скобок", bracket2);
				bracket1++;
				bracket2++;
			} while (bracket1 != bracket2);
			return true;
		}
#if BRACKET_CHECK_MAD
		static bool bracket_check_mad(string str)
		{
			char[] bracket = { '(', ')' };
			int bracket1 = str.IndexOfAny(bracket);
			int bracket2 = 0;
			//Console.WriteLine(bracket1);
			//do//проверка на безобразие скобок: ")("(решено в security), "a+b)+(c-d"
			//{

			//} while (true);
			return true;
		}
#endif
		static string Priority(string str, char[] op)
		{
			do//Решения по приоритету 
			{
				int indx_pr = 0;
				int indx_prl = 0;
				int indx_pr1 = 0;
				int indx_pr2 = 0;
				indx_pr = str.IndexOfAny(op);
				indx_prl = str.LastIndexOfAny(op);
				if (indx_pr == -1) break;
				Console.ForegroundColor = ConsoleColor.DarkGray;
				string str3 = " по знаку:";
				string str4 = "а нет:";
				Console.WriteLine("Приоритет" + (op == priority ? str3 : str4));
				Console.ResetColor();
				indx_pr1 = str.LastIndexOfAny(operators, indx_pr - 1);
				indx_pr2 = str.IndexOfAny(operators, indx_pr + 1);
				if (indx_pr2 == -1) indx_pr2 = str.Length;
				str_in = str.Substring(indx_pr1 + 1, (indx_pr2 - indx_pr1) - 1);
				if (str.IndexOfAny(operators) == str.LastIndexOfAny(operators))
				{
					str = Calc(str_in);
					break;
				}
				str = str.Remove(indx_pr1 + 1, indx_pr2 - indx_pr1 - 1);
				str = str.Insert(indx_pr1 + 1, Calc(str_in));
				Console.WriteLine(str);
			} while (true);
			return str;
		}
		static string Priority_in_cicle(string str)//чтобы расчёт внутренних скобок не чекал скобки
		{
			str = Priority(str, priority);
			str = Priority(str, operators);
			return str;
		}


	}//programm

}