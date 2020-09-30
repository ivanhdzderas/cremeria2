using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public class Lista_precios:ConnectDB
	{
		public int Id { get; set; }
		public int Id_cliente { get; set; }
		public int Id_Producto { get;set; }
		public double Descuento { get; set; }
		public Lista_precios(
			int id,
			int id_cliente,
			int id_producto,
			double descuento
			)
		{
			Id = id;
			Id_cliente = id_cliente;
			Id_Producto = id_producto;
			Descuento = descuento;

		}

		public Lista_precios() { }

		private Lista_precios build_lista(MySqlDataReader data) {
			Lista_precios item = new Lista_precios(
				data.GetInt32("id"),
				data.GetInt32("id_cliente"),
				data.GetInt32("id_producto"),
				data.GetDouble("cantidad")
				);
			return item;
		}
		public void delete_lista()
		{
			string query = "delete from tbalista_precios where id='" + this.Id + "'";
			object result = runQuery(query);
		}
		public void create_lista()
		{
			string query = "insert into tbalista_precios (id_cliente, id_producto,cantidad) values ('" + this.Id_cliente + "', '" + this.Id_Producto + "', '" + this.Descuento + "')";
			object result = runQuery(query);
		}
		public void update_lista()
		{
			string query = "update tbalista_precios set id_cliente='" + this.Id_cliente + "',id_producto='" + this.Id_Producto + "', cantidad='" + this.Descuento + "' where id	='" + this.Id + "'";
			object result = runQuery(query);
		}
		public List<Lista_precios> get_listabycliente(int cliente)
		{
			string query = "select id, id_cliente, id_producto, cantidad from tbalista_precios where id_cliente='" + cliente + "'";
			MySqlDataReader data = runQuery(query);
			List<Lista_precios> result = new List<Lista_precios>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Lista_precios item = build_lista(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Lista_precios> getlistas_byid(int id)
		{
			string query = "select id, id_cliente, id_producto, cantidad from tbalista_precios where id='" + id + "'";
			MySqlDataReader data = runQuery(query);
			List<Lista_precios> result = new List<Lista_precios>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Lista_precios item = build_lista(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Lista_precios> get_listabycliente_producto(int cliente,int producto)
		{
			string query = "select id, id_cliente, id_producto, cantidad from tbalista_precios where id_cliente='" + cliente + "' and id_producto='" + producto + "'";
			MySqlDataReader data = runQuery(query);
			List<Lista_precios> result = new List<Lista_precios>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Lista_precios item = build_lista(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Lista_precios> get_listas()
		{
			string query = "select id, id_cliente, id_producto, cantidad from tbalista_precios ";
			MySqlDataReader data = runQuery(query);
			List<Lista_precios> result = new List<Lista_precios>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Lista_precios item = build_lista(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
