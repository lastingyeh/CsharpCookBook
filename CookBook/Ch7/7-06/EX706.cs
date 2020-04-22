using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CookBook.Ch7
{
    public static class EX706
    {
        public static void Run()
        {
            TestOccurrencesOf();
        }

        public static Match FindOccurrenceOf(string source,
            string pattern, int occurrence)
        {
            if (occurrence < 1)
                throw new ArgumentException("Cannot be less than 1", nameof(occurrence));
            // make zero-based
            --occurrence;

            Regex re = new Regex(pattern, RegexOptions.Multiline);
            MatchCollection matches = re.Matches(source);

            if (occurrence >= matches.Count)
                return null;

            return matches[occurrence];
        }

        public static List<Match> FindEachOccurrenceOf(string source, string pattern,
            int occurrence)
        {
            if (occurrence < 1)
                throw new ArgumentException("Cannot be less than 1", nameof(occurrence));

            List<Match> occurrences = new List<Match>();

            Regex re = new Regex(pattern, RegexOptions.Multiline);
            MatchCollection matches = re.Matches(source);

            for (int index = (occurrence - 1); index < matches.Count; index += occurrence)
            {
                occurrences.Add(matches[index]);
            }
            return occurrences;
        }

        public static void TestOccurrencesOf()
        {
            // find second 'two'
            Match matchResult = FindOccurrenceOf(
                "one two three one two three one two three one"
                + " two three one two three one two three",
                "two", 2);

            Console.WriteLine($"{matchResult?.ToString()}\t{matchResult?.Index}");

            Console.WriteLine();

            // find 2, 4, 6, ... 'one'
            List<Match> results = FindEachOccurrenceOf(
                "one two three one two three one two three one"
                + " two three one two three one two three",
                "one", 2);

            foreach (var m in results)
            {
                Console.WriteLine($"{m.ToString()}\t{m.Index}");
            }
        }
    }
}
