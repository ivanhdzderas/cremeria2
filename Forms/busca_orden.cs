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
	public partial class busca_orden : Form
	{
		public busca_orden()
		{
			InitializeComponent();
		}
		private void buscar()
		{
			Models.Ordenes_compra ordenes = new Models.Ordenes_compra();
			using (ordenes)
			{
				List<Models.Ordenes_compra> orden = ordenes.get_ordenproveedor_sin(Convert.ToInt32(txtNumero.Text));
				if (orden.Count > 0)
				{
					foreach(Models.Ordenes_compra item in orden)
					{
						dataGridView1.Rows.Insert(0, item.Id,false);
					}
				}
			}
		}
		private AutoCompleteStringCollection carga_proveedor()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Providers proveedores = new Models.Providers();
			using (proveedores)
			{
				List<Models.Providers> result = proveedores.getProviders();
				foreach (Models.Providers item in result)
				{
					datos.Add(item.Name);
				}
				return datos;
			}
		}

		private AutoCompleteStringCollection carga_num_proveedor()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Providers proveedores = new Models.Providers();
			using (proveedores)
			{
				List<Models.Providers> result = proveedores.getProviders();
				foreach (Models.Providers item in result)
				{
					datos.Add(item.Id.ToString());
				}
				return datos;
			}
		}
		private void busca_orden_Load(object sender, EventArgs e)
		{
			txtNumero.AutoCompleteCustomSource = carga_num_proveedor();
			txtNumero.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtNumero.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtProveedor.AutoCompleteCustomSource = carga_proveedor();
			txtProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
		}

		private void txtNumero_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Providers proveedores = new Models.Providers();
				using (proveedores)
				{
					List<Models.Providers> proveedor = proveedores.getProviderbyId(Convert.ToInt32(txtNumero.Text));
					txtProveedor.Text = proveedor[0].Name;
					buscar();
				}
			}
		}

		private void txtProveedor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Providers proveedores = new Models.Providers();
				using (proveedores)
				{
					List<Models.Providers> proveedor = proveedores.getProviderbyNombre(txtProveedor.Text);
					txtNumero.Text = proveedor[0].Id.ToString();
					buscar();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_compras form_interface = this.Owner as Form_compras;
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (Convert.ToBoolean(row.Cells["chk"].Value) == true)
				{
					
					form_interface.dtDocumentos.Rows.Add(row.Cells["id"].Value.ToString());
				}
			}
			this.Close();
		}
	}
}
