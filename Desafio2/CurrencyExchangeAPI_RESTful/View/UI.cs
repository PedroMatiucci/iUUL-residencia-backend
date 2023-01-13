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
        public static Exchange Form(FormValidator formValidator)
        {
            UI.PrintCurrencies();

            Console.Write("\nFrom: ");
            string? from = Console.ReadLine();

            formValidator.IsValid(from);

            Console.Write("\nTo: ");
            string? to = Console.ReadLine();

            formValidator.IsValid(to);

            Console.Write("\nAmount: ");
            string? amount = Console.ReadLine();

            //...

            return new Exchange();
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
