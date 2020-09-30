using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Bcpg;

namespace Cremeria.Models
{
	public class Ordenes_compra:ConnectDB
	{
		public int Id { get; set; }
		public int Id_proveedor { get; set; }
		public int Usuario { get; set; }
		public bool Terminado { get; set; }
		public Ordenes_compra(
			int id,
			int id_proveedor,
			int usuario,
			bool terminado
			)
		{
			Id = id;
			Id_proveedor = id_proveedor;
			Usuario = usuario;
			Terminado = terminado;
		}

		public Ordenes_compra() { }

		private Ordenes_compra build_orden(MySqlDataReader data)
		{
			Ordenes_compra item = new Ordenes_compra(
				data.GetInt32("id"),
				data.GetInt32("id_proveedor"),
				data.GetInt32("usuario"),
				Convert.ToBoolean(data.GetInt32("terminado"))
				);
			return item;
		}
		public void create_orden()
		{
			string query = "insert into tbaordenes  (id_proveedor, usuario,terminado) values ('" + this.Id_proveedor + "', '" + this.Usuario + "', '" + Convert.ToInt32(this.Terminado) + "')";
			object result = runQuery(query);
		}
		public void termina_orden()
		{
			string query = "update tbaordenes set terminado='" + Convert.ToInt32(this.Terminado) + "' where id='" + this.Id + "'";
			object result = runQuery(query);
		}
		public List<Ordenes_compra> get_ordenes()
		{
			string query = "select id, id_proveedor, usuario, terminado from tbaordenes";
			MySqlDataReader data = runQuery(query);
			List<Ordenes_compra> result = new List<Ordenes_compra>();
			if(data.HasRows){
				while (data.Read())
				{
					Ordenes_compra item = build_orden(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Ordenes_compra> get_ordenbyid(int id)
		{
			string query = "select id, id_proveedor, usuario, terminado from tbaordenes where id='" + id + "'";
			MySqlDataReader data = runQuery(query);
			List<Ordenes_compra> result = new List<Ordenes_compra>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Ordenes_compra item = build_orden(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Ordenes_compra> get_lastordenes(int id_prov,int usu)
		{
			string query = "select id, id_proveedor, usuario, terminado from tbaordenes where id_proveedor='" + id_prov + "' and usuario='" + usu + "'";
			MySqlDataReader data = runQuery(query);
			List<Ordenes_compra> result = new List<Ordenes_compra>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Ordenes_compra item = build_orden(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Ordenes_compra> get_ordenproveedor_sin(int id_prov)
		{
			string query = "select id, id_proveedor, usuario, terminado from tbaordenes where id_proveedor='" + id_prov + "' and terminado='0'";
			MySqlDataReader data = runQuery(query);
			List<Ordenes_compra> result = new List<Ordenes_compra>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Ordenes_compra item = build_orden(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
 