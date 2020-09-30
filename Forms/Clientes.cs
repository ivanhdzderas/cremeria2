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
	public partial class Clientes : Form
	{
		public Clientes()
		{
			InitializeComponent();
		}
		private void carga()
		{
			dtgClientes.Rows.Clear();

			Models.Client client = new Models.Client();
			using (client)
			{
				List<Models.Client> result = client.getClients();
				foreach (Models.Client item in result)
				{
					dtgClientes.Rows.Add(item.Id, item.Name, item.RFC);
				}
			}
		}
		private void Clientes_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void dtgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtgClientes.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtgClientes.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
			Form_cliente.id = codigo;
			Form_cliente clie = new Form_cliente();
			clie.Show(this);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_cliente.id = "0";
			Form_cliente clie = new Form_cliente();
			clie.Show(this);
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
					dtgClientes.Rows.Clear();
					string bus_descripcion = txtBuscar.Text;
					Models.Client clien = new Models.Client();
					using (clien)
					{
						List<Models.Client> result = clien.getClientbyName(bus_descripcion);
						foreach (Models.Client item in result)
						{
							dtgClientes.Rows.Add(item.Id, item.Name, item.RFC);
						}
					}
				}

			}
		}
	}
}
