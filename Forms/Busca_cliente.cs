﻿using System;
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
	public partial class Busca_cliente : Form
	{
		public Busca_cliente()
		{
			InitializeComponent();
		}
		private void Clientes()
		{
			dtClientes.Rows.Clear();
			Models.Client cliente = new Models.Client();
			using (cliente)
			{
				List<Models.Client> cli = cliente.getClients();
				if (cli.Count > 0)
				{
					foreach (Models.Client item in cli)
					{
						dtClientes.Rows.Add(item.Id, item.Name, item.RFC, item.Tel);
					}
				}

			}

		}
		private void Busca_cliente_Load(object sender, EventArgs e)
		{
			Clientes();
		}

		private void dtClientes_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int i = dtClientes.CurrentRow.Index;
				string valor = dtClientes.Rows[i].Cells["id"].Value.ToString();

				Forms.Caja.id_cliente = Convert.ToInt16(valor);
				this.Close();
			}
		}

		private void txtRFC_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				dtClientes.Rows.Clear();
				Models.Client clients = new Models.Client();
				using (clients)
				{
					List<Models.Client> result = clients.getClientbyRFC(txtRFC.Text);
					if (result.Count > 0)
					{
						foreach (Models.Client item in result)
						{
							dtClientes.Rows.Add(item.Id, item.Name, item.RFC, item.Tel);
						}
					}
				}

			}
		}

		private void txtNombre_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				dtClientes.Rows.Clear();
				Models.Client clients = new Models.Client();
				using (clients)
				{
					List<Models.Client> result = clients.getClientbyName(txtNombre.Text);
					if (result.Count > 0)
					{
						foreach (Models.Client item in result)
						{
							dtClientes.Rows.Add(item.Id, item.Name, item.RFC, item.Tel);
						}
					}
					dtClientes.Focus();
				}

			}
		}

		private void dtClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtClientes.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtClientes.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
			Forms.Caja.id_cliente = Convert.ToInt16(codigo);

			this.Close();
		}
	}
}
