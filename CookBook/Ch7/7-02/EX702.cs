using System;
using System.Text.RegularExpressions;

namespace CookBook.Ch7
{
    public static class EX702
    {
        public static void Run()
        {
            // limit backtracking
            // Regex regex = new RegEx(bkTrkPattern, RegexOptions.None,
            //                  TimeSpan.FromMilliseconds(1000));
        }

        public static bool VerifyRegEx(string testPattern)
        {
            bool isValid = true;

            if ((testPattern?.Length ?? 0) > 0)
            {
                try
                {
                    Regex.Match("", testPattern);
                }
                catch (ArgumentException)
                {
                    isValid = false;
                }
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }

        public static void TestUserInputRegEx(string regEx)
        {
            if (VerifyRegEx(regEx))
                Console.WriteLine("This is a valid regular expression.");
            else
                Console.WriteLine("This is not a valid regular expression.");
        }
    }
}
