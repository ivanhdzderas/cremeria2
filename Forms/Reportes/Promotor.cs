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

namespace Cremeria.Forms.Reportes
{
	public partial class Promotor : Form
	{
		public Promotor()
		{
			InitializeComponent();
		}

		private void Promotor_Load(object sender, EventArgs e)
		{
			Finicial.Format = DateTimePickerFormat.Custom;
			Finicial.CustomFormat = "yyyy-MM-dd";
			Ffinal.Format = DateTimePickerFormat.Custom;
			Ffinal.CustomFormat = "yyyy-MM-dd";

			DataTable table = new DataTable();
			DataRow row;
			table.Columns.Add("Text", typeof(string));
			table.Columns.Add("Value", typeof(string));
			row = table.NewRow();
			row["Text"] = "";
			row["Value"] = "";
			table.Rows.Add(row);
			// cboMarca.Items.Clear();
			Models.Users usuarios = new Models.Users();
			using (usuarios)
			{
				List<Models.Users> result = usuarios.getUsers();
				foreach (Models.Users item in result)
				{
					row = table.NewRow();
					row["Text"] = item.Nombre;
					row["Value"] = item.Id;
					table.Rows.Add(row);
				}
			}

			cbPromotor.BindingContext = new BindingContext();
			cbPromotor.DataSource = table;
			cbPromotor.DisplayMember = "Text";
			cbPromotor.ValueMember = "Value";
			cbPromotor.BindingContext = new BindingContext();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (cbPromotor.Text == "")
			{
				MessageBox.Show("Se debe de seleccionar un promotor");
			}
			else
			{
				this.reportViewer1.LocalReport.ReportEmbeddedResource = "Cremeria.Reports.Promotor.rdlc";
				this.reportViewer1.LocalReport.DataSources.Clear();

				Models.Reports.Det_promotor promotor = new Models.Reports.Det_promotor();
				using (promotor)
				{
					List<Models.Reports.Det_promotor> promo = promotor.get_cantidades(Convert.ToInt32(cbPromotor.SelectedValue.ToString()), Finicial.Text, Ffinal.Text);
					ReportDataSource rettt = new ReportDataSource("Promotor", promo);
					this.reportViewer1.LocalReport.DataSources.Add(rettt);
					this.reportViewer1.RefreshReport();
				}

				

			}
			
		}
	}
}
