using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CookBook.Ch4
{
	public static class EX412
	{
		public static void Run()
		{
			GenericWay genericWay = new GenericWay();
			genericWay.FuncCall();
			SeeOuterWork();
		}

		public static void SeeOuterWork()
		{
			int count = 0;
			int total = 0;
			Func<int> countUp = () => count++;

			for (int i = 0; i < 10; i++)
				total += countUp();

			Debug.WriteLine($"Totla = {total}");
		}
	}
}