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
	public partial class Ventas_det : Form
	{
		public Ventas_det()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void Ventas_det_Load(object sender, EventArgs e)
		{
			Finicial.Format = DateTimePickerFormat.Custom;
			Finicial.CustomFormat = "yyyy-MM-dd";
			Ffinal.Format = DateTimePickerFormat.Custom;
			Ffinal.CustomFormat = "yyyy-MM-dd";
		}
	}
}
