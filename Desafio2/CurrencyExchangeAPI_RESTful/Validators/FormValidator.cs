using CurrencyExchangeAPI_RESTful.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchangeAPI_RESTful.Validators
{
    internal class FormValidator
    {
        private static string? OriginChoice { get; set; }
        internal bool IsValid(string? choice)
        {
            if(choice == null) return false;
            if(choice.Length != 3) return false;
            if(!IsValidCurrency(choice)) return false;
            if (OriginChoice != null)
                if (OriginChoice == choice) return false;
            else OriginChoice = choice;

            return true;
        }

        private static bool IsValidCurrency(string choice)
        {
            foreach (var c in Currency.Symbols)
            {
                if(c.Code == choice) return true;
            }
            return false;
        }
    }
}
