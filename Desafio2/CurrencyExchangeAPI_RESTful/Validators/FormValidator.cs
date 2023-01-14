using CurrencyExchangeAPI_RESTful.Model;
using CurrencyExchangeAPI_RESTful.Exceptions;
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
        
        internal bool IsCurrencyValid(string? choice)
        {
            if(choice == null) throw new ArgumentNullException("[ERROR] Currency cannot be null.");
            if(choice.Length != 3) throw new ArgumentLenghtException("[ERROR] Invalid currency code lenght.");
            if(!IsValidCurrency(choice)) throw new CurrencyNotValidException("[ERROR] Currency code unexistent.");
            if (FormValidator.OriginChoice != null)
                if (FormValidator.OriginChoice == choice) throw new SameCurrencyException("[ERROR] Currencies cannot be of the same type for conversion.");
            else FormValidator.OriginChoice = choice;

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

        internal void IsAmountValid(string? amount)
        {
            if (!float.TryParse(amount, out float value)) throw new InvalidAmountException();
            if (value < 0) throw new NegativeAmountException();
        }
    }
}
