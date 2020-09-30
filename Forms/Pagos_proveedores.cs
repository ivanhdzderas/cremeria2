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
	public partial class Pagos_proveedores : Form
	{
		public Pagos_proveedores()
		{
			InitializeComponent();
		}
		public void carga()
		{
			dtPagos.Rows.Clear();
			Models.Pagos_compras pagos = new Models.Pagos_compras();
			using (pagos)
			{
				List<Models.Pagos_compras> pago = pagos.getcompras();
				Models.Compras compras = new Models.Compras();
				foreach (Models.Pagos_compras item in pago)
				{
					List<Models.Compras> compra = compras.getCompraByid(item.Id_compra);
					dtPagos.Rows.Add(item.Id, item.Fecha, compra[0].Proveedor, item.Monto);
				}
			}

		}
		private void Pagos_proveedores_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Forms_pagos pagos = new Forms_pagos();
			pagos.Owner = this;
			pagos.ShowDialog();
			carga();
		}
	}
}
