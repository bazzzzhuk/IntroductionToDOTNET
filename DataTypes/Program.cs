//#define DATA_TYPES
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
		const string delimiter = "=========================================";
		
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
			PrintSizeOf<sbyte>();
			PrintSizeOf<byte>();
			PrintSizeOf<short>();
			PrintSizeOf<ushort>();
			PrintSizeOf<int>();
			PrintSizeOf<uint>();
			PrintSizeOf<long>();
			PrintSizeOf<ulong>();
			PrintSizeOf<char>();
			PrintSizeOf<float>();
			PrintSizeOf<double>();
			PrintSizeOf<decimal>();
			PrintSizeOf<bool>();
			}
		static unsafe void PrintSizeOf<T>() where T : unmanaged
		{
			Console.WriteLine("|\t\t\t\t\t|");
			Console.WriteLine($"|{typeof(T).Name}  занимает {sizeof(T)} байт и\t\t|");
			Console.WriteLine($"|Класс-обёртка - {typeof(T)}\t\t|");

			//Console.WriteLine("\t\t\t\t|");
			Console.WriteLine("|\t\t\t\t\t|");
			Console.WriteLine(delimiter);
		}
		//принимает значения в диапазоне от {T.MinValue} до {T.MaxValue} - осталось за бортом, не нашёл простого решения.

	}

}
