﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio
{
    internal class Consulta
    {
        public long CPF { get; set; }
        public DateOnly DataConsulta { get; set; }
        public int HoraInicial { get; set; }
        public int HoraFinal { get; set; }
        
        public Consulta(long cpf,DateOnly data, int h1, int h2)
        {
            this.CPF = cpf;
            this.DataConsulta = data;
            this.HoraInicial = h1;
            this.HoraFinal = h2;
        }
    }
}
