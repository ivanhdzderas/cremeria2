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
	public partial class Busca_unidad_SAT : Form
	{
		public Busca_unidad_SAT()
		{
			InitializeComponent();
		}
        private void carga()
        {
            dgUnidadSat.Rows.Clear();
            Models.Unidad_Sat unidad_sat = new Models.Unidad_Sat();
            using (unidad_sat)
            {
                List<Models.Unidad_Sat> result = unidad_sat.getUnidadSat();
                foreach (Models.Unidad_Sat item in result)
                {
                    dgUnidadSat.Rows.Add(item.Code, item.Description);
                }
            }
        }
        private void Busca_unidad_SAT_Load(object sender, EventArgs e)
		{
			carga();
		}

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dgUnidadSat.Rows.Clear();
                Models.Unidad_Sat unidad_sat = new Models.Unidad_Sat();
                using (unidad_sat)
                {
                    List<Models.Unidad_Sat> result = unidad_sat.getUnidadSatByDescripton(txtSearch.Text);
                    foreach (Models.Unidad_Sat item in result)
                    {
                        dgUnidadSat.Rows.Add(item.Code, item.Description);
                    }
                    dgUnidadSat.Focus();
                }
            }
        }

        private void dgUnidadSat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int i = dgUnidadSat.CurrentRow.Index;
                string valor = dgUnidadSat.Rows[i].Cells["clave"].Value.ToString();
                (this.Owner as Producto).txtUnidadSat.Text = valor;
                this.Close();
            }
        }
    }
}
