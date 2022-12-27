using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Model;

namespace Consultorio.View
{
    internal static class ViewListagem
    {
        public static void ExibeListaPacientes(List<Paciente> listaPacientes)
        {
            //Metodo para listar pacientes, recebe uma lista ja ordenada pelo controlador e da o print nela
            Console.WriteLine("------------------------------------------------------------\r\nCPF Nome Dt.Nasc. Idade\r\n------------------------------------------------------------");
            foreach (Paciente paciente in listaPacientes)
            {
                int idade = DateTime.Now.Year - paciente.DataNascimento.Year;
                Console.WriteLine("{0} {1} {2} {3}", paciente.CPF, paciente.Nome, DateOnly.FromDateTime(paciente.DataNascimento), idade);
            }
            Console.WriteLine("------------------------------------------------------------");
        }

        internal static void ExibeAgenda(Agenda agenda)
        {
            Console.WriteLine("--------------------------");
            foreach (Consulta consulta in agenda.Consultas)
            {
                Console.WriteLine(consulta.DataConsulta
                    +"\t"+consulta.CPF
                    +"\t"+consulta.HoraInicial
                    +"\t"+consulta.HoraFinal);
                Console.WriteLine("--------------------------");
            }
        }

        internal static void ExibeAgendaPeriodo(Agenda agenda, string[] datas)
        {
            Console.WriteLine("--------------------------");
            foreach (Consulta consulta in agenda.Consultas)
            {
                if(consulta.DataConsulta.CompareTo(
                    DateOnly.FromDateTime(DateTime.Parse(datas[0]))) > 0
                    &&
                    consulta.DataConsulta.CompareTo(
                        DateOnly.FromDateTime(DateTime.Parse(datas[1]))) < 0)
                {
                    Console.WriteLine(consulta.DataConsulta
                    + "\t" + consulta.CPF
                    + "\t" + consulta.HoraInicial
                    + "\t" + consulta.HoraFinal);
                    Console.WriteLine("--------------------------");
                }
                if (consulta.DataConsulta.CompareTo(
                    DateOnly.FromDateTime(DateTime.Parse(datas[0]))) == 0
                    ||
                    consulta.DataConsulta.CompareTo(
                        DateOnly.FromDateTime(DateTime.Parse(datas[1]))) == 0)
                {
                    Console.WriteLine(consulta.DataConsulta
                    + "\t" + consulta.CPF
                    + "\t" + consulta.HoraInicial
                    + "\t" + consulta.HoraFinal);
                    Console.WriteLine("--------------------------");
                }
            }
        }
    }
}
