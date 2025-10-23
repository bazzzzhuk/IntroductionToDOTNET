//#define ARRAY_1
//#define ARRAY_11
//#define ARRAY_2
#define JAGGED_ARRAY
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random rand = new Random(0);
#if ARRAY_1
			int[] arr = { 3, 5, 8, 13, 21 };
			for (int i = 0; i < arr.Length; i++)
			{
				Console.Write(arr[i]+"\t");
			}
			Console.WriteLine();
			foreach (int i in arr)
			{
				Console.Write(i+"\t");
			}
			Console.WriteLine();
#endif
#if ARRAY_11
			Console.Write("Enter length array: ");
			int n = Convert.ToInt32(Console.ReadLine());
			int[] arr = new int[n];
			#region FOR
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = rand.Next(100);
			}
			for (int i = 0; i < arr.Length; i++)
			{
				Console.Write($"{arr[i]}\t");
			}
			Console.WriteLine();
			Console.WriteLine($"Sum array: {arr.Sum()}");
			Console.WriteLine($"AVG array: {arr.Average()}");
			Console.WriteLine($"Min value in array: {arr.Min()}");
			Console.WriteLine($"Max value in array: {arr.Max()}");


			#endregion
			#region Foreach
			/*foreach (ref int i in arr)
			{
				i = rand.Next(100);
			}

			foreach (int i in arr)
			{
				Console.Write($"{i}\t");
			} */
			#endregion
#endif
#if ARRAY_2
			Console.Write("Enter count strok: ");
			int rows = Convert.ToInt32(Console.ReadLine());

			Console.Write("Enter count elements strok: ");
			int cols = Convert.ToInt32(Console.ReadLine());

			int[,] arr = new int[rows, cols];
			Console.WriteLine($"{arr.Rank}");
			Console.WriteLine($"{arr.Length}");
			for (int I = 0; I < arr.GetLength(0); I++)
			{
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					arr[I, j] = rand.Next(100);
				}
			}
			Console.WriteLine();
			foreach (int i in arr) Console.Write(i + "\t");
			Console.WriteLine();
			Console.WriteLine();
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					Console.Write($"{arr[i, j]}\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
			Console.WriteLine($"sum array: {arr.Cast<int>().Sum()}");
			Console.WriteLine($"AVG array: {arr.Cast<int>().Average()}");
			Console.WriteLine($"Min value array: {arr.Cast<int>().Min()}");
			Console.WriteLine($"Max value array: {arr.Cast<int>().Max()}"); 
#endif
#if JAGGED_ARRAY
			int[][] arr =
				{
				new int[]{0, 1, 1,2},
				new int[]{3,5,8,13,21},
				new int[]{34,55,89},
				new int[]{144,233,377,610,987}
				};
			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = 0; j < arr[i].Length; j++)
				{
					Console.Write(arr[i][j]+"\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine("\n================================\n");
			foreach(int[] i in arr)
			{
				//Console.Write(i+"\t");
				foreach(int j in i)
				{
					Console.Write(j+"\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
			int sum =0;
			int count = 0;
			foreach (int[] i in arr)
			{
				sum += i.Sum();
				count+=i.Length;
			}
			Console.WriteLine($"sum elements:{sum}");
			Console.WriteLine($"Count elements:{count}");
			Console.WriteLine($"avg elements:{(double)sum/count}");
			int min, max;
			min = max = arr[0][0];
			foreach (int[] i in arr)
			{
				if(i.Min() < min) min = i.Min();
				if(i.Max() > max) max = i.Max();
			}
			Console.WriteLine($"min : {min}");
			Console.WriteLine($"max : {max}");
			Console.WriteLine();
#endif


		}
	}
}
