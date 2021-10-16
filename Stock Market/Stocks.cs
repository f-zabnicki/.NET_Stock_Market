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
        public Stocks(string name, int values)
        {
            Name = name;
            Value = values;
        }
        public Stocks()
        {
            
        }
    }
}
