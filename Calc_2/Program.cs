using System;
using System.Collections.Generic;
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
		static string str, str1, str2, str_in;
		static void Main(string[] args)
		{
			Calc_2();
		}
		static void Calc_2()
		{
			int bracket1;
			int bracket2;

			int indx_pr;
			int indx_pr1;
			int indx_pr2;

			char[] prority = { '*', '/' };
			Console.Write("Введите арифметическое выражение:");
			str = Console.ReadLine();
			do
			{
				do//проверка скобок и их упрощение
				{
					bracket1 = str.IndexOf('(');
					bracket2 = str.IndexOf(')');
					if(bracket1==bracket2)break;
					str_in = str.Substring(bracket1 + 1, bracket2 - bracket1 - 1);
					str = str.Remove(bracket1,bracket2-bracket1+1);
					str=str.Insert(bracket1,Calc(str_in));
					Console.WriteLine(str);
					Console.ReadKey();
				} while (true);
				do//Решения по приоритету 
				{
					indx_pr = str.IndexOfAny(prority);
					if(indx_pr==-1) break;
					indx_pr1 = str.LastIndexOfAny(chars,indx_pr-1);
					indx_pr2 = str.IndexOfAny(chars,indx_pr);
					str_in = str.Substring(indx_pr1+1, indx_pr2-indx_pr1+1);
					str = str.Remove(indx_pr1+1, indx_pr-indx_pr1+1);
					str = str.Insert(indx_pr1 + 1, Calc(str_in));
					Console.WriteLine(str);
					Console.ReadKey();

				} while (true);
				do//решение упрощенного выражения
				{
					indx_pr = str.IndexOfAny(chars);
					if (indx_pr == -1) break;
					indx_pr1 = str.LastIndexOfAny(chars, indx_pr - 1);
					indx_pr2 = str.IndexOfAny(chars, indx_pr);
					str_in = str.Substring(indx_pr1 + 1, indx_pr2 - indx_pr1 + 1);
					str = str.Remove(indx_pr1 + 1, indx_pr - indx_pr1 + 1);
					str = str.Insert(indx_pr1 + 1, Calc(str_in));
					Console.WriteLine(str);
					Console.ReadKey();


				} while (true);

				Console.WriteLine("OK!");
					Console.ReadKey();

			} while (true);
		}
		static string Calc(string str_in)
		{
			//Console.WriteLine($"{str_in}");
			do
			{
				oper = str_in.IndexOfAny(chars);
				if (oper == -1) continue;
				str1 = str_in.Substring(0, oper);
				str2 = str_in.Substring(oper + 1);
				if (double.TryParse(str1, out double rez) == double.TryParse(str2, out double rez2)) break;
			} while (true);
			switch (str_in[oper])
			{
				case '-': str_in = Convert.ToString(Convert.ToDouble(str1) - Convert.ToDouble(str2)); break;
				case '+': str_in = Convert.ToString(Convert.ToDouble(str1) + Convert.ToDouble(str2));break;
				case '*': str_in = Convert.ToString(Convert.ToDouble(str1) * Convert.ToDouble(str2)); break;
				case '/': str_in = Convert.ToString(Convert.ToDouble(str1) / Convert.ToDouble(str2)); break;
			}
			//Console.WriteLine($"!!!{str_in}");
			return str_in;
		}
	}

}
