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
	public partial class Proveedores : Form
	{
		public Proveedores()
		{
			InitializeComponent();
		}
		public void carga()
		{

			Models.Providers prov = new Models.Providers();
			using (prov)
			{
				List<Models.Providers> result = prov.getProviders();

				foreach (Models.Providers item in result)
				{
					dtgProveedores.Rows.Add(item.Id, item.Name, item.RFC, item.Tel);
				}
			}

		}
		private void Proveedores_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtBuscar.Text == "")
				{
					carga();

				}
				else
				{
					dtgProveedores.Rows.Clear();
					string bus_descripcion = txtBuscar.Text;


					Models.Providers prov = new Models.Providers();
					using (prov)
					{
						List<Models.Providers> result = prov.getProviderbyNombre(bus_descripcion);

						foreach (Models.Providers item in result)
						{
							dtgProveedores.Rows.Add(item.Id, item.Name, item.RFC, item.Tel);
						}
					}


				}

			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_proveedor.id = "0";
			Form_proveedor prov = new Form_proveedor();
			prov.Show(this);
		}

		private void dtgProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtgProveedores.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtgProveedores.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
			Form_proveedor.id = codigo;
			Form_proveedor prov = new Form_proveedor();
			prov.Show(this);
		}
	}
}
