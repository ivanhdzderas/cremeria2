using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public class det_devolution:ConnectDB
	{
		public int Id { get; set; }
		public int Id_devolucion { get; set; }
		public double Cantidad { get; set; }
		public int Id_producto { get; set; }
		public double Pu { get; set; }
		public string Almacen { get; set; }
		public det_devolution(
			int id, 
			int id_devolucion, 
			double cantidad,
			int id_producto, 
			double pu,
			string almacen
			)
		{
			Id = id;
			Id_devolucion = id_devolucion;
			Cantidad = cantidad;
			Id_producto = id_producto;
			Pu = pu;
			Almacen = almacen;
		}
		 
		public det_devolution() { }

		private det_devolution build_detdevo(MySqlDataReader data)
		{
			det_devolution item = new det_devolution(
				data.GetInt32("id"),
				data.GetInt32("id_devolucion"),
				data.GetDouble("cantidad"),
				data.GetInt32("id_producto"),
				data.GetDouble("pu"),
				data.GetString("almacen")
				) ;
			return item;
		}
		public void enviar()
		{
			string query = "update tbadetdevo set estado='E' where id_devolucion='" + this.Id_devolucion + "' and id_producto='" + this.Id_producto + "'";
			object result = runQuery(query);
		}
		public void create_det()
		{
			string query = "insert into tbadetdevo (id_devolucion, cantidad, id_producto, pu, almacen) values ('" + this.Id_devolucion + "', '" + this.Cantidad + "', '" + this.Id_producto + "', '" + this.Pu + "', '" + this.Almacen + "')";
			object result = runQuery(query);
		}

		public List<det_devolution> get_detalle(int id_devo)
		{
			string query = "select id, id_devolucion, cantidad, id_producto, pu, almacen from tbadetdevo where id_devolucion='" + id_devo.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<det_devolution> result = new List<det_devolution>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					det_devolution item = build_detdevo(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<det_devolution> get_no_enviados()
		{
			string query = "select id, id_devolucion, cantidad, id_producto, pu, almacen from tbadetdevo where estado='N'";
			MySqlDataReader data = runQuery(query);
			List<det_devolution> result = new List<det_devolution>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					det_devolution item = build_detdevo(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<det_devolution> get_detallebyproveedor(int id_proveedor)
		{
			string query = "select tbadetdevo.id, tbadetdevo.id_devolucion, tbadetdevo.cantidad, tbadetdevo.id_producto, tbadetdevo.pu, tbadetdevo.almacen from tbadetdevo inner join tbaproductos on tbadetdevo.id_producto=tbaproductos.id inner join tbadevoluciones on tbadevoluciones.id=tbadetdevo.id_devolucion where tbaproductos.proveedor='" + id_proveedor + "' and tbadevoluciones.estado='N' group by tbadetdevo.id_producto";
			MySqlDataReader data = runQuery(query);
			List<det_devolution> result = new List<det_devolution>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					det_devolution item = build_detdevo(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
