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
	
	public partial class Form_ordenes : Form
	{
		public static int Id;
		public Form_ordenes()
		{
			InitializeComponent();
		}
		private void sugerido()
		{
			if (Id == 0)
			{
				string foliados = "";
				DialogResult dialogo = MessageBox.Show("¿Desea cargar el sugerido?", "Sugerido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogo == DialogResult.Yes)
				{
					dtProductos.Rows.Clear();
					Models.Product productos = new Models.Product();
					using (productos)
					{
						List<Models.Product> producto = productos.getProductByproveedor(txtNumero.Text);
						if (producto.Count > 0)
						{
							foreach (Models.Product item in producto)
							{
								if (item.Existencia <= item.Min)
								{
									if ((item.Max - item.Existencia) <= 0)
									{

									}
									else
									{
										dtProductos.Rows.Insert(0, item.Id, item.Code1, (item.Max - item.Existencia), item.Description);
									}
									
								}
							}
						}
					}
				}
			}
			
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
					sugerido();
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
					sugerido();
				}
			}
		}

		private void Form_ordenes_Load(object sender, EventArgs e)
		{
			
			txtNumero.AutoCompleteCustomSource = carga_num_proveedor();
			txtNumero.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtNumero.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtProveedor.AutoCompleteCustomSource = carga_proveedor();
			txtProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;

			if (Id!=0) {
				Models.Ordenes_compra ordenes = new Models.Ordenes_compra();
				
				using (ordenes)
				{
					List<Models.Ordenes_compra> orden = ordenes.get_ordenbyid(Id);
					txtNumero.Text = orden[0].Id_proveedor.ToString();
					txtNumero_KeyDown(this,new KeyEventArgs(Keys.Enter));
				}
				Models.Det_ordenes detalles = new Models.Det_ordenes();
				Models.Product productos = new Models.Product();
				using (detalles)
				{
					List<Models.Det_ordenes> detalle = detalles.get_detalles(Id);
					foreach(Models.Det_ordenes item in detalle)
					{
						List<Models.Product> producto = productos.getProductById(item.Id_producto);
						dtProductos.Rows.Insert(0, item.Id_producto, producto[0].Code1, item.Cantidad, producto[0].Description);
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

		private void button1_Click(object sender, EventArgs e)
		{
			Models.Ordenes_compra ordenes = new Models.Ordenes_compra();
			Models.Det_ordenes detalles = new Models.Det_ordenes();
			using (ordenes)
			{
				using (detalles)
				{
					ordenes.Id_proveedor = Convert.ToInt32(txtNumero.Text);
					ordenes.Usuario = Convert.ToInt32(Inicial.id_usario);
					ordenes.Terminado = false;
					ordenes.create_orden();
					List<Models.Ordenes_compra> orden = ordenes.get_lastordenes(Convert.ToInt32(txtNumero.Text), Convert.ToInt32(Inicial.id_usario));
					detalles.Id_orden = orden[0].Id;
					foreach (DataGridViewRow row in dtProductos.Rows)
					{
						detalles.Id_producto = Convert.ToInt32(row.Cells["id_producto"].Value.ToString());
						detalles.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
						detalles.create_det();
					}
				}
			}
			this.Close();
		}
	}
}
