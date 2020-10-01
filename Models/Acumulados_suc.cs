using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cremeria.Forms;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public class Acumulados_suc:ConnectOtherDb
	{
		public int Id { get; set; }
		public int Id_master_product { get; set; }
		public int Id_producto { get; set; }
		public double Cantidad { get; set; }
		public Acumulados_suc(
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

		public Acumulados_suc()
		{

		}
		public void delete_acumulados()
		{
			string query = "delete from tbaacumulados where id_master_product='" + this.Id_master_product + "'";
			object result = runQuery(query,intercambios.conector);
		}
		public void create_acumulado()
		{
			string query = "insert into tbaacumulados (id_master_product, id_producto, cantidad) values ('" + this.Id_master_product + "', '" + this.Id_producto + "', '" + this.Cantidad + "')";
			object result = runQuery(query, intercambios.conector);
		}
		private Acumulados_suc build_acumulados(MySqlDataReader data)
		{
			Acumulados_suc item = new Acumulados_suc(
				data.GetInt32("id"),
				data.GetInt32("id_master_product"),
				data.GetInt32("id_producto"),
				data.GetDouble("cantidad")
				);
			return item;
		}

		public List<Acumulados_suc> get_acumulados(int id_producto)
		{
			string query = "select id, id_master_product, id_producto, cantidad from tbaacumulados where id_master_product='" + id_producto + "'";
			MySqlDataReader data = runQuery(query, intercambios.conector);

			List<Acumulados_suc> result = new List<Acumulados_suc>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Acumulados_suc item = build_acumulados(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
