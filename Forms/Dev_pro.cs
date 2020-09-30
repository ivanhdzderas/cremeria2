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
	public partial class Dev_pro : Form
	{
		public Dev_pro()
		{
			InitializeComponent();
		}
		private void carga()
		{
			dtDevoluciones.Rows.Clear();
			Models.Dev_prov devo = new Models.Dev_prov();
			Models.Providers proveedores = new Models.Providers();

			using (devo)
			{
				
				List<Models.Dev_prov> dev = devo.get_devoluciones();
				if (dev.Count > 0)
				{
					foreach(Models.Dev_prov item in dev)
					{
						using (proveedores)
						{
							List<Models.Providers> prov = proveedores.getProviderbyId(item.Id_proveedor);
							dtDevoluciones.Rows.Add(item.Id, item.Fecha,prov[0].Name, item.Estado);
						}
						
					}
				}
			}
		}
		private void Dev_pro_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_devoluciones devoluciones = new Form_devoluciones();
			devoluciones.ShowDialog();
			carga();
		}

		private void dtDevoluciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtDevoluciones.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtDevoluciones.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
			Forms.Devo.Folio = Convert.ToInt32(codigo);
			Devo dev = new Devo();
			dev.Show(this);
		}
	}
}
