using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;

namespace Cremeria.Models.Reports
{
	public class Promotores:ConnectDB
	{
		public string Nombre { get; set; }
		public double Total { get; set; }
		public Promotores(
			string nombre,
			double total
			)
		{
			Nombre = nombre;
			Total = total;
		}

		public Promotores() { }

		private Promotores build_promotor(MySqlDataReader data)
		{
			Promotores item = new Promotores(
				data.GetString("Nombre"),
				data.GetDouble("total")
				);
			return item;
		}
		public List<Promotores> get_listado( string Fecha1, string Fecha2)
		{
			
			string query = "select tbausuario.nombre, sum(tbatickets.total) as total from tbausuario inner join tbatickets on tbatickets.atendio=tbausuario.id_usuario";
			if (Fecha1 == Fecha2)
			{
				query = query + " where  DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d')='" + Fecha1 + "' and tbausuario.tipo='Promotor' group by tbausuario.nombre order by total";
			}
			else
			{
				query = query + " where   DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d') BETWEEN  '" + Fecha1 + "' and  '" + Fecha2 + "' and tbausuario.tipo='Promotor' group by tbausuario.nombre order by total";
			}
			MySqlDataReader data = runQuery(query);
			List<Promotores> result = new List<Promotores>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Promotores item = build_promotor(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
