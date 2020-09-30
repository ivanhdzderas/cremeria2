using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms
{
	public partial class Buscar_producto : Form
	{
		public Buscar_producto()
		{
			InitializeComponent();
		}
		private void carga()
		{
			dtProductos.Rows.Clear();
			Models.Product productos = new Models.Product();
			using (productos)
			{
				List<Models.Product> producto = productos.getProducts();
				if (producto.Count > 0)
				{
					foreach(Models.Product item in producto)
					{
						dtProductos.Rows.Add(item.Id,item.Code1, item.Description, item.Price1, item.Price1);
					}
				}
			}
		}
		private void Buscar_producto_Load(object sender, EventArgs e)
		{
			carga();
			txtCodigo.Focus();
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			
			if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
			{
				txtDescripcion.Focus();
			}
			if (e.KeyCode == Keys.Enter)
			{
				
				dtProductos.Rows.Clear();
				Models.Product productos = new Models.Product();
				using (productos)
				{
					List<Models.Product> producto = productos.getProductByCode(txtCodigo.Text);
					if (producto.Count > 0)
					{
						foreach (Models.Product item in producto)
						{
							dtProductos.Rows.Add(item.Id, item.Code1, item.Description, item.Price1, item.Price1);
						}
						dtProductos.Focus();
					}
				}

			}
		}

		private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
			{
				txtCodigo.Focus();
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtDescripcion.Text != "")
				{
					dtProductos.Rows.Clear();
					Models.Product productos = new Models.Product();
					using (productos)
					{
						List<Models.Product> producto = productos.getProductByDescription(txtDescripcion.Text);
						if (producto.Count > 0)
						{
							foreach (Models.Product item in producto)
							{
								dtProductos.Rows.Add(item.Id, item.Code1, item.Description, item.Price1, item.Price1);
							}
							dtProductos.Focus();
						}

					}
				}
			}
		}

		private void dtProductos_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int i = dtProductos.CurrentRow.Index;
				string valor = dtProductos.Rows[i].Cells["id"].Value.ToString();

				intercambios.Id_producto = Convert.ToInt16(valor);
				this.Close();
			}
		}
	}
}
