using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Market
{
    class UIMethods
    {
        private List<Stocks> Stocks{ get; set; }
        private Watcher Watcher { get; set; }
        public UIMethods(List<Stocks> currentStocks)
        {
            Stocks = new List<Stocks>();
            Stocks = currentStocks;
        }
        private void MakeAction(char key)
        {
            Console.Clear();
            switch (key)
            {
                case '1':
                    ShowStocks();
                    break;
                case '2':
                    SetWatcher();
                    break;
                case '3':
                    PurchasedHistory();
                    break;
                case '4':
                    RunTheStockMarket(Stocks, Watcher);
                    break;
                case '0':
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("Not implemented key, please try again\n\n");
                    ShowMenu();
                    break;
            }
        }
        public void ShowMenu()
        {
            Console.WriteLine("Welcome to the Stock Market!");
            Console.WriteLine();
            Console.WriteLine("1 Show stocks and their value");
            Console.WriteLine("2 Set watcher for stocks");
            Console.WriteLine("3 Recently purchased stocks");
            Console.WriteLine();
            Console.WriteLine("4 Run the stock market");
            MakeAction(Console.ReadKey().KeyChar);
        }
        private void ShowStocks()
        {
            foreach (var item in Stocks)
            {
                Console.WriteLine($"{item.Name} {item.Value}");
            }
            Console.WriteLine("Press any button to back to menu");
            Console.ReadKey();
            Console.Clear();
            ShowMenu();
        }
        private void SetWatcher()
        {
            Console.WriteLine("Set watcher:");
            var watcher = Console.ReadLine();
            Watcher = new Watcher(watcher);
            Console.Clear();
            if (Watcher.StockName == "")
                Console.WriteLine($"Watcher set for stocks under {Watcher.Value} has been set");
            else
                Console.WriteLine($"Watcher for {Watcher.StockName} for value under {Watcher.Value} has been set");
            ShowMenu();
        }
        private void PurchasedHistory()
        {
            Console.WriteLine("Recenty purchased");
            var orders = FileOperator.GetPurchaseHistory();
            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Name} {item.Value}");
            }
            Console.WriteLine("Press any button to back to menu");
            Console.ReadLine();
            Console.Clear();
            ShowMenu();
        }
        private static void RunTheStockMarket(List<Stocks> stocks, Watcher setWatcher)
        {
            StartStockMarket.Run(stocks, setWatcher);
        }
    }
}
