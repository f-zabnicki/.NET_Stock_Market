using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Market
{
    static class StartStockMarket
    {
        static public void Run(List<Stocks> stocks, Watcher settedWatcher)
        {
            IEnumerable<Stocks> toBuy;
            if (settedWatcher.StockName == "")
                toBuy = stocks.Where<Stocks>(o => o.Value < settedWatcher.Value);
            else
                toBuy = stocks.Where<Stocks>(o => o.Name == settedWatcher.StockName &&
                                             o.Value < settedWatcher.Value);
            var purchased = new List<Stocks>(toBuy);
            FileOperator.CreatePurchaseHistory(purchased);
            foreach (var item in stocks)
            {
                Console.WriteLine(item.Name + item.Value);
            }
            Console.WriteLine($"Purchased {purchased.Count} stocks.");
            Console.ReadLine();
        }
    }
}
