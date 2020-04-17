using System;
using System.Diagnostics;
using System.Linq;

namespace CookBook.Ch5
{
    public static class EX509
    {
        public enum ProcessRespondingState
        {
            Responding,
            NotResponding,
            Unknown
        }

        public static ProcessRespondingState GetProcessState(Process p)
        {
            if (p.MainWindowHandle == IntPtr.Zero)
            {
                Trace.WriteLine($"{p.ProcessName} does not have a MainWindowHandle");
                return ProcessRespondingState.Unknown;
            }

            if (!p.Responding)
                return ProcessRespondingState.NotResponding;

            return ProcessRespondingState.Responding;
        }

        public static void Run()
        {
            var processes = Process.GetProcesses().ToArray();

            Array.ForEach(processes, p =>
            {
                var processState = GetProcessState(p);
                switch (processState)
                {
                    case ProcessRespondingState.NotResponding:
                        Console.WriteLine($"{p.ProcessName} is not responding.");
                        break;
                    case ProcessRespondingState.Responding:
                        Console.WriteLine($"{p.ProcessName} is responding.");
                        break;
                    case ProcessRespondingState.Unknown:
                        Console.WriteLine($"{p.ProcessName}'s state could not be determined.");
                        break;
                }
            });
        }
    }
}
