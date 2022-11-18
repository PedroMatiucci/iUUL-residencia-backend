using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02
{
    abstract class ValidaCliente
    {
        protected String ValidaNome(string nome)
        {
            while (nome.Length <= 4)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine("Nome do campo: nome");
                Console.WriteLine($"Dado: {nome}");
                Console.WriteLine("Erro: Nome possui menos de 5 caracteres.");
                Console.WriteLine(">> ");
                nome = Console.ReadLine();
            }
            return nome;
        }

        //#########################################################
        //VALIDAR CPF
        protected long ValidaCPF(string cpf)
        {
            valida:
            if(cpf.Length != 11)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine("Nome do campo: cpf");
                Console.WriteLine($"Dado: {cpf}");
                Console.WriteLine("Erro: CPF deve conter 11 dígitos.");
                Console.WriteLine(">> ");
                cpf = Console.ReadLine();
                goto valida;
            }
            if(cpf == "11111111111"
                || cpf == "22222222222" 
                || cpf == "33333333333" 
                || cpf == "44444444444" 
                || cpf == "55555555555"
                || cpf == "66666666666"
                || cpf == "77777777777"
                || cpf == "88888888888"
                || cpf == "99999999999")
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine("Nome do campo: cpf");
                Console.WriteLine($"Dado: {cpf}");
                Console.WriteLine("Erro: Números do CPF não podem ser todos iguais.");
                Console.WriteLine(">> ");
                cpf = Console.ReadLine();
                goto valida;
            }
            
            var cpfArray = cpf.ToCharArray();
            char primeiroDigitoVerificador = cpfArray[cpfArray.Length - 2];
            char segundoDigitoVerificador = cpfArray[cpfArray.Length - 1];
            int multiplicador,contador = 0,soma = 0;
            for(multiplicador = 10; multiplicador >= 2; multiplicador--)
            {
                soma += cpfArray[contador] * multiplicador;
                ++contador;
            }
            int resultado = soma % 11;
            if(resultado == 0 || resultado == 1)
            {
                if(primeiroDigitoVerificador != 0)
                {
                    Console.WriteLine("\n---------ERRO----------");
                    Console.WriteLine("Nome do campo: cpf");
                    Console.WriteLine($"Dado: {cpf}");
                    Console.WriteLine("Erro: CPF Inválido: Primeiro dígito verificador não confere.");
                    Console.WriteLine(">> ");
                    cpf = Console.ReadLine();
                    goto valida;
                }
            }
            else if(resultado <= 10 && resultado >= 2)
            {
                if(primeiroDigitoVerificador != 11 - resultado)
                {
                    Console.WriteLine("\n---------ERRO----------");
                    Console.WriteLine("Nome do campo: cpf");
                    Console.WriteLine($"Dado: {cpf}");
                    Console.WriteLine("Erro: CPF Inválido: Primeiro dígito verificador não confere.");
                    Console.WriteLine(">> ");
                    cpf = Console.ReadLine();
                    goto valida;
                }
            }
            for (multiplicador = 11; multiplicador >= 2; multiplicador--)
            {
                soma += cpfArray[contador] * multiplicador;
                ++contador;
            }
            resultado = soma % 11;
            if (resultado == 0 || resultado == 1)
            {
                if (segundoDigitoVerificador != 0)
                {
                    Console.WriteLine("\n---------ERRO----------");
                    Console.WriteLine("Nome do campo: cpf");
                    Console.WriteLine($"Dado: {cpf}");
                    Console.WriteLine("Erro: CPF Inválido: Segundo dígito verificador não confere.");
                    Console.WriteLine(">> ");
                    cpf = Console.ReadLine();
                    goto valida;
                }
            }
            else if (resultado <= 10 && resultado >= 2)
            {
                if (segundoDigitoVerificador != 11 - resultado)
                {
                    Console.WriteLine("\n---------ERRO----------");
                    Console.WriteLine("Nome do campo: cpf");
                    Console.WriteLine($"Dado: {cpf}");
                    Console.WriteLine("Erro: CPF Inválido: Segundo dígito verificador não confere.");
                    Console.WriteLine(">> ");
                    cpf = Console.ReadLine();
                    goto valida;
                }
            }

            return long.Parse(cpf);
        }

        protected DateTime ValidaNascimento(String dt)
        {
            String format = "dd/MM/yyyy";
            DateTime dataFormatada;

        valida:
            try
            {
                dataFormatada = DateTime.ParseExact(dt, format, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine("Nome do campo: dataNascimento");
                Console.WriteLine($"Dado: {dt}");
                Console.WriteLine("Erro: Formatação fora do padrão dd/mm/yyyy.");
                Console.WriteLine(">> ");
                dt = Console.ReadLine();
                goto valida;
            }

            DateTime now = DateTime.Now;
            int anoAtual = now.Year;
            int anoNascimento = dataFormatada.Year;

            while ((anoAtual - anoNascimento) <= 17)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine("Nome do campo: dataNascimento");
                Console.WriteLine($"Dado: {anoNascimento}");
                Console.WriteLine("Erro: Idade menor do que 18 anos.");
                Console.WriteLine(">> ");
                dt = Console.ReadLine();

                goto valida;
            }
            return dataFormatada;
        }


        //#########################################################
        //VALIDAR RENDA
        protected float ValidaRendaMensal(String renda)
        {
            //
            /*
            valida:
            //
            
            if ()
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine("Nome do campo: rendaMensal");
                Console.WriteLine($"Dado: {renda}");
                Console.WriteLine("Erro: Renda menor do que zero.");
                Console.WriteLine(">> ");

                renda = Console.ReadLine();

                goto valida;
            }
            */
            return float.Parse(renda);
        }

        enum EC
        {
            C,
            S,
            V,
            D
        }

        protected char ValidaEstadoCivil(String estadoCivil)
        {

            while (true)
            {
                foreach (var ec in Enum.GetNames(typeof(EC)))
                {
                    if (estadoCivil.ToUpper() == ec.ToString())
                    {
                        return char.Parse(estadoCivil.ToUpper());
                    }
                }
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine("Nome do campo: estadoCivil");
                Console.WriteLine($"Dado: {estadoCivil}");
                Console.WriteLine("Erro: Estado civil desconhecido.");
                Console.WriteLine(">> ");
                estadoCivil = Console.ReadLine();
            }
        }

        protected int ValidaQtdDependentes(String qtd)
        {
            int dependentes = int.Parse(qtd);
            while (dependentes <= -1 || dependentes >= 11)
            {
                Console.WriteLine("\n---------ERRO----------");
                Console.WriteLine("Nome do campo: qtdDependentes");
                Console.WriteLine($"Dado: {qtd}");
                Console.WriteLine("Erro: Quantidade de dependentes menor que 0 ou maior que 10.");
                Console.WriteLine(">> ");
                qtd = Console.ReadLine();
                dependentes = int.Parse(qtd);
            }
            return dependentes;
        }

        public void ImprimeCliente(Cliente c)
        {
            Console.WriteLine();
            Console.WriteLine("---------SUCESSO----------");
            Console.WriteLine("==========Imprimindo cliente===========");
            Console.WriteLine("Nome: " + c.nome);
            Console.WriteLine("CPF: " + c.cpf);
            Console.WriteLine("Nascimento: " + c.dataNascimento);
            Console.WriteLine("Renda mensal: " + c.rendaMensal);
            Console.WriteLine("Estado civil: " + c.estadoCivil);
            Console.WriteLine("Quantidade de dependentes: " + c.qtdDependentes);
        }
    }
}
