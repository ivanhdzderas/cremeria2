using Cremeria.Models;
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
	public partial class Devoluciones : Form
	{
		public static Boolean cancelado;
		private static string Id;
		public static int id_usuario;
		public Devoluciones()
		{
			InitializeComponent();
		}
		private AutoCompleteStringCollection cargadatos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Product producto = new Models.Product();
			using (producto)
			{
				List< Models.Product > result = producto.getProducts();
				foreach (Models.Product item in result)
				{
					datos.Add(item.Code1);
				}
			}

			return datos;
		}
		private void devolucion()
		{
			Models.Devolutions devolucion = new Models.Devolutions();
			Models.Log historial = new Models.Log();
			using (devolucion)
			{
				devolucion.Fecha = dtFecha.Text + " 00:00:00";
				devolucion.Autorizo = id_usuario;
				devolucion.Total = Convert.ToDouble(txtTotal.Text);
				devolucion.create();
				List<Models.Devolutions> devo = devolucion.get_lastdevocion(dtFecha.Text + " 00:00:00", id_usuario, Convert.ToDouble(txtTotal.Text));

				Models.det_devolution detalles = new Models.det_devolution();
				using (detalles)
				{
					detalles.Id_devolucion = devo[0].Id;

					Models.Product productos = new Models.Product();
					foreach (DataGridViewRow row in dtProductos.Rows)
					{
						detalles.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
						detalles.Id_producto = Convert.ToInt16(row.Cells["id_producto"].Value.ToString());
						detalles.Pu = Convert.ToDouble(row.Cells["pu"].Value.ToString());
						detalles.Almacen = row.Cells["almacen"].Value.ToString();
						detalles.create_det();

						using (historial)
						{
							historial.Id_usuario=Convert.ToInt32(Inicial.id_usario);
							historial.Descripcion = "el usuairo "+ id_usuario+" autorizo la devolucion de " + row.Cells["cantidad"].Value.ToString()+" " + row.Cells["descripcion"].Value.ToString();
							historial.createLog();
						}
						
						using (productos)
						{

							productos.Id = Convert.ToInt16(row.Cells["id_producto"].Value.ToString());
							List<Models.Product> produ = productos.getProductById(Convert.ToInt16(row.Cells["id_producto"].Value.ToString()));
							if (row.Cells["almacen"].Value.ToString() == "Devolucion")
							{
								productos.Devoluciones = produ[0].Devoluciones + Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
								productos.update_devoluciones();
							}
							else
							{
								productos.Existencia = produ[0].Existencia + Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
								productos.update_inventary();
							}
							
						}
						
						

					}
				}


			}
			imprimir();
			limpiar();
			MessageBox.Show("Se guardo con exito la devolucion");
		}
		private void imprimir()
		{
			printDocument1 = new PrintDocument();
			Models.Configuration configuracion = new Models.Configuration();
			int cuantos = dtProductos.RowCount;
			int faltantes = 0;
			int valor = 0;
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
		private void limpiar()
		{
			dtProductos.Rows.Clear();
			txtTotal.Text = "";
			txtCodigo.Text = "";
			txtCantidad.Text = "";
			txtDescripcion.Text = "";
			txtPrecio.Text = "";
			id_usuario = 0;
			Id = "";

		}
		private void calcula()
		{
			double total = 0;
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				total += Convert.ToDouble(row.Cells["total"].Value.ToString());
			}
			txtTotal.Text = total.ToString();
		}
		private AutoCompleteStringCollection cargadatos2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Product producto = new Models.Product();
			using (producto)
			{
				List<Models.Product> result = producto.getProducts();
				foreach (Models.Product item in result)
				{
					datos.Add(item.Description);
				}
			}

			return datos;
		}
		private void Devoluciones_Load(object sender, EventArgs e)
		{
			dtFecha.Format = DateTimePickerFormat.Custom;
			dtFecha.CustomFormat = "yyyy-MM-dd";

			txtCodigo.AutoCompleteCustomSource = cargadatos();
			txtCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtDescripcion.AutoCompleteCustomSource = cargadatos2();
			txtDescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtDescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;

			cbAlmacen.Items.Add("Devolucion");
			cbAlmacen.Items.Add("Venta");
			cbAlmacen.SelectedIndex = 0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Autenficiar cb = new Autenficiar();
			Autenficiar.origen = "Devolucion";
			cancelado = false;
			cb.Owner = this;
			cb.ShowDialog();
			if (cancelado == false)
			{
				devolucion();
			}
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Product producto = new Models.Product();
				using (producto)
				{
					List<Models.Product> result = producto.getProductByCodeAbsolute(txtCodigo.Text);
					if (result.Count > 0)
					{
						txtDescripcion.Text = result[0].Description;
						txtPrecio.Text = result[0].Price1.ToString();
						Id = result[0].Id.ToString();
						txtCantidad.Text = "1";
						txtCantidad.Focus();
					}
				}

			}
		}

		private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Product producto = new Models.Product();
				using (producto)
				{
					List<Models.Product> result = producto.getProductByDescription(txtDescripcion.Text);
					if (result.Count > 0)
					{
						txtCodigo.Text = result[0].Code1;
						txtPrecio.Text = result[0].Price1.ToString();
						Id = result[0].Id.ToString();
						txtCantidad.Text = "1";
						txtCantidad.Focus();
					}
				}

			}
		}


		private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbAlmacen.Focus();
			}
		}

		private void cbAlmacen_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				double total = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecio.Text);
				dtProductos.Rows.Add(Id, txtCodigo.Text, txtCantidad.Text, txtDescripcion.Text, txtPrecio.Text, total, cbAlmacen.Text);
				txtCantidad.Text = "";
				txtDescripcion.Text = "";
				txtCodigo.Text = "";
				txtPrecio.Text = "";
				Id = "";
				calcula();
				txtCodigo.Focus();
			}
		}

		private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
		{
			Models.Configuration configuracion = new Models.Configuration();
			Models.Devolutions devoluciones = new Models.Devolutions();
			Models.det_devolution detallado = new Models.det_devolution();
			Models.Product productos = new Models.Product();
			using (configuracion)
			{
				List<Models.Configuration> config = configuracion.getConfiguration();
				Font font = new Font("Verdana", 8, FontStyle.Regular);
				int y = 70;
				var format = new StringFormat() { Alignment = StringAlignment.Center };
				if (config[0].Logo_ticket != "")
				{
					if (File.Exists(config[0].Logo_ticket))
					{
						Image logo = Image.FromFile(config[0].Logo_ticket);
						e.Graphics.DrawImage(logo, new Rectangle(0, 00, 250, 70));
					}
				}
				y = y + 10;
				e.Graphics.DrawString(config[0].Razon_social, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString(config[0].RFC, font, Brushes.Black, 125, y, format);
				y = y + 10;
				string calle = config[0].Calle + " " + config[0].No_ext;
				if (config[0].No_int != "")
				{
					calle += "-" + config[0].No_int;
				}
				e.Graphics.DrawString(calle, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString(config[0].Municipio + " " + config[0].Estado, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString("Telefono" + config[0].Telefono, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString(config[0].Razon_social, font, Brushes.Black, 125, y, format);
				format = new StringFormat() { Alignment = StringAlignment.Far };
				y = y + 10;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
				y = y + 15;
				using (devoluciones)
				{
					List<Models.Devolutions> devo = devoluciones.get_lastdevocion(dtFecha.Text, id_usuario, Convert.ToDouble(txtTotal.Text));
					e.Graphics.DrawString("Folio: " + devo[0].Id, font, Brushes.Black, 0, y);
					y = y + 20;
					e.Graphics.DrawString("Cant.", font, Brushes.Black, 50, y, format);
					e.Graphics.DrawString("P/U.", font, Brushes.Black, 120, y, format);
					
					e.Graphics.DrawString("IMPTE.", font, Brushes.Black, 220, y, format);
					y = y + 10;
					e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
					using (detallado)
					{
						List<Models.det_devolution> det = detallado.get_detalle(devo[0].Id);
						using (productos)
						{
							foreach(Models.det_devolution item in det)
							{
								List<Models.Product> producto = productos.getProductById(item.Id);
								y = y + 30;
								e.Graphics.DrawString(producto[0].Description, font, Brushes.Black, 10, y);
								e.Graphics.DrawString(item.Cantidad.ToString(), font, Brushes.Black, 50, y + 10, format);
								e.Graphics.DrawString(string.Format("{0:#,0.00}", item.Pu), font, Brushes.Black, 120, y + 10, format);

								
								e.Graphics.DrawString(string.Format("{0:#,0.00}", (item.Cantidad*item.Pu)), font, Brushes.Black, 220, y + 10, format);
							}
						}
					}
					y = y + 15;
					e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
					y = y + 15;
					e.Graphics.DrawString("Total", font, Brushes.Black, 150, y + 10, format);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", devo[0].Total), font, Brushes.Black, 220, y + 10, format);
				}
				

			}
		}
	}
}
