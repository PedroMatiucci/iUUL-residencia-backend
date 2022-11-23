using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02.Q5
{
    internal class Carro
    {
        private String placa { get; set; }
        private String modelo { get; set; }
        private Motor motor { get; set; }

        public  Carro(string placa, string modelo, Motor motor)
        {
            this.placa = placa;
            this.modelo = modelo;
            this.motor = motor;
        }

        public void TrocaMotor(Motor.Cilindrada cl) //pode passar assim?
        {
            this.motor = new(cl);
        }
    }
}
