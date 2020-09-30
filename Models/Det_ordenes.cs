using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public class Det_ordenes:ConnectDB
	{
		public int Id { get; set; }
		public int Id_orden { get; set; }
		public double Cantidad { get; set; }
		public int Id_producto { get; set; }

		public Det_ordenes(
			int id,
			int id_orden,
			double cantidad,
			int id_producto
			)
		{
			Id = id;
			Id_orden = id_orden;
			Cantidad = cantidad;
			Id_producto = id_producto;
		}

		public Det_ordenes()
		{

		}

		private Det_ordenes build_det_orden(MySqlDataReader data)
		{
			Det_ordenes item = new Det_ordenes(
				data.GetInt32("id"),
				data.GetInt32("id_orden"),
				data.GetDouble("cantidad"),
				data.GetInt32("id_producto")
				);
			return item;
		}
		public void create_det()
		{
			string query = "insert into tbadetordenes (id_orden, cantidad, id_producto) values ('" + this.Id_orden + "', '" + this.Cantidad + "', '" + this.Id_producto + "')";
			object result = runQuery(query);
		}

		public List<Det_ordenes> get_detalles(int id_orden)
		{
			string query = "select id, id_orden, cantidad, id_producto from tbadetordenes where id_orden='" + id_orden + "'";
			MySqlDataReader data = runQuery(query);
			List<Det_ordenes> result = new List<Det_ordenes>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Det_ordenes item = build_det_orden(data);
					result.Add(item);
				}
			}
			return result;
		}

	}
}
