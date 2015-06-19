using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace DiskSpace
{
	class Program
	{
		static void Main(string[] args)
		{
			DriveInfo di = new DriveInfo((args.Length > 0) ? args[0] : "C:");
			double gig = Math.Pow(1024.0, 3);
			while (true)
			{
				double size = (double)di.TotalSize;
				double free = (double)di.TotalFreeSpace;
				double used = (size - free);
				double pctUsed = used / size * 100;
				double pctFree = free / size * 100;

				Console.WriteLine("Drive: {0,-5}", di.Name);
				Console.WriteLine(" Size: {0,7:0.000}", size / gig);
				Console.WriteLine(" Used: {0,7:0.000} ({1,6:0.00}%)", used / gig, pctUsed);
				Console.WriteLine(" Free: {0,7:0.000} ({1,6:0.00}%)", free / gig, pctFree);
				double fill = pctUsed / 5;
				fill = Math.Floor(fill + .5);
				Thread.Sleep(10000);
			}
		}
	}
}
