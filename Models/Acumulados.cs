using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public class Acumulados:ConnectDB
	{
		public int Id { get; set; }
		public int Id_master_product { get; set; }
		public int Id_producto { get; set; }
		public double Cantidad { get; set; }
		public Acumulados(
			int id,
			int id_master_producto,
			int id_producto,
			double cantidad
			)
		{
			Id = id;
			Id_master_product = id_master_producto;
			Id_producto = id_producto;
			Cantidad = cantidad;

		}

		public Acumulados()
		{

		}
		public void delete_acumulados()
		{
			string query = "delete from tbaacumulados where id_master_product='" + this.Id_master_product + "'";
			object result = runQuery(query);
		}
		public void create_acumulado()
		{
			string query = "insert into tbaacumulados (id_master_product, id_producto, cantidad) values ('" + this.Id_master_product + "', '" + this.Id_producto + "', '" + this.Cantidad + "')";
			object result = runQuery(query);
		}
		private Acumulados build_acumulados(MySqlDataReader data)
		{
			Acumulados item = new Acumulados(
				data.GetInt32("id"),
				data.GetInt32("id_master_product"),
				data.GetInt32("id_producto"),
				data.GetDouble("cantidad")
				);
			return item;
		}

		public List<Acumulados> get_acumulados(int id_producto)
		{
			string query = "select id, id_master_product, id_producto, cantidad from tbaacumulados where id_master_product='" + id_producto + "'";
			MySqlDataReader data = runQuery(query);

			List<Acumulados> result = new List<Acumulados>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Acumulados item = build_acumulados(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
