using System;

namespace CookBook.Ch4
{
	public class DirectAssignmentWay
	{
		delegate int DoWork(string work);

		public void WorkItOut()
		{
			DoWork dw = DoWorkMethodImpl;
			int i = dw("Do some direct assignment work");
		}

		public int DoWorkMethodImpl(string s)
		{
			Console.WriteLine(s);
			return s.GetHashCode();
		}
	}
}