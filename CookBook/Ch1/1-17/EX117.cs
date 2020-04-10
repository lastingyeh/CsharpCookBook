using System;

namespace CookBook.Ch1._1_17
{
    public static class EX117
    {
        public static void Run()
        {
            StockPortfolio tech = new StockPortfolio()
            {
                {"OU81",-10.5 },
                {"C#6VR",2.0 },
                {"PCKD",12.3 },
                {"BTML",0.5 },
                {"NOVB",-35.2 },
                {"MGDCD",15.7 },
                {"GNRCS",4.0 },
                {"FNCTR",9.16 },
                {"LMBDA",9.12 },
                {"PCLS",6.11 },
            };

            tech.PrintPortfolio("Starting Portfolio");
            var worstPerformers = tech.GetWorstPerformers(3);
            Console.WriteLine("Selling the worst performers:");
            worstPerformers.DisplayStocks();
            tech.SellStocks(worstPerformers);
            tech.PrintPortfolio("After Selling Worst 3 Performers");
        }
    }
}
