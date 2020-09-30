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
	public partial class Compras : Form
	{
		public Compras()
		{
			InitializeComponent();
		}
		public void carga()
		{
			dtCompras.Rows.Clear();
			Models.Compras funcompra = new Models.Compras();
			using (funcompra)
			{
				List<Models.Compras> result = funcompra.GetCompras();
				foreach (Models.Compras item in result)
				{
					dtCompras.Rows.Add(item.Id, item.Proveedor, item.Fecha, item.Total);
				}
			}

		}
		private void Compras_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			Form_compras.folio = "0";
			Form_compras new_compra = new Form_compras();
			new_compra.Owner = this;
			new_compra.ShowDialog();
			carga();
		}

		private void dtCompras_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtCompras.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtCompras.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["documento"].Value);
			Form_compras.folio = codigo;
			Form_compras new_compra = new Form_compras();
			new_compra.Owner = this;
			new_compra.Show();
		}
	}
}
