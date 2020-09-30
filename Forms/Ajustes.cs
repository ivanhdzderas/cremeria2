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
	public partial class Ajustes : Form
	{
		public Ajustes()
		{
			InitializeComponent();
		}
		public void carga()
		{
			dtAjustes.Rows.Clear();
			Models.Ajuste ajuste = new Models.Ajuste();
			using (ajuste)
			{
				List<Models.Ajuste> resultado = ajuste.getAjustes();
				foreach (Models.Ajuste item in resultado)
				{
					dtAjustes.Rows.Add(item.Id, item.Fecha, item.Total);
				}
			}

		}
		private void Ajustes_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_ajustes.folio = "0";
			Form_ajustes new_ajuste = new Form_ajustes();
			new_ajuste.Owner = this;
			new_ajuste.Show();
		}

		private void dtAjustes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtAjustes.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtAjustes.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["folio"].Value);
			Form_ajustes.folio = codigo;
			Form_ajustes new_ajuste = new Form_ajustes();
			new_ajuste.Owner = this;
			new_ajuste.Show();
		}

		private void dtAjustes_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int i = dtAjustes.CurrentRow.Index;
				string valor = dtAjustes.Rows[i].Cells["folio"].Value.ToString();
				Form_ajustes.folio = valor;
				Form_ajustes new_ajuste = new Form_ajustes();
				new_ajuste.Owner = this;
				new_ajuste.Show();
			}
		}
	}
}
