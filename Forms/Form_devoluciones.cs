using Cremeria.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Cremeria.Forms
{
	public partial class Form_devoluciones : Form
	{
		static int Folio_guardado;
		int Id_producto;
		public Form_devoluciones()
		{
			InitializeComponent();
		}

		private void Form_devoluciones_Load(object sender, EventArgs e)
		{
			txtId_proveedor.AutoCompleteCustomSource = carga_id_proveedor();
			txtId_proveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtId_proveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtProveedor.AutoCompleteCustomSource = carga_proveedor();
			txtProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtCodigo.AutoCompleteCustomSource = carga_codigo();
			txtCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;


			txtDescripcion.AutoCompleteCustomSource = carga_productos();
			txtDescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtDescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;

			
		}

		private AutoCompleteStringCollection carga_productos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Product productos = new Models.Product();
			using (productos)
			{
				List<Models.Product> result = productos.getProducts();
				foreach (Models.Product item in result)
				{
					datos.Add(item.Description);
				}
				return datos;
			}
		}

		private AutoCompleteStringCollection carga_codigo()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Product productos = new Models.Product();
			using (productos)
			{
				List<Models.Product> result = productos.getProducts();
				foreach (Models.Product item in result)
				{
					datos.Add(item.Code1);
				}
				return datos;
			}
		}

		private AutoCompleteStringCollection carga_proveedor()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Providers proveedores = new Models.Providers();
			using (proveedores)
			{
				List<Models.Providers> result = proveedores.getProviders();
				foreach (Models.Providers item in result)
				{
					datos.Add(item.Name);
				}
				return datos;
			}
		}

		private AutoCompleteStringCollection carga_id_proveedor()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Providers proveedores = new Models.Providers();
			using (proveedores)
			{
				List<Models.Providers> result = proveedores.getProviders();
				foreach (Models.Providers item in result)
				{
					datos.Add(item.Id.ToString());
				}
				return datos;
			}
		}
		private void agregar()
		{
			Models.prov_prod costos = new Models.prov_prod();
			using (costos)
			{
				List<Models.prov_prod> costo = costos.get_costobyproveedorandprodu(Id_producto,Convert.ToInt32(txtId_proveedor.Text));
				if (costo.Count > 0)
				{
					dtProductos.Rows.Insert(0, Id_producto, txtCantidad.Text, txtCodigo.Text, txtDescripcion.Text, "", txtPu.Text, (Convert.ToDouble(txtPu.Text) * Convert.ToDouble(txtCantidad.Text)));
					Id_producto = 0;
					txtCantidad.Text = "";
					txtCodigo.Text = "";
					txtPu.Text = "";
					txtDescripcion.Text = "";
					txtCantidad.Focus();
					calcula();
				}
			}
		}
		private void calcula()
		{
			double total = 0;
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				total = total + Convert.ToDouble(row.Cells["importe"].Value.ToString());

			}
			txtTotal.Text = total.ToString();
		}
		private void sugerido()
		{
			string foliados = "";
			DialogResult dialogo = MessageBox.Show("¿Desea cargar el sugerido?", "Sugerido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogo == DialogResult.Yes)
			{
				dtProductos.Rows.Clear();
				Models.det_devolution det_devo_clie = new Models.det_devolution();
				Models.Product productos = new Models.Product();
				using (det_devo_clie)
				{
					List<Models.det_devolution> devo = det_devo_clie.get_detallebyproveedor(Convert.ToInt32(txtId_proveedor.Text));
					List<Models.det_devolution> listas = det_devo_clie.get_no_enviados();
					if (devo.Count > 0)
					{
						foreach(Models.det_devolution alfa in listas)
						{
							if (foliados == "")
							{
								foliados = alfa.Id.ToString();
							}
							else
							{
								foliados = foliados + "," + alfa.Id.ToString();
							}
							
						}
						foreach(Models.det_devolution item in devo)
						{
							using (productos)
							{
								List<Models.Product> producto = productos.getProductById(item.Id_producto);
								dtProductos.Rows.Add(item.Id_producto, item.Cantidad, producto[0].Code1, producto[0].Description,producto[0].Unit, producto[0].Cost,(producto[0].Cost*item.Cantidad), foliados);
							}
						}
						
					}
				}
				calcula();
			}
		}
		private void txtId_proveedor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Providers proveedores = new Models.Providers();
				using (proveedores)
				{
					List<Models.Providers> result = proveedores.getProviderbyId(Convert.ToInt32(txtId_proveedor.Text));
					if (result.Count > 0)
					{
						txtProveedor.Text = result[0].Name;

						sugerido();
					}
				}
			}
		}

		private void txtProveedor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Providers proveedores = new Models.Providers();
				using (proveedores)
				{
					List<Models.Providers> result = proveedores.getProviderbyNombre(txtProveedor.Text);
					if (result.Count > 0)
					{
						txtId_proveedor.Text = result[0].Id.ToString();

						sugerido();
					}
				}
			}
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				Buscar_producto busca = new Buscar_producto();
				busca.ShowDialog();
				if (intercambios.Id_producto != 0)
				{
					Models.Product productos = new Models.Product();
					using (productos)
					{
						List<Models.Product> producto = productos.getProductById(intercambios.Id_producto);
						if (producto.Count > 0)
						{
							txtCodigo.Text = producto[0].Code1;
							txtDescripcion.Text = producto[0].Description;
							txtPu.Text = string.Format("{0:#,0.00}", producto[0].Cost);
							txtDescripcion.Focus();
							Id_producto = producto[0].Id;
						}
					}
				}
			}
			if (e.KeyCode == Keys.Enter)
			{
				Models.Product productos = new Models.Product();
				using (productos)
				{
					List<Models.Product> producto = productos.getProductByCodeAbsolute(txtCodigo.Text);
					if (producto.Count > 0)
					{
						txtDescripcion.Text = producto[0].Description;
						txtPu.Text= string.Format("{0:#,0.00}", producto[0].Cost);
						txtDescripcion.Focus();
						Id_producto = producto[0].Id;
					}
				}
			}
		}

		private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				Buscar_producto busca = new Buscar_producto();
				busca.ShowDialog();
				if (intercambios.Id_producto != 0)
				{
					Models.Product productos = new Models.Product();
					using (productos)
					{
						List<Models.Product> producto = productos.getProductById(intercambios.Id_producto);
						if (producto.Count > 0)
						{
							txtCodigo.Text = producto[0].Code1;
							txtDescripcion.Text = producto[0].Description;
							txtPu.Text = string.Format("{0:#,0.00}", producto[0].Cost);
							txtDescripcion.Focus();
							Id_producto = producto[0].Id;
						}
					}
				}
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtDescripcion.Text!="" && txtCodigo.Text!="" && txtPu.Text != "")
				{
					agregar();
				}
				else
				{
					Models.Product productos = new Models.Product();
					using (productos)
					{
						List<Models.Product> producto = productos.getProductByDescription(txtDescripcion.Text);
						if (producto.Count > 0)
						{
							txtCodigo.Text = producto[0].Code1;
							txtPu.Text = string.Format("{0:#,0.00}", producto[0].Cost);
							txtDescripcion.Focus();
							Id_producto = producto[0].Id;
						}
					}
				}
				
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Models.Dev_prov devo = new Models.Dev_prov();
			Models.det_dev_prov detalles = new Models.det_dev_prov();
			Models.Product productos = new Models.Product();
			Models.det_devolution det_devolu = new Models.det_devolution();
			Models.Log historial = new Models.Log();
			using (devo)
			{
				
				devo.Id_proveedor = Convert.ToInt32(txtId_proveedor.Text);
				devo.Total = Convert.ToDouble(txtTotal.Text);
				devo.Estado = false;
				devo.Motivo = txtMotivo.Text;
				devo.create_dev();
				string mensaje = "se envio una devolucion a "+txtProveedor.Text+"<br/>";
				List<Models.Dev_prov> ultimo = devo.get_lastdevolucion(Convert.ToInt32(txtId_proveedor.Text), Convert.ToDouble(txtTotal.Text), txtMotivo.Text);
				Folio_guardado = ultimo[0].Id;
				using (detalles)
				{
					foreach (DataGridViewRow row in dtProductos.Rows)
					{
						
						detalles.Id_devolucion = ultimo[0].Id;
						detalles.Id_producto = Convert.ToInt32(row.Cells["id"].Value.ToString());
						detalles.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());

						detalles.Pu = Convert.ToDouble(row.Cells["p_u"].Value.ToString());
						detalles.Estado = false;
						detalles.create_det();
						using (historial)
						{
							historial.Id_usuario = Convert.ToInt32(Inicial.id_usario);
							historial.Descripcion="se envio "+ row.Cells["cantidad"].Value.ToString()+" del producto " + row.Cells["desripcion"].Value.ToString() + " como devolucion al proveedor " + txtProveedor.Text;
							historial.createLog();
						}
						mensaje += row.Cells["cantidad"].Value.ToString()+" -- " + row.Cells["desripcion"].Value.ToString()+"<br/>";
						if (row.Cells["folios"].Value is null) {

							using (productos)
							{
								List<Models.Product> producto = productos.getProductById(Convert.ToInt32(row.Cells["id"].Value.ToString()));
								productos.Existencia = producto[0].Existencia - Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
								productos.Id = Convert.ToInt32(row.Cells["id"].Value.ToString());
								productos.update_inventary();
							}
							


						}
						else
						{
							using (productos)
							{
								productos.Id = Convert.ToInt32(row.Cells["id"].Value.ToString());
								List<Models.Product> produ = productos.getProductById(Convert.ToInt32(row.Cells["id"].Value.ToString()));
								productos.Devoluciones = produ[0].Devoluciones - Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
								productos.update_devoluciones();
							}


							char delimitar = ',';
							string[] folios = row.Cells["folios"].Value.ToString().Split(delimitar);
							int cuantos = folios.Count();
							for (int i = 0; i < cuantos; i++)
							{
								using (det_devolu)
								{
									det_devolu.Id_producto = Convert.ToInt32(row.Cells["id"].Value.ToString());
									det_devolu.Id_devolucion = Convert.ToInt32(folios[i]);
									det_devolu.enviar();
								}

							}
						}


					}
				}

				mensaje += "con un total de $"+txtTotal.Text;
				intercambios intercambios = new intercambios();
				intercambios.enviar_correo("",mensaje, "Envio de devolucion");
			}
			imprimir();
		}
		private void imprimir()
		{
			printDocument1 = new PrintDocument();
			Models.Configuration configuracion = new Models.Configuration();
			int cuantos = dtProductos.RowCount;
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
		private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCantidad.Text == "")
				{
					txtCantidad.Text = "1";
				}
				txtCodigo.Focus();
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
					List<Models.Dev_prov> listas = devoluciones.get_devolucionesbyfolio(Folio_guardado);
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
				e.Graphics.DrawString("Devolucion: " + Folio_guardado.ToString(), font, Brushes.Black, 0, y);
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
					List<Models.det_dev_prov> list = detallado.get_detalles(Folio_guardado);
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
			Folio_guardado = 0;
		}

		private void button2_Click(object sender, EventArgs e)
		{

		}
	}
}
