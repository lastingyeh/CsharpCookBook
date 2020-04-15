using System;

namespace CookBook.Ch4{
	public class GenericWay{
		Func<string, string> dwString = s => {
			Console.WriteLine(s);
			return s;
		};

		Func<int, int> dwInt = i =>{
			Console.WriteLine(i);
			return i;
		};

		public void FuncCall(){
			string retStr = dwString("Do some generic work");
			Console.WriteLine(retStr);

			int j = dwInt(5);
			Console.WriteLine(j);
		}
		
	}
}