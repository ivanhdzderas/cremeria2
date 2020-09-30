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
	public partial class Listas_precios : Form
	{
		public Listas_precios()
		{
			InitializeComponent();
		}
		private void carga()
		{
			dtListas.Rows.Clear();
			Models.Lista_precios listas = new Models.Lista_precios();
			Models.Product productos = new Models.Product();
			Models.Client clientes = new Models.Client();
			using (listas)
			{
				using (productos)
				{
					using (clientes)
					{
						List<Models.Lista_precios> lista = listas.get_listas();
						if (lista.Count > 0)
						{
							foreach (Models.Lista_precios item in lista)
							{
								List<Models.Product> producto = productos.getProductById(item.Id_Producto);
								List<Models.Client> cliente = clientes.getClientbyId(item.Id_cliente);
								dtListas.Rows.Add(item.Id, cliente[0].Name, producto[0].Description, item.Descuento);
							}
						}
					}
				}
				
			}
		}
		private void Listas_precios_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_listas_precios listado = new Form_listas_precios();
			listado.Id_lista = 0;
			listado.ShowDialog();
			carga();
		}

		private void dtListas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtListas.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtListas.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
			Form_listas_precios listado = new Form_listas_precios();
			listado.Id_lista = Convert.ToInt32(codigo);
			listado.ShowDialog();
			carga();
		}
	
	}
}
