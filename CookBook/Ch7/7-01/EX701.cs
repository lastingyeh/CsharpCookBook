using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CookBook.Ch7
{
    public static class EX701
    {
        public static void Run()
        {
            // 1. Unnamed
            // string matchPattern = @"\\\\(\w*)\\(\w*)\\";
            // Unnamed syntax
            // string group1 = theMatch.Groups[1].Value;
            // string group2 = theMatch.Groups[2].Value;

            // 2. Named syntax
            // string group1 = theMatch.Groups["Group1_Name"].Value;
            // string group2 = theMatch.Groups["Group2_Name"].Value;

            TestExtractGroupings();
        }

        public static List<Dictionary<string, Group>> ExtractGrouping(string source,
            string matchPattern, bool wantInitialMatch)
        {
            List<Dictionary<string, Group>> keyedMathes =
                new List<Dictionary<string, Group>>();
            int startingElement = 1;

            if (wantInitialMatch)
                startingElement = 0;

            Regex re = new Regex(matchPattern, RegexOptions.Multiline);
            MatchCollection theMatches = re.Matches(source);

            foreach (Match m in theMatches)
            {
                Dictionary<string, Group> groupings = new Dictionary<string, Group>();
                // wantInitialMatch = false
                // result =
                // Key / Value = TheService / MyService
                // Key / Value = TheServer / MyServer
                // Key / Value = TheService / MyService2
                // Key / Value = TheServer / MyServer2
                for (int counter = startingElement; counter < m.Groups.Count; counter++)
                {
                    // if we had just returned the MatchCollection directly, the
                    // GroupNameFromNumber method would not be available to use.
                    groupings.Add(re.GroupNameFromNumber(counter), m.Groups[counter]);
                }
                keyedMathes.Add(groupings);
            }
            return keyedMathes;
        }

        public static void TestExtractGroupings()
        {
            string source = @"Path = ""\\MyServer\MyService\MyPath;
                                      \\MyServer2\MyService2\MyPath2\""";
            string matchPattern = @"\\\\(?<TheServer>\w*)\\(?<TheService>\w*)\\";

            foreach (Dictionary<string, Group> grouping in
                ExtractGrouping(source, matchPattern, true))
            {
                foreach (KeyValuePair<string, Group> kvp in grouping)
                {
                    Console.WriteLine($"Key/Value = {kvp.Key} / {kvp.Value}");
                }
                Console.WriteLine("");
            }
        }



    }
}
