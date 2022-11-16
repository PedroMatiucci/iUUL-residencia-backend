using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade01
{
    internal class Triangulo    {
        public Vertice v1 { get; private set; }
        public Vertice v2 { get; private set; }
        public Vertice v3 { get; private set; }

     
        public Triangulo(Vertice v1, Vertice v2, Vertice v3)
        {
            double d1 = Math.Abs(v1.Distancia() - v2.Distancia());
            double d2 = v1.Distancia() + v2.Distancia();
            double value = v3.Distancia();
            if(value > d1 && value < d2)
            {
                d1 = Math.Abs(v2.Distancia() - v3.Distancia());
                d2 = v2.Distancia() + v3.Distancia();
                value = v1.Distancia();
                if (value > d1 && value < d2)
                {
                    d1 = Math.Abs(v1.Distancia() - v3.Distancia());
                    d2 = v1.Distancia() + v3.Distancia();
                    value = v2.Distancia();
                    if (value > d1 && value < d2)
                    {
                        this.v1 = v1;
                        this.v2 = v2;
                        this.v3 = v3;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public string ComparaTriangulo(Triangulo t1, Triangulo t2)
        {
            if (TipoEquilatero(t1) == TipoEquilatero(t2)) return "Triângulos são iguais";
            return "Não são iguais";
        }

        public double Perimetro(Triangulo t)
        {
            return t.v1.Distancia() + t.v2.Distancia() + t.v3.Distancia();
        }

        public double Area(Triangulo t)
        {
            return Perimetro(t)/2;
        }

        enum Tipo
        {
            Equilatero,
            Escaleno,
            Isosceles
        }

        static String TipoTriangulo(Tipo t)
        {
            switch (t)
            {
                case Tipo.Equilatero: return "Equilátero";
                case Tipo.Isosceles: return "Isósceles";
                case Tipo.Escaleno: return "Escaleno";
                default: return "Invalid";
            }
        }

        static bool TipoEquilatero(Triangulo t)
        {
            if(t.v1.Distancia() == t.v2.Distancia() && t.v2.Distancia() == t.v3.Distancia())
            {
                return true;
            }
            return false;
        }

        static bool TipoEscaleno(Triangulo t)
        {
            if (t.v1.Distancia() != t.v2.Distancia() && t.v2.Distancia() != t.v3.Distancia())
            {
                return true;
            }
            return false;
        }

        static bool TipoIsosceles(Triangulo t)
        {
            double d1 = t.v1.Distancia();
            double d2 = t.v2.Distancia();
            double d3 = t.v3.Distancia();

            if (d1 == d2 || d1 == d3 || d2 == d3)
            {
                return true;
            }
            return false;
        }

        public string ConfereTipoTriangulo(Triangulo t)
        {
            if (TipoEquilatero(t)) return TipoTriangulo(Tipo.Equilatero);
            else if (TipoEscaleno(t)) return TipoTriangulo(Tipo.Escaleno);
            else if (TipoIsosceles(t)) return TipoTriangulo(Tipo.Isosceles);
            else return "Invalid";
        }

    }
}
