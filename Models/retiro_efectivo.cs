using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public class retiro_efectivo:ConnectDB
	{
		public int Id { get; set; }
		public double Monto { get; set; }
		public int Usuario { get; set; }
		public string Fecha { get; set; }
		public int Id_proveedor { get; set; }
		public double Monto_proveedor { get; set; }
		public string Notas { get; set; }

		public retiro_efectivo(
			int id,
			double monto,
			int usuario,
			string fecha,
			int id_proveedor,
			double monto_proveedor,
			string notas
			) {
			Id = id;
			Monto = monto;
			Usuario = usuario;
			Fecha = fecha;
			Id_proveedor = id_proveedor;
			Monto_proveedor = monto_proveedor;
			Notas = notas;
		}

		public retiro_efectivo() { }

		private retiro_efectivo buildretiro(MySqlDataReader data)
		{
			retiro_efectivo item = new retiro_efectivo(
				data.GetInt32("id"),
				data.GetDouble("monto"),
				data.GetInt32("usuario"),
				data.GetString("fecha"),
				data.GetInt32("id_proveedor"),
				data.GetDouble("monto_proveedor"),
				data.GetString("notas")
				);
			return item;
		}
		public void createRetiro()
		{
			string query = "insert into retiros (monto, usuario, fecha, id_proveedor, monto_proveedor, notas) values ('" + this.Monto + "', '" + this.Usuario + "', NOW(), '" + this.Id_proveedor + "', '" + this.Monto_proveedor + "', '" + this.Notas + "')";
			object result = runQuery(query);
		}
		public List<retiro_efectivo> get_retirosbyuser(int user)
		{
			string query = "select id, monto, usuario, fecha, id_proveedor, monto_proveedor, notas from retiros where usuario='" + user.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<retiro_efectivo> result = new List<retiro_efectivo>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					retiro_efectivo item = buildretiro(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<retiro_efectivo> get_lastretiro(int user)
		{
			string query = "select id, monto, usuario, fecha,id_proveedor, monto_proveedor, notas from retiros where usuario='" + user.ToString() + "' order by id desc";
			MySqlDataReader data = runQuery(query);
			List<retiro_efectivo> result = new List<retiro_efectivo>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					retiro_efectivo item = buildretiro(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<retiro_efectivo> get_retirostoday()
		{
			string fecha=DateTime.Now.ToString("yyyy-MM-dd");
			string query = "select id, monto, usuario, fecha,id_proveedor, monto_proveedor, notas from retiros where fecha like '%" + fecha + "%'";
			MySqlDataReader data = runQuery(query);
			List<retiro_efectivo> result = new List<retiro_efectivo>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					retiro_efectivo item = buildretiro(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<retiro_efectivo> get_retiro_fecha(string fecha1, string fecha2)
		{
			string query = "select id, monto, usuario, fecha,id_proveedor, monto_proveedor, notas from retiros";
			if (fecha1 == fecha2)
			{
				query = query + " where DATE_FORMAT(retiros.fecha,'%Y-%m-%d')='" + fecha1 + "'";
			}
			else
			{
				query = query + "  where DATE_FORMAT(retiros.fecha,'%Y-%m-%d') BETWEEN '" + fecha1 + "' AND '" + fecha2 + "'";
			}
			
			MySqlDataReader data = runQuery(query);
			List<retiro_efectivo> result = new List<retiro_efectivo>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					retiro_efectivo item = buildretiro(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
