using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public class Dev_prov:ConnectDB
	{
		public int Id { get; set; }
		public int Id_proveedor { get; set; }
		public string Fecha { get; set; }
		public double Total { get; set; }
		public Boolean Estado { get; set; }
		public string Motivo { get; set; }

		public Dev_prov(
			int id,
			int id_proveedor,
			string fecha, 
			double total,
			Boolean estado,
			string motivo
			)
		{
			Id = id;
			Id_proveedor = id_proveedor;
			Fecha = fecha;
			Total = total;
			Estado = estado;
			Motivo = motivo;
		}

		public Dev_prov()
		{

		}

		private Dev_prov build_dev(MySqlDataReader data)
		{
			Dev_prov item = new Dev_prov(
				data.GetInt32("id"),
				data.GetInt32("id_proveedor"),
				data.GetString("fecha"),
				data.GetDouble("total"),
				Convert.ToBoolean(data.GetInt32("estado")),
				data.GetString("motivo")
				);
			return item;
		}

		public void create_dev()
		{
			string query = "insert into dev_prov (id_proveedor,fecha,total,estado, motivo) values ('" + this.Id_proveedor + "', CURDATE(), '" + this.Total + "', '" + Convert.ToInt32(this.Estado) + "', '"  + this.Motivo + "')";
			runQuery(query);
		}
		public void save_dev()
		{
			string query = "update dev_prov set id_proveedor='" + this.Id_proveedor + "', total='" + this.Total + "', estado='" + Convert.ToInt32(this.Estado) + "', motivo='" + this.Motivo + "' where id='"  + this.Id + "'";
			runQuery(query);
		}
		public void termina_dev()
		{
			string query = "update dev_prov set  estado='" + Convert.ToInt32(this.Estado) + "' where id='" + this.Id + "'";
			runQuery(query);
		}
		public List<Dev_prov> get_devoluciones()
		{
			string query = "select id, id_proveedor, fecha, total, estado, motivo from dev_prov";
			MySqlDataReader data = runQuery(query);
			List<Dev_prov> result = new List<Dev_prov>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Dev_prov item = build_dev(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Dev_prov> get_devolucionesbyfolio(int folio)
		{
			string query = "select id, id_proveedor, fecha, total, estado, motivo from dev_prov where id='" + folio.ToString() +"'";
			MySqlDataReader data = runQuery(query);
			List<Dev_prov> result = new List<Dev_prov>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Dev_prov item = build_dev(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Dev_prov> get_lastdevolucion(int id_provee, double total, string motivo)
		{
			string query = "select id, id_proveedor, fecha, total, estado, motivo from dev_prov where id_proveedor='" + id_provee + "' and total='" + total + "' and motivo='" + motivo + "'";
			MySqlDataReader data = runQuery(query);
			List<Dev_prov> result = new List<Dev_prov>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Dev_prov item = build_dev(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Dev_prov> get_devolucionesbyproveedor(int id_proveedor)
		{
			string query = "select id, id_proveedor, fecha, total, estado, motivo from dev_prov where id_proveedor'" + id_proveedor.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Dev_prov> result = new List<Dev_prov>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Dev_prov item = build_dev(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
