using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBook.Ch1._1_16
{
    public static class EX116
    {
        delegate void CalculateEarnings(SalesPerson sp);

        static CalculateEarnings GetEarningsCalculator(decimal quarterlySales, decimal bonusRate)
        {
            return salesPerson =>
            {
                decimal quarterlyQuota = (salesPerson.AnnualQuota / 4);

                if (quarterlySales < quarterlyQuota)
                {
                    salesPerson.Commission = 0;
                }
                else if (quarterlySales > (quarterlyQuota * 2.0m))
                {
                    decimal baseCommission = quarterlyQuota * salesPerson.CommissionRate;

                    salesPerson.Commission = (baseCommission +
                    ((quarterlySales - quarterlyQuota) * (salesPerson.CommissionRate * (1 + bonusRate))));
                }
                else
                {
                    salesPerson.Commission = salesPerson.CommissionRate * quarterlySales;
                }
            };
        }

        static SalesPerson[] salesPeople =
        {
            new SalesPerson{Name="Chas", AnnualQuota=100000m, CommissionRate=0.10m},
            new SalesPerson{Name="Ray", AnnualQuota=200000m, CommissionRate=0.025m},
            new SalesPerson{Name="Biff", AnnualQuota=50000m, CommissionRate=0.001m}
        };

        static QuarterlyEarning[] quarterlyEarnings =
        {
            new QuarterlyEarning(){Name="Q1", Earnings=65000m, Rate=0.1m},
            new QuarterlyEarning(){Name="Q2", Earnings=20000m, Rate=0.1m},
            new QuarterlyEarning(){Name="Q3", Earnings=37000m, Rate=0.1m},
            new QuarterlyEarning(){Name="Q4", Earnings=110000m, Rate=0.15m},
        };

        public static void Run()
        {
            var calculators = from e in quarterlyEarnings
                              select new
                              {
                                  Calculator = GetEarningsCalculator(e.Earnings, e.Rate),
                                  QuarterlyEarning = e
                              };

            decimal annualEarnings = 0;

            foreach (var c in calculators)
            {
                WriteQuarterlyReport(c.QuarterlyEarning.Name,
                    c.QuarterlyEarning.Earnings, c.Calculator, salesPeople);

                annualEarnings += c.QuarterlyEarning.Earnings;
            }

            WriteCommissionReport(annualEarnings, salesPeople);
        }

        static void WriteQuarterlyReport(string quarter, decimal quarterlySales,
            CalculateEarnings eCalc, SalesPerson[] salesPeople)
        {
            // Currency format string
            Console.WriteLine($"{quarter} Sales Earnings on Quarterly Sales of {quarterlySales.ToString("C")}:");

            foreach (SalesPerson salesPerson in salesPeople)
            {
                eCalc(salesPerson);
                // Currency format string
                Console.WriteLine($"\tSales person {salesPerson.Name} " +
                    $"made a commission of : " +
                    $"{salesPerson.Commission.ToString("C")}");
            }
        }

        static void WriteCommissionReport(decimal annualEarnings, SalesPerson[] salesPeople)
        {
            decimal revenueProduced = ((annualEarnings) / salesPeople.Length);
            Console.WriteLine("");

            Console.WriteLine($"Annual Earnings were {annualEarnings.ToString("C")}");
            Console.WriteLine("");

            var whoToCan = from salesPerson in salesPeople
                           select new
                           {
                               CanThem = (revenueProduced * 0.2m) < salesPerson.TotalCommission,
                               salesPerson.Name,
                               salesPerson.TotalCommission,
                           };

            foreach (var salesPersonInfo in whoToCan)
            {
                Console.WriteLine($"\t\tPaid {salesPersonInfo.Name} " +
                    $"{salesPersonInfo.TotalCommission.ToString("C")} to produce " +
                    $"{revenueProduced.ToString("C")}");

                if (salesPersonInfo.CanThem)
                {
                    Console.WriteLine($"\t\t\tFIRE {salesPersonInfo.Name}!");
                }
            }
        }

    }
}
