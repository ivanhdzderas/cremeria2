using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms.Reportes
{
	public partial class Reporte_ventas : Form
	{
		public Reporte_ventas()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ventas vent = new ventas();
			vent.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			ventas_detallado venta = new ventas_detallado();
			venta.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Ventas_det venta = new Ventas_det();
			venta.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Promotor promotor = new Promotor();
			promotor.Show();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Global_promotores global = new Global_promotores();
			global.Show();
		}
	}
}
