using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace Cremeria.Forms
{
	public partial class Form_compras : Form
	{
		public static string Entrada;
		public static string folio;
		public static string id;
		public Form_compras()
		{
			InitializeComponent();
		}
		public void carga_proveedor()
		{
			cbProveedor.DataSource = null;
			cbProveedor.Items.Clear();
			DataTable table = new DataTable();
			DataRow row;
			table.Columns.Add("Text", typeof(string));
			table.Columns.Add("Value", typeof(string));
			row = table.NewRow();
			row["Text"] = "";
			row["Value"] = "";
			table.Rows.Add(row);
			Models.Providers prov = new Models.Providers();
			using (prov)
			{
				List<Models.Providers> data = prov.getProviders();

				foreach (Models.Providers item in data)
				{
					row = table.NewRow();
					row["Text"] = item.Name;
					row["Value"] = item.Id;
					table.Rows.Add(row);
				}
			}
			cbProveedor.BindingContext = new BindingContext();
			cbProveedor.DataSource = table;
			cbProveedor.DisplayMember = "Text";
			cbProveedor.ValueMember = "Value";
			cbProveedor.BindingContext = new BindingContext();
		}
		private AutoCompleteStringCollection cargadatos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Product producto = new Models.Product();
			using (producto)
			{
				List<Models.Product> result = producto.getProducts();
				foreach (Models.Product item in result)
				{
					datos.Add(item.Code1);
				}
				return datos;
			}
		}
		private AutoCompleteStringCollection cargadatos2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Product producto = new Models.Product();
			using (producto)
			{
				List<Models.Product> result = producto.getProducts();
				foreach (Models.Product item in result)
				{
					datos.Add(item.Description);
				}
				return datos;
			}
		}
		public void calcula()
		{
			double totales = 0;
			double cuantos = 0;
			double importe = 0;
			double excento = 0;
			double once = 0;
			double diezyseis = 0;
			double cero = 0;
			double grabado = 0;
			double sin_grabar = 0;
			//double descuento = Convert.ToDouble(txtTdescuento.Text);
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				cuantos = cuantos + Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
				totales = totales + Convert.ToDouble(row.Cells["total"].Value.ToString());
				importe = Convert.ToDouble(row.Cells["total"].Value.ToString());
				switch (row.Cells["impuesto"].Value.ToString())
				{
					case "EXENTO IMPUESTOS":
						break;
					case "11":
						once = once + ((importe) * 0.11);
						break;
					case "16":
						diezyseis = diezyseis + ((importe) * 0.16);
						break;
					case "TASA CERO":
						break;
				}
				if (row.Cells["impuesto"].Value.ToString() == "16" || row.Cells["impuesto"].Value.ToString() == "11")
				{
					grabado = grabado + Convert.ToDouble(row.Cells["total"].Value.ToString());
				}
				else
				{
					sin_grabar = sin_grabar + Convert.ToDouble(row.Cells["total"].Value.ToString());
				}
			}
			//double descuento = (importe / 100) * Convert.ToDouble(txtdescuento.Text);
			double descuento = Convert.ToDouble(txtdescuento.Text);
			double productos = cuantos;
			double subtotal = totales;
			double iva = excento + once + diezyseis + cero;
			double total = (subtotal + iva) - descuento;
			txtiva.Text = string.Format("{0:#,0.00}", grabado);
			txtSubtotal.Text = string.Format("{0:#,0.00}", subtotal);
			txttotal.Text = string.Format("{0:#,0.00}", total);
		}
		private void Form_compras_Load(object sender, EventArgs e)
		{
			txtCodigo.AutoCompleteCustomSource = cargadatos();
			txtCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;
			txtDescripcion.AutoCompleteCustomSource = cargadatos2();
			txtDescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtDescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;
			dtFecha.Format = DateTimePickerFormat.Custom;
			dtFecha.CustomFormat = "yyyy-MM-dd";
			dtFechaDoc.Format = DateTimePickerFormat.Custom;
			dtFechaDoc.CustomFormat = "yyyy-MM-dd";
			dtVencimiento.Format = DateTimePickerFormat.Custom;
			dtVencimiento.CustomFormat = "yyyy-MM-dd";
			txtdescuento.Text = "0";
			carga_proveedor();
			if (folio != "0")
			{
				Models.Compras compra = new Models.Compras();
				using (compra)
				{
					List<Models.Compras> resultado = compra.getCompraByid(Convert.ToInt16(folio));
					foreach (Models.Compras item in resultado)
					{
						cbProveedor.SelectedText = item.Proveedor;
						txtFolio.Text = item.Folio_doc;
						dtFecha.Text = item.Fecha;
						dtFechaDoc.Text = item.Fecha_doc;
						txttotal.Text = item.Total.ToString();
						txtiva.Text = item.Iva.ToString();
						txtdescuento.Text = item.Descuento.ToString();
						txtSubtotal.Text = item.Subtotal.ToString();
						if (item.Pagado == "SI")
						{
							chkContado.Checked = true;
						}
						else
						{
							chkContado.Checked = false;
						}

						if (chkContado.Checked == false)
						{
							txtdias.Text = item.Dias.ToString();
							dtVencimiento.Text = item.Fecha_credito;
						}
					}
				}
				Models.Product producto = new Models.Product();
				Models.Purchases detalle = new Models.Purchases();
				Models.Caducidades caducidades = new Models.Caducidades();
				string master = "0";
				int id_prod = 0;
				using (detalle)
				{
					List<Models.Purchases> resu = detalle.getPurchases(Convert.ToInt16(folio));
					foreach (Models.Purchases va in resu)
					{
						using (producto)
						{
							List<Models.Product> prod = producto.getProductById(va.Id_producto);
							master = prod[0].Parent;
							id_prod = prod[0].Id;
							while (master != "0")
							{
								List<Models.Product> encontrado = producto.getProductById(Convert.ToInt16(master));
								master = encontrado[0].Parent;
								id_prod = encontrado[0].Id;
							}
							using (caducidades)
							{
								List<Models.Caducidades> cadu = caducidades.GetCaducidadesbyCompra(Convert.ToInt16(folio), id_prod);
								if (cadu.Count > 0)
								{
									dtProductos.Rows.Add(va.Id_producto, prod[0].Code1, va.Cantidad, prod[0].Description, va.P_u, va.Total, cadu[0].Lote, cadu[0].Caducidad);
								}
								else
								{
									dtProductos.Rows.Add(va.Id_producto, prod[0].Code1, va.Cantidad, prod[0].Description, va.P_u, va.Total, "", "");
								}
								

							}
						}
					}
				}
				txtFolio.Enabled = false;
				button1.Enabled = false;
				toolStripButton2.Enabled = false;
				toolStripButton1.Enabled = false;
				button4.Enabled = false;
				button2.Enabled = false;
				txtCodigo.Enabled = false;
				txtDescripcion.Enabled = false;
				txtdescuento.Enabled = false;
				txtCantidad.Enabled = false;
				txtpu.Enabled = false;
				chkContado.Enabled = false;
				txtNumero.Enabled = false;
				cbProveedor.Enabled = false;
				dtFechaDoc.Enabled = false;
				dtProductos.Columns["cantidad"].ReadOnly = true;
				txtdescuento.Enabled = false;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "")
				{
					Models.Product producto = new Models.Product();
					using (producto)
					{
						List<Models.Product> result = producto.getProductByCodeAbsolute(txtCodigo.Text);
						foreach (Models.Product item in result)
						{
							id = item.Id.ToString();
							txtCodigo.Text = item.Code1;
							txtDescripcion.Text = item.Description;
							txtpu.Text = item.Cost.ToString();
						}
					}
					txtpu.Focus();
				}
				else
				{
					txtdescuento.Focus();
				}
				
			}
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
						txtpu.Text = item.Cost.ToString();
					}
				}
				txtpu.Focus();
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "" && txtDescripcion.Text != "")
				{
					button1.Focus();
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
			if (e.KeyCode == Keys.Enter)
			{
				Models.Product producto = new Models.Product();
				using (producto)
				{
					List<Models.Product> result = producto.getProductByDescription(txtDescripcion.Text);
					foreach (Models.Product item in result)
					{
						id = item.Id.ToString();
						txtCodigo.Text = item.Code1;
						txtDescripcion.Text = item.Description;
						txtpu.Text = item.Cost.ToString();
					}
				}
				txtpu.Focus();
			}
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
						txtpu.Text = item.Cost.ToString();
					}
				}
				txtpu.Focus();
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "" && txtDescripcion.Text != "")
				{
					button1.Focus();
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

		private void dtProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			calcula();
		}

		private void dtProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			double p_u = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["p_u"].Value);
			double cantidad = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["cantidad"].Value);
			dtProductos.Rows[e.RowIndex].Cells["total"].Value = (p_u * cantidad).ToString();
			calcula();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string Lote = "";
			string Cadu = "";
			Boolean pasa = false;
			Models.Product producto = new Models.Product();
			using (producto)
			{
				List<Models.Product> item = producto.getProductById(Convert.ToInt16(id));
				if (Convert.ToBoolean(item[0].Lote) == true)
				{
					while (pasa == false)
					{
						Caducidad caduci = new Caducidad();
						caduci.ShowDialog();
						Lote = intercambios.Lote;
						Cadu = intercambios.Caducidad;
						if (!string.IsNullOrEmpty(Lote) || !string.IsNullOrEmpty(Cadu))
						{
							pasa = true;
						}
					}
				}
			}
			double total1 = (Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtpu.Text));
			Models.prov_prod costos = new Models.prov_prod();
			using (producto)
			{
				using (costos)
				{
					List<Models.prov_prod> cos = costos.get_costobyproveedorandprodu(Convert.ToInt16(id),Convert.ToInt32(txtNumero.Text));
					if (cos.Count > 0)
					{
						List<Models.Product> item = producto.getProductById(Convert.ToInt16(id));
						dtProductos.Rows.Add(id, txtCodigo.Text, txtCantidad.Text, txtDescripcion.Text, txtpu.Text, total1.ToString(), Lote, Cadu, item[0].Buy_tax);
						id = "";
						txtCodigo.Text = "";
						txtCantidad.Text = "";
						txtDescripcion.Text = "";
						txtpu.Text = "";
						calcula();
						txtCantidad.Focus();
					}
				}
				
			}
			
		}

		private void txtdescuento_Leave(object sender, EventArgs e)
		{
			if (txtdescuento.Text == "")
			{
				txtdescuento.Text = "0";
			}
			calcula();
		}

		private void txtpu_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "" && txtDescripcion.Text != "")
				{
					button1.Focus();
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

		private void button2_Click(object sender, EventArgs e)
		{
			
			int dias = 0;
			string fecha_credito = "0000-00-00";
			string pagado = "SI";
			if (chkContado.Checked != true)
			{
				dias = Convert.ToInt16(txtdias.Text);
				fecha_credito = dtVencimiento.Text;
				pagado = "NO";
			}
			Models.Compras compra = new Models.Compras(
				0,
				txtFolio.Text,
				dtFecha.Text ,
				dtFechaDoc.Text,
				txtNumero.Text,
				"A",
				dias,
				fecha_credito,
				pagado,
				Convert.ToDouble(txtSubtotal.Text),
				Convert.ToDouble(txtiva.Text),
				Convert.ToDouble(txttotal.Text),
				Convert.ToDouble(txtdescuento.Text)
				);
			using (compra)
			{
				compra.crateCompra();

				Models.Log historial = new Models.Log();
				using (historial)
				{
					historial.Id_usuario = Convert.ToInt32(Inicial.id_usario);
					historial.Descripcion = "agrego la compra " + txtFolio.Text + "del proveedor " + cbProveedor.Text + " por $ "+txttotal.Text;
					historial.createLog();
				}


				List<Models.Compras> resultado = compra.GetlastCompras(dtFecha.Text, dtFechaDoc.Text, txtNumero.Text, Convert.ToDouble(txttotal.Text));
				Models.Purchases detalles = new Models.Purchases();
				detalles.Id = 0;
				detalles.Id_compra = resultado[0].Id;
				Models.Kardex kardex = new Models.Kardex();
				Models.Product producto = new Models.Product();
				Models.Afecta_inv afecta = new Models.Afecta_inv();
				Models.Caducidades Caducida = new Models.Caducidades();
				Models.prov_prod costos = new Models.prov_prod();
				Caducida.Id = 0;
				Caducida.Id_compra = resultado[0].Id;
				double nuevo = 0;
				foreach (DataGridViewRow row in dtProductos.Rows)
				{
					using (producto)
					{
						List<Models.Product> prod = producto.getProductById(Convert.ToInt16(row.Cells["id_producto"].Value.ToString()));

						nuevo = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
						while (prod[0].Parent != "0")
						{
							nuevo = nuevo * Convert.ToInt16(prod[0].C_unidad);
							prod = producto.getProductById(Convert.ToInt16(prod[0].Parent));
						}
						detalles.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
						detalles.Id_producto = Convert.ToInt32(row.Cells["id_producto"].Value.ToString());
						detalles.P_u = Convert.ToDouble(row.Cells["p_u"].Value.ToString());
						detalles.Total = Convert.ToDouble(row.Cells["total"].Value.ToString());
						using (detalles)
						{
							using (costos)
							{
								List<Models.prov_prod> cost = costos.get_costobyproveedorandprodu(Convert.ToInt32(row.Cells["id_producto"].Value.ToString()),Convert.ToInt32(txtNumero.Text));
								if (cost.Count>0)
								{
									costos.Id_producto = Convert.ToInt32(row.Cells["id_producto"].Value.ToString());
									costos.Id_proveedor = Convert.ToInt32(txtNumero.Text);
									costos.Cantidad = cost[0].Cantidad;
									costos.Costo = Convert.ToDouble(row.Cells["p_u"].Value.ToString());
									costos.update_from_compra();
								}
								else
								{
									costos.Id_producto = Convert.ToInt32(row.Cells["id_producto"].Value.ToString());
									costos.Id_proveedor = Convert.ToInt32(txtNumero.Text);
									costos.Cantidad =Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
									costos.Costo = Convert.ToDouble(row.Cells["p_u"].Value.ToString());
									costos.create();
								}
							}
							detalles.createPurchases();
							if (row.Cells["lote"].Value.ToString() != "")
							{
								Caducida.Id_producto = prod[0].Id;
								Caducida.Caducidad = row.Cells["caducidad"].Value.ToString();
								Caducida.Lote = row.Cells["lote"].Value.ToString();
								Caducida.Cantidad = nuevo;
								using (caducidad)
								{
									Caducida.createCaducidad();

								}
							}
							kardex.Fecha = Convert.ToDateTime(dtFecha.Text).ToString();
							kardex.Id_producto = prod[0].Id;
							kardex.Tipo = "C";
							kardex.Cantidad = nuevo;
							kardex.Antes = prod[0].Existencia;
							kardex.Id = 0;
							kardex.Id_documento = Convert.ToInt16(resultado[0].Id);
							using (kardex)
							{
								kardex.CreateKardex();
								List<Models.Kardex> numeracion = kardex.getidKardex(prod[0].Id, Convert.ToInt16(resultado[0].Id), "C");
								using (afecta)
								{
									afecta.Agrega(numeracion[0].Id);
								}
							}
						}
					}
				}
			}


			foreach (DataGridViewRow row in dtDocumentos.Rows)
			{
				Models.Ordenes_compra ordenes = new Models.Ordenes_compra();
				using (ordenes)
				{
					ordenes.Id = Convert.ToInt32(row.Cells["documento"].Value.ToString());
					ordenes.Terminado = true;
					ordenes.termina_orden();
				}
			}
			this.Close();
		}

		private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbProveedor.Text != "")
			{
				txtNumero.Text = cbProveedor.SelectedValue.ToString();
			}
			else
			{
				txtNumero.Text = "";
			}
		}

		private void chkContado_CheckedChanged(object sender, EventArgs e)
		{
			if (chkContado.Checked != true)
			{
				label14.Visible = true;
				label15.Visible = true;
				txtdias.Visible = true;
				dtVencimiento.Visible = true;
			}
			else
			{
				label14.Visible = false;
				label15.Visible = false;
				txtdias.Visible = false;
				dtVencimiento.Visible = false;
			}	
		}

		private void txtNumero_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cbProveedor.SelectedIndex = Convert.ToInt16(txtNumero.Text);
				chkContado.Focus();
			}
		}

		private void txtdias_TextChanged(object sender, EventArgs e)
		{
			if (txtdias.Text == "" || txtdias.Text == "0")
			{
				dtVencimiento.Value = dtFechaDoc.Value;
			}
			else
			{
				dtVencimiento.Value = dtFechaDoc.Value.AddDays(Convert.ToInt16(txtdias.Text));
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			open.Filter = "txt files (*.xml)|*.xml";
			if (open.ShowDialog() == DialogResult.OK && open.ToString() != " ")
			{
				XmlDocument CFDI = new XmlDocument();
				CFDI.Load(@open.FileName);
				XmlNode nodo = CFDI.GetElementsByTagName("cfdi:Comprobante").Item(0);
				string valorAtributo = nodo.Attributes.GetNamedItem("Fecha").Value;
				dtFechaDoc.Value = Convert.ToDateTime(valorAtributo);
				txtFolio.Text = nodo.Attributes.GetNamedItem("Folio").Value;
				txtdescuento.Text = nodo.Attributes.GetNamedItem("Descuento").Value.ToString();
				XmlNode emisor = CFDI.GetElementsByTagName("cfdi:Emisor").Item(0);
				string RFC = emisor.Attributes.GetNamedItem("Rfc").Value;
				Models.Product prod = new Models.Product();
				string clave = "";
				double sumatoria = 0;
				Models.Providers proveedor = new Models.Providers();
				using (proveedor)
				{
					List<Models.Providers> resultado = proveedor.getProviderbyRFC(RFC);
					if (resultado.Count > 0)
					{
						cbProveedor.SelectedValue = resultado[0].Id;
						txtNumero.Text = resultado[0].Id.ToString();
					}
					else
					{
						proveedor.Id = 0;
						proveedor.RFC = emisor.Attributes.GetNamedItem("Rfc").Value;
						proveedor.Name = emisor.Attributes.GetNamedItem("Nombre").Value;
						proveedor.createProvider();
						resultado = proveedor.getProviderbyRFC(RFC);
						carga_proveedor();
						cbProveedor.SelectedValue = resultado[0].Id;
						txtNumero.Text = resultado[0].Id.ToString();
					}
				}
				foreach (XmlNode conceptos in CFDI.GetElementsByTagName("cfdi:Conceptos").Item(0).ChildNodes)
				{
					clave = conceptos.Attributes.GetNamedItem("NoIdentificacion").Value;
					using (prod)
					{
						List<Models.Product> bucador = prod.getProductByigualCode(clave);
						if (bucador.Count > 0)
						{
							sumatoria = Convert.ToDouble(conceptos.Attributes.GetNamedItem("Cantidad").Value) * Convert.ToDouble(conceptos.Attributes.GetNamedItem("ValorUnitario").Value);
							dtProductos.Rows.Add(bucador[0].Id, bucador[0].Code1, conceptos.Attributes.GetNamedItem("Cantidad").Value, bucador[0].Description, conceptos.Attributes.GetNamedItem("ValorUnitario").Value, sumatoria,"","",bucador[0].Buy_tax);
						}
						else
						{
							DialogResult is_new = MessageBox.Show("El producto " + conceptos.Attributes.GetNamedItem("Descripcion").Value + " no fue encontrado, ¿Es nuevo?", "Producto no encontrado", MessageBoxButtons.YesNo);
							if (is_new == DialogResult.Yes)
							{
								Forms.Producto.Codigo = "";
								Forms.Producto Producto = new Forms.Producto();
								Producto.txtCodigo1.Text = clave;
								Producto.txtDescripcion.Text = conceptos.Attributes.GetNamedItem("Descripcion").Value;
								Producto.txtCosto.Text = conceptos.Attributes.GetNamedItem("ValorUnitario").Value;
								Producto.txtUnidadSat.Text = conceptos.Attributes.GetNamedItem("ClaveUnidad").Value;
								Producto.txtSAT.Text = conceptos.Attributes.GetNamedItem("ClaveProdServ").Value;
								Producto.Owner = this;
								Producto.ShowDialog();
								bucador = prod.getProductByigualCode(clave);
								sumatoria = Convert.ToDouble(conceptos.Attributes.GetNamedItem("Cantidad").Value) * Convert.ToDouble(conceptos.Attributes.GetNamedItem("ValorUnitario").Value);
								dtProductos.Rows.Add(bucador[0].Id, bucador[0].Code1, conceptos.Attributes.GetNamedItem("Cantidad").Value, bucador[0].Description, conceptos.Attributes.GetNamedItem("ValorUnitario").Value, sumatoria, "", "", bucador[0].Buy_tax);
							}
							else if (is_new == DialogResult.No)
							{
								Buscar_producto buscar = new Buscar_producto();
								buscar.ShowDialog();
								if (intercambios.Id_producto != 0)
								{
									bucador = prod.getProductById(Convert.ToInt32(intercambios.Id_producto));

									bool encontrado = false;
									if (bucador[0].Code2.Trim() == "" && encontrado==false)
									{
										prod.Id = Convert.ToInt32(intercambios.Id_producto);
										prod.Code2 = clave;
										prod.update_code2();
										encontrado = true;
									}

									if (bucador[0].Code3.Trim() == "" && encontrado == false)
									{
										prod.Id = Convert.ToInt32(intercambios.Id_producto);
										prod.Code3 = clave;
										prod.update_code3();
										encontrado = true;
									}
									if (bucador[0].Code4.Trim() == "" && encontrado == false)
									{
										prod.Id = Convert.ToInt32(intercambios.Id_producto);
										prod.Code4 = clave;
										prod.update_code4();
										encontrado = true;
									}

									if (bucador[0].Code5.Trim() == "" && encontrado == false)
									{
										prod.Id = Convert.ToInt32(intercambios.Id_producto);
										prod.Code5 = clave;
										prod.update_code5();
										encontrado = true;
									}
									sumatoria = Convert.ToDouble(conceptos.Attributes.GetNamedItem("Cantidad").Value) * Convert.ToDouble(conceptos.Attributes.GetNamedItem("ValorUnitario").Value);
									dtProductos.Rows.Add(bucador[0].Id, bucador[0].Code1, conceptos.Attributes.GetNamedItem("Cantidad").Value, bucador[0].Description, conceptos.Attributes.GetNamedItem("ValorUnitario").Value, sumatoria, "", "", bucador[0].Buy_tax);
								}
								else
								{
									MessageBox.Show("No se agregara el producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								}
								
								
							}
						}
					}
				}
				calcula();
			}
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			if (txtCodigo.Text != "")
			{
				Forms.Producto.Codigo = id.ToString();
				Forms.Producto prod = new Forms.Producto();
				prod.Show(this);
			}
			else
			{
				MessageBox.Show("Debe seleccionar un articulo a modificar");
			}
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			Forms.Producto.Codigo = "";
			Forms.Producto prod = new Forms.Producto();
			prod.Show(this);
		}

		private void cbProveedor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Providers proveedores = new Models.Providers();
				using (proveedores)
				{
					List<Models.Providers> proveedor = proveedores.getProviderbyNombreabsolute(cbProveedor.Text);
					if (proveedor.Count > 0)
					{
						txtNumero.Text = proveedor[0].Id.ToString();
					}
				}
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			busca_orden busca = new busca_orden();
			busca.Owner = this;
			busca.ShowDialog();
			int cuantos = dtDocumentos.Rows.Count;
			if (cuantos > 0)
			{
				foreach (DataGridViewRow row in dtDocumentos.Rows)
				{
					Models.Ordenes_compra ordenes = new Models.Ordenes_compra();
					using (ordenes)
					{
						List<Models.Ordenes_compra> orden = ordenes.get_ordenbyid(Convert.ToInt32(row.Cells["documento"].Value.ToString()));
						txtNumero.Text = orden[0].Id_proveedor.ToString();
						txtNumero_KeyDown(this, new KeyEventArgs(Keys.Enter));
					}
					Models.Det_ordenes detalles = new Models.Det_ordenes();
					Models.Product productos = new Models.Product();
					using (detalles)
					{
						List<Models.Det_ordenes> detalle = detalles.get_detalles( Convert.ToInt32(row.Cells["documento"].Value.ToString()));
						foreach (Models.Det_ordenes item in detalle)
						{
							List<Models.Product> producto = productos.getProductById(item.Id_producto);
							dtProductos.Rows.Insert(0, item.Id_producto, producto[0].Code1, item.Cantidad, producto[0].Description, producto[0].Cost,(producto[0].Cost* item.Cantidad),"", "0000-00-00 00:00:00", producto[0].Buy_tax);
						}
					}

				}
				calcula();
			}
		}

		private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Right)
			{
				txtCodigo.Focus();
			}

		}
	}
}