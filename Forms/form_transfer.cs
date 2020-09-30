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
	public partial class form_transfer : Form
	{
		public static int id_transfer;
		static Boolean recuperado = false;
		static int id_producto;
		public static string Origen;
		public form_transfer()
		{
			InitializeComponent();
		}
		private string formato(string numero)
		{
			double valor = 0;
			string resultado = "";
			valor = Convert.ToDouble(numero);
			resultado = valor.ToString("0.00");
			return resultado;
		}
		public void calcula()
		{
			double subtotal = 0;
			double total = 0;
			double iva = 0;
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				subtotal += Convert.ToDouble(row.Cells["Importe"].Value);
			}
			total = subtotal * 1.16;
			iva = subtotal * 0.16;
			txtSubtotal.Text = string.Format("{0:#,0.00}", subtotal);
		}
		private AutoCompleteStringCollection cargadatos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Product producto = new Models.Product();
			using (producto)
			{
				List<Models.Product> result = producto.getProductByCodeAbsolute(txtCodigo.Text);
				foreach (Models.Product item in result)
				{
					datos.Add(item.Code1);
				}
			}

			return datos;
		}
		private void get_folio()
		{
			Models.Folios folio = new Models.Folios();
			using (folio)
			{
				List<Models.Folios> transfer = folio.getFolios();
				txtFolios.Text = transfer[0].Transferencia.ToString();

			}
		}
		private void form_transfer_Load(object sender, EventArgs e)
		{
			lbFecha.Visible = false;
			this.txtFolios.AutoSize = true;
			txtCodigo.AutoCompleteCustomSource = cargadatos();
			txtCodigo.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;

			DataTable table = new DataTable();
			DataRow row;

			table.Columns.Add("Text", typeof(string));
			table.Columns.Add("Value", typeof(string));
			row = table.NewRow();
			row["Text"] = "";
			row["Value"] = "";
			table.Rows.Add(row);

			Models.Offices oficinas = new Models.Offices();
			using (oficinas)
			{
				List<Models.Offices> oficina = oficinas.GetOffices();
				foreach (Models.Offices ofi in oficina)
				{
					row = table.NewRow();
					row["Text"] = ofi.Name;
					row["Value"] = ofi.Id;
					table.Rows.Add(row);
				}
			}

			cbOficinas.BindingContext = new BindingContext();
			cbOficinas.DataSource = table;
			cbOficinas.DisplayMember = "Text";
			cbOficinas.ValueMember = "Value";
			cbOficinas.BindingContext = new BindingContext();
			if (id_transfer == 0)
			{
				get_folio();
			}
			else
			{
				recuperado = true;
				Models.Transfers traspasos = new Models.Transfers();
				using (traspasos)
				{
					List<Models.Transfers> traspaso = traspasos.getTransferbyid(id_transfer);
					if (traspaso.Count > 0)
					{
						lbFecha.Text = traspaso[0].Fecha.ToString();
						cbOficinas.SelectedValue = traspaso[0].Sucursal;
						txtFolios.Text = traspaso[0].Folio.ToString();
					}
				}
				Models.Det_transfers det = new Models.Det_transfers();
				Models.Product productos = new Models.Product();
				using (det)
				{
					using (productos)
					{
						List<Models.Det_transfers> detallado = det.getDet_trans(Convert.ToInt32(txtFolios.Text));
						if (detallado.Count > 0)
						{
							foreach (Models.Det_transfers item in detallado)
							{
								List<Models.Product> producto = productos.getProductById(item.Id_producto);
								dtProductos.Rows.Insert(0, item.Id_producto, item.Cantidad, producto[0].Code1, producto[0].Description, item.Precio, (item.Precio*item.Cantidad));
							}
						}
					}
					
				}
			}
			
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Product productos = new Models.Product();
				using (productos)
				{
					List<Models.Product> producto = productos.getProductBycode1(txtCodigo.Text);
					if (producto.Count > 0)
					{
						id_producto = producto[0].Id;
						txtDescripcion.Text = producto[0].Description;
						txtPrecio.Text = producto[0].Cost.ToString();
						txtPrecio.Focus();
					}
				}

			}
		}

		private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text.Trim() != "" && txtDescripcion.Text.Trim() != "" && txtPrecio.Text.Trim() != "0")
				{
					double importe = Convert.ToDouble(nuCantidad.Value) * Convert.ToDouble(txtPrecio.Text);
					dtProductos.Rows.Add(id_producto, nuCantidad.Value, txtCodigo.Text, txtDescripcion.Text, txtPrecio.Text, importe);
					id_producto = 0;
					nuCantidad.Focus();
					calcula();
					nuCantidad.Value = 0;
					txtCodigo.Text = "";
					txtDescripcion.Text = "";
					txtPrecio.Text = "";
				}
			}
		}

		private void dtProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			calcula();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (cbOficinas.Text == "")
			{
				MessageBox.Show("Seleccione una sucursal","Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbOficinas.Focus();
			}
			else {
				if (recuperado == false)
				{
					Models.Transfers transferencia = new Models.Transfers();
					using (transferencia)
					{
						transferencia.Folio = Convert.ToInt16(txtFolios.Text);
						transferencia.Tipo_trapaso = "E";
						transferencia.Sucursal = cbOficinas.SelectedValue.ToString();
						transferencia.Subtotal = Convert.ToDouble(txtSubtotal.Text);
						transferencia.Iva = 0;
						transferencia.Total = 0;
						transferencia.Facturado = Convert.ToInt16(false);
						transferencia.CreateTransfer();
						List<Models.Transfers> ultimo = transferencia.getTransferbyfolio(Convert.ToInt16(txtFolios.Text), "E");

						Models.Det_transfers detalles = new Models.Det_transfers();
						using (detalles)
						{
							detalles.Folio = Convert.ToInt16(txtFolios.Text);
							detalles.Tipo = "E";

							Models.Product poductos = new Models.Product();
							foreach (DataGridViewRow row in dtProductos.Rows)
							{
								detalles.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
								detalles.Id_producto = Convert.ToInt16(row.Cells["id"].Value.ToString());
								detalles.Precio = Convert.ToDouble(row.Cells["p_u"].Value.ToString());
								detalles.CreateDet();
								using (poductos)
								{
									List<Models.Product> producto = poductos.getProductById(Convert.ToInt16(row.Cells["id"].Value.ToString()));
									Models.Kardex kardex = new Models.Kardex();
									using (kardex)
									{
										kardex.Id_producto = Convert.ToInt16(row.Cells["id"].Value.ToString());
										kardex.Tipo = "T";
										kardex.Id_documento = ultimo[0].Id;
										kardex.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
										kardex.Antes = producto[0].Existencia;
										kardex.CreateKardex();

										List<Models.Kardex> ultimo_kardez = kardex.getidKardex(Convert.ToInt16(row.Cells["id"].Value.ToString()), ultimo[0].Id, "T");
										Models.Afecta_inv afecta = new Models.Afecta_inv();
										using (afecta)
										{

											afecta.Disminuye(ultimo_kardez[0].Id);
										}


									}
								}

							}
						}

					}


					Models.Folios folio = new Models.Folios();
					using (folio)
					{
						folio.Transferencia = (Convert.ToInt16(txtFolios.Text) + 1);
						folio.savenewTransfer();
					}
				}
				else
				{
					Models.Transfers transferencia = new Models.Transfers();
					using (transferencia)
					{
						transferencia.Folio = Convert.ToInt32(txtFolios.Text);
						transferencia.Tipo_trapaso = "E";
						transferencia.Sucursal = cbOficinas.SelectedValue.ToString();
						transferencia.Subtotal = Convert.ToDouble(txtSubtotal.Text);
						transferencia.Iva = 0;
						transferencia.Total = 0;
						transferencia.Facturado = Convert.ToInt16(false);
						transferencia.updateTrasfer();
					}
					Models.Det_transfers detalles = new Models.Det_transfers();
					using (detalles)
					{
						detalles.Folio = Convert.ToInt32(txtFolios.Text);
						detalles.delete_det();

						detalles.Folio = Convert.ToInt16(txtFolios.Text);
						detalles.Tipo = "E";

						Models.Product poductos = new Models.Product();
						foreach (DataGridViewRow row in dtProductos.Rows)
						{
							detalles.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
							detalles.Id_producto = Convert.ToInt16(row.Cells["id"].Value.ToString());
							detalles.Precio = Convert.ToDouble(row.Cells["p_u"].Value.ToString());
							detalles.CreateDet();
							using (poductos)
							{
								List<Models.Product> producto = poductos.getProductById(Convert.ToInt16(row.Cells["id"].Value.ToString()));
								Models.Kardex kardex = new Models.Kardex();
								using (kardex)
								{
									kardex.Id_producto = Convert.ToInt16(row.Cells["id"].Value.ToString());
									kardex.Tipo = "T";
									kardex.Id_documento = id_transfer;
									kardex.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
									kardex.Antes = producto[0].Existencia;
									kardex.CreateKardex();

									List<Models.Kardex> ultimo_kardez = kardex.getidKardex(Convert.ToInt16(row.Cells["id"].Value.ToString()), id_transfer, "T");
									Models.Afecta_inv afecta = new Models.Afecta_inv();
									using (afecta)
									{

										afecta.Disminuye(ultimo_kardez[0].Id);
									}


								}
							}

						}
					}
				}
				

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

				
				this.Close();
			}
			



		}

		private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
		{
			Models.Configuration configuracion = new Models.Configuration();
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
				e.Graphics.DrawString("Transferencia: " + txtFolios.Text, font, Brushes.Black, 0, y);
				/* y = y + 10;
                e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
                */
				y = y + 20;
				e.Graphics.DrawString("Cant.", font, Brushes.Black, 50, y, format);
				e.Graphics.DrawString("P/U.", font, Brushes.Black, 100, y, format);

				e.Graphics.DrawString("IMPTE.", font, Brushes.Black, 220, y, format);
				y = y + 10;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
				foreach (DataGridViewRow row in dtProductos.Rows)
				{
					y = y + 30;
					e.Graphics.DrawString(row.Cells["descripcion"].Value.ToString(), font, Brushes.Black, 10, y);
					e.Graphics.DrawString(row.Cells["cantidad"].Value.ToString(), font, Brushes.Black, 50, y + 10, format);
					e.Graphics.DrawString(formato(row.Cells["p_u"].Value.ToString()), font, Brushes.Black, 100, y + 10, format);

					e.Graphics.DrawString(formato(row.Cells["Importe"].Value.ToString()), font, Brushes.Black, 220, y + 10, format);
				}
				y = y + 15;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
				y = y + 15;

				e.Graphics.DrawString("Total", font, Brushes.Black, 150, y + 10, format);
				e.Graphics.DrawString(txtSubtotal.Text, font, Brushes.Black, 220, y + 10, format);

				y = y + 40;
				intercambios inter = new intercambios();
				e.Graphics.DrawString(inter.enletras(txtSubtotal.Text), font, Brushes.Black, 0, y);

				y = y + 30;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
			}
		}
	}
}
