//#define CONSOLE
using System; //#include
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToDOTNET
{
	internal class Program//internal - сущность в пределах сборки
	{
		static void Main(string[] args)
		{
#if CONSOLE
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Hello.NET\t");
            Console.WriteLine("Hello.NET");
            Console.WriteLine();
            Console.Title = "Introduction to .NET";
            Console.Beep(57, 1000);
            Console.CursorLeft = 25;
            Console.CursorTop = 5;
            Console.WriteLine("SetCursorePosition");
            Console.SetCursorPosition(22, 8);
            Console.WriteLine("AnotherPosition");
            Console.ResetColor(); 
#endif
			Console.Write("Введите ваше имя: ");
			string firstName = Console.ReadLine();

			Console.Write("Введите вашу фамилию: ");
			string lastName = Console.ReadLine();

			Console.Write("Введите Ваш возраст: ");
			int age = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Привет, " + lastName + " " + firstName + "!" + " Твой возраст: " + age);//конкатенация строк
			Console.WriteLine(String.Format("{0} {1} {2}", lastName, firstName, age)); //форматирование строк
			Console.WriteLine($"{lastName} {firstName} {age}");

		}
	}
}
