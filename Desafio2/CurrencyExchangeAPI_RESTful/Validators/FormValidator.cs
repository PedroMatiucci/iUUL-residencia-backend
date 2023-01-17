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
        public string? OriginChoice { get; set; }
        
        internal void TryValidateCurrency(string choice,Currency c)
        {
            if (choice == "") throw new ExitApplicationCodeException();
            if(choice.Length != 3) throw new ArgumentLenghtException("[ERROR] Invalid currency code lenght.");
            if(!c.IsValidSymbol(choice)) throw new CurrencyNotValidException("[ERROR] Currency code unexistent.");
            if (OriginChoice != null)
                if (OriginChoice == choice) throw new SameCurrencyException("[ERROR] Currencies cannot be of the same type for conversion.");
            else OriginChoice = choice;
        }

        internal static void TryValidateAmount(string amount)
        {
            if (!float.TryParse(amount, out float value)) throw new InvalidAmountException();
            if (value <= 0) throw new InsufficientAmountException();
        }
    }
}
