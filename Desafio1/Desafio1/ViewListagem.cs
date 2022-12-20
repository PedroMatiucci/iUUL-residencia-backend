using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    public static class ViewListagem
    {
        public static void ExibeListaPacientes(List<Cliente> listaClientes)
        {
            //Metodo para listar pacientes, recebe uma lista ja ordenada pelo controlador e da o print nela
            Console.WriteLine("------------------------------------------------------------\r\nCPF Nome Dt.Nasc. Idade\r\n------------------------------------------------------------");
            foreach (Cliente cliente in listaClientes)
            {
                int idade = DateTime.Now.Year - cliente.DataNascimento.Year;
                Console.WriteLine("{0} {1} {2} {3}", cliente.CPF, cliente.Nome, DateOnly.FromDateTime(cliente.DataNascimento), idade);
            }
            Console.WriteLine("------------------------------------------------------------");
        }
    }
}
