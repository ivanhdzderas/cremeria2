using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cremeria.Models.Reports
{
	public class Totales
	{
		public double Total { get; set; }
		public double Traspasos { get; set; }
		public double Gran_total { get; set; }
		public Totales(
			double total,
			double traspasos,
			double gran_total
			) {
			Total = total;
			Traspasos = traspasos;
			Gran_total = gran_total;
		}
		public Totales() { }
	}
}
