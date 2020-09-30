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
	public partial class Devo : Form
	{
		public static int Folio;
		public static int Cuantos = 0;
		public Devo()
		{
			InitializeComponent();
		}

		private void Devo_Load(object sender, EventArgs e)
		{
			Models.Dev_prov devoluciones = new Models.Dev_prov();
			using (devoluciones)
			{
				List<Models.Dev_prov> listas = devoluciones.get_devolucionesbyfolio(Folio);
				if (listas.Count > 0)
				{
					txtFolio.Text = listas[0].Id.ToString();
					txtMotivo.Text = listas[0].Motivo;
					txtTotal.Text = listas[0].Total.ToString();
				}
			}

			Models.det_dev_prov detallado = new Models.det_dev_prov();
			Models.Product productos = new Models.Product();
			using (detallado)
			{
				List<Models.det_dev_prov> list = detallado.get_detalles(Folio);
				if (list.Count > 0)
				{
					foreach(Models.det_dev_prov item in list)
					{
						Cuantos = Cuantos + 1;
						using (productos)
						{
							List<Models.Product> producto = productos.getProductById(item.Id);
						
							dtDevoluciones.Rows.Add(item.Id, item.Cantidad,producto[0].Code1, producto[0].Description, item.Pu, (item.Pu*item.Cantidad), item.Estado);
							if (item.Estado == true)
							{
								dtDevoluciones.Rows[dtDevoluciones.Rows.Count-1].Cells["recibido"].ReadOnly = true;
							}
						}
					}
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult dialogo = MessageBox.Show("¿Desea agregar las devoluciones al inventario para su venta?",
			   "Devoluciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			

			int llegaron = 0;
			Models.det_dev_prov detallado = new Models.det_dev_prov();
			Models.Product productos = new Models.Product();
			using (detallado)
			{
				foreach (DataGridViewRow row in dtDevoluciones.Rows)
				{
					if (Convert.ToBoolean(row.Cells["recibido"].Value) == true)
					{
						if (!row.Cells.IsReadOnly)
						{
							if (dialogo == DialogResult.Yes)
							{
								using (productos)
								{
									List<Models.Product> producto = productos.getProductBycode1(row.Cells["codigo"].Value.ToString());
									productos.Existencia = producto[0].Existencia + Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
									productos.Id = producto[0].Id;
									productos.update_inventary();
								}
							}
						}
						llegaron = llegaron + 1;
						detallado.Id = Convert.ToInt32(row.Cells["id"].Value);
						detallado.recibir();
					}
				}
			}
			Models.Dev_prov devolu = new Models.Dev_prov();
			using (devolu)
			{
				if (llegaron == Cuantos)
				{
					devolu.Estado = false;
					devolu.Id = Folio;
					devolu.termina_dev();
				}
			}
			
			
			this.Close();
			
		}
	}
}
