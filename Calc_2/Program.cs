//#define STEP

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

//12345+(5*2)/2-(12/3)+678

namespace Calc_2
{
	internal class Program
	{
		static int oper;
		static char[] chars = { '-', '+', '*', '/' };
		static char[] priority = { '*', '/' };
		static string str, str1, str2, str_in;
		static void Main(string[] args)
		{
			str=Enter_expression();
			//Console.WriteLine(str);
			Calc_2(str);
		}
		static string Enter_expression()
		{
			//Console.Write("Введите арифметическое выражение:");
			//str = Console.ReadLine();
			//str="12345 + (5 * 2) / 2 - (12 / 3) + 678";
			str = "(12+5)*2/4-12/(3+67)+*123";
			//bool ooo = security_str(str);
			//Console.WriteLine(ooo);
			if (security_str(str)) 
			{ 
				return str;
			}
			else
			{
				Console.WriteLine("Error input expression"); return "0";
			}
		}
		static bool security_str(string str)
		{
			for (int i = 0;	i<str.Length-1;i++)
			{
				//Console.WriteLine(str);
				//Console.WriteLine();
				//Console.Write(str[i]);
				//Console.Write(" ");
				//Console.WriteLine(Convert.ToString(str[i]).IndexOfAny(chars));
				if (chars.Contains(str[i]) && chars.Contains(str[i + 1]))
				{
					//Console.WriteLine($"> {str[i]} <~~~> {str[i+1]} <");
					return false;
				}/*else Console.WriteLine("not")*/;
			}
			return true;
		}
		static void Calc_2(string str)
		{
			str = str.Replace(" ", string.Empty);
			Console.WriteLine(str);
			str = Bracket(str);
			str = Priority(str, priority);
			str = Priority(str, chars);
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.WriteLine($"{str} <--- Результат выражения");
			Console.ResetColor();
		}
		static string Calc(string str_in)
		{
			do
			{
				oper = str_in.IndexOfAny(chars);
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
				case '/': str_in = Convert.ToString(Convert.ToDouble(str1) / Convert.ToDouble(str2)); break;
			}
			Console.WriteLine(str_in);
			return str_in;
		}
		static string Bracket(string str)
		{
			do//проверка скобок и их упрощение
			{
				int bracket1;
				int bracket2;
				bracket1 = str.IndexOf('(');
				bracket2 = str.IndexOf(')');
				if (bracket1 == bracket2) break;
			Console.WriteLine("Приоритет скобок:");
				str_in = str.Substring(bracket1 + 1, bracket2 - bracket1 - 1);
				str = str.Remove(bracket1, bracket2 - bracket1 + 1);
				str = str.Insert(bracket1, Calc(str_in));
				Console.WriteLine(str);
			} while (true);
			return str;
		}
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
				string str3 = " по знаку:";
				string str4 = "а нет:";
				Console.WriteLine("Приоритет" + (op==priority?str3:str4));
				indx_pr1 = str.LastIndexOfAny(chars, indx_pr - 1);
				indx_pr2 = str.IndexOfAny(chars, indx_pr + 1);
				if (indx_pr2 == -1) indx_pr2 = str.Length;
				str_in = str.Substring(indx_pr1 + 1, (indx_pr2 - indx_pr1) - 1);
				if (str.IndexOfAny(chars) == str.LastIndexOfAny(chars))
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


	}//programm

}