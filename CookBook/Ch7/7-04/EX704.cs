using System;
using System.Text.RegularExpressions;

namespace CookBook.Ch7
{
    public static class EX704
    {
        public static void Run()
        {
            TestTokenize();
        }

        public static string[] Tokenize(string equation)
        {
            // [+, -, * , (, ), ^, \]
            Regex re = new Regex(@"([\+\-\*\(\)\^\\])");
            return re.Split(equation);
        }

        public static void TestTokenize()
        {
            foreach (var token in Tokenize("(y – 3)*(3111*x^21 + x + 320)"))
            {
                Console.WriteLine("String token= " + token.Trim());
            }
        }
    }
}
