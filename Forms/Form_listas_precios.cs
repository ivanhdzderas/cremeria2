
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
	public partial class Form_listas_precios : Form
	{
		private int Id_producto;
		public int Id_lista;
		public Form_listas_precios()
		{
			InitializeComponent();
		}

		private void Form_listas_precios_Load(object sender, EventArgs e)
		{
			nmDescuento.DecimalPlaces = 2;
			nmDescuento.ThousandsSeparator = true;

			txtCodigo.AutoCompleteCustomSource = carga_codigo();
			txtCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtDescripcion.AutoCompleteCustomSource = carga_descripcion();
			txtDescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtDescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtCliente.AutoCompleteCustomSource = carga_cliente();
			txtCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtId_cliente.AutoCompleteCustomSource = carga_clientes();
			txtId_cliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtId_cliente.AutoCompleteSource = AutoCompleteSource.CustomSource;


			if (Id_lista != 0)
			{
				Models.Lista_precios listas = new Models.Lista_precios();
				using (listas)
				{
					List<Models.Lista_precios> lista=listas.getlistas_byid(Id_lista);
					txtId_cliente.Text = lista[0].Id_cliente.ToString();
					txtId_cliente_KeyDown(this, new KeyEventArgs(Keys.Enter));
					busca_producto(lista[0].Id_Producto);
					nmDescuento.Value = Convert.ToDecimal(lista[0].Descuento);
					button3.Visible = true;
					txtId_cliente.ReadOnly = true;
					txtCliente.ReadOnly = true;
					txtCodigo.ReadOnly = true;
					txtDescripcion.ReadOnly = true;
				}
			}
		}
		private void busca_producto(int id)
		{
			Models.Product productos = new Models.Product();
			using (productos)
			{
				List<Models.Product> producto = productos.getProductById(id);
				txtCodigo.Text = producto[0].Code1;
				txtCodigo_KeyDown(this, new KeyEventArgs(Keys.Enter));
			}
		}
		private AutoCompleteStringCollection carga_clientes()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Client clientes = new Models.Client();
			using (clientes)
			{
				List<Models.Client> result = clientes.getClients();
				foreach (Models.Client item in result)
				{
					datos.Add(item.Id.ToString());
				}
				return datos;
			}
		}

		private AutoCompleteStringCollection carga_cliente()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Client clientes = new Models.Client();
			using (clientes)
			{
				List<Models.Client> result = clientes.getClients();
				foreach (Models.Client item in result)
				{
					datos.Add(item.Name);
				}
				return datos;
			}
		}

		private AutoCompleteStringCollection carga_descripcion()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Product producto = new Models.Product();
			using (producto)
			{
				List<Models.Product> result = producto.getProducts();
				foreach (Models.Product item in result)
				{
					datos.Add(item.Description);
				}
				return datos;
			}
		}

		private AutoCompleteStringCollection carga_codigo()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Product producto = new Models.Product();
			using (producto)
			{
				List<Models.Product> result = producto.getProducts();
				foreach (Models.Product item in result)
				{
					datos.Add(item.Code1);
				}
				return datos;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
			Models.Lista_precios listas = new Models.Lista_precios();
			using (listas) {
				listas.Id_cliente = Convert.ToInt32(txtId_cliente.Text);
				listas.Id_Producto = Id_producto;
				listas.Descuento = Convert.ToDouble(nmDescuento.Value);
				if (Id_lista == 0)
				{
					listas.create_lista();
				}
				else
				{
					listas.Id = Id_lista;
					listas.update_lista();

				}
				
			}
			this.Close();
		}

		private void txtId_cliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Client clientes = new Models.Client();
				using (clientes)
				{
					List<Models.Client> result = clientes.getClientbyId(Convert.ToInt32(txtId_cliente.Text));
					if (result.Count > 0)
					{
						txtCliente.Text = result[0].Name;
					}
				}
			}
		}

		private void txtCliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Client clientes = new Models.Client();
				using (clientes)
				{
					List<Models.Client> result = clientes.getClientbyName(txtCliente.Text);
					if (result.Count > 0)
					{
						txtId_cliente.Text = result[0].Id.ToString();
					}
				}
			}
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Product producto = new Models.Product();
				using (producto)
				{
					List<Models.Product> result = producto.getProductBycode1(txtCodigo.Text);
					if (result.Count > 0)
					{
						txtDescripcion.Text = result[0].Description;
						Id_producto = result[0].Id;
					}
				}
			}
		}

		private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Product producto = new Models.Product();
				using (producto)
				{
					List<Models.Product> result = producto.getProductByDescription(txtDescripcion.Text);
					if (result.Count > 0)
					{
						txtCodigo.Text = result[0].Code1;
						Id_producto = result[0].Id;
					}
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			DialogResult dialogo = MessageBox.Show("¿Desea borrar el registro?",
			   "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogo == DialogResult.Yes)
			{
				Models.Lista_precios listas =new  Models.Lista_precios();
				using (listas)
				{
					listas.Id = Id_lista;
					listas.delete_lista();
				}
				this.Close();
			
			}
		}
	}
}
