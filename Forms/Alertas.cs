using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms
{
	public partial class Alertas : Form
	{
		public Alertas()
		{
			InitializeComponent();
		}

		private void Alertas_Load(object sender, EventArgs e)
		{
			DateTime today = DateTime.Today;
			string dia11 = today.ToString("dddd", new CultureInfo("es-ES"));

			Models.Providers proveedores = new Models.Providers();
			Models.Compras compras = new Models.Compras();
			using (proveedores)
			{
				List<Models.Providers> proveedor = proveedores.getProvidersbypago(dia11);
				using (compras)
				{
					//List<Models.Compras> compra = compras.GetComprasporvencer(today.ToString("yyyy-MM-dd"),proveedor[0].Id);
					
				}
			}

		}
	}
}
