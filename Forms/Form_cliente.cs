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
	public partial class Form_cliente : Form
	{
        public static string id;
        public Form_cliente()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Form_cliente_Load(object sender, EventArgs e)
		{
            if (id == "0")
            {
                txtNombre.Text = "";
                txtRFC.Text = "";
                txtCalle.Text = "";
                txtNumExt.Text = "";
                txtNumInt.Text = "";
                txtColonia.Text = "";
                txtCp.Text = "";
                txtEstado.Text = "";
                txtMunicipio.Text = "";
                txtTelefono.Text = "";
                txtNotas.Text = "";
                txtEmail.Text = "";
            }
            else
            {
                Models.Client client = new Models.Client();
                using (client)
                {
                    List<Models.Client> result = client.getClientbyId(Convert.ToInt16(id));
                    foreach (Models.Client item in result)
                    {
                        txtNombre.Text = item.Name;
                        txtRFC.Text = item.RFC;
                        txtCalle.Text = item.Street;
                        txtNumExt.Text = item.Ext_number;
                        txtNumInt.Text = item.Int_number;
                        txtColonia.Text = item.Col;
                        txtCp.Text = item.Cp;
                        txtEstado.Text = item.State;
                        txtMunicipio.Text = item.Muni;
                        txtTelefono.Text = item.Tel;
                        txtNotas.Text = item.Note;
                        txtEmail.Text = item.Email;
                        txtUso.Text = item.Uso_cfdi;
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtTelefono.Text != "" || txtCp.Text != "")
            {
                Models.Client client = new Models.Client(
                    Convert.ToInt16(id),
                    txtNombre.Text,
                    txtRFC.Text,
                    txtCalle.Text,
                    txtNumExt.Text,
                    txtNumInt.Text,
                    txtColonia.Text,
                    txtCp.Text,
                    txtEstado.Text,
                    txtMunicipio.Text,
                    txtTelefono.Text,
                    txtNotas.Text,
                    txtEmail.Text,
                    txtUso.Text
                    );
                using (client)
                {
                    if (id == "0")
                    {
                        client.createClient();
                    }
                    else
                    {
                        client.saveClient();
                    }
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Ingrese campos minios para dar de alta");
                txtNombre.Focus();
            }
        }
    }
}
