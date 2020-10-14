﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
	public class Permisos:ConnectDB
	{
		public int Id { get; set; }
		public int Id_usuario{ get; set; }
		public int May_men{ get; set; }
		public int Historia_venta{ get; set; }
		public int Entrada_efectivo{ get; set; }
		public int Salida_efectivo{ get; set; }
		public int Cobrar_ticket{ get; set; }
		public int Cancelar_ticket{ get; set; }
		public int Alimina_art_venta{ get; set; }
		public int Cred_cli{ get; set; }
		public int Mod_cli{ get; set; }
		public int Nuevo_prod{ get; set; }
		public int Mod_prod{ get; set; }
		public int Del_prod{ get; set; }
		public int Rep_venta{ get; set; }
		public int Nueva_promo{ get; set; }
		public int Add_mercancia{ get; set; }
		public int Ver_minimos{ get; set; }
		public int Ver_mov_inv{ get; set; }
		public int Ajus_inv{ get; set; }
		public int Corte_caja { get; set; }
		public int Corte_todos { get; set; }
		public int Ganancias { get; set; }
		public int Reporte_ganancias { get; set; }
		public int Retiro_efectivo { get; set; }
		public int Transferencias { get; set; }
		public int Devoluciones { get; set; }
		public int Cam_precio { get; set; }
		
		public Permisos(
			int id,
			int id_usuario,
			int may_men,
			int historia_venta,
			int entrada_efectivo,
			int salida_efectivo,
			int cobrar_ticket,
			int cancelar_ticket,
			int alimina_art_venta,
			int cred_cli,
			int mod_cli,
			int nuevo_prod,
			int mod_prod,
			int del_prod,
			int rep_venta,
			int nueva_promo,
			int add_mercancia,
			int ver_minimos,
			int ver_mov_inv,
			int ajus_inv,
			int corte_caja,
			int corte_todos,
			int ganancias,
			int reporte_ganancias,
			int retiro_efectivo,
			int trasnferencias,
			int devoluciones,
			int cam_precio
		) {
			Id = id;
			Id_usuario = id_usuario;
			May_men = may_men;
			Historia_venta = historia_venta;
			Entrada_efectivo = entrada_efectivo;
			Salida_efectivo = salida_efectivo;
			Cobrar_ticket = cobrar_ticket;
			Cancelar_ticket = cancelar_ticket;
			Alimina_art_venta = alimina_art_venta;
			Cred_cli = cred_cli;
			Mod_cli = mod_cli;
			Nuevo_prod = nuevo_prod;
			Mod_prod = mod_prod;
			Del_prod = del_prod;
			Rep_venta = rep_venta;
			Nueva_promo = nueva_promo;
			Add_mercancia = add_mercancia;
			Ver_minimos = ver_minimos;
			Ver_mov_inv = ver_mov_inv;
			Ajus_inv = ajus_inv;
			Corte_caja = corte_caja;
			Corte_todos = corte_todos;
			Ganancias = ganancias;
			Reporte_ganancias = reporte_ganancias;
			Retiro_efectivo = retiro_efectivo;
			Transferencias = trasnferencias;
			Devoluciones = devoluciones;
			Cam_precio = cam_precio;
		}
		public Permisos() { }

		private Permisos buildPermisos(MySqlDataReader data) {
			Permisos item = new Permisos(
				data.GetInt32("id"),
				data.GetInt32("id_usuario"),
				data.GetInt32("may_men"),
				data.GetInt32("historia_venta"),
				data.GetInt32("entrada_efectivo"),
				data.GetInt32("salida_efectivo"),
				data.GetInt32("cobrar_ticket"),
				data.GetInt32("cancelar_ticket"),
				data.GetInt32("alimina_art_venta"),
				data.GetInt32("cred_cli"),
				data.GetInt32("mod_cli"),
				data.GetInt32("nuevo_prod"),
				data.GetInt32("mod_prod"),
				data.GetInt32("del_prod"),
				data.GetInt32("rep_venta"),
				data.GetInt32("nueva_promo"),
				data.GetInt32("add_mercancia"),
				data.GetInt32("ver_minimos"),
				data.GetInt32("ver_mov_inv"),
				data.GetInt32("ajus_inv"),
				data.GetInt32("corte_caja"),
				data.GetInt32("corte_todos"),
				data.GetInt32("ganancias"),
				data.GetInt32("reporte_ganancias"),
				data.GetInt32("retiro_efectivo"),
				data.GetInt32("transferencias"),
				data.GetInt32("devoluciones"),
				data.GetInt32("cambio_precio")
				);
			return item;
		}
		public void createPermisos() {
			string query = "insert into tbapermisos ( id_usuario,may_men,historia_venta,entrada_efectivo,salida_efectivo,cobrar_ticket,cancelar_ticket,alimina_art_venta,cred_cli,mod_cli,nuevo_prod,mod_prod,del_prod,rep_venta,nueva_promo,add_mercancia,ver_minimos,ver_mov_inv,ajus_inv,corte_caja,corte_todos,ganancias,reporte_ganancias, retiro_efectivo, transferencias, devoluciones, cambio_precio)";
			query += "values (";
			query += "'" + this.Id_usuario + "', ";
			query += "'" + this.May_men + "', ";
			query += "'" + this.Historia_venta + "', ";
			query += "'" + this.Entrada_efectivo + "', ";
			query += "'" + this.Salida_efectivo + "', ";
			query += "'" + this.Cobrar_ticket + "', ";
			query += "'" + this.Cancelar_ticket + "', ";
			query += "'" + this.Alimina_art_venta + "', ";
			query += "'" + this.Cred_cli + "', ";
			query += "'" + this.Mod_cli + "', ";
			query += "'" + this.Nuevo_prod + "', ";
			query += "'" + this.Mod_prod + "', ";
			query += "'" + this.Del_prod + "', ";
			query += "'" + this.Rep_venta + "', ";
			query += "'" + this.Nueva_promo + "', ";
			query += "'" + this.Add_mercancia + "', ";
			query += "'" + this.Ver_minimos + "', ";
			query += "'" + this.Ver_mov_inv + "', ";
			query += "'" + this.Ajus_inv + "', ";
			query += "'" + this.Corte_caja + "', ";
			query += "'" + this.Corte_todos + "', ";
			query += "'" + this.Ganancias + "', ";
			query += "'" + this.Reporte_ganancias + "', ";
			query += "'" + this.Retiro_efectivo + "', ";
			query += "'" + this.Transferencias + "', ";
			query += "'" + this.Devoluciones + "', ";
			query += "'" + this.Cam_precio + "'";
			query += ")";
			object result = runQuery(query);
		}

		public void savePermisos() {
			string query = "update tbapermisos set ";
			query += "id_usuario='" + this.Id_usuario + "', ";
			query+="may_men='" + this.May_men + "', ";
			query+="historia_venta='" + this.Historia_venta + "', ";
			query+="entrada_efectivo='" + this.Entrada_efectivo + "', ";
			query+="salida_efectivo='" + this.Salida_efectivo + "', ";
			query+="cobrar_ticket='" + this.Cobrar_ticket + "', ";
			query+="cancelar_ticket='" + this.Cancelar_ticket + "', ";
			query+="alimina_art_venta='" + this.Alimina_art_venta + "', ";
			query+="cred_cli='" + this.Cred_cli + "', ";
			query+="mod_cli='" + this.Mod_cli + "', ";
			query+="nuevo_prod='" + this.Nuevo_prod + "', ";
			query+="mod_prod='" + this.Mod_prod + "', ";
			query+="del_prod='" + this.Del_prod + "', ";
			query+="rep_venta='" + this.Rep_venta + "', ";
			query+="nueva_promo='" + this.Nueva_promo + "', ";
			query+="add_mercancia='" + this.Add_mercancia + "', ";
			query+="ver_minimos='" + this.Ver_minimos + "', ";
			query+="ver_mov_inv='" + this.Ver_mov_inv + "', ";
			query += "corte_caja='" + this.Corte_caja + "', ";
			query += "corte_todos='" + this.Corte_todos + "', ";
			query += "ganancias='" + this.Ganancias + "', ";
			query += "reporte_ganancias='" + this.Reporte_ganancias + "', ";
			query += "ajus_inv='" + this.Ajus_inv + "', ";
			query += "retiro_efectivo='" + this.Retiro_efectivo + "', ";
			query += "transferencias='" + this.Transferencias + "', ";
			query += "devoluciones='" + this.Devoluciones + "', ";

			query += "cambio_precio='" + this.Cam_precio + "'";
			query += "where id='" + this.Id + "'";
			object result = runQuery(query);
		}
		string mac_query = "select id,id_usuario,may_men,historia_venta,entrada_efectivo,salida_efectivo,cobrar_ticket,cancelar_ticket,alimina_art_venta,cred_cli,mod_cli,nuevo_prod,mod_prod,del_prod,rep_venta,nueva_promo,add_mercancia,ver_minimos,ver_mov_inv,ajus_inv,corte_caja,corte_todos,ganancias,reporte_ganancias, retiro_efectivo, transferencias, devoluciones,cambio_precio from tbapermisos";
		public List<Permisos> getPermiso(int id_usuario) {
			string query = mac_query + " where id_usuario = '" + id_usuario.ToString() + "'";
			MySqlDataReader data = runQuery(query);
			List<Permisos> result = new List<Permisos>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Permisos item = buildPermisos(data);
					result.Add(item);
				}
			}
			return result;
		}
		public List<Permisos> getPermisos()
		{
			string query = mac_query;
			MySqlDataReader data = runQuery(query);
			List<Permisos> result = new List<Permisos>();
			if (data.HasRows)
			{
				while (data.Read())
				{
					Permisos item = buildPermisos(data);
					result.Add(item);
				}
			}
			return result;
		}

	}
}
