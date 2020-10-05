using Microsoft.Office.Interop.Excel;
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
	public partial class Form_proveedor : Form
	{
		public static string id;
		public Form_proveedor()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Form_proveedor_Load(object sender, EventArgs e)
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

			if (id != "'0")
			{
				Models.Providers proveedor = new Models.Providers();
				using (proveedor)
				{
					List<Models.Providers> result = proveedor.getProviderbyId(Convert.ToInt16(id));

					foreach (Models.Providers item in result)
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
						char delimitar = ',';
						string[] dias = item.Pago.Split(delimitar);
						int cuantos = dias.Count();


						
							
						for (int i = 0; i < cuantos; i++)
						{
							if (dias[i] != "")
							{
								checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(dias[i]), true);
							}
						}
					}
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string s = "";
			for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
			{
				s = s +  checkedListBox1.CheckedItems[x].ToString() + ",";
			}
			
			Models.Providers prov = new Models.Providers(
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
				s
				);
			using (prov)
			{
				if (id == "0")
				{
					prov.createProvider();
				}
				else
				{
					prov.saveProvider();
				}
			}

			this.Close();
			
		}
	}
}
