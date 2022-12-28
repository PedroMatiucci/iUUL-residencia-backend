using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Model;
using Consultorio.View;

namespace Consultorio.Validators
{
    internal static class ValidaAgendaForm
    {
        private enum Horas
        {
            H08 = 8, H09 = 9, H10 = 10,
            H11 = 11, H12 = 12, H13 = 13,
            H14 = 14, H15 = 15, H16 = 16,
            H17 = 17, H18 = 18, H19 = 19
        }
        private enum Minutos
        {
            M00 = 0, M15 = 15,
            M30 = 30, M45 = 45
        }

        /***********************/
        /* VALIDAÇÃO DE HORAS */
        /***********************/
        internal static bool ValidaHora(string? entrada)
        {
            if (entrada == null) return false;
            if (!HoraValida(entrada)) return false;

            return true;
        }
        private static bool HoraValida(string entrada)
        {
            int horario;
            try
            {
                horario = int.Parse(entrada);
            }
            catch
            {
                return false;
            }

            entrada = entrada.Substring(0, 2);
            Console.WriteLine(entrada);

            foreach (int hh in Enum.GetValues(typeof(Horas)))
            {
                if (int.Parse(entrada) == hh) return true;
            }

            entrada = entrada.Substring(2, 2);
            Console.WriteLine(entrada);

            /*
            if (entrada.Length >= 5 || entrada.Length <= 2)
                return false;
            */


            return true;
        }

        internal static string InsereHoraInicialValida()
        {
            string? entrada;
            bool v = true;
            do
            {
                if (!v)
                    ViewMensagens.ExibeMensagemErroHora();

                Console.Write("Hora inicial: ");
                entrada = Console.ReadLine();

                v = ValidaHora(entrada);

            } while (!v);

            return entrada;
        }






        /***********************/
        /* VALIDAÇÃO DE DATAS */
        /***********************/
        public static bool ValidaData(string? entrada)
        {
            if (entrada == null) return false;
            if (!DataValida(entrada)) return false;

            var agora = DateOnly.FromDateTime(DateTime.Now);
            var dtConsulta = DateOnly.FromDateTime(DateTime.Parse(entrada));

            return true;
        }
        public static bool ValidaDataMarcacaoConsulta(string? entrada)
        {
            if (entrada == null) return false;
            if (!DataValida(entrada)) return false;

            var agora = DateOnly.FromDateTime(DateTime.Now);
            var dtConsulta = DateOnly.FromDateTime(DateTime.Parse(entrada));

            // What
            if (dtConsulta.CompareTo(agora) < 0 || dtConsulta.CompareTo(agora) == 0)
                return false;

            return true;
        }

        private static bool DataValida(string entrada)
        {
            try
            {
                DateOnly data = DateOnly.Parse(entrada);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
