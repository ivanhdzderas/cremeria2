using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public class Log:ConnectDB
	{
		public int Id { get; set; }
		public int Id_usuario { get; set; }
		public string Fecha { get; set; }
		public string Descripcion { get; set; }
		public bool Activo { get; set; }
		public Log(
			int id,
			int id_usuario,
			string fecha,
			string descripcion,
			bool activo
			)
		{
			Id = id;
			Id_usuario = id_usuario;
			Fecha = fecha; 
			Descripcion = descripcion;
			Activo = activo;
		}
		public Log()
		{

		}

		private Log build_log(MySqlDataReader data)
		{
			Log item = new Log(
				data.GetInt32("id"),
				data.GetInt32("usuario"),
				data.GetString("fecha"),
				data.GetString("descripcion"),
				Convert.ToBoolean(data.GetInt16("activo"))
				) ;
			return item;
		}
		public void createLog()
		{
			string query = "insert into tbalog (usuario, fecha, descripcion,activo) values ('" + this.Id_usuario + "', NOW(), '" + this.Descripcion + "',1)";
			object result = runQuery(query);

			Forms.intercambios intercambios = new Forms.intercambios();
			//intercambios.Bot_SendMessaeg("-430019282",this.Descripcion);

		}
		public List<Log> get_logbydate(string Fecha1)
		{
			string query = "select id, usuario, fecha, descripcion, activo from tbalog where fecha like '%"+Fecha1+"%'";
			MySqlDataReader data = runQuery(query);
			List<Log> result = new List<Log>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Log item = build_log(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
