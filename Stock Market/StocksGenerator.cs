using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Market
{
    class StocksGenerator
    {
        public List<Stocks> CurrentStocks{ get; }
        Random random = new Random();
        public StocksGenerator(string[] companies)
        {
            CurrentStocks = new List<Stocks>();
            for (int i = 0; i < 1000; i++)
            {
                CurrentStocks.Add(new Stocks(
                    companies[random.Next(0, companies.Length)],
                    random.Next(10, 100), i));
            }
        }
    }
}
