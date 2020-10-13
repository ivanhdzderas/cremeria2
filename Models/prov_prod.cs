using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public class prov_prod:ConnectDB
	{
		public int Id { get; set; }
		public int Id_producto { get; set; }
		public int Id_proveedor { get; set; }
		public double Costo { get; set; }
		public double Cantidad { get; set; }
		public prov_prod(
			int id,
			int id_producto,
			int id_proveedor, 
			double costo, 
			double cantidad
			)
		{
			Id = id;
			Id_producto = id_producto;
			Id_proveedor = id_proveedor;
			Costo = costo;
			Cantidad = cantidad;
		}
		public prov_prod() { }

		private  prov_prod build_enlace( MySqlDataReader data)
		{
			prov_prod item = new prov_prod(
				data.GetInt32("id"),
				data.GetInt32("id_producto"),
				data.GetInt32("id_proveedor"),
				data.GetDouble("costo"),
				data.GetDouble("cantidad")
				);
			return item;
		}

		public void create()
		{
			string query = "insert into tbaprov_prod (id_producto, id_proveedor, costo, cantidad) values ('" +  this.Id_producto + "', '" + this.Id_proveedor + "', '" + this.Costo + "', '" + this.Cantidad + "')";
			object result = runQuery(query);
		}
		public void update_from_compra()
		{
			string query = "update tbaprov_prod set cantidad='" + this.Cantidad + "', costo='" + this.Costo + "' where id_producto='" + this.Id_producto + "' and id_proveedor='" + this.Id_proveedor + "'";
			object result = runQuery(query);
		}
		public void delete()
		{
			string query = "delete from tbaprov_prod where id_producto='" + this.Id_producto + "'";
			object result = runQuery(query);
		}
		public void delete_all()
		{
			string query = "delete from tbaprov_prod where id_proveedor='" + this.Id_proveedor + "'";
			object result = runQuery(query);
		}
		public void delete_()
		{
			string query = "delete from tbaprov_prod where id='" + this.Id + "'";
			object result = runQuery(query);
		}

		public List<prov_prod> get_costo(int id_prod)
		{
			string query = "select id,id_producto, id_proveedor, costo, cantidad  from tbaprov_prod where id_producto='" + id_prod  + "'";
			MySqlDataReader data = runQuery(query);
			List<prov_prod> result = new List<prov_prod>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					prov_prod item = build_enlace(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<prov_prod> get_costobyproveedorandprodu(int id_prod, int proveedor)
		{
			string query = "select id,id_producto, id_proveedor, costo, cantidad  from tbaprov_prod where id_producto='" + id_prod + "' and id_proveedor='" + proveedor + "'";
			MySqlDataReader data = runQuery(query);
			List<prov_prod> result = new List<prov_prod>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					prov_prod item = build_enlace(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<prov_prod> get_costobyproveedor(int proveedor)
		{
			string query = "select id,id_producto, id_proveedor, costo, cantidad  from tbaprov_prod where  id_proveedor='" + proveedor + "'";
			MySqlDataReader data = runQuery(query);
			List<prov_prod> result = new List<prov_prod>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					prov_prod item = build_enlace(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
