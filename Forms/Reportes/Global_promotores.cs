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
	public partial class Global_promotores : Form
	{
		public Global_promotores()
		{
			InitializeComponent();
		}

		private void Global_promotores_Load(object sender, EventArgs e)
		{

			dtInicial.Format = DateTimePickerFormat.Custom;
			dtInicial.CustomFormat = "yyyy-MM-dd";
			dtFinal.Format = DateTimePickerFormat.Custom;
			dtFinal.CustomFormat = "yyyy-MM-dd";
			this.reportViewer1.RefreshReport();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "Cremeria.Reports.General.rdlc";
			this.reportViewer1.LocalReport.DataSources.Clear();

			Models.Reports.Promotores promotor = new Models.Reports.Promotores();
			using (promotor)
			{
				List<Models.Reports.Promotores> promo = promotor.get_listado(dtInicial.Text, dtFinal.Text);
				ReportDataSource rettt = new ReportDataSource("promo", promo);
				this.reportViewer1.LocalReport.DataSources.Add(rettt);
				this.reportViewer1.RefreshReport();
			}

		}
	}
}
