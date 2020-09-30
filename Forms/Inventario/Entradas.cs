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
	public partial class Entradas : Form
	{
		public Entradas()
		{
			InitializeComponent();
		}
		public void carga()
		{
			dgvEntradas.Rows.Clear();
			Models.Inv_in inv = new Models.Inv_in();
			using (inv)
			{
				List<Models.Inv_in> result = inv.getLista();
				foreach (Models.Inv_in item in result)
				{
					dgvEntradas.Rows.Add(item.Date, item.Id, item.Status);
				}
			}

		}
		private void Entradas_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Inventario.Form_entradas.folio = "0";
			Inventario.Form_entradas new_entrada = new Inventario.Form_entradas();
			new_entrada.Owner = this;
			new_entrada.Show();
		}

		private void dgvEntradas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dgvEntradas.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dgvEntradas.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["folio"].Value);
			Form_entradas.folio = codigo;
			Form_entradas new_entrada = new Form_entradas();
			new_entrada.Owner = this;
			new_entrada.Show();
		}

		private void dgvEntradas_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int i = dgvEntradas.CurrentRow.Index;
				string valor = dgvEntradas.Rows[i].Cells["folio"].Value.ToString();

				Form_entradas.folio = valor;
				Form_entradas new_entrada = new Form_entradas();
				new_entrada.Owner = this;
				new_entrada.Show();
			}
		}
	}
}
