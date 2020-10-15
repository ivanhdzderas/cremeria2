using Microsoft.Office.Interop.Excel;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Cremeria.Forms.Reportes
{
	public partial class ventas : Form
	{
		public ventas()
		{
			InitializeComponent();
		}
		private void generar()
		{
			System.Data.DataTable tabla1 = new System.Data.DataTable();
			tabla1.Columns.Add("Usuario");
			tabla1.Columns.Add("Fecha");
			tabla1.Columns.Add("Descripcion");
			Models.Log historia = new Models.Log();
			Models.Users usuarios = new Models.Users();
			using (historia)
			{
				using (usuarios)
				{
					List<Models.Log> logs = historia.get_logbydate(DateTime.Now.ToString("yyyy-MM-dd"));
					if (logs.Count > 0)
					{
						foreach (Models.Log item in logs)
						{
							List<Models.Users> usuario = usuarios.getUserbyid(item.Id_usuario);
							tabla1.Rows.Add(usuario[0].Nombre, item.Fecha, item.Descripcion);
						}
					}
				}
			}
			System.Data.DataTable tabla2 = new System.Data.DataTable();
			tabla2.Columns.Add("Folio");
			tabla2.Columns.Add("Sucursal");
			tabla2.Columns.Add("Total");
			Models.Reports.Transferencias transferencias = new Models.Reports.Transferencias();
			Models.Offices sucursales = new Models.Offices();
			using (transferencias)
			{
				using (sucursales)
				{
					List<Models.Reports.Transferencias> transfer = transferencias.getTransferbyDate(DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"), "E");
					if (transfer.Count > 0)
					{
						foreach (Models.Reports.Transferencias item in transfer)
						{
							List<Models.Offices> oficina = sucursales.GetOfficesbyid(Convert.ToInt32(item.Sucursal));
							tabla2.Rows.Add(item.Folio, oficina[0].Name, item.Monto);
						}
					}
				}
			}
			System.Data.DataTable tabla3 = new System.Data.DataTable();
			tabla3.Columns.Add("Monto");
			System.Data.DataTable tabla4 = new System.Data.DataTable();
			tabla4.Columns.Add("Proveedor");
			tabla4.Columns.Add("Monto");
			double Total_proveedor = 0;
			Models.retiro_efectivo retiros = new Models.retiro_efectivo();
			Models.Providers proveedores = new Models.Providers();
			using (retiros)
			{
				List<Models.retiro_efectivo> retiro = retiros.get_retiro_fecha(DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
				if (retiro.Count > 0)
				{
					foreach (Models.retiro_efectivo item in retiro)
					{
						if (item.Id_proveedor == 0)
						{
							if (item.Monto != 0)
							{
								tabla3.Rows.Add(item.Monto);
							}
							else
							{
								tabla3.Rows.Add(item.Monto_proveedor);
							}
						}
						else
						{
							using (proveedores)
							{
								Total_proveedor = Total_proveedor + item.Monto_proveedor;
								List<Models.Providers> proveedor = proveedores.getProviderbyId(item.Id_proveedor);
								tabla4.Rows.Add(proveedor[0].Name, item.Monto_proveedor);
							}
						}
					}
				}
			}
			double total_tickets = 0;
			System.Data.DataTable tabla5 = new System.Data.DataTable();
			tabla5.Columns.Add("Tickets");
			tabla5.Columns.Add("Traspasos");
			tabla5.Columns.Add("Total del dia");
			Models.Reports.Tickets tickets = new Models.Reports.Tickets();
			using (tickets)
			{
				List<Models.Reports.Tickets> listado = tickets.get_tickets(DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
				if (listado.Count > 0)
				{
					foreach (Models.Reports.Tickets item in listado)
					{
						total_tickets = total_tickets + item.Total;
					}
				}
			}
			tabla5.Rows.Add(total_tickets, Total_proveedor, (total_tickets + Total_proveedor));
			Models.Export_pdf pdf = new Models.Export_pdf();
			pdf.genera_reporte(tabla1, tabla2, tabla3, tabla4, tabla5, "reporte.pdf", "Reporte diario");
			intercambios intercambios = new intercambios();
			intercambios.enviar_correo("reporte.pdf","Envio reporte del dia","Reporte Diario");
		}
		private void ventas_Load(object sender, EventArgs e)
		{
			Finicial.Format = DateTimePickerFormat.Custom;
			Finicial.CustomFormat = "yyyy-MM-dd";
			Ffinal.Format = DateTimePickerFormat.Custom;
			Ffinal.CustomFormat = "yyyy-MM-dd";
			generar();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Models.Reports.Tickets diario = new Models.Reports.Tickets();
			Models.retiro_efectivo retiros = new Models.retiro_efectivo();
			Models.Reports.Totales totales = new Models.Reports.Totales();
			Models.Reports.Encaja encaja = new Models.Reports.Encaja();
			Models.Reports.Retiro_proveedores retiro_proveedores = new Models.Reports.Retiro_proveedores();
			Models.Providers proveedores = new Models.Providers();
			Models.Cortes cortes = new Models.Cortes();
			Models.Reports.Retiro_efectivo retiro_efectivo = new Models.Reports.Retiro_efectivo();
			Models.Reports.Mas_vendidos mas_vedidos = new Models.Reports.Mas_vendidos();
			Models.Reports.Transferencias transferencias = new Models.Reports.Transferencias();
			using (diario)
			{
				using (retiros)
				{
					using (cortes)
					{
						using (proveedores)
						{
							using (mas_vedidos)
							{
								using (transferencias)
								{
									this.reportViewer1.LocalReport.ReportEmbeddedResource = "Cremeria.Reports.corte.rdlc";
									this.reportViewer1.LocalReport.DataSources.Clear();
									List<Models.Reports.Tickets> reporte = diario.get_tickets(Finicial.Text, Ffinal.Text);
									List<Models.Reports.Mas_vendidos> lista_vendidos = mas_vedidos.get_masvendidos(Finicial.Text, Ffinal.Text);
									ReportDataSource datasource = new ReportDataSource("Mas_vendidos", lista_vendidos);
									this.reportViewer1.LocalReport.DataSources.Add(datasource);
									foreach (Models.Reports.Tickets item in reporte)
									{
										if (item.Status == "A")
										{
											totales.Total = totales.Total + item.Total;
										}
									}
									List<Models.Cortes> no_cerrado = cortes.getnoclose(Convert.ToInt16(Inicial.id_usario));
									if (no_cerrado.Count > 0)
									{
										encaja.Fondo = no_cerrado[0].Caja_inicial;
									}
									else
									{
										encaja.Fondo = 0;
									}
									List<Models.Reports.Transferencias> listad = transferencias.getTransferbyDate(Finicial.Text, Ffinal.Text, "E");
									foreach(Models.Reports.Transferencias item in listad)
									{
									totales.Traspasos = totales.Traspasos + item.Monto;
									}
									totales.Gran_total = totales.Total + totales.Traspasos;
									ReportDataSource tra = new ReportDataSource("transfer", listad);
									this.reportViewer1.LocalReport.DataSources.Add(tra);
									List<Models.retiro_efectivo> ret = retiros.get_retiro_fecha(Finicial.Text, Ffinal.Text);
									List<Models.Reports.Retiro_proveedores> lista_retiro_proveedores = new List<Models.Reports.Retiro_proveedores>();
									List<Models.Reports.Retiro_efectivo> reti = new List<Models.Reports.Retiro_efectivo>();
									foreach (Models.retiro_efectivo item in ret)
									{
										if (item.Id_proveedor == 0)
										{
											retiro_efectivo.Monto = item.Monto_proveedor;
											if (item.Monto != 0)
											{
												encaja.Retiros = encaja.Retiros + item.Monto;
											}
											else {
												encaja.Retiros = encaja.Retiros + item.Monto_proveedor;
											}
												
											reti.Add(new Models.Reports.Retiro_efectivo(item.Monto));
										}
										else
										{
											List<Models.Providers> proveedor = proveedores.getProviderbyId(item.Id_proveedor);
											retiro_proveedores.Proveedor = proveedor[0].Name;
											retiro_proveedores.Monto = item.Monto_proveedor;
											lista_retiro_proveedores.Add(new Models.Reports.Retiro_proveedores(proveedor[0].Name, item.Monto_proveedor));
										}
									}
									ReportDataSource prov = new ReportDataSource("Proveedores", lista_retiro_proveedores);
									this.reportViewer1.LocalReport.DataSources.Add(prov);
									ReportDataSource rettt = new ReportDataSource("retiro_efectivo", reti);
									this.reportViewer1.LocalReport.DataSources.Add(rettt);
									List<Models.Reports.Encaja> Lista_encaja = new List<Models.Reports.Encaja>();
									Lista_encaja.Add(encaja);
									ReportDataSource caj = new ReportDataSource("EnCaja", Lista_encaja);
									this.reportViewer1.LocalReport.DataSources.Add(caj);
									List<Models.Reports.Totales> tot = new List<Models.Reports.Totales>();
									tot.Add(totales);
									ReportDataSource ven = new ReportDataSource("Totales", tot);
									this.reportViewer1.LocalReport.DataSources.Add(ven);
									this.reportViewer1.RefreshReport();
								}
							}
						}
					}
				}
			}
		}
	}
}