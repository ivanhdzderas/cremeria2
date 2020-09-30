﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public class Fpagos:ConnectDB
	{
		public int Id { get; set; }
		public string Fpago { get; set; }

		public Fpagos(int id,
			string fpago)
		{
			Id = id;
			Fpago = fpago;
		}
		public Fpagos()
		{

		}
		private Fpagos buildFpago(MySqlDataReader data) {
			Fpagos item = new Fpagos(
				Convert.ToInt32(data.GetInt16("c_formapago")),
				data.GetString("descripcion")
				);
			return item;
		}

		public List<Fpagos> getpagos()
		{
			string query = "select c_formapago,descripcion from zz33_formapago";
			MySqlDataReader data = runQuery(query);
			List<Fpagos> result = new List<Fpagos>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Fpagos item = buildFpago(data);
					result.Add(item);

				}
			}
			return result;
		}

		public List<Fpagos> getpagosbyid(string id)
		{
			string query = "select c_formapago,descripcion from zz33_formapago where c_formapago='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Fpagos> result = new List<Fpagos>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Fpagos item = buildFpago(data);
					result.Add(item);

				}
			}
			return result;
		}

		public List<Fpagos> getpagosbydescripcion(string descripcion)
		{
			string query = "select c_formapago,descripcion from zz33_formapago where descripcion='" + descripcion + "'";
			MySqlDataReader data = runQuery(query);
			List<Fpagos> result = new List<Fpagos>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Fpagos item = buildFpago(data);
					result.Add(item);

				}
			}
			return result;
		}


		public List<Fpagos> getpagosbyidlike(string codigo)
		{
			string query = "select c_formapago,descripcion from zz33_formapago where c_formapago like '" + codigo + "'";
			MySqlDataReader data = runQuery(query);
			List<Fpagos> result = new List<Fpagos>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Fpagos item = buildFpago(data);
					result.Add(item);

				}
			}
			return result;
		}
	}
}
