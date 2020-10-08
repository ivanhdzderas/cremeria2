using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms
{
	public partial class Form_ajustes : Form
	{
		public static string folio;
		public static string id;
		public Form_ajustes()
		{
			InitializeComponent();
		}
		public void calcula()
		{
			double totales = 0;
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				totales = totales + Convert.ToDouble(row.Cells["total"].Value.ToString());
			}
			txtTotal.Text = totales.ToString();
		}
		private void Form_ajustes_Load(object sender, EventArgs e)
		{
			dtFecha.Format = DateTimePickerFormat.Custom;
			dtFecha.CustomFormat = "yyyy-MM-dd";
			txtFolio.Enabled = false;
			dtFecha.Enabled = false;
			if (folio != "0")
			{
				txtCosto.Enabled = false;
				txtCodigo.Enabled = false;
				txtCantidad.Enabled = false;
				txtDescripcion.Enabled = false;
				txtCodigo.Enabled = false;
				btnAgregar.Enabled = false;
				btnGuardar.Enabled = false;
				dtProductos.Columns["cantidad"].ReadOnly = true;
				Models.Ajuste ajuste = new Models.Ajuste();
				using (ajuste)
				{
					List<Models.Ajuste> result = ajuste.getAjustesbyId(Convert.ToInt16(folio));
					foreach (Models.Ajuste item in result)
					{
						dtFecha.Value = Convert.ToDateTime(item.Fecha);
						txtTotal.Text = item.Total.ToString();
						txtFolio.Text = item.Id.ToString();
					}
				}



				Models.det_ajustes detalles = new Models.det_ajustes();
				using (detalles)
				{
					Models.Product producto = new Models.Product();
					List<Models.det_ajustes> res = detalles.getDet_ajustes(Convert.ToInt16(folio));
					foreach (Models.det_ajustes it in res)
					{

						List<Models.Product> prod = producto.getProductById(it.Id_producto);
						dtProductos.Rows.Add(it.Id_producto, it.Cantidad, prod[0].Code1, prod[0].Description, it.P_u, it.Total);


					}
				}



			}
		}

		private void btnCerrar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			double total = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtCosto.Text);
			dtProductos.Rows.Add(id, txtCantidad.Text, txtCodigo.Text, txtDescripcion.Text, txtCosto.Text, total);
			txtCantidad.Text = "";
			txtCodigo.Text = "";
			txtDescripcion.Text = "";
			txtCosto.Text = "";
			id = "0";
			calcula();
			txtCantidad.Focus();
		}

		private void dtProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			double p_u = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["costo"].Value);
			double cantidad = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["cantidad"].Value);
			dtProductos.Rows[e.RowIndex].Cells["total"].Value = (p_u * cantidad).ToString();
			calcula();
		}

		private void dtProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			calcula();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			Models.Ajuste ajutes = new Models.Ajuste(
				0,
				dtFecha.Text + " 00:00:00",
				Convert.ToDouble(txtTotal.Text),
				"",
				"A"
				);

			using (ajutes)
			{
				ajutes.createAjuste();
				List<Models.Ajuste> general = ajutes.getlastAjustes(dtFecha.Text + " 00:00:00", Convert.ToDouble(txtTotal.Text));
				Models.det_ajustes detalle = new Models.det_ajustes();
				detalle.Id = 0;
				detalle.Id_ajuste = general[0].Id;
				Models.Kardex kardex = new Models.Kardex();
				Models.Product producto = new Models.Product();
				Models.Afecta_inv afecta = new Models.Afecta_inv();
				double nuevo = 0;
				folio = general[0].Id.ToString();
				foreach (DataGridViewRow row in dtProductos.Rows)
				{
					detalle.Id_producto = Convert.ToInt16(row.Cells["id_producto"].Value.ToString());
					detalle.P_u = Convert.ToDouble(row.Cells["costo"].Value.ToString());
					detalle.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
					detalle.Total = Convert.ToDouble(row.Cells["total"].Value.ToString());
					using (detalle)
					{
						detalle.craeteDet_ajuste();
						using (producto)
						{
							Models.Log historia = new Models.Log();
							using (historia)
							{
								historia.Id_usuario = Convert.ToInt32(Inicial.id_usario);
								historia.Descripcion = "se ajusto el inventario del producto "+ row.Cells["descripcion"].Value.ToString();
								historia.createLog();
							}

							List<Models.Product> prod = producto.getProductById(Convert.ToInt16(row.Cells["id_producto"].Value.ToString()));
							nuevo = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
							while (prod[0].Parent != "0")
							{
								nuevo = nuevo * Convert.ToDouble(prod[0].C_unidad);
								prod = producto.getProductById(Convert.ToInt16(prod[0].Parent));
							}
							kardex.Fecha = Convert.ToDateTime(dtFecha.Text).ToString();
							kardex.Id_producto = prod[0].Id;
							kardex.Tipo = "A";
							kardex.Cantidad = nuevo;
							kardex.Antes = prod[0].Existencia;
							kardex.Id = 0;
							kardex.Id_documento = Convert.ToInt16(folio);
							using (kardex)
							{
								kardex.CreateKardex();
								List<Models.Kardex> numeracion = kardex.getidKardex(prod[0].Id, Convert.ToInt16(folio), "A");
								using (afecta)
								{
									afecta.Ajusta(numeracion[0].Id);
								}

							}

						}

					}
				}
			}



			this.Close();
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				Buscar_producto busca = new Buscar_producto();
				busca.ShowDialog();
				Models.Product producto = new Models.Product();
				using (producto)
				{
					List<Models.Product> result = producto.getProductById(intercambios.Id_producto);
					foreach (Models.Product item in result)
					{
						id = item.Id.ToString();
						txtCodigo.Text = item.Code1;
						txtDescripcion.Text = item.Description;
						txtCosto.Text = item.Cost.ToString();
					}
				}



				btnAgregar.Focus();
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "" && txtDescripcion.Text != "")
				{
					btnAgregar.Focus();
				}
				if (txtDescripcion.Text == "")
				{
					txtDescripcion.Focus();
				}
				else if (txtCodigo.Text == "")
				{
					txtCodigo.Focus();
				}
			}
		}

		private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				Buscar_producto busca = new Buscar_producto();
				busca.ShowDialog();
				Models.Product producto = new Models.Product();
				using (producto)
				{
					List<Models.Product> result = producto.getProductById(intercambios.Id_producto);
					foreach (Models.Product item in result)
					{
						id = item.Id.ToString();
						txtCodigo.Text = item.Code1;
						txtDescripcion.Text = item.Description;
						txtCosto.Text = item.Cost.ToString();
					}
				}



				btnAgregar.Focus();
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "" && txtDescripcion.Text != "")
				{
					btnAgregar.Focus();
				}
				if (txtDescripcion.Text == "")
				{
					txtDescripcion.Focus();
				}
				else if (txtCodigo.Text == "")
				{
					txtCodigo.Focus();
				}
			}
		}
	}
}
