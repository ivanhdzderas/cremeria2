using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cremeria.Models.Reports
{
	public class Retiro_efectivo
	{
		public double Monto { get; set; }

		public Retiro_efectivo(
			double monto
			)
		{
			Monto = monto;
		}

		public Retiro_efectivo() { }


	}
}
