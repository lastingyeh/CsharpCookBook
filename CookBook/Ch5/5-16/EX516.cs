using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch5
{
    public static class EX516
    {
        public static void Run()
        {
            Console.WriteLine("Simulating database call timeout");
            try
            {
                ProtectedCallTheDatabase("timeout");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception catch caught a database exception: {ex.Message}");
            }
            Console.WriteLine("");

            Console.WriteLine("Simulating database call login failure");
            try
            {
                ProtectedCallTheDatabase("loginfail");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception catch caught a database excpeption: {ex.Message}");
            }
            Console.WriteLine("");

            Console.WriteLine("Simulating successful database call");
            try
            {
                ProtectedCallTheDatabase("noerror");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception catch caught a database excpeption: {ex.Message}");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void ProtectedCallTheDatabase(string problem)
        {
            try
            {
                CallTheDatabase(problem);
                Console.WriteLine("No error on database call");
            }
            catch (DatabaseException dex) when (dex.Number == -2)
            {
                Console.WriteLine("DatabaseException catch caught a database exception: " +
                    $"{dex.Message}");
            }
        }

        private static void CallTheDatabase(string problem)
        {
            switch (problem)
            {
                case "timeout":
                    throw new DatabaseException(
                        "Timeout expired. The timeout period elapsed prior to " +
                        "completion of the operation or the server is not " +
                        "responding. (Micorsoft SQL Server, Error: -2).")
                    {
                        Number = -2,
                        Class = 11
                    };
                case "loginfail":
                    throw new DatabaseException("Login failed for user"){ Number = 18456 };
            }
        }
    }
}
