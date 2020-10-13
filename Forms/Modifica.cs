using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms
{
	public partial class Modifica : Form
	{
		public Modifica()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Models.Product productos = new Models.Product();

			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				using (productos)
				{
					productos.Id = Convert.ToInt32(row.Cells["id"].Value.ToString());
					productos.Max = Convert.ToDouble(row.Cells["maximos"].Value.ToString());
					productos.Min = Convert.ToDouble(row.Cells["minimos"].Value.ToString());
					productos.Price1 = Convert.ToDouble(row.Cells["precio1"].Value.ToString());
					productos.Price2 = Convert.ToDouble(row.Cells["precio2"].Value.ToString());
					productos.Price3 = Convert.ToDouble(row.Cells["precio3"].Value.ToString());
					productos.update_max_min();
				}

			}
			MessageBox.Show("Se actualizo satisfactoriamente");
		}
		private void carga()
		{
			dtProductos.Rows.Clear();
			Models.Product productos = new Models.Product();
			using (productos) {
				List<Models.Product> producto = productos.getProducts();
				if (producto.Count > 0)
				{
					foreach (Models.Product item in producto) {
						dtProductos.Rows.Add(item.Id, item.Code1, item.Description, item.Max, item.Min, item.Price1, item.Price2, item.Price3);
					}
				}
			}
		}
		private void Modifica_Load(object sender, EventArgs e)
		{
			carga();
		}
	}
}
