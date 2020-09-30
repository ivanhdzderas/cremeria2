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
	public partial class AbreCaja : Form
	{
		public AbreCaja()
		{
			InitializeComponent();
		}

		private void txtEfectivo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				button1.PerformClick();
			}
		}

		private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
		{
			char ch = e.KeyChar;
			if (ch == 46 && txtEfectivo.Text.IndexOf('.') != -1)
			{
				e.Handled = true;
				return;
			}
			if (!Char.IsDigit(ch) && ch != 9 && ch != 46)
			{
				e.Handled = true;
			}
		}

		private void txtEfectivo_Leave(object sender, EventArgs e)
		{
			if (txtEfectivo.Text == "")
			{
				txtEfectivo.Text = "0.00";
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Models.Cortes corto = new Models.Cortes();
			using (corto)
			{
				corto.Id_usuario = Convert.ToInt16(Inicial.id_usario);
				corto.Caja_inicial = Convert.ToDouble(txtEfectivo.Text);
				corto.start_caja();
			}



			this.Close();
		}
	}
}
