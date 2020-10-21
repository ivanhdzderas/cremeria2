using Microsoft.Office.Interop.Excel;
using MySql.Data.X.XDevAPI.Common;
using System;
using System.CodeDom;
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
	public partial class Form_proveedor : Form
	{
		public static string id;
		public Form_proveedor()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void combobox_popular()
		{
			Models.Product productos = new Models.Product();
			using (productos)
			{
				List<Models.Product> producto = productos.getProducts();
				cbproducto.ValueMember = "Id";
				cbproducto.DisplayMember = "Code1";
				cbproducto.DataSource = producto;
			}
		}
		private void Form_proveedor_Load(object sender, EventArgs e)
		{
			combobox_popular();
			txtNombre.Text = "";
			txtRFC.Text = "";
			txtCalle.Text = "";
			txtNumExt.Text = "";
			txtNumInt.Text = "";
			txtColonia.Text = "";
			txtCp.Text = "";
			txtEstado.Text = "";
			txtMunicipio.Text = "";
			txtTelefono.Text = "";
			txtNotas.Text = "";
			txtEmail.Text = "";

			cbTiempo.Items.Add("Fecha recepcion");
			cbTiempo.Items.Add("Fecha factura");
			cbTiempo.Items.Add("Fecha alta");

			if (id != "'0")
			{
				Models.Providers proveedor = new Models.Providers();
				using (proveedor)
				{
					List<Models.Providers> result = proveedor.getProviderbyId(Convert.ToInt16(id));

					foreach (Models.Providers item in result)
					{
						txtNombre.Text = item.Name;
						txtRFC.Text = item.RFC;
						txtCalle.Text = item.Street;
						txtNumExt.Text = item.Ext_number;
						txtNumInt.Text = item.Int_number;
						txtColonia.Text = item.Col;
						txtCp.Text = item.Cp;
						txtEstado.Text = item.State;
						txtMunicipio.Text = item.Muni;
						txtTelefono.Text = item.Tel;
						txtNotas.Text = item.Note;
						txtEmail.Text = item.Email;
						char delimitar = ',';
						string[] dias = item.Pago.Split(delimitar);
						int cuantos = dias.Count();

							
						for (int i = 0; i < cuantos; i++)
						{
							if (dias[i] != "")
							{
								checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(dias[i]), true);
							}
						}
					}
				}
				carga_productos();
			}
		}
		private void carga_productos()
		{
			dtProductos.Rows.Clear();
			Models.prov_prod costo = new Models.prov_prod();
			Models.Product productos = new Models.Product();
			using (costo)
			{
				using (productos)
				{
					List<Models.prov_prod> cot = costo.get_costobyproveedor(Convert.ToInt32(id));
					if (cot.Count > 0)
					{
						foreach (Models.prov_prod item in cot)
						{
							List<Models.Product> producto = productos.getProductById(item.Id_producto);
							dtProductos.Rows.Add(item.Id, producto[0].Id, producto[0].Description);
						}
					}
				}

			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			string s = "";
			for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
			{
				s = s +  checkedListBox1.CheckedItems[x].ToString() + ",";
			}
			
			Models.Providers prov = new Models.Providers(
				Convert.ToInt16(id),
				txtNombre.Text,
				txtRFC.Text,
				txtCalle.Text,
				txtNumExt.Text,
				txtNumInt.Text,
				txtColonia.Text,
				txtCp.Text,
				txtEstado.Text,
				txtMunicipio.Text,
				txtTelefono.Text,
				txtNotas.Text,
				txtEmail.Text,
				s,
				cbTiempo.Text,
				txtComercial.Text
				);
			using (prov)
			{
				if (id == "0")
				{
					prov.createProvider();
				}
				else
				{
					prov.saveProvider();
					Models.prov_prod costos = new Models.prov_prod();
					using (costos)
					{
						costos.Id_proveedor = Convert.ToInt32(id);
						costos.delete_all();

						foreach (DataGridViewRow row in dtProductos.Rows)
						{
							if (row.Cells["cbproducto"].Value is null)
							{

							}
							else
							{
								if (row.Cells["id_registro"].Value is null)
								{
									DataGridViewComboBoxCell combo = row.Cells["cbproducto"] as DataGridViewComboBoxCell;
									costos.Id_producto = Convert.ToInt32(combo.Value.ToString());
									costos.Costo = 0;
									costos.Cantidad = 0;
									costos.Id_proveedor = Convert.ToInt32(id);
									costos.create();
								}
							}	
						}
					}
				}
			}

			this.Close();
			
		}

		private void dtProductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			DataGridViewComboBoxEditingControl combo= e.Control as DataGridViewComboBoxEditingControl;
			if (combo != null)
			{
				combo.SelectedIndexChanged -= new EventHandler(dvgCombo_SelectedIndexChanged);

				combo.SelectedIndexChanged += new EventHandler(dvgCombo_SelectedIndexChanged);
			}
		}

		private void dvgCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox combo = sender as ComboBox;
			if (combo.SelectedValue != null)
			{
				Models.Product productos = new Models.Product();
				using (productos)
				{
					List<Models.Product> producto = productos.getProductById(Convert.ToInt32(combo.SelectedValue.ToString()));
					DataGridViewRow row = dtProductos.CurrentRow;

					DataGridViewTextBoxCell cell = row.Cells["descripcion"] as DataGridViewTextBoxCell;
					if (producto.Count > 0)
					{
						cell.Value = producto[0].Description;
					}
				}
			}
		}
	}
}
