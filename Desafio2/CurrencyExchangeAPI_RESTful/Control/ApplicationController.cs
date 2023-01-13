using CurrencyExchangeAPI_RESTful.Model;
using CurrencyExchangeAPI_RESTful.Validators;
using CurrencyExchangeAPI_RESTful.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchangeAPI_RESTful.Control
{
    internal class ApplicationController
    {
        public static async void Start()
        {
            // Open and configure client
            HttpClientController client = new HttpClientController();
            client.ConfigureHttpClient();

            // Get list of available currencies worldwide, generate objects and save symbols list
            var symbols = await client.GetSymbolsAsync();
            Currency.Symbols = symbols;

            // Get user inputs, do conversion and generate object
            FormValidator fv = new();
            Exchange exchangeParams = UI.Form(fv);
            Conversion conversion = await client.ConvertAsync(exchangeParams);

            // Finally, print stuff in a human-readable-format
            UI.Print(exchangeParams,conversion);


            Console.WriteLine("\nEnter a key to exit application...");
            Console.ReadKey();
        }
    }
}
