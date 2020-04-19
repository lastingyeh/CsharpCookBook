using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Ch5
{
    public static class EX515
    {
        public static void Run()
        {
            TestHandlingAsyncExceptionsAsync().Wait();
        }
        public async static Task TestHandlingAsyncExceptionsAsync()
        {
            // single async caller
            try
            {
                await SteveCreateSomeCodeAsync();
            }
            catch (DefectCreatedException dce)
            {
                Console.WriteLine($"Steve introduced a Defect: {dce.Message}");
            }

            // multiple async WaitAll
            Task jayCode = JayCreateSomeCodeAsync();
            Task tomCode = TomCreateSomeCodeAsync();
            Task sethCode = SethCreateSomeCodeAsync();

            Task teamComplete = Task.WhenAll(new Task[] { jayCode, tomCode, sethCode });

            try
            {
                await teamComplete;
            }
            catch
            {
                var defectMessages = teamComplete.Exception?.InnerExceptions.
                    Select(e => e.Message).ToList();
                defectMessages?.ForEach(m => Console.WriteLine($"{m}"));
            }

            try
            {
                try
                {
                    await SteveCreateSomeCodeAsync();
                }
                catch (DefectCreatedException dce)
                {
                    Console.WriteLine(dce.ToString());
                    await WriteEventLogEntryAsync("ManagerApplication", dce.Message, EventLogEntryType.Error);
                    throw;
                }
            }
            catch (DefectCreatedException dce)
            {
                Console.WriteLine(dce.ToString());
            }
        }

        public async static Task WriteEventLogEntryAsync(string source, string message, EventLogEntryType type)
        {
            await Task.Factory.StartNew(() => EventLog.WriteEntry(source, message, type));
        }

        public async static Task SteveCreateSomeCodeAsync()
        {
            Random rnd = new Random();
            await Task.Delay(rnd.Next(100, 1000));
            throw new DefectCreatedException("Null Reference", 42);
        }

        public async static Task JayCreateSomeCodeAsync()
        {
            Random rnd = new Random();
            await Task.Delay(rnd.Next(100, 1000));
            throw new DefectCreatedException("Ambiguous Match", 2);
        }

        public async static Task TomCreateSomeCodeAsync()
        {
            Random rnd = new Random();
            await Task.Delay(rnd.Next(100, 1000));
            throw new DefectCreatedException("Quota Exceeded", 11);
        }

        public async static Task SethCreateSomeCodeAsync()
        {
            Random rnd = new Random();
            await Task.Delay(rnd.Next(100, 1000));
            throw new DefectCreatedException("Out of Memory", 8);
        }
    }
}
