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
	public partial class Sucursales : Form
	{
		public Sucursales()
		{
			InitializeComponent();
		}
		public void carga()
		{
			dtOficinas.Rows.Clear();
			Models.Offices oficinas = new Models.Offices();
			using (oficinas)
			{
				List<Models.Offices> lista = oficinas.GetOffices();
				foreach (Models.Offices item in lista)
				{
					dtOficinas.Rows.Add(item.Id, item.Name, item.Telefono, item.Domicilio);
				}
			}

		}
		private void Sucursales_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_sucursal.id = 0;
			Form_sucursal sucursal = new Form_sucursal();
			sucursal.ShowDialog();
			carga();
		}
	}
}
