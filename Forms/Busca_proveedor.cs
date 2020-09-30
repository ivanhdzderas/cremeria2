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
	public partial class Busca_proveedor : Form
	{
		public Busca_proveedor()
		{
			InitializeComponent();
		}
		private void carga()
		{
			Models.Providers proveedores = new Models.Providers();
			using (proveedores)
			{
				List<Models.Providers> proveedor = proveedores.getProviders();
				if (proveedor.Count > 0)
				{
					foreach(Models.Providers item in proveedor)
					{
						dtProveedores.Rows.Add(item.Id, item.Name);
					}
				}
			}
		}
		private void Busca_proveedor_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void dtProveedores_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int i = dtProveedores.CurrentRow.Index;
				string valor = dtProveedores.Rows[i].Cells["id"].Value.ToString();
				(this.Owner as Producto).txtProveedor.Text = valor;
				this.Close();
			}
		}

		private void dtProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtProveedores.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtProveedores.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
			(this.Owner as Producto).txtProveedor.Text = codigo;
			this.Close();
		}

		private void txtNombre_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				dtProveedores.Focus();
			}
			if (e.KeyCode == Keys.Enter)
			{
				Models.Providers proveedores = new Models.Providers();
				using (proveedores)
				{
					List<Models.Providers> proveedor = proveedores.getProviderbyNombre(txtNombre.Text);
					if (proveedor.Count > 0)
					{
						dtProveedores.Rows.Clear();
						foreach(Models.Providers item in proveedor)
						{
							dtProveedores.Rows.Add(item.Id, item.Name);
						}
						dtProveedores.Focus();
					}
				}
			}
		}
	}
}
