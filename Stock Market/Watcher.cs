using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Market
{
    class Watcher
    {
        public int Value { get; }
        public string StockName { get; }
        public Watcher(string input)
        {
            var watchers = GetWatcherFromString(input);
            Value = watchers.Item1;
            StockName = watchers.Item2;
        }
        public Tuple<int, string> GetWatcherFromString(string input)
        {
            var inputValues = input.Split(' ');
            int value;
            if (inputValues.Length < 2)
            {
                value = Int32.Parse(inputValues[0]);
                return Tuple.Create(value, String.Empty);
            }
            else
            {
                value = Int32.Parse(inputValues[1]);
                return Tuple.Create(value ,inputValues[0].ToUpper());
            }
            throw new NotSupportedException("Wrong values for watcher. Please check syntax and try again");
        }
        public void GetInfo()
        {
            if (StockName == "")
                Console.WriteLine($"Watcher set for stocks under {Value} has been set");
            else
                Console.WriteLine($"Watcher for {StockName} for value under {Value} has been set");
        }
    }
}
