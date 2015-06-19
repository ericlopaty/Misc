using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountLineLength
{
	class Program
	{
		static void Main(string[] args)
		{
			string line;
			while ((line = Console.ReadLine()) != null)
				Console.WriteLine("{0,3:000}", line.TrimEnd().Length);
		}
	}
}
