using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CookBook.Ch5
{
    public static class EX514
    {
        public static void Run()
        {
            TestCallerInfoAttribs();
        }

        public static void TestCallerInfoAttribs()
        {
            try
            {
                LibraryMethod();
            }
            catch (Exception ex)
            {
                RecordCatchBlock(ex);
            }
        }

        public static void RecordCatchBlock(Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineName = 0)
        {
            string catchDetails =
                $"{ex.GetType().Name} caught in member \"{memberName}\" " +
                $"in catch block encompassing line {sourceLineName} " +
                $"in file {sourceFilePath} " +
                $"with message \"{ex.Message}\"";

            Console.WriteLine(catchDetails);

        }

        public static void LibraryMethod(
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            try
            {
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw new LibraryException(ex)
                {
                    CallerMemberName = memberName,
                    CallerFilePath = sourceFilePath,
                    CallerLineNumber = sourceLineNumber
                };
            }
        }
    }


}
