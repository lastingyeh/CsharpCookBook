using System;
using System.Text.RegularExpressions;

namespace CookBook.Ch7
{
    public static class EX703
    {
        public static void Run()
        {
            TestComplexReplace();
        }

        public static string MatchHandler(Match theMatch)
        {
            if (theMatch.Value.StartsWith("ControlID_", StringComparison.Ordinal))
            {
                // obtain the numeric value of the top attribute
                // [-]{0-n}, \d{0-n}
                Match topAttributeMatch = Regex.Match(theMatch.Value, @"Top=([-]*\d*)");

                if (topAttributeMatch.Success)
                {
                    if (topAttributeMatch.Groups[1].Value.Trim().Equals(""))
                    {
                        // if blank, set to zero
                        return theMatch.Value.Replace(
                            topAttributeMatch.Groups[0].Value.Trim(), "Top=0");
                    }

                    if (topAttributeMatch.Groups[1].Value.Trim().StartsWith("-",
                        StringComparison.Ordinal))
                    {
                        // if only a negative sign (syntax error), set to zero
                        return theMatch.Value.Replace(
                            topAttributeMatch.Groups[0].Value.Trim(), "Top=0");
                    }
                    else
                    {
                        long controlValue = long.Parse(topAttributeMatch.Groups[1].Value,
                            System.Globalization.NumberStyles.Any);

                        if (controlValue < 0 || controlValue > 5000)
                        {
                            return theMatch.Value.Replace(
                                topAttributeMatch.Groups[0].Value.Trim(),
                                "Top=0");
                        }
                    }
                }
            }
            return theMatch.Value;
        }

        public static void ComplexReplace(string matchPattern, string source)
        {
            MatchEvaluator replaceCallback = new MatchEvaluator(MatchHandler);
            //Regex re = new Regex(matchPattern, RegexOptions.Multiline);
            //string newString = re.Replace(source, replaceCallback);
            string newString = Regex.Replace(source, matchPattern, replaceCallback);

            Console.WriteLine($"Replaced String = {newString}");
        }

        public static void TestComplexReplace()
        {
            string matchPattern = "(ControlID_.*)";
            string source = @"WindowID=Main
                            ControlID_TextBox1 Top=-100 Left=0 Text=BLANK
                            ControlID_Label1 Top=9999990 Left=0 Caption=Enter Name Here
                            ControlID_Label2 Top= Left=0 Caption=Enter Name Here";

            ComplexReplace(matchPattern, source);
        }
    }
}
