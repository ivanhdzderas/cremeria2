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
	public partial class CerrarCaja : Form
	{
		public CerrarCaja()
		{
			InitializeComponent();
		}
		private void calcula()
		{
			double diferencia = 0;
			double deberia = Convert.ToDouble(lbEsperado.Text) - Convert.ToDouble(txtReal.Text);
			lbDiferencia.Text = string.Format("{0:#,0.00}", deberia);
		}
		private void txtReal_TextChanged(object sender, EventArgs e)
		{
			calcula();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Inicial.cancelado = true;
			this.Close();
		}

		private void CerrarCaja_Load(object sender, EventArgs e)
		{
			Models.Tickets ticket = new Models.Tickets();
			using (ticket)
			{
				List<Models.Tickets> lista = ticket.getbyUser(Convert.ToInt16(Inicial.id_usario));
				double total = 0;
				Models.Cortes cortes = new Models.Cortes();
				using (cortes)
				{
					List<Models.Cortes> ultimo = cortes.getnoclose(Convert.ToInt16(Inicial.id_usario));
					foreach (Models.Cortes item in ultimo)
					{
						total += item.Caja_inicial;
					}

					foreach (Models.Tickets item in lista)
					{
						total += item.Total;
					}
					lbEsperado.Text = string.Format("{0:#,0.00}", total);
					txtReal.TextAlign = HorizontalAlignment.Right;
					txtReal.Text = "0.00";
					calcula();
				}
			}
		}

		private void txtReal_KeyPress(object sender, KeyPressEventArgs e)
		{
			char ch = e.KeyChar;
			if (ch == 46 && txtReal.Text.IndexOf('.') != -1)
			{
				e.Handled = true;
				return;
			}
			if (!Char.IsDigit(ch) && ch != 9 && ch != 46)
			{
				e.Handled = true;
			}
		}

		private void txtReal_Leave(object sender, EventArgs e)
		{
			if (txtReal.Text == "")
			{
				txtReal.Text = "0.00";
			}
		}

		private void txtReal_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				button1.PerformClick();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Models.Cortes corte = new Models.Cortes();
			using (corte)
			{
				corte.Caja_fin = Convert.ToDouble(txtReal.Text);
				corte.Diferencia = Convert.ToDouble(lbDiferencia.Text);
				corte.Id_usuario = Convert.ToInt16(Inicial.id_usario);
				corte.end_caja();
			}
			Inicial.exit = true;
			this.Close();
		}
	}
}
