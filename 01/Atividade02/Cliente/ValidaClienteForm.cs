using Atividade02.Q1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02
{
    internal class ValidaClienteForm
    {
        private enum EC{C,S,V,D}

        internal bool IsValid(ClienteForm cf)
        {
            bool ClienteValido = true;

            //Valida Nome
            if (cf.Nome.Length <= 4)
                ClienteValido = false;

            //Valida CPF
            if (cf.CPF.Length != 11)
                ClienteValido = false;

            if (cf.CPF == "11111111111" ||
                cf.CPF == "22222222222" ||
                cf.CPF == "33333333333" ||
                cf.CPF == "44444444444" ||
                cf.CPF == "55555555555" ||
                cf.CPF == "66666666666" ||
                cf.CPF == "77777777777" ||
                cf.CPF == "88888888888" ||
                cf.CPF == "99999999999")
                ClienteValido = false;

            char[] CPFArray = cf.CPF.ToCharArray();

            char primeiroDigitoVerificador = CPFArray[^2];
            char segundoDigitoVerificador = CPFArray[^1];

            int resultado, multiplicador, contador = 0, soma = 0;
            for (multiplicador = 10; multiplicador >= 2; multiplicador--)
            {
                soma += CPFArray[contador] * multiplicador;
                ++contador;
            }

            resultado = soma % 11;

            if (resultado == 0 || resultado == 1)
                if (primeiroDigitoVerificador != 0)
                    ClienteValido = false;
                else if (resultado <= 10 && resultado >= 2)
                    if (primeiroDigitoVerificador != 11 - resultado)
                        ClienteValido = false;

            for (multiplicador = 11; multiplicador >= 2; multiplicador--)
            {
                soma += CPFArray[contador] * multiplicador;
                ++contador;
            }

            resultado = soma % 11;

            if (resultado == 0 || resultado == 1)
                if (segundoDigitoVerificador != 0)
                    ClienteValido = false;
                else if (resultado <= 10 && resultado >= 2)
                    if (segundoDigitoVerificador != 11 - resultado)
                        ClienteValido = false;

            long.Parse(cf.CPF);

            //Valida DataNascimento
            String format = "dd/MM/yyyy";
            DateTime DataFormatada;
            int AnoAtual, AnoNascimento;
            try
            {
                DataFormatada = DateTime.ParseExact(cf.DataNascimento, format, System.Globalization.CultureInfo.InvariantCulture);
                DateTime now = DateTime.Now;
                AnoAtual = now.Year;
                AnoNascimento = DataFormatada.Year;
            }
            catch
            {
                ClienteValido = false;
            }

            if ((AnoAtual - AnoNascimento) <= 17)
                ClienteValido = false;

            //Valida RendaMensal


            //Valida EstadoCivil
            if(cf.EstadoCivil.Length != 1)
                ClienteValido = false;
            foreach (var ec in Enum.GetNames(typeof(EC)))
                if (cf.EstadoCivil.ToUpper() != ec.ToString())
                    ClienteValido = false;
                else
                    ClienteValido = true;

            cf.EstadoCivil.ToUpper();
            

            //Valida QtdDependentes
            int dependentes = int.Parse(cf.QtdDependentes);
            if (dependentes <= -1 || dependentes >= 11)
                ClienteValido = false;
            
            int.Parse(cf.QtdDependentes);

            return ClienteValido;
        }
    }
}