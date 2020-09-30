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
	public partial class Traspasos_e : Form
	{
		public Traspasos_e()
		{
			InitializeComponent();
		}
		private void carga()
		{
			dtTraspasos.Rows.Clear();
			Models.Offices oficinas = new Models.Offices();
			Models.Transfers transferencias = new Models.Transfers();
			using (transferencias)
			{
				List<Models.Transfers> tranfer = transferencias.getTransfers_e();
				foreach(Models.Transfers item in tranfer)
				{
					using (oficinas)
					{
						if (item.Sucursal == "")
						{
							
							dtTraspasos.Rows.Add(item.Id, item.Folio, "", item.Fecha, item.Subtotal);
						}
						else
						{
							List<Models.Offices> sucursal = oficinas.GetOfficesbyid(Convert.ToInt16(item.Sucursal));
							dtTraspasos.Rows.Add(item.Id, item.Folio, sucursal[0].Name, item.Fecha, item.Subtotal);
						}
						
					}
				}
			}
		}
		private void Traspasos_e_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			form_transfer transfer = new form_transfer();
			form_transfer.Origen = "E";
			transfer.MdiParent = this.MdiParent;
			transfer.Show();
		}

		private void dtTraspasos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtTraspasos.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtTraspasos.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
			form_transfer trasfer = new form_transfer();
			form_transfer.id_transfer = Convert.ToInt32(codigo);
			trasfer.Show(this);
		}
	}
}
