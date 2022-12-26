using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    internal class ValidaAgendaForm
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

        /* VALIDAÇÃO DE DATAS */
        public static bool ValidaData(string? entrada)
        {
            if (entrada == null) return false;
            if (!DataValida(entrada)) return false;

            var agora = DateOnly.FromDateTime(DateTime.Now);
            var dtConsulta = DateOnly.FromDateTime(DateTime.Parse(entrada));

            if (dtConsulta.CompareTo(agora) < 0)
                return false;

            return true;
        }

        internal static bool DataValida(string entrada)
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


        /* VALIDAÇÃO DE HORAS */
        internal static bool HoraValida(string[] entrada)
        {
            if (entrada == null) return false;

            int horaInicial;
            int horaFinal;
            try
            {
                horaInicial = int.Parse(entrada[0]);
            }
            catch
            {
                return false;
            }
            try
            {
                horaFinal = int.Parse(entrada[1]);
            }
            catch
            {
                return false;
            }


            if (entrada[0].Length >= 5 || entrada[1].Length >= 5)
                return false;


            horaInicial = int.Parse(horaInicial.ToString().Substring(0, 2));
            horaFinal = int.Parse(horaFinal.ToString().Substring(0, 2));

            int agora = DateTime.Now.Hour;

            if (horaInicial > horaFinal)
                return false;

            if (horaInicial < agora ||
                horaFinal < agora)
                return false;

            if (horaInicial == (int) Horas.H19)
                return false;

            return true;
        }

       internal static bool HorarioValido(string[] entrada)
        {
            int hhHoraInicial, mmHoraInicial;
            hhHoraInicial = int.Parse(entrada[0].Substring(0, 2));
            mmHoraInicial = int.Parse(entrada[0].Substring(2, 2));

            Console.WriteLine(mmHoraInicial);
            Console.WriteLine(hhHoraInicial);
            
            bool valido = false;

            foreach (int hh in Enum.GetValues(typeof(Horas)))
            {
                if (hhHoraInicial == hh) valido = true;
            }
            if (valido == false) return false;

            foreach (int mm in Enum.GetValues(typeof(Minutos)))
            {
                if (mmHoraInicial == mm) valido = true;
            }
            if (valido == false) return false;

            valido = false;

            int hhHoraFinal, mmHoraFinal;
            hhHoraFinal = int.Parse(entrada[1].Substring(0, 2));
            mmHoraFinal = int.Parse(entrada[1].Substring(2, 2));

            foreach (int hh in Enum.GetValues(typeof(Horas)))
            {
                if (hhHoraFinal == hh) valido = true;
            }
            if (valido == false) return false;

            foreach (int mm in Enum.GetValues(typeof(Minutos)))
            {
                if (mmHoraFinal == mm) valido = true;
            }
            if (valido == false) return false;

            return true;
        }

        internal static bool HorarioDisponivel(string[] entrada, Agenda agenda)
        {
            foreach (Consulta consulta in agenda.Consultas)
            {
                if (consulta.HoraInicial == int.Parse(entrada[0]))
                    return false;
            }

            return true;
        }
    }
}
