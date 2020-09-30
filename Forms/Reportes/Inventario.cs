using Cremeria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms.Reportes
{
	public partial class Inventario : Form
	{
		public Inventario()
		{
			InitializeComponent();
		}
		DataTable maketable()
		{
			DataTable inventario = new DataTable();

			inventario.Columns.Add("Codigo 1");
			inventario.Columns.Add("Codigo 2");
			inventario.Columns.Add("Descripcion");
			inventario.Columns.Add("Cantidad");
			inventario.Columns.Add("Total");

			Product producto = new Product();
			using (producto)
			{
				List<Product> productos = producto.getProducts();
				foreach (Product item in productos)
				{
					inventario.Rows.Add(item.Code1, item.Code2, item.Description, item.Existencia, "     ");
				}
				return inventario;
			}

		}
		DataTable proveedores()
		{
			DataTable inventario = new DataTable();

			inventario.Columns.Add("Codigo 1");
			inventario.Columns.Add("Codigo 2");
			inventario.Columns.Add("Descripcion");
			inventario.Columns.Add("Cantidad");
			inventario.Columns.Add("Total");

			Product producto = new Product();
			using (producto)
			{
				List<Product> productos = producto.getProductByproveedor(cboProveedor.SelectedValue.ToString());
				foreach (Product item in productos)
				{
					inventario.Rows.Add(item.Code1, item.Code2, item.Description, item.Existencia, "     ");
				}
				return inventario;
			}

		}
		DataTable marca()
		{
			DataTable inventario = new DataTable();

			inventario.Columns.Add("Codigo 1");
			inventario.Columns.Add("Codigo 2");
			inventario.Columns.Add("Descripcion");
			inventario.Columns.Add("Cantidad");
			inventario.Columns.Add("Marca");

			Product producto = new Product();
			using (producto)
			{
				List<Product> productos = producto.getProductbymarca(cboMarca.SelectedValue.ToString()) ;
				foreach (Product item in productos)
				{
					inventario.Rows.Add(item.Code1, item.Code2, item.Description, item.Existencia, cboMarca.Text);
				}
				return inventario;
			}
		}
		DataTable minimos()
		{
			DataTable inventario = new DataTable();

			inventario.Columns.Add("Codigo 1");
			inventario.Columns.Add("Codigo 2");
			inventario.Columns.Add("Descripcion");
			inventario.Columns.Add("Cantidad");
			inventario.Columns.Add("Total");

			Product producto = new Product();
			using (producto)
			{
				List<Product> productos = producto.getMinProduct();
				foreach (Product item in productos)
				{
					inventario.Rows.Add(item.Code1, item.Code2, item.Description, item.Existencia, "     ");
				}
				return inventario;
			}

		}

		private void Inventario_Load(object sender, EventArgs e)
		{
			DataTable table = new DataTable();
			DataRow row;
			table.Columns.Add("Text", typeof(string));
			table.Columns.Add("Value", typeof(string));
			row = table.NewRow();
			row["Text"] = "";
			row["Value"] = "";
			table.Rows.Add(row);
			// cboMarca.Items.Clear();
			Models.Marcas marca = new Models.Marcas();
			using (marca)
			{
				List<Models.Marcas> result = marca.getMarcas();
				foreach (Models.Marcas item in result)
				{
					row = table.NewRow();
					row["Text"] = item.Marca;
					row["Value"] = item.Id;
					table.Rows.Add(row);
				}
			}

			cboMarca.BindingContext = new BindingContext();
			cboMarca.DataSource = table;
			cboMarca.DisplayMember = "Text";
			cboMarca.ValueMember = "Value";
			cboMarca.BindingContext = new BindingContext();





			DataTable table2 = new DataTable();
			DataRow row2;
			table2.Columns.Add("Text", typeof(string));
			table2.Columns.Add("Value", typeof(string));
			row2 = table2.NewRow();
			row2["Text"] = "";
			row2["Value"] = "";
			table2.Rows.Add(row2);
			// cboMarca.Items.Clear();
			Models.Providers proveedor = new Models.Providers() ;
			using (marca)
			{
				List<Models.Providers> result = proveedor.getProviders();
				foreach (Models.Providers item in result)
				{
					row2 = table2.NewRow();
					row2["Text"] = item.Name;
					row2["Value"] = item.Id;
					table2.Rows.Add(row2);
				}
			}

			cboProveedor.BindingContext = new BindingContext();
			cboProveedor.DataSource = table2;
			cboProveedor.DisplayMember = "Text";
			cboProveedor.ValueMember = "Value";
			cboProveedor.BindingContext = new BindingContext();
		}

		private void btnPdf_Click(object sender, EventArgs e)
		{
			Configuration config = new Configuration();
			using (config)
			{
				List<Configuration> configuracion = config.getConfiguration();
				DataTable dtbl = maketable();
				Export_pdf pdf = new Export_pdf();
				pdf.ExportDatatablePdf(dtbl, configuracion[0].Ruta_reportes + "/inventario.pdf", "Inventario");
				MessageBox.Show("Terminado");
			}
		}

		private void btnExcel_Click(object sender, EventArgs e)
		{
			Configuration config = new Configuration();
			using (config)
			{
				List<Configuration> configuracion = config.getConfiguration();
				DataTable dtbl = maketable();
				Export_excel excel = new Export_excel();
				excel.ExportToExcel(dtbl, configuracion[0].Ruta_reportes + "/inventario");
				MessageBox.Show("Terminado");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Configuration config = new Configuration();
			using (config)
			{
				List<Configuration> configuracion = config.getConfiguration();
				DataTable dtbl = minimos();
				Export_pdf pdf = new Export_pdf();
				pdf.ExportDatatablePdf(dtbl, configuracion[0].Ruta_reportes + "/inventario.pdf", "Inventario");
				MessageBox.Show("Terminado");

			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Configuration config = new Configuration();
			using (config)
			{
				List<Configuration> configuracion = config.getConfiguration();
				DataTable dtbl = minimos();
				Export_excel excel = new Export_excel();
				excel.ExportToExcel(dtbl, configuracion[0].Ruta_reportes + "inventario");
				MessageBox.Show("Terminado");
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			DataTable dtbl = minimos();
			dtReporte.DataSource = dtbl;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			DataTable dtbl = maketable();
			dtReporte.DataSource = dtbl;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (cboMarca.Text == "")
			{
				MessageBox.Show("Seleccione una marca");
			}
			else
			{
				Configuration config = new Configuration();
				using (config)
				{
					List<Configuration> configuracion = config.getConfiguration();
					DataTable dtbl = marca();
					Export_excel excel = new Export_excel();
					excel.ExportToExcel(dtbl, configuracion[0].Ruta_reportes + "inventario");
					MessageBox.Show("Terminado");
				}
			}
			
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (cboMarca.Text == "")
			{
				MessageBox.Show("Seleccione una marca");
			}
			else
			{
				Configuration config = new Configuration();
				using (config)
				{
					List<Configuration> configuracion = config.getConfiguration();
					DataTable dtbl = marca();
					Export_pdf pdf = new Export_pdf();
					pdf.ExportDatatablePdf(dtbl, configuracion[0].Ruta_reportes + "/inventario.pdf", "Inventario");
					MessageBox.Show("Terminado");

				}
			}
			
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (cboMarca.Text == "")
			{
				MessageBox.Show("Seleccione una marca");
			}
			else
			{
				DataTable dtbl = marca();
				dtReporte.DataSource = dtbl;
			}
			
		}

		private void button10_Click(object sender, EventArgs e)
		{
			if (cboProveedor.Text == "")
			{
				MessageBox.Show("Seleccione un proveedor");
			}
			else
			{
				Configuration config = new Configuration();
				using (config)
				{
					List<Configuration> configuracion = config.getConfiguration();
					DataTable dtbl = proveedores();
					Export_excel excel = new Export_excel();
					excel.ExportToExcel(dtbl, configuracion[0].Ruta_reportes + "inventario");
					MessageBox.Show("Terminado");
				}
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			if (cboProveedor.Text == "")
			{
				MessageBox.Show("Seleccione un proveedor");
			}
			else
			{
				Configuration config = new Configuration();
				using (config)
				{
					List<Configuration> configuracion = config.getConfiguration();
					DataTable dtbl = proveedores();
					Export_pdf pdf = new Export_pdf();
					pdf.ExportDatatablePdf(dtbl, configuracion[0].Ruta_reportes + "/inventario.pdf", "Inventario");
					MessageBox.Show("Terminado");

				}
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (cboProveedor.Text == "")
			{
				MessageBox.Show("Seleccione un proveedor");
			}
			else
			{
				DataTable dtbl = proveedores();
				dtReporte.DataSource = dtbl;
			}
		}
	}
}
