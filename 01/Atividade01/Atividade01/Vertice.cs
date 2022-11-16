using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade01
{
	internal class Vertice
	{
		public double X { get; private set; }
		public double Y { get; private set; }

		public Vertice(double X, double Y)
		{
			this.X = X;
			this.Y = Y;
		}

		public double Distancia()
		{
			return Math.Sqrt((this.X - this.Y) * (this.X - this.Y));
		}

		public void Move(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		public bool ComparaVertice(Vertice v)
		{
			if (this.X == v.X && this.Y == v.Y)
			{
				return true;
			}
			return false;
		}
	}
}