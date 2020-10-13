using iTextSharp.text.pdf.security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms
{
	
	public partial class Form_ordenes : Form
	{
		public static int Id;
		private static int Id_producto;
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

			txtCodigo.AutoCompleteCustomSource = carga_producto1();
			txtCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;


			txtDescripcion.AutoCompleteCustomSource = carga_producto2();
			txtDescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtDescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;

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
		private AutoCompleteStringCollection carga_producto1()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Product productos = new Models.Product();
			using (productos)
			{
				List<Models.Product> result = productos.getProducts();
				foreach (Models.Product item in result)
				{
					datos.Add(item.Code1);
				}
				return datos;
			}
		}
		private AutoCompleteStringCollection carga_producto2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Product productos = new Models.Product();
			using (productos)
			{
				List<Models.Product> result = productos.getProducts();
				foreach (Models.Product item in result)
				{
					datos.Add(item.Description);
				}
				return datos;
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

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Product productos = new Models.Product();
				using (productos)
				{
					List<Models.Product> producto = productos.getProductByCodeAbsolute(txtCodigo.Text);
					Id_producto = producto[0].Id;
					txtDescripcion.Text = producto[0].Description;
					if (txtCantidad.Text == "")
					{
						txtCantidad.Focus();
					}
					else
					{
						button2.Focus();
					}
				}
			}
			if (e.KeyCode == Keys.F2)
			{
				Forms.Buscar_producto busca = new Forms.Buscar_producto();
				busca.ShowDialog();
				if (intercambios.Id_producto != 0)
				{
					Models.Product productos = new Models.Product();
					using (productos)
					{
						
						List<Models.Product> producto = productos.getProductById(intercambios.Id_producto);
						Id_producto = producto[0].Id;
						txtCodigo.Text = producto[0].Code1;
						txtDescripcion.Text= producto[0].Description;
						if (txtCantidad.Text == "")
						{
							txtCantidad.Focus();
						}
						else
						{
							button2.Focus();
						}
						

					}
				}
			}
		}

		private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Product productos = new Models.Product();
				using (productos)
				{
					List<Models.Product> producto = productos.getProductByDescription(txtDescripcion.Text);

					txtCodigo.Text = producto[0].Code1;
					if (txtCantidad.Text == "")
					{
						txtCantidad.Focus();
					}
					else
					{
						button2.Focus();
					}
				}
			}
			if (e.KeyCode == Keys.F2)
			{
				Forms.Buscar_producto busca = new Forms.Buscar_producto();
				busca.ShowDialog();
				if (intercambios.Id_producto != 0)
				{
					Models.Product productos = new Models.Product();
					using (productos)
					{

						List<Models.Product> producto = productos.getProductById(intercambios.Id_producto);

						txtCodigo.Text = producto[0].Code1;
						txtDescripcion.Text = producto[0].Description;
						if (txtCantidad.Text == "")
						{
							txtCantidad.Focus();
						}
						else
						{
							button2.Focus();
						}

					}
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Models.prov_prod costos = new Models.prov_prod();
			using (costos)
			{
				List<Models.prov_prod> cot = costos.get_costobyproveedorandprodu(Convert.ToInt32(txtNumero.Text), Id_producto);
				if (cot.Count > 0)
				{
					dtProductos.Rows.Add(Id_producto,txtCodigo.Text, txtCantidad.Text, txtDescripcion.Text);
					Id_producto = 0;
					txtDescripcion.Text = "";
					txtCodigo.Text = "";
					txtCantidad.Text = "";
					txtCodigo.Focus();
				}
			}
		}

		private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
		{
			if (txtDescripcion.Text == "")
			{
				txtDescripcion.Focus();
			}
			else
			{
				button2.Focus();
			}
		}
	}
}
