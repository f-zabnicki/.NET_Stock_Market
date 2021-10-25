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
            Console.WriteLine("Do you want to see stocks in time period (y/n)?");
            switch (Console.ReadKey().KeyChar)
            {
                case 'y':
                    ShowStockInTimePeriod();
                    break;
                case 'n':
                    foreach (var item in Stocks)
                    {
                        Console.WriteLine($"{item.Name} {item.Value}");
                    }
                    Console.WriteLine("Press any button to back to menu");
                    Console.ReadKey();
                    Console.Clear();
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("Not implemented key, Try again.");
                    ShowStocks();
                    break;
            }
        }

        private void ShowStockInTimePeriod()
        {
            Console.WriteLine("Type in time period (from-to)");
            string input = Console.ReadLine();
            var fromTo = input.Split('-');
            var condition = Stocks.Where<Stocks>(o => o.TimeUnit >= int.Parse(fromTo[0]) && o.TimeUnit <= int.Parse(fromTo[1]));
            var selected = new List<Stocks>(condition);
            foreach (var item in selected)
            {
                Console.WriteLine($"{item.Name} {item.Value}");
            }
            Console.WriteLine("Press any button to back to main menu");
            Console.ReadLine();
            Console.Clear();
            ShowMenu();
        }

        private void SetWatcher()
        {
            ShowAvailableStocks();
            Console.WriteLine("Set watcher:");
            Watcher = new Watcher(Console.ReadLine());
            Console.Clear();
            Watcher.GetInfo();
            ShowMenu();
        }

        private void PurchasedHistory()
        {
            Console.WriteLine("Recenty purchased");
            FileOperator.GetPurchaseHistory();
            Console.WriteLine("Press any button to back to menu");
            Console.ReadLine();
            Console.Clear();
            ShowMenu();
        }
        private static void RunTheStockMarket(List<Stocks> stocks, Watcher setWatcher)
        {
            StartStockMarket.Run(stocks, setWatcher);
        }
        private void ShowAvailableStocks()
        {
            var companiesNames = FileOperator.ReadBaseInputFile();
            Console.WriteLine("Available stocks to set watcher for:");
            foreach (var item in companiesNames)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------");
        }
    }
}
