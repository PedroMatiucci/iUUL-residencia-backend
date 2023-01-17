using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchangeAPI_RESTful.Model
{
    internal class Currency
    {
        public List<Symbol> Symbols { get; private set; }

        public Currency(List<Symbol> s)
        {
            Symbols = s;
        }

        public List<Symbol> GetSymbols()
        {
            return Symbols;
        }

        public bool IsValidSymbol(string choice)
        {
            foreach (var c in Symbols)
            {
                if (c.Code == choice) return true;
            }
            return false;
        }
    }
}
