using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableReferences
{
    public class TradingDay
    {
        public DateTime Date { get; set; }
        public List<ExchangeRate> ExchangeRates { get; set; }
    }

    public class ExchangeRate
    {
        public string Symbol{ get; set; }
        public double EuroRate { get; set; }
    }
}
