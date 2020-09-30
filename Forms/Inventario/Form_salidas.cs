using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms.Inventario
{
	public partial class Form_salidas : Form
	{
		public static string Entrada;
		public static string folio;
		public static string id;
		public Form_salidas()
		{
			InitializeComponent();
		}

		private void Form_salidas_Load(object sender, EventArgs e)
		{
			dtFecha.Format = DateTimePickerFormat.Custom;
			dtFecha.CustomFormat = "yyyy-MM-dd";

			if (folio == "0")
			{
				txtCantidad.Text = "";
				txtCodigo.Text = "";
				txtDescripcion.Text = "";
				txtTotal.Text = "";
				txtFolio.Text = "";
				txtCosto.Text = "";
				id = "0";
			}
			else
			{
				Models.Inv_out inv_out = new Models.Inv_out();
				using (inv_out)
				{
					List<Models.Inv_out> data = inv_out.getListabyId(folio);
					foreach (Models.Inv_out item in data)
					{
						txtFolio.Text = folio;
						txtTotal.Text = item.Total.ToString();
						dtFecha.Text = item.Date.ToString();

					}
				}




				Models.Product producto = new Models.Product();
				Models.Det_salidas detalles = new Models.Det_salidas();
				using (detalles)
				{
					List<Models.Det_salidas> det = detalles.getDet_salidas(Convert.ToInt16(folio));
					foreach (Models.Det_salidas item in det)
					{
						using (producto)
						{
							List<Models.Product> det_producto = producto.getProductById(item.Id_producto);
							foreach (Models.Product res in det_producto)
							{
								dtProductos.Rows.Add(item.Id_producto, res.Code1, item.Cantidad, res.Description, item.P_u, item.Total.ToString());
							}
						}



					}
				}



				txtCantidad.Enabled = false;
				txtCodigo.Enabled = false;
				txtDescripcion.Enabled = false;
				button1.Enabled = false;
				button2.Enabled = false;
				dtFecha.Enabled = false;
				dtProductos.Columns["cantidad"].ReadOnly = true;
			}
		}
		public void calcula()
		{
			double totales = 0;
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				totales = totales + Convert.ToDouble(row.Cells["total"].Value.ToString());
			}
			txtTotal.Text = totales.ToString();
		}
		private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				Buscar_producto busca = new Buscar_producto();
				busca.ShowDialog();

				Models.Product producto = new Models.Product();
				using (producto)
				{
					List<Models.Product> result = producto.getProductById(intercambios.Id_producto);
					foreach (Models.Product item in result)
					{
						id = item.Id.ToString();
						txtCodigo.Text = item.Code1;
						txtDescripcion.Text = item.Description;
						txtCosto.Text = item.Cost.ToString();
					}
				}



				button1.Focus();
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "" && txtDescripcion.Text != "")
				{
					button1.Focus();
				}
				if (txtDescripcion.Text == "")
				{
					txtDescripcion.Focus();
				}
				else if (txtCodigo.Text == "")
				{
					txtCodigo.Focus();
				}
			}
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				Buscar_producto busca = new Buscar_producto();
				busca.ShowDialog();

				Models.Product producto = new Models.Product();
				using (producto)
				{
					List<Models.Product> result = producto.getProductById(intercambios.Id_producto);
					foreach (Models.Product item in result)
					{
						id = item.Id.ToString();
						txtCodigo.Text = item.Code1;
						txtDescripcion.Text = item.Description;
						txtCosto.Text = item.Cost.ToString();
					}
				}



				button1.Focus();
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "" && txtDescripcion.Text != "")
				{
					button1.Focus();
				}
				if (txtDescripcion.Text == "")
				{
					txtDescripcion.Focus();
				}
				else if (txtCodigo.Text == "")
				{
					txtCodigo.Focus();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			double total1 = (Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtCosto.Text));
			dtProductos.Rows.Add(id, txtCodigo.Text, txtCantidad.Text, txtDescripcion.Text, txtCosto.Text, total1.ToString());
			id = "";
			txtCodigo.Text = "";
			txtCantidad.Text = "";
			txtDescripcion.Text = "";
			txtCosto.Text = "";
			calcula();
			txtCantidad.Focus();
		}
	}
}
