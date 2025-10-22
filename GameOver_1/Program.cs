using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameOver_1
{
	class Rocket
	{
		int pos_x;
		int pos_y;
		void print_rocket(int pos_x, int pos_y)
		{
			Console.CursorLeft = pos_x + 1;
			Console.CursorTop = pos_y;
			Console.Write("▲");
			Console.CursorLeft = pos_x + 1;
			Console.CursorTop = pos_y + 1;
			Console.Write("█");
			Console.CursorLeft = pos_x;
			Console.CursorTop = pos_y + 2;
			Console.Write("▄█▄");
			//Console.CursorLeft = pos_x;
			//Console.CursorTop = pos_y + 3;
			//Console.Write("▌▓▐");
		}
		void print_flame(int pos_x, int pos_y)
		{
			Console.CursorLeft = pos_x;
			Console.CursorTop = pos_y + 3;
			Console.Write("▌▓▐");
			Thread.Sleep(1);
			Console.CursorLeft = pos_x;
			Console.CursorTop = pos_y + 3;
			Console.Write("▌░▐");
		}
		Rocket(int x, int y)
		{
			this.pos_x = x;
			this.pos_y = y;
		}
		void Rocket_move(ConsoleKey key2)
		{
			Random rand = new Random();
			Console.WriteLine(rand.Next(10)+rand.Next(10));

			if (key2 == ConsoleKey.LeftArrow) this.pos_x--;
			if (key2 == ConsoleKey.RightArrow) this.pos_x++;
			if (key2 == ConsoleKey.UpArrow) this.pos_y--;
			if (key2 == ConsoleKey.DownArrow) this.pos_y++;
			this.print_rocket(pos_x, pos_y);
			this.print_flame(pos_x, pos_y);
		}

		internal class Program
		{
			static void Main(string[] args)
			{
				int x = Console.CursorLeft = 25;
				int y = Console.CursorTop = 25;
				Rocket rocket = new Rocket(x, y);
				Console.CursorVisible = false;
				//do
				//{
				//}
				//while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)) ;
				bool isQuit = false;
				while (!isQuit)
				{
					var task = Task.Factory.StartNew(() => { return Console.ReadKey(true); });
					//System.SendKeys.Send("L");
					if (task.Wait(-1)) // wait forever
					{
						//Console.Write(task.Result.Key.ToString());
						Console.Clear();
						Console.WriteLine("Илон Маск отдыхает...");
						Console.WriteLine("Enter Q to exit!");
						rocket.Rocket_move(task.Result.Key);
						if (task.Result.Key == ConsoleKey.Q)
						{
							//ConsoleKey key2 = Console.CancelKeyPress();
							isQuit = true;
						}
					}
				}
			}

		}
	}
}
