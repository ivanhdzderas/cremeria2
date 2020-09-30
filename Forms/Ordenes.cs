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
	public partial class Ordenes : Form
	{
		private void carga()
		{
			dtOrdenes.Rows.Clear();
			Models.Ordenes_compra ordenes = new Models.Ordenes_compra();
			Models.Providers proveedores = new Models.Providers();
			using (ordenes)
			{
				List<Models.Ordenes_compra> orden = ordenes.get_ordenes();
				if (orden.Count > 0)
				{
					foreach(Models.Ordenes_compra item in orden)
					{
						using (proveedores)
						{
							List<Models.Providers> proveedor = proveedores.getProviderbyId(item.Id_proveedor);
							dtOrdenes.Rows.Insert(0, item.Id, proveedor[0].Name,item.Terminado);
						}
							
					}
				}
			}
		}
		public Ordenes()
		{
			InitializeComponent();
		}

		private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtOrdenes.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtOrdenes.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
			Form_ordenes.Id = Convert.ToInt32(codigo);
			Form_ordenes orde = new Form_ordenes();
			orde.Show();
		}

		private void Ordenes_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_ordenes orde = new Form_ordenes();
			orde.ShowDialog();
			carga();
		}
	}
}
