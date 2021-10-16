using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Market
{
    public class Stocks
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int TimeUnit { get; }
        public Stocks(string name, int values, int timeUnit)
        {
            Name = name;
            Value = values;
            TimeUnit = timeUnit;
        }
        public Stocks()
        {
            
        }
    }
}
