using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CookBook.Ch7
{
    public static class EX705
    {
        public static void Run()
        {
            TeestGetLine();
        }

        public static List<string> GetLines(string source,
            string pattern, bool isFileName)
        {
            List<string> matchedLines = new List<string>();

            if (isFileName)
            {
                using (FileStream fs = new FileStream(source,
                    FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        Regex re = new Regex(pattern, RegexOptions.Multiline);
                        string text = string.Empty;

                        while (text != null)
                        {
                            text = sr.ReadLine();
                            if (text != null)
                            {
                                // run the regex on each line in the string
                                if (re.IsMatch(text))
                                {
                                    // get the line if a match was found
                                    matchedLines.Add(text);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // run the regex once on the entire string.
                Regex re = new Regex(pattern, RegexOptions.Multiline);
                MatchCollection matches = re.Matches(source);

                int lastLineStartPos = -1;
                int lastLineEndPos = -1;

                foreach (Match m in matches)
                {
                    int lineStartPos = GetBeginningOfLine(source, m.Index);
                    int lineEndPos = GetEndOfLine(source, m.Index + m.Length - 1);
                    // If this is not a duplicate line, add it.
                    if (lastLineStartPos != lineStartPos &&
                        lastLineEndPos != lineEndPos)
                    {
                        string line = source.Substring(lineStartPos,
                            lineEndPos - lineStartPos);
                        matchedLines.Add(line);

                        // reset line pos
                        lastLineStartPos = lineStartPos;
                        lastLineEndPos = lineEndPos;
                    }
                }

            }
            return matchedLines;
        }

        public static int GetBeginningOfLine(string text, int startPointOfMatch)
        {
            if (startPointOfMatch > 0)
            {
                --startPointOfMatch;
            }

            if (startPointOfMatch >= 0 && startPointOfMatch < text?.Length)
            {
                // Move to the left until the first '\n char is found.
                for (int index = startPointOfMatch; index >= 0; index--)
                {
                    if (text?[index] == '\n')
                        return index + 1;
                }
                return 0;
            }
            return startPointOfMatch;
        }

        public static int GetEndOfLine(string text, int endPointOfMatch)
        {
            if (endPointOfMatch >= 0 && endPointOfMatch < text?.Length)
            {
                // Move to the right until the first '\n char is found.
                for (int index = endPointOfMatch; index < text.Length; index++)
                {
                    if (text?[index] == '\n')
                    {
                        return index;
                    }
                }
                return text.Length;
            }
            return endPointOfMatch;
        }

        public static void TeestGetLine()
        {
            Console.WriteLine();
            List<string> lines = GetLines(@"../../../Res/TestFile.txt", "Line", true);
            foreach (var s in lines)
            {
                Console.WriteLine($"MatchedLine: {s}");
            }

            Console.WriteLine();
            lines = GetLines("Line1\r\nLine2\r\nLine3\nLine4", "Line", false);
            foreach (var s in lines)
            {
                Console.WriteLine($"MatchedLine: {s}");
            }
        }
    }
}
