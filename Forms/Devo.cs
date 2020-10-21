using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms
{
	public partial class Devo : Form
	{
		public static int Folio;
		public static int Cuantos = 0;
		public Devo()
		{
			InitializeComponent();
		}

		private void Devo_Load(object sender, EventArgs e)
		{
			Models.Dev_prov devoluciones = new Models.Dev_prov();
			using (devoluciones)
			{
				List<Models.Dev_prov> listas = devoluciones.get_devolucionesbyfolio(Folio);
				if (listas.Count > 0)
				{
					txtFolio.Text = listas[0].Id.ToString();
					txtMotivo.Text = listas[0].Motivo;
					txtTotal.Text = listas[0].Total.ToString();
				}
			}

			Models.det_dev_prov detallado = new Models.det_dev_prov();
			Models.Product productos = new Models.Product();
			using (detallado)
			{
				List<Models.det_dev_prov> list = detallado.get_detalles(Folio);
				if (list.Count > 0)
				{
					foreach (Models.det_dev_prov item in list)
					{
						Cuantos = Cuantos + 1;
						using (productos)
						{
							List<Models.Product> producto = productos.getProductById(item.Id_producto);

							dtDevoluciones.Rows.Add(item.Id, item.Cantidad, producto[0].Code1, producto[0].Description, item.Pu, (item.Pu * item.Cantidad), item.Estado);
							if (item.Estado == true)
							{
								dtDevoluciones.Rows[dtDevoluciones.Rows.Count - 1].Cells["recibido"].ReadOnly = true;
							}
						}
					}
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult dialogo = MessageBox.Show("¿Desea agregar las devoluciones al inventario para su venta?",
			   "Devoluciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			

			int llegaron = 0;
			Models.det_dev_prov detallado = new Models.det_dev_prov();
			Models.Product productos = new Models.Product();
			Models.Log historial = new Models.Log();
			using (detallado)
			{
				foreach (DataGridViewRow row in dtDevoluciones.Rows)
				{
					if (Convert.ToBoolean(row.Cells["recibido"].Value) == true)
					{
						if (!row.Cells.IsReadOnly)
						{
							if (dialogo == DialogResult.Yes)
							{
								using (productos)
								{
									if (row.Cells["recibido"].ReadOnly == true)
									{

									}
									else
									{
										List<Models.Product> producto = productos.getProductBycode1(row.Cells["codigo"].Value.ToString());
										productos.Existencia = producto[0].Existencia + Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
										productos.Id = producto[0].Id;
										productos.update_inventary();

										using (historial)
										{
											historial.Id_usuario=Convert.ToInt32(Inicial.id_usario);
											historial.Descripcion = "se regreso " + row.Cells["cantidad"].Value.ToString() + " del producto " + row.Cells["descripcion"].Value.ToString();
											historial.createLog();
										}
									}
									
								}
							}
						}
						llegaron = llegaron + 1;
						detallado.Id = Convert.ToInt32(row.Cells["id"].Value);
						detallado.recibir();
					}
				}
			}
			Models.Dev_prov devolu = new Models.Dev_prov();
			using (devolu)
			{
				if (llegaron == Cuantos)
				{
					devolu.Estado = true;
					devolu.Id = Folio;
					devolu.termina_dev();
				}
			}
			
			
			this.Close();
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			printDocument1 = new PrintDocument();
			Models.Configuration configuracion = new Models.Configuration();
			int cuantos = dtDevoluciones.RowCount;
			int faltantes = 0;
			int valor;
			using (configuracion)
			{
				faltantes = cuantos - 1;
				valor = 110 * faltantes;
				valor = valor + 1150;
				PaperSize ps = new PaperSize("Custom", 300, valor);
				List<Models.Configuration> config = configuracion.getConfiguration();
				printDocument1.DefaultPageSettings.PaperSize = ps;
				printDocument1.PrinterSettings.PrinterName = config[0].Impresora;
				printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
				printDocument1.Print();
			}
		}

		private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
		{
			Models.Configuration configuracion = new Models.Configuration();
			Models.Dev_prov devoluciones = new Models.Dev_prov();
			Models.Providers proveedores = new Models.Providers();

			using (configuracion)
			{
				List<Models.Configuration> config = configuracion.getConfiguration();
				Font font = new Font("Verdana", 8, FontStyle.Regular);
				int y = 70;
				var format = new StringFormat() { Alignment = StringAlignment.Center };
				double cambio = 0;
				if (config[0].Logo_ticket != "")
				{
					if (File.Exists(config[0].Logo_ticket))
					{
						Image logo = Image.FromFile(config[0].Logo_ticket);
						e.Graphics.DrawImage(logo, new Rectangle(0, 00, 250, 70));
					}
				}

				string fecha = "";
				using (devoluciones)
				{
					List<Models.Dev_prov> listas = devoluciones.get_devolucionesbyfolio(Folio);
					fecha = listas[0].Fecha;
					List<Models.Providers> providers = proveedores.getProviderbyId(listas[0].Id_proveedor);
					if (providers.Count > 0)
					{
						y = y + 10;
						e.Graphics.DrawString(providers[0].Name, font, Brushes.Black, 125, y, format);
						y = y + 10;
						e.Graphics.DrawString(providers[0].RFC, font, Brushes.Black, 125, y, format);
						y = y + 10;
						string calle = providers[0].Street + " " + providers[0].Ext_number;
						if (providers[0].Int_number != "")
						{
							calle += "-" + providers[0].Int_number;
						}
						e.Graphics.DrawString(calle, font, Brushes.Black, 125, y, format);
						y = y + 10;
						e.Graphics.DrawString(providers[0].Muni + " " + providers[0].State, font, Brushes.Black, 125, y, format);
						y = y + 10;
						e.Graphics.DrawString("Telefono" + providers[0].Tel, font, Brushes.Black, 125, y, format);
						
					}
				}

				format = new StringFormat() { Alignment = StringAlignment.Far };
				y = y + 10;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);


				y = y + 15;
				e.Graphics.DrawString("Devolucion: " + Folio.ToString(), font, Brushes.Black, 0, y);
				y = y + 15;
				e.Graphics.DrawString("Fecha: " + fecha.ToString(), font, Brushes.Black, 0, y);
				y = y + 20;
				e.Graphics.DrawString("Cant.", font, Brushes.Black, 50, y, format);
				e.Graphics.DrawString("P/U.", font, Brushes.Black, 120, y, format);
				
				e.Graphics.DrawString("IMPTE.", font, Brushes.Black, 220, y, format);
				y = y + 10;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);

				double totali = 0;
				Models.det_dev_prov detallado = new Models.det_dev_prov();
				Models.Product productos = new Models.Product();
				using (detallado)
				{
					List<Models.det_dev_prov> list = detallado.get_detalles(Folio);
					if (list.Count > 0)
					{
						foreach (Models.det_dev_prov item in list)
						{
							
							using (productos)
							{
								List<Models.Product> producto = productos.getProductById(item.Id_producto);


								y = y + 30;
								e.Graphics.DrawString(producto[0].Description, font, Brushes.Black, 10, y);
								e.Graphics.DrawString(item.Cantidad.ToString(), font, Brushes.Black, 50, y + 10, format);
								e.Graphics.DrawString(string.Format("{0:#,0.00}", item.Pu), font, Brushes.Black, 120, y + 10, format);
								
								e.Graphics.DrawString(string.Format("{0:#,0.00}", (item.Pu * item.Cantidad)), font, Brushes.Black, 220, y + 10, format);
								totali = totali + 1;


							}
						}
					}
				}
				y = y + 15;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
				y = y + 15;
				e.Graphics.DrawString("Total", font, Brushes.Black, 120, y, format);

				e.Graphics.DrawString("$ " + string.Format("{0:#,0.00}", txtTotal.Text), font, Brushes.Black, 220, y, format);
			}
		}
	}
}
