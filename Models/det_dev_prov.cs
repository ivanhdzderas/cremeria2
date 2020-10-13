using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public class det_dev_prov:ConnectDB
	{
		public int Id { get; set; }
		public int Id_devolucion { get; set; }
		public int Id_producto { get; set; }
		public double Cantidad { get; set; }
		public double Pu { get; set; }
		public Boolean Estado { get; set; }

		public det_dev_prov(
			int id,
			int id_devolucion, 
			int id_producto,
			double cantidad,
			double pu, 
			Boolean estado
			)
		{
			Id = id;
			Id_devolucion = id_devolucion;
			Id_producto = id_producto;
			Cantidad = cantidad;
			Pu = pu;
			Estado = estado;
		}

		public det_dev_prov()
		{

		}

		private det_dev_prov build_detalle(MySqlDataReader data)
		{
			det_dev_prov item = new det_dev_prov(
				data.GetInt32("id"),
				data.GetInt32("id_devolucion"),
				data.GetInt32("id_producto"),
				data.GetDouble("cantidad"),
				data.GetDouble("pu"),
				Convert.ToBoolean(data.GetInt32("estado"))
				);
			return item;
		}
		public void create_det()
		{
			string query = "insert into det_dev_pro (id_devolucion, id_producto, cantidad, pu, estado) values ('" + this.Id_devolucion + "', '" + this.Id_producto + "', '" + this.Cantidad + "', '" +  this.Pu + "', '" + Convert.ToInt32(this.Estado) + "')";
			runQuery(query);
		}
		public void recibir()
		{
			string query = "update det_dev_pro set estado='" + Convert.ToInt32(true) + "' where id='" + this.Id + "'";
			runQuery(query);
		}
		public void delete_det()
		{
			string query = "delete from det_dev_pro where id_devolucion='" + this.Id_devolucion + "'";
			runQuery(query);
		}
		public List<det_dev_prov> get_detalles(int id_devo)
		{
			string query = "select id, id_devolucion, id_producto, cantidad, pu, estado from det_dev_pro where id_devolucion='" + id_devo + "'";
			MySqlDataReader data = runQuery(query);
			List<det_dev_prov> result = new List<det_dev_prov>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					det_dev_prov item = build_detalle(data);
					result.Add(item);
				}
			}
			return result;
		}

	}
}
