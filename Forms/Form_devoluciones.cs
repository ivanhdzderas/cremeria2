using Cremeria.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms
{
	public partial class Form_devoluciones : Form
	{
		int Id_producto;
		public Form_devoluciones()
		{
			InitializeComponent();
		}

		private void Form_devoluciones_Load(object sender, EventArgs e)
		{
			txtId_proveedor.AutoCompleteCustomSource = carga_id_proveedor();
			txtId_proveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtId_proveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtProveedor.AutoCompleteCustomSource = carga_proveedor();
			txtProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtCodigo.AutoCompleteCustomSource = carga_codigo();
			txtCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;


			txtDescripcion.AutoCompleteCustomSource = carga_productos();
			txtDescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtDescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;
		}

		private AutoCompleteStringCollection carga_productos()
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

		private AutoCompleteStringCollection carga_codigo()
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

		private AutoCompleteStringCollection carga_id_proveedor()
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
		private void agregar()
		{
			dtProductos.Rows.Insert(0,Id_producto, txtCantidad.Text, txtCodigo.Text,txtDescripcion.Text,"",txtPu.Text, (Convert.ToDouble(txtPu.Text)*Convert.ToDouble(txtCantidad.Text)));
			Id_producto = 0;
			txtCantidad.Text = "";
			txtPu.Text = "";
			txtDescripcion.Text = "";
			txtCantidad.Focus();
		}
		private void calcula()
		{
			double total = 0;
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				total = total + Convert.ToDouble(row.Cells["importe"].Value.ToString());

			}
			txtTotal.Text = total.ToString();
		}
		private void sugerido()
		{
			string foliados = "";
			DialogResult dialogo = MessageBox.Show("¿Desea cargar el sugerido?", "Sugerido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogo == DialogResult.Yes)
			{
				dtProductos.Rows.Clear();
				Models.det_devolution det_devo_clie = new Models.det_devolution();
				Models.Product productos = new Models.Product();
				using (det_devo_clie)
				{
					List<Models.det_devolution> devo = det_devo_clie.get_detallebyproveedor(Convert.ToInt32(txtId_proveedor.Text));
					List<Models.det_devolution> listas = det_devo_clie.get_no_enviados();
					if (devo.Count > 0)
					{
						foreach(Models.det_devolution alfa in listas)
						{
							if (foliados == "")
							{
								foliados = alfa.Id.ToString();
							}
							else
							{
								foliados = foliados + "," + alfa.Id.ToString();
							}
							
						}
						foreach(Models.det_devolution item in devo)
						{
							using (productos)
							{
								List<Models.Product> producto = productos.getProductById(item.Id_producto);
								dtProductos.Rows.Add(item.Id_producto, item.Cantidad, producto[0].Code1, producto[0].Description,producto[0].Unit, producto[0].Cost,(producto[0].Cost*item.Cantidad), foliados);
							}
						}
						
					}
				}
				calcula();
			}
		}
		private void txtId_proveedor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Providers proveedores = new Models.Providers();
				using (proveedores)
				{
					List<Models.Providers> result = proveedores.getProviderbyId(Convert.ToInt32(txtId_proveedor.Text));
					if (result.Count > 0)
					{
						txtProveedor.Text = result[0].Name;

						sugerido();
					}
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
					List<Models.Providers> result = proveedores.getProviderbyNombre(txtProveedor.Text);
					if (result.Count > 0)
					{
						txtId_proveedor.Text = result[0].Id.ToString();

						sugerido();
					}
				}
			}
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Product productos = new Models.Product();
				using (productos)
				{
					List<Models.Product> producto = productos.getProductBycode1(txtCodigo.Text);
					if (producto.Count > 0)
					{
						txtDescripcion.Text = producto[0].Description;
						txtPu.Text= string.Format("{0:#,0.00}", producto[0].Cost);
						txtDescripcion.Focus();
						Id_producto = producto[0].Id;
					}
				}
			}
		}

		private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtDescripcion.Text!="" && txtCodigo.Text!="" && txtPu.Text != "")
				{
					agregar();
				}
				else
				{
					Models.Product productos = new Models.Product();
					using (productos)
					{
						List<Models.Product> producto = productos.getProductByDescription(txtDescripcion.Text);
						if (producto.Count > 0)
						{
							txtCodigo.Text = producto[0].Code1;
							txtPu.Text = string.Format("{0:#,0.00}", producto[0].Cost);
							txtDescripcion.Focus();
							Id_producto = producto[0].Id;
						}
					}
				}
				
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Models.Dev_prov devo = new Models.Dev_prov();
			Models.det_dev_prov detalles = new Models.det_dev_prov();
			Models.Product productos = new Models.Product();
			Models.det_devolution det_devolu = new Models.det_devolution();
			using (devo)
			{
				
				devo.Id_proveedor = Convert.ToInt32(txtId_proveedor.Text);
				devo.Total = Convert.ToDouble(txtTotal.Text);
				devo.Estado = true;
				devo.Motivo = txtMotivo.Text;
				devo.create_dev();
				
				List<Models.Dev_prov> ultimo = devo.get_lastdevolucion(Convert.ToInt32(txtId_proveedor.Text), Convert.ToDouble(txtTotal.Text), txtMotivo.Text);
				using (detalles)
				{
					foreach (DataGridViewRow row in dtProductos.Rows)
					{
						
						detalles.Id_devolucion = ultimo[0].Id;
						detalles.Id_producto = Convert.ToInt32(row.Cells["id"].Value.ToString());
						detalles.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());

						detalles.Pu = Convert.ToDouble(row.Cells["p_u"].Value.ToString());
						detalles.Estado = true;
						detalles.create_det();



						using (productos)
						{
							productos.Id = Convert.ToInt32(row.Cells["id"].Value.ToString());
							List<Models.Product> produ = productos.getProductById(Convert.ToInt32(row.Cells["id"].Value.ToString()));
							productos.Devoluciones = produ[0].Devoluciones - Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
							productos.update_devoluciones();
						}

						
						if (row.Cells["folios"].Value.ToString() != "")
						{
							char delimitar = ',';
							string[] folios = row.Cells["folios"].Value.ToString().Split(delimitar);
							int cuantos = folios.Count();
							for(int i = 0; i < cuantos; i++)
							{
								using (det_devolu)
								{
									det_devolu.Id_producto = Convert.ToInt32(row.Cells["id"].Value.ToString());
									det_devolu.Id_devolucion = Convert.ToInt32(folios[i]);
									det_devolu.enviar();
								}
								
							}
						}
					}
				}
			}
			this.Close();
		}
	}
}
