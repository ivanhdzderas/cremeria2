using Microsoft.Reporting.WinForms;
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
	public partial class Listas : Form
	{
		public Listas()
		{
			InitializeComponent();
		}

		private void Listas_Load(object sender, EventArgs e)
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
			Models.Providers proveedores = new Models.Providers();
			using (proveedores)
			{
				List<Models.Providers> result = proveedores.getProviders();
				foreach (Models.Providers item in result)
				{
					row = table.NewRow();
					row["Text"] = item.Name;
					row["Value"] = item.Id;
					table.Rows.Add(row);
				}
			}

			cbProveedor.BindingContext = new BindingContext();
			cbProveedor.DataSource = table;
			cbProveedor.DisplayMember = "Text";
			cbProveedor.ValueMember = "Value";
			cbProveedor.BindingContext = new BindingContext();

			this.reportViewer1.RefreshReport();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (cbProveedor.Text != "")
			{
				Models.Reports.Lista_proveedor listado = new Models.Reports.Lista_proveedor();
				using (listado)
				{
					this.reportViewer1.LocalReport.ReportEmbeddedResource = "Cremeria.Reports.Listas.rdlc";
					this.reportViewer1.LocalReport.DataSources.Clear();
					List<Models.Reports.Lista_proveedor> list = listado.get_listado(Convert.ToInt32(cbProveedor.SelectedValue));
					ReportDataSource lista = new ReportDataSource("Listas", list);
					this.reportViewer1.LocalReport.DataSources.Add(lista);
					this.reportViewer1.RefreshReport();
				}
			}
		}
	}
}
