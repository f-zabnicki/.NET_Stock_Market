using System;
using System.Collections.Generic;
using System.IO;

namespace Stock_Market
{
    class Program
    {
        public static string Path { get; set; }
        static void Main(string[] args)
        {
            var companies = FileOperator.ReadBaseInputFile();
            var generator = new StocksGenerator(companies);
            var stockOffers = generator.CurrentStocks;
            Path = FileOperator.SaveAndGetPathOfStocks(stockOffers);
            UIMethods userInterface = new UIMethods(stockOffers);
            userInterface.ShowMenu();
        }
    }
}
