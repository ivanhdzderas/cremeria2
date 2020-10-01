using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cremeria.Forms;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public class Kardex_suc:ConnectOtherDb
	{
		public int Id { get; set; }
		public int Id_producto { get; set; }
		public string Tipo { get; set; }
		public int Id_documento { get; set; }
		public double Cantidad { get; set; }
		public double Antes { get; set; }
		public string Fecha { get; set; }

		public Kardex_suc(
			int id,
			int id_producto,
			string tipo,
			int id_documento,
			double cantidad,
			double antes,
			string fecha
			)
		{
			Id = id;
			Id_producto = id_producto;
			Tipo = tipo;
			Id_documento = id_documento;
			Cantidad = cantidad;
			Antes = antes;
			Fecha = fecha;
		}
		public Kardex_suc() { }

		private Kardex_suc buildKardex(MySqlDataReader data)
		{
			Kardex_suc item = new Kardex_suc(
				data.GetInt32("id"),
				data.GetInt32("id_producto"),
				data.GetString("tipo_movimiento"),
				data.GetInt32("id_documento"),
				data.GetDouble("cantidad"),
				data.GetDouble("antes"),
				data.GetString("fecha")
				);
			return item;
		}
		public void CreateKardex()
		{
			string query = "insert into tbakardex (id_producto, tipo_movimiento,id_documento, cantidad, antes, fecha ) values (";
			query += "'" + this.Id_producto + "', ";
			query += "'" + this.Tipo + "', ";
			query += "'" + this.Id_documento + "', ";
			query += "'" + this.Cantidad + "', ";
			query += "'" + this.Antes + "', ";
			query += "curdate()";
			query += ")";
			object result = runQuery(query,intercambios.conector);
		}
		public void delete_kardex()
		{
			string query = "delete from tbakardex where id='" + this.Id + "'";
			object result = runQuery(query, intercambios.conector);

		}

		public List<Kardex_suc> getKardex(int id_producto)
		{
			string query = "select id, id_producto, tipo_movimiento,id_documento, cantidad, antes, fecha from tbakardex where id_producto='" + id_producto.ToString() + "' order by id";
			MySqlDataReader data = runQuery(query, intercambios.conector);
			List<Kardex_suc> result = new List<Kardex_suc>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Kardex_suc item = buildKardex(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Kardex_suc> getidKardex(int id_producto, int id_documento, string tipo)
		{
			string query = "select id, id_producto, tipo_movimiento,id_documento, cantidad, antes, fecha from tbakardex where id_producto='" + id_producto.ToString() + "' and id_documento='" + id_documento + "' and tipo_movimiento='" + tipo + "'";
			MySqlDataReader data = runQuery(query, intercambios.conector);
			List<Kardex_suc> result = new List<Kardex_suc>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Kardex_suc item = buildKardex(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Kardex_suc> getkardexbyid(int id)
		{
			string query = "select id, id_producto, tipo_movimiento,id_documento, cantidad, antes, fecha from tbakardex where id='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query, intercambios.conector);
			List<Kardex_suc> result = new List<Kardex_suc>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Kardex_suc item = buildKardex(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
