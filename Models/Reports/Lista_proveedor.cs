using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cremeria.Models.Reports
{
	public class Lista_proveedor:ConnectDB
	{
		public string Codigo { get; set; }
		public string Descripcion { get; set; }
		public double Precio1 { get; set; }
		public double Precio2 { get; set; }
		public Lista_proveedor(
			string codigo, 
			string descripcion, 
			double precio1,
			double precio2
			) {
			Codigo = codigo;
			Descripcion = descripcion;
			Precio1 = precio1;
			Precio2 = precio2;
		}

		public Lista_proveedor() { }

		private Lista_proveedor build_proveedor(MySqlDataReader data)
		{
			Lista_proveedor item = new Lista_proveedor(
				data.GetString("codigo"),
				data.GetString("descripcion"),
				data.GetDouble("precio1"),
				data.GetDouble("precio2")
				);
			return item;
		}

		public List<Lista_proveedor> get_listado(int proveedor)
		{
			string cadena = "select codigo, descripcion, precio1, precio2 from tbaproductos where proveedor='" + proveedor.ToString() + "'";
			MySqlDataReader data = runQuery(cadena);
			List<Lista_proveedor> result = new List<Lista_proveedor>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Lista_proveedor item = build_proveedor(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
