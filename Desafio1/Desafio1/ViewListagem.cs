using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
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
    }
}
