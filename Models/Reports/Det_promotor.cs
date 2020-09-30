using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;

namespace Cremeria.Models.Reports
{
	public class Det_promotor:ConnectDB
	{
		public string Codigo { get; set; }
		public string Descripcion { get; set; }
		public double Cantidad { get; set; }
		public double Vendido { get; set; }
		public Det_promotor(
			string codigo, 
			string descripcion, 
			double cantidad,
			double vendido
			) {
			Codigo = codigo;
			Descripcion = descripcion;
			Cantidad = cantidad;
			Vendido = vendido;
		}

		public Det_promotor()
		{

		}

		private Det_promotor build_promotor(MySqlDataReader data)
		{
			Det_promotor item = new Det_promotor(
				data.GetString("codigo"),
				data.GetString("descripcion"),
				data.GetDouble("cantidad"),
				data.GetDouble("vendido")
				);
			return item;
		}

		public List<Det_promotor> get_cantidades(int promotor, string Fecha1, string Fecha2)
		{
			string query = "select tbadetticket.descripcion, tbaproductos.codigo, tbadetticket.cantidad,sum(tbadetticket.total) as vendido from tbadetticket inner join tbaproductos on tbadetticket.id_producto=tbaproductos.id inner join tbatickets on tbadetticket.id_ticket=tbatickets.folio";
			if (Fecha1 == Fecha2) {
				query = query + " where tbatickets.atendio='" + promotor + "' and  DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d')='" + Fecha1 + "' group by tbaproductos.codigo order by tbadetticket.cantidad";
			}
			else
			{
				query = query + " where tbatickets.atendio='" + promotor + "' and  DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d') BETWEEN  '" + Fecha1 + "' and  '" + Fecha2 + "' group by tbaproductos.codigo order by tbadetticket.cantidad";
			}
			MySqlDataReader data = runQuery(query);
			List<Det_promotor> result = new List<Det_promotor>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Det_promotor item = build_promotor(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
