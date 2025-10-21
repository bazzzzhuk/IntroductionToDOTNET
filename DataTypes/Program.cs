#define DATA_TYPES
//#define DATA_TYPES
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{


	internal class Program
	{
		const string delimiter = "\n=================================\n";
		void print_type(Type str)
		{
			//template<typename T>;
			Console.WriteLine(delimiter);
			Console.WriteLine
				(
$@"Тип данных {str} занимает {sizeof(int)} Байт памяти 
и принимает значение в диапазоне от {(int)char.MinValue} до {(int)int.MaxValue}. Класс-обёртка - {typeof(char)}");
			Console.WriteLine(delimiter);
		}
		static void Main(string[] args)
		{
#if DATA_TYPES
			Console.WriteLine($"bool занимает {sizeof(bool)} Байт памяти, класс-обёртка Boolean");
			Console.WriteLine(bool.FalseString);
			Console.WriteLine(bool.TrueString);
			Console.WriteLine(typeof(bool));

			////////////////////////////////////////////////////////////////////
			// @ - RAW-строка игнорирует все специальные символы и ESC-последовательности, т.е. воспринимается как есть.
			Console.WriteLine(delimiter);
			Console.WriteLine
				(
$@"Тип данных char занимает {sizeof(char)} Байт памяти 
и принимает значение в диапазоне от {(int)char.MinValue} до {(int)char.MaxValue}. Класс-обёртка - {typeof(char)}");
			Console.WriteLine(delimiter);
			Console.WriteLine
				(
$@"@-RAW - строка игнорирует все специальные символы и ESC - последовательности,
т.е.воспринимается как есть."
				);
			Console.WriteLine(delimiter);
			Console.WriteLine
				(
$@"byte занимает {sizeof(byte)} Байт памяти,
и принимает значения в диапазоне от {byte.MinValue} до {byte.MaxValue},
Класс-обёртка - {typeof(byte)} "
				);
			Console.WriteLine(delimiter);
			Console.WriteLine
				(
$@"sbyte занимает {sizeof(sbyte)} Байт памяти,
и принимает значения в диапазоне от {sbyte.MinValue} до {sbyte.MaxValue},
Класс-обёртка - {typeof(sbyte)} "
				);
			Console.WriteLine(delimiter);
			Console.WriteLine
				(
$@"sbyte занимает {sizeof(sbyte)} Байт памяти.");
			Console.WriteLine(delimiter);
			Console.WriteLine
				(
$@"sbyte занимает {sizeof(decimal)} Байт памяти.");
			Console.WriteLine(delimiter);
#endif

			print_type(char);


		}
	}
}
