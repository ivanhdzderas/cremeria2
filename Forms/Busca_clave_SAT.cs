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
	public partial class Busca_clave_SAT : Form
	{
		public Busca_clave_SAT()
		{
			InitializeComponent();
		}
		private void carga()
		{
			dgClaveSat.Rows.Clear();
			Models.SAT_prod sat_prod = new Models.SAT_prod();
			using (sat_prod)
			{
				List<Models.SAT_prod> result = sat_prod.getSat_prod();
				foreach (Models.SAT_prod item in result)
				{
					dgClaveSat.Rows.Add(item.Code, item.Description);
				}
			}
		}
		private void Busca_clave_SAT_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				dgClaveSat.Rows.Clear();
				Models.SAT_prod sat_prod = new Models.SAT_prod();
				using (sat_prod)
				{
					List<Models.SAT_prod> result = sat_prod.getSat_prodbyDescription(txtSearch.Text);
					foreach (Models.SAT_prod item in result)
					{
						dgClaveSat.Rows.Add(item.Code, item.Description);
					}
					dgClaveSat.Focus();
				}
			}
		}

		private void dgClaveSat_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int i = dgClaveSat.CurrentRow.Index;
				string valor = dgClaveSat.Rows[i].Cells["clave"].Value.ToString();
				(this.Owner as Producto).txtSAT.Text = valor;
				this.Close();
			}
		}
	}
}
