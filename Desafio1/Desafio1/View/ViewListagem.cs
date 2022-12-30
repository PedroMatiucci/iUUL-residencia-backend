using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Controller;
using Consultorio.Model;
using static System.Net.Mime.MediaTypeNames;

namespace Consultorio.View
{
    internal static class ViewListagem
    {
        public static void ExibeListaPacientes(List<Paciente> listaPacientes)
        {
            int idade;
            //Metodo para listar pacientes, recebe uma lista ja ordenada pelo controlador e da o print nela
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("CPF\t\tNome\tDt.Nasc.\tIdade\t");
            Console.WriteLine("--------------------------------------------------");
            foreach (Paciente paciente in listaPacientes)
            {
                idade = DateTime.Now.Year - paciente.DataNascimento.Year;
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", paciente.CPF, paciente.Nome, DateOnly.FromDateTime(paciente.DataNascimento), idade);
                if(paciente.Consulta != null) {
                    Console.WriteLine("\t\tAgendado Para: " + paciente.Consulta.DataConsulta);
                    Console.WriteLine("\t\t{0} às {1}", paciente.Consulta.HoraInicial, paciente.Consulta.HoraFinal);
                }
            }
            Console.WriteLine("--------------------------------------------------");
        }

        internal static void ExibeAgenda(Agenda agenda)
        {
            int tempoConsulta;
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Data\t\tH.Ini\tH.Fim\tTempo\tNome\tDt.Nasc.");
            Console.WriteLine("-------------------------------------------------");
            foreach (Consulta consulta in Agenda.Consultas)
            {
                tempoConsulta = int.Parse(consulta.HoraFinal) - int.Parse(consulta.HoraInicial);
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\tnome\tdtnascimento", consulta.DataConsulta, consulta.HoraInicial, consulta.HoraFinal, tempoConsulta);
            }
            Console.WriteLine("-------------------------------------------------");
        }

        internal static void ExibeAgendaPeriodo(Agenda agenda, string[] datas)
        {
            int tempoConsulta;
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Data\t\tH.Ini\tH.Fim\tTempo\tNome\tDt.Nasc.");
            Console.WriteLine("-------------------------------------------------");
            foreach (Consulta consulta in Agenda.Consultas)
            {
                if(consulta.DataConsulta.CompareTo(
                    DateOnly.FromDateTime(DateTime.Parse(datas[0]))) > 0
                    &&
                    consulta.DataConsulta.CompareTo(
                        DateOnly.FromDateTime(DateTime.Parse(datas[1]))) < 0)
                {
                    tempoConsulta = int.Parse(consulta.HoraFinal) - int.Parse(consulta.HoraInicial);
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\tnome\tdtnascimento", consulta.DataConsulta, consulta.HoraInicial, consulta.HoraFinal, tempoConsulta);
                }
                if (consulta.DataConsulta.CompareTo(
                    DateOnly.FromDateTime(DateTime.Parse(datas[0]))) == 0
                    ||
                    consulta.DataConsulta.CompareTo(
                        DateOnly.FromDateTime(DateTime.Parse(datas[1]))) == 0)
                {
                    tempoConsulta = int.Parse(consulta.HoraFinal) - int.Parse(consulta.HoraInicial);
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\tnome\tdtnascimento", consulta.DataConsulta, consulta.HoraInicial, consulta.HoraFinal, tempoConsulta);
                }
            }
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
