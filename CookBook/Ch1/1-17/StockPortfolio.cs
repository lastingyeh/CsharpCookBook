using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBook.Ch1.EX1_17
{
    public class StockPortfolio : IEnumerable<Stock>
    {
        List<Stock> _stocks;
        public StockPortfolio()
        {
            _stocks = new List<Stock>();
        }
        public void Add(string ticker, double gainLoss)
        {
            _stocks.Add(new Stock() { Ticker = ticker, GainLoss = gainLoss });
        }
        public IEnumerable<Stock> GetWorstPerformers(int topNumber) =>
            _stocks.OrderBy((Stock stock) => stock.GainLoss).Take(topNumber);
        public void SellStocks(IEnumerable<Stock> stocks)
        {
            foreach (Stock s in stocks)
            {
                _stocks.Remove(s);
            }
        }
        public void PrintPortfolio(string title)
        {
            Console.WriteLine(title);
            _stocks.DisplayStocks();
        }

        public void DisplayStocks()
        {
            foreach (Stock s in _stocks)
            {
                string gainedOrLost = s.GainLoss > 0 ? "gained" : "lost";
                Console.WriteLine($"\t({s.Ticker} {gainedOrLost} {s.GainLoss})");
            }
        }
        public IEnumerator<Stock> GetEnumerator() => _stocks.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

    public static class StocksExtensions
    {
        public static void DisplayStocks(this IEnumerable<Stock> stocks)
        {
            foreach (Stock stock in stocks)
            {
                string gainOrLost = stock.GainLoss > 0 ? "gained" : "lost";
                Console.WriteLine($"\t({stock.Ticker}) {gainOrLost} {stock.GainLoss}");
            }
        }
    }
}
