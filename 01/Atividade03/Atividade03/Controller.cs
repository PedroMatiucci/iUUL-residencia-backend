using Atividade03;
using Atividade03.Q1;
using System;

static class Controller
{
	public static void Start()
	{
		//
		// UI > CONTROLLER > VALIDADOR > ERROS > VALIDADOR > CONTROLLER > CLIENTE
		//
        ClienteForm[] cfarr;
        Errors err = new();
		Cliente c = null;
		var carr = new List<Cliente>();

		// UI - CONTROLLER
		string strjson = ClienteForm.ReadJsonFile();
		cfarr = ClienteForm.ReadData(strjson);

        // CONTROLLER - VALIDADOR - ERROS - VALIDADOR - CONTROLLER
		foreach(var cf in cfarr)
		{
            while (!ValidaClienteForm.IsValid(cf, err))
                cf.ReadInvalidData(err);
			// CONTROLLER - CLIENTE
			c = new(cf);
			carr.Add(c);
        }

        //CONTROLLER - UI
        ClienteForm.PrintValidCliente(carr);

    }
}
