﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public class Tickets:ConnectDB
	{
		public int Id { get; set; }
		public int Folio { get; set; }
		public int Id_cliente { get; set; }
		public string Fecha { get; set; }
		public double Subtotal { get; set; }
		public double Descuento { get; set; }
		public double Iva { get; set; }
		public double Total { get; set; }
		public string Status { get; set; }
		public double C_iva { get; set; }
		public double S_iva { get; set; }
		public int Id_usuario { get; set; }
		public int Atienda { get; set; }
		public int A_facturar { get; set; }
		public double Recibido { get; set; }
		public Tickets(
			int id,
			int folio,
			int id_cliente,
			string fecha, 
			double subtotal,
			double descuento,
			double iva,
			double total,
			string status,
			double c_iva,
			double s_iva,
			int id_usuario,
			int atienda,
			int a_facturar,
			double recibido
			) {
			Id = id;
			Folio = folio;
			Id_cliente = id_cliente;
			Fecha = fecha;
			Subtotal = subtotal;
			Descuento = descuento;
			Iva = iva;
			Total = total;
			Status = status;
			C_iva = c_iva;
			S_iva = s_iva;
			Id_usuario = id_usuario;
			Atienda = atienda;
			A_facturar = a_facturar;
			Recibido = recibido;
		}
		public Tickets() { }
		public void CancelTicket()
		{
			string query = "update tbatickets set status='C' where folio='" + this.Folio + "'";
			runQuery(query);
		}
		public void termina()
		{
			string query = "update tbatickets set a_facturar='" + this.A_facturar + "'";
			runQuery(query);
		}
		public void CreateTicket()
		{
			string query = "insert into tbatickets (folio,id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario, atendio, a_facturar, recibido) values (";
			query += "'" + this.Folio + "', ";
			query += "'" + this.Id_cliente + "', ";
			query += "NOW(), ";
			query += "'" + this.Subtotal + "', ";
			query += "'" + this.Descuento + "', ";
			query += "'" + this.Iva + "', ";
			query += "'" + this.Total + "', ";
			query += "'" + this.Status + "', ";
			query += "'" + this.C_iva + "', ";
			query += "'" + this.S_iva + "', ";
			query += "'" + this.Id_usuario + "',";
			query += "'" + this.Atienda + "', ";
			query += "'" + this.A_facturar + "', ";
			query += "'" + this.Recibido + "')";

			object result = runQuery(query);
		}
		public void update_ticket()
		{
			string query = "update tbatickets set ";
			query += "folio='" + this.Folio + "', ";
			query += "id_cliente='" + this.Id_cliente + "', ";
			query += "subtotal='" + this.Subtotal + "', ";
			query += "descuento='" + this.Descuento + "', ";
			query += "iva='" + this.Iva + "', ";
			query += "total='" + this.Total + "', ";
			query += "status='" + this.Status + "', ";
			query += "c_iva='" + this.C_iva + "', ";
			query += "s_iva='" + this.S_iva + "', ";
			query += "id_usuario='" + this.Id_usuario + "',";
			query += "atendio='" + this.Atienda + "', ";
			query += "a_facturar='" + this.A_facturar + "', ";
			query += "recibido='" + this.Recibido + "' ";
			query += "where id='" + this.Id + "'";
			runQuery(query);
		}
		public void update_ticketbyfolio()
		{
			string query = "update tbatickets set ";
			query += "id_cliente='" + this.Id_cliente + "', ";
			query += "subtotal='" + this.Subtotal + "', ";
			query += "descuento='" + this.Descuento + "', ";
			query += "iva='" + this.Iva + "', ";
			query += "total='" + this.Total + "', ";
			query += "status='" + this.Status + "', ";
			query += "c_iva='" + this.C_iva + "', ";
			query += "s_iva='" + this.S_iva + "', ";
			query += "id_usuario='" + this.Id_usuario + "',";
			query += "atendio='" + this.Atienda + "', ";
			query += "a_facturar='" + this.A_facturar + "', ";
			query += "recibido='" + this.Recibido + "' ";
			query += "where folio='" + this.Folio + "'";
			runQuery(query);
		}
		public void delete_ticket()
		{
			string query = "delete from tbatickets where id='" + this.Id + "'";
			runQuery(query);
		}
		private Tickets buildTicket(MySqlDataReader data) {
			Tickets item = new Tickets(
				data.GetInt32("id"),
				data.GetInt32("folio"),
				data.GetInt32("id_cliente"),
				data.GetString("fecha"),
				data.GetDouble("subtotal"),
				data.GetDouble("descuento"),
				data.GetDouble("iva"),
				data.GetDouble("total"),
				data.GetString("status"),
				data.GetDouble("c_iva"),
				data.GetDouble("s_iva"),
				data.GetInt32("id_usuario"),
				data.GetInt32("atendio"),
				data.GetInt32("a_facturar"),
				data.GetDouble("recibido")
				);
			return item;
		}

		public List<Tickets> getTickets() {
			string query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario,atendio, a_facturar, recibido from tbatickets";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Tickets> getTicketsbypromotor(int promotor, string fecha1, string fecha2 )
		{
			string query = "";
			if (fecha1 == fecha2)
			{
				query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario,atendio, a_facturar, recibido from tbatickets where status='A' and folio<>0 and DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d') = '" + fecha1 + "' and atendio='" + promotor.ToString() + "'";
			}
			else
			{
				//query = "select tbatickets.folio,tbatickets.total,(select IFNULL(sum(((tbadetticket.pu-tbadetticket.costo)*tbadetticket.cantidad)),0) from tbadetticket where tbadetticket.id_ticket=tbatickets.id) as ganancia, tbatickets.status,tbatickets.c_iva,tbatickets.s_iva  from tbatickets where status<>'G' and folio<>0 and  DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d') BETWEEN  '" + Fecha1 + "' and  '" + Fecha2 + "' ";
				query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario,atendio, a_facturar, recibido from tbatickets where status='A' and folio<>0 and  DATE_FORMAT(tbatickets.fecha,'%Y-%m-%d') BETWEEN  '" + fecha1 + "' and  '" + fecha2 + "' and atendio='" + promotor.ToString() + "'";
			}

			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Tickets> getTickets_guardados()
		{
			string query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario,atendio, a_facturar, recibido from tbatickets where status='G' order by folio desc";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Tickets> get_last_ticket(string fecha, int id_cliente, int id_usuario)
		{
			string query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario,atendio, a_facturar, recibido from tbatickets where id_cliente='" + id_cliente + "' and folio='0' and id_usuario='"+id_usuario+"'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Tickets> getTickets_porfacturar()
		{
			string query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario,atendio, a_facturar, recibido from tbatickets where a_facturar='1'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Tickets> getTickets_sin_pago()
		{
			string query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario,atendio, a_facturar, recibido  from tbatickets where id not in (select id_ticket  from  tbapagticket)";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Tickets> getTicketsbyId(int id)
		{
			string query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario,atendio, a_facturar, recibido  from tbatickets where id='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Tickets> getTicketsbyFolio(int id)
		{
			string query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario,atendio, a_facturar, recibido  from tbatickets where folio='" + id.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Tickets> getActiveTicketsbyId(int id)
		{
			string query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario,atendio, a_facturar, recibido  from tbatickets where folio='" + id.ToString() + "' and status='A'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Tickets> getTicketsToday(string fecha)
		{
			string query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva,id_usuario, atendio, a_facturar, recibido from tbatickets where fecha like '%" + fecha + "%'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Tickets> getbyclient(string id_cliente)
		{
			string query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva,id_usuario, atendio, a_facturar, recibido from tbatickets where id_cliente='" + id_cliente + "'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Tickets> getTicketsbyFechas(string fecha1, string fecha2)
		{
			string query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva,id_usuario, atendio, a_facturar, recibido from tbatickets where fecha BETWEEN '" + fecha1 + "' and '" + fecha2 + "'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Tickets> getLastTicket(string fecha, double subtotal, double descuento, double iva, double total, int cliente)
		{
			string query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario, atendio, a_facturar, recibido from tbatickets where fecha='" + fecha + "' and subtotal='" + subtotal.ToString() + "' and iva='" + iva.ToString() + "' and descuento='" + descuento.ToString() + "' and total='" + total.ToString() + "' and id_cliente='" + cliente + "'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Tickets> getbyUser(int id_perosna)
		{
			DateTime thisDay = DateTime.Today;

			string query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario, atendio, a_facturar, recibido from tbatickets where id_usuario='" + id_perosna.ToString() + "' and fecha like '%" + thisDay.ToString("yyyy-MM-dd") + "%'";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}

		public List<Tickets> get_folio()
		{
			DateTime thisDay = DateTime.Today;

			string query = "select id,folio, id_cliente, fecha, subtotal, descuento, iva, total, status, c_iva, s_iva, id_usuario, atendio, a_facturar, recibido from tbatickets order by id desc";
			MySqlDataReader data = runQuery(query);
			List<Tickets> result = new List<Tickets>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Tickets item = buildTicket(data);
					result.Add(item);
				}
			}
			return result;
		}
	}
}
