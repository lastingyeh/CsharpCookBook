using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookBook.Ch2
{
    public static class EX210
    {
        private static ConcurrentDictionary<int, Fan> stadiumGates =
            new ConcurrentDictionary<int, Fan>();
        private static bool monitorGates = true;

        public static async Task Run()
        {
            List<Fan> fansAttending = new List<Fan>();

            for (int i = 0; i < 100; i++)
            {
                fansAttending.Add(new Fan() { Name = "Fan" + i });
            }

            Fan[] fans = fansAttending.ToArray();

            // ConcurrentDictionary one fan entry only
            int gateCount = 10;
            Task[] entryGates = new Task[gateCount];
            Task[] securityMonitors = new Task[gateCount];
            // entry tasks
            for (int gateNumber = 0; gateNumber < gateCount; gateNumber++)
            {
                int GateNum = gateNumber;
                int GateCount = gateCount;
                Action action = delegate () { AdmitFans(fans, GateNum, GateCount); };
                entryGates[GateNum] = Task.Run(action);
            }
            // monitor tasks
            for (int gateNumber = 0; gateNumber < gateCount; gateNumber++)
            {
                int GateNum = gateNumber;
                Action action = delegate () { MonitorGates(GateNum); };
                securityMonitors[gateNumber] = Task.Run(action);
            }

            await Task.WhenAll(entryGates);

            monitorGates = false;
        }

        private static void AdmitFans(Fan[] fans, int gateNumber, int gateCount)
        {
            Random rnd = new Random();
            int fansPerGate = fans.Length / gateCount;
            int start = gateNumber * fansPerGate;
            int end = start + fansPerGate - 1;

            for (int f = start; f <= end; f++)
            {
                Console.WriteLine($"Admitting {fans[f].Name} through gate {gateNumber}");
                var fanAtGate =
                    stadiumGates.AddOrUpdate(gateNumber, fans[f], (key, fanInGate) =>
                    {
                        Console.WriteLine($"{fanInGate.Name} was replaced by "
                            + $"{fans[f].Name} in gate {gateNumber}");

                        return fans[f];
                    });

                // check ticket && security
                Thread.Sleep(rnd.Next(500, 2000));
                // allow to entry
                fans[f].Admitted = DateTime.Now;
                fans[f].AdmittanceGateNumber = gateNumber;
                // remove from stadiumGates
                Fan fanAdmitted;
                if (stadiumGates.TryRemove(gateNumber, out fanAdmitted))
                {
                    Console.WriteLine($"{fanAdmitted.Name} entering event from gate "
                        + $"{fanAdmitted.AdmittanceGateNumber} on {fanAdmitted.Admitted.ToShortTimeString()}");
                }
                else
                {
                    Console.WriteLine($"{fanAdmitted.Name} held by security " +
                        $"at gate {fanAdmitted.AdmittanceGateNumber}");
                }
            }
        }

        private static void MonitorGates(int gateNumber)
        {
            Random rnd = new Random();

            while (monitorGates)
            {
                Fan currentFanInGate;
                if (stadiumGates.TryGetValue(gateNumber, out currentFanInGate))
                {
                    Console.WriteLine($"Monitor: {currentFanInGate} is in Gate {gateNumber}");
                }
                else
                {
                    Console.WriteLine($"Monitor: No fan is in Gate {gateNumber}");
                }

                // Check security (buffer time)
                Thread.Sleep(rnd.Next(500, 5000));
            }
        }
    }
}
