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
	public partial class Ticket_a_factura : Form
	{
		public Ticket_a_factura()
		{
			InitializeComponent();
		}
		private AutoCompleteStringCollection cargadatos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Client clientes = new Models.Client();
			using (clientes)
			{
				List<Models.Client> client = clientes.getClients();
				foreach (Models.Client item in client)
				{
					datos.Add(item.Id.ToString());
				}

			}

			return datos;


		}

		private AutoCompleteStringCollection cargadatos2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Client clientes = new Models.Client();
			using (clientes)
			{
				List<Models.Client> client = clientes.getClients();
				foreach (Models.Client item in client)
				{
					datos.Add(item.Name);
				}
			}

			return datos;
		}
		private void Ticket_a_factura_Load(object sender, EventArgs e)
		{
			txtIdCliente.AutoCompleteCustomSource = cargadatos();
			txtIdCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtIdCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;


			txtCliente.AutoCompleteCustomSource = cargadatos2();
			txtCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_factura form_interface = this.Owner as Form_factura;
			foreach (DataGridViewRow row in dtTickets.Rows)
			{
				if (Convert.ToBoolean(row.Cells["chk"].Value) == true)
				{

					form_interface.dtdocumentos.Rows.Add(row.Cells["folio"].Value.ToString(), "Ticket");
				}
			}
			form_interface.txtIdCliente.Text = txtIdCliente.Text;
			form_interface.txtCliente.Text = txtCliente.Text;

			this.Close();
		}

		private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Client clientes = new Models.Client();
				using (clientes)
				{
					List<Models.Client> client = clientes.getClientbyId(Convert.ToInt16(txtIdCliente.Text));
					txtCliente.Text = client[0].Name;
					Models.Tickets ticket = new Models.Tickets();
					using (ticket)
					{
						List<Models.Tickets> tic = ticket.getforbuild(txtIdCliente.Text);
						dtTickets.Rows.Clear();
						foreach (Models.Tickets item in tic)
						{
							dtTickets.Rows.Add(item.Id, item.Folio, item.Fecha, item.Total);
						}
					}

				}

			}
		}

		private void txtCliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Client clientes = new Models.Client();
				using (clientes)
				{
					List<Models.Client> client = clientes.getClientbyName(txtCliente.Text);
					txtIdCliente.Text = client[0].Id.ToString();
					Models.Tickets ticket = new Models.Tickets();
					using (ticket)
					{
						List<Models.Tickets> tic = ticket.getbyclient(txtIdCliente.Text);
						dtTickets.Rows.Clear();
						foreach (Models.Tickets item in tic)
						{
							dtTickets.Rows.Add(item.Id, item.Folio, item.Fecha, item.Total);
						}
					}

				}

			}
		}
	}
}
