using CurrencyExchangeAPI_RESTful.Exceptions;
using CurrencyExchangeAPI_RESTful.Model;
using CurrencyExchangeAPI_RESTful.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchangeAPI_RESTful.View
{
    internal static class UI
    {
        public static Exchange? Form(FormValidator formValidator)
        {
            UI.PrintCurrencies();

            
            FROM:
            Console.Write("\nFrom: ");
            string? from = Console.ReadLine();
            try
            {
                formValidator.IsCurrencyValid(from);
            }
            catch (ArgumentNullException) { return null; }
            catch(MyCurrencyExchangeAPIException){ goto FROM; }


            TO:
            Console.Write("\nTo: ");
            string? to = Console.ReadLine();
            try
            {
                formValidator.IsCurrencyValid(to);
            }
            catch (MyCurrencyExchangeAPIException) { goto TO; }

            
            AMOUNT:
            Console.Write("\nAmount: ");
            string? amount = Console.ReadLine();
            try
            {
                formValidator.IsAmountValid(amount);
            }
            catch (MyCurrencyExchangeAPIException) { goto AMOUNT; }


            return new Exchange(from,to,float.Parse(amount));
        }

        public static void PrintCurrencies()
        {
            int count = 1;
            foreach (var s in Currency.Symbols)
            {
                Console.Write($"[{s.Code}]\t");
                if (count % 4 == 0) Console.WriteLine();
                ++count;
            }
        }

        internal static void Print(Exchange ex,Conversion cv)
        {
            Console.WriteLine($"----{ex.Origin} to {ex.Destiny}----");
            Console.WriteLine($"\t\t{ex.Amount} = {cv.Result}\t\t");
        }
    }
}
