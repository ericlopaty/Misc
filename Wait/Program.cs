using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Wait
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				int interval = (int)int.Parse(args[0]);
				Thread.Sleep(interval);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
