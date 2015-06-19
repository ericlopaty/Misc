using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
	class Program
	{
		static void Main(string[] args)
		{
			Chapter3 chapter = new Chapter3();
			chapter.Run();
		}

		public static void Header(string title)
		{
			Console.WriteLine();
			Console.WriteLine(string.Format("-----[ {0} ]", title).PadRight(Console.WindowWidth - 1, '-'));
			Console.WriteLine();
		}

		public static void Trailer()
		{
			Console.WriteLine();
			Console.WriteLine("".PadRight(Console.WindowWidth-1, '-'));
			Console.WriteLine();
		}
	}
}
