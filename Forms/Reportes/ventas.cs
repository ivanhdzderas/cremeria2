﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms.Reportes
{
	public partial class ventas : Form
	{
		public ventas()
		{
			InitializeComponent();
		}

		private void ventas_Load(object sender, EventArgs e)
		{

			Finicial.Format = DateTimePickerFormat.Custom;
			Finicial.CustomFormat = "yyyy-MM-dd";
			Ffinal.Format = DateTimePickerFormat.Custom;
			Ffinal.CustomFormat = "yyyy-MM-dd";
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
