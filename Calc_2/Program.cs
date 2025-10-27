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
			//Console.Write("Введите арифметическое выражение:");
			//str = Console.ReadLine();
			//str="12345 + (5 * 2) / 2 - (12 / 3) + 678";
			str = "(12+5)*2/4-12/(3+67)+2";
			Calc_2(str);
		}
		static void Calc_2(string str)
		{			
			str = str.Replace(" ", string.Empty);			
			Console.WriteLine(str);
			Console.WriteLine("Backet");
				str = Bracket(str);
			Console.WriteLine("Priority");
				str = Priority(str, priority);
			Console.WriteLine("Cars-pr");
				str = Priority(str, chars);
				//str = Calc(str);
				Console.WriteLine($"str: {str} ");
				Console.WriteLine("OK!");
				Console.ReadKey();
		}
		static string Calc(string str_in)
		{
			//Console.WriteLine($"{str_in}");
			do
			{
				//Console.WriteLine($"Calc1");
				//Console.ReadKey();	
				oper = str_in.IndexOfAny(chars);
				if (oper == -1) break;
				str1 = str_in.Substring(0, oper);
				str2 = str_in.Substring(oper + 1);
				if (double.TryParse(str1, out double rez) == double.TryParse(str2, out double rez2)) break;
			} while (true);
			Console.WriteLine($"str1: {str1} {str_in[oper]} str2: {str2}");
			switch (str_in[oper])
			{
				case '-': str_in = Convert.ToString(Convert.ToDouble(str1) - Convert.ToDouble(str2)); break;
				case '+': str_in = Convert.ToString(Convert.ToDouble(str1) + Convert.ToDouble(str2)); break;
				case '*': str_in = Convert.ToString(Convert.ToDouble(str1) * Convert.ToDouble(str2)); break;
				case '/': str_in = Convert.ToString(Convert.ToDouble(str1) / Convert.ToDouble(str2)); break;
			}
			Console.WriteLine($"{str_in} <--- Calc вовращает");
				//Console.WriteLine($"Calc2");
			Console.ReadKey();
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
				//Console.WriteLine(bracket1);
				//Console.WriteLine(bracket2);
				if (bracket1 == bracket2) break;
				str_in = str.Substring(bracket1 + 1, bracket2 - bracket1 - 1);
				str = str.Remove(bracket1, bracket2 - bracket1 + 1);
				str = str.Insert(bracket1, Calc(str_in));
				Console.WriteLine(str);
				Console.ReadKey();
			} while (true);
			return str;
		}
		//static string Priority(string str, char[] chars)
		//{
		//	do//Решения по приоритету 
		//	{
		//		int indx_pr;
		//		int indx_pr1;
		//		int indx_pr2;
		//		indx_pr = str.IndexOfAny(priority);
		//		if (indx_pr == -1) break;
		//		indx_pr1 = str.LastIndexOfAny(chars, indx_pr - 1);
		//		indx_pr2 = str.IndexOfAny(chars, indx_pr);
		//		str_in = str.Substring(indx_pr1 + 1, indx_pr2 - indx_pr1 + 1);
		//		str = str.Remove(indx_pr1 + 1, indx_pr - indx_pr1 + 1);
		//		str = str.Insert(indx_pr1 + 1, Calc(str_in));
		//		Console.WriteLine(str);
		//		Console.ReadKey();

		//	} while (true);
		//	return str;
		//}
		static string Priority(string str, char[] op)
		{
			do//Решения по приоритету 
			{
				int indx_pr;
				int indx_prl;
				int indx_pr1;
				int indx_pr2;

				indx_pr = str.IndexOfAny(op);
				indx_prl = str.LastIndexOfAny(op);
				Console.WriteLine($"indx_pr {indx_pr}");
				Console.WriteLine($"indx_pr {indx_prl}");
				if (indx_pr == -1) break;
				indx_pr1 = str.LastIndexOfAny(op, indx_pr - 1);
				indx_pr2 = str.IndexOfAny(op, indx_pr);
				str_in = str.Substring(indx_pr1 + 1, indx_pr2 - indx_pr1 + 1);
				if (str.IndexOfAny(chars)== str.LastIndexOfAny(chars))
				{
					str = Calc(str_in);
					Console.WriteLine("---");
					break;
				}
				//Console.WriteLine(str_in);
				str = str.Remove(indx_pr1 + 1, indx_pr - indx_pr1 + 1);
					str = str.Insert(indx_pr1 + 1, Calc(str_in));
				Console.WriteLine(str);
				Console.ReadKey();
			} while (true);
			return str;
		}


	}//programm

}