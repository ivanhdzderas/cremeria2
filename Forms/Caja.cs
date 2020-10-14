using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.VisualBasic;
using Renci.SshNet.Messages.Transport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms
{
	public partial class Caja : Form
	{
		public static string Id_producto;
		public static int contador = 0;
		public static int Folio_guardado;
		public static double Siva;
		public static double Civa;
		public static double Subtotal;
		public static double Iva;
		public static double Total;
		public static double Descuento;
		public static int Atiende;
		public static string Recuperada = "NO";
		public static bool cancelado;
		public static double porcentaje_anterior;
		public static bool autorizado;
		public static int Quien_autorizo;
		public static bool Facturar = false;
		public static int id_cliente;
		public Caja()
		{
			InitializeComponent();
		}
		private void ver_ticket(int folio)
		{
			bool encontrado;
			dtProductos.Rows.Clear();
			Models.Tickets tickets = new Models.Tickets();
			Models.Client clientes = new Models.Client();
			Models.Dettickets detalles = new Models.Dettickets();
			Models.Product productos = new Models.Product();
			Models.Users usuarios = new Models.Users();
			using (tickets)
			{
				List<Models.Tickets> tic = tickets.getTicketsbyFolio(folio);
				if (tic.Count > 0)
				{
					encontrado = true;
					txtIdcliente.Text = tic[0].Id_cliente.ToString();
					Folio_guardado = tic[0].Folio;
					txtDescuento.Text = tic[0].Descuento.ToString();
					using (clientes)
					{
						List<Models.Client> cliente = clientes.getClientbyId(tic[0].Id_cliente);
						txtCliente.Text = cliente[0].Name;
						txtRFC.Text = cliente[0].RFC;
					}
					using (usuarios)
					{
						List<Models.Users> usuario = usuarios.getUserbyid(tic[0].Atienda);
						if (usuario.Count > 0)
						{
							txtVendedor.Text = usuario[0].Id.ToString();
							lbAtiende.Text = usuario[0].Nombre;
						}
					}
				}
				else
				{
					encontrado = false;
				}
			}
			Recuperada = "SI";
			if (encontrado == true)
			{
				using (detalles)
				{
					using (productos)
					{
						List<Models.Dettickets> det = detalles.getDetalles(Folio_guardado);
						if (det.Count > 0)
						{
							foreach (Models.Dettickets item in det)
							{
								List<Models.Product> prod = productos.getProductById(item.Id_producto);
								double costo = prod[0].Cost;
								string grabado = prod[0].Sale_tax;
								grabado = grabado.Replace("IVA ", "");
								dtProductos.Rows.Insert(0,item.Id_producto, Convert.ToDouble(item.Cantidad), prod[0].Code1, item.Descripcion, string.Format("{0:#,0.00}", item.Pu), string.Format("{0:#,0.00}" + "%", Convert.ToDouble(item.Descuento)), string.Format("{0:#,0.00}", Convert.ToDouble(item.Total)), grabado, costo, "SI");
							}
						}
					}
				}
				txtFolio.Text = Folio_guardado.ToString();
				calcula();
				txtCodigo.Focus();
			}
			if (encontrado == false)
			{
				MessageBox.Show("No se encontro folio", "Folio", MessageBoxButtons.OK, MessageBoxIcon.Error);
				limpiar();
			}
			
		}
		private void get_folio()
		{
			txtFolio.Text = folio().ToString();
		}
		private void cancelar()
		{
			string folio = Interaction.InputBox("Ingrese el folio a cancelar", "Cancelar");
			if (folio != "")
			{
				Models.Tickets tickets = new Models.Tickets();
				using (tickets)
				{
					List<Models.Tickets> ticket = tickets.getTicketsbyFolio(Convert.ToInt16(folio));
					if (ticket.Count > 0)
					{
						if (ticket[0].Status == "C")
						{
							MessageBox.Show("Ticket cancelado previamente");
						}
						else
						{
							tickets.Folio = Convert.ToInt16(folio);
							tickets.CancelTicket();
							Models.Dettickets detalle_ticket = new Models.Dettickets();
							using (detalle_ticket)
							{
								List<Models.Dettickets> Detalles = detalle_ticket.getDetalles(Convert.ToInt16(folio));
								Models.Product productos = new Models.Product();
								Models.Kardex kardex = new Models.Kardex();
								Models.Afecta_inv afecta = new Models.Afecta_inv();
								int nuevo = 0;
								foreach (Models.Dettickets dettickets in Detalles)
								{
									using (productos)
									{
										List<Models.Product> prod = productos.getProductById(dettickets.Id_producto);
										nuevo = Convert.ToInt16(dettickets.Cantidad);
										while (prod[0].Parent != "0")
										{
											nuevo = nuevo * Convert.ToInt16(prod[0].C_unidad);
											prod = productos.getProductById(Convert.ToInt16(prod[0].Parent));
										}
										kardex.Id_producto = prod[0].Id;
										kardex.Tipo = "D";
										kardex.Id_documento = Convert.ToInt16(folio);
										kardex.Cantidad = nuevo;
										kardex.Antes = prod[0].Existencia;
										using (kardex)
										{
											kardex.CreateKardex();
											List<Models.Kardex> ultimo = kardex.getidKardex(prod[0].Id, Convert.ToInt16(folio), "D");
											using (afecta)
											{
												afecta.Agrega(ultimo[0].Id);
											}
										}
									}
								}
							}
							Models.Log historial = new Models.Log();
							using (historial)
							{
								historial.Id_usuario = Convert.ToInt32(Inicial.id_usario);
								historial.Descripcion = "se cancelo el ticket "+ folio ;
								historial.createLog();
							}

							MessageBox.Show("Ticket cancelado satisfactoriamente");
						}
					}
					else
					{
						MessageBox.Show("No se encontro Ticket");
					}
				}


			}
		}
		public int folio()
		{
			int nuevo = 0;
			Models.Folios folios = new Models.Folios();
			using (folios)
			{
				List<Models.Folios> folio = folios.getFolios();
				if (folio.Count > 0)
				{
					nuevo = folio[0].Ticket;
				}
			}
			return nuevo;
		}
		private void Listar()
		{
			listGuardados.Items.Clear();
			Models.Tickets tickets = new Models.Tickets();
			using (tickets)
			{
				List<Models.Tickets> tic = tickets.getTickets_guardados();
				if (tic.Count > 0)
				{
					foreach(Models.Tickets item in tic)
					{
						listGuardados.Items.Add(item.Folio.ToString());
					}
				}
			}
		}
		private void cliente_default()
		{
			Models.Client cliente = new Models.Client();
			using (cliente)
			{
				List<Models.Client> clien = cliente.getClientbyRFC("XAXX010101000");
				if (clien.Count > 0)
				{
					txtCliente.Text = clien[0].Name;
					txtRFC.Text= clien[0].RFC;
					txtIdcliente.Text = clien[0].Id.ToString();
				}
			}
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
		private AutoCompleteStringCollection carga_clientes()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Client clientes = new Models.Client();
			using (clientes)
			{
				List<Models.Client> result = clientes.getClients();
				foreach (Models.Client item in result)
				{
					datos.Add(item.Id.ToString());
				}
				return datos;
			}
		}
		private AutoCompleteStringCollection carga_clientes2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Client clientes = new Models.Client();
			using (clientes)
			{
				List<Models.Client> result = clientes.getClients();
				foreach (Models.Client item in result)
				{
					datos.Add(item.Name);
				}
				return datos;
			}
		}
		private AutoCompleteStringCollection carga_atiende()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Users usuarios = new Models.Users();
			using (usuarios)
			{
				List<Models.Users> result = usuarios.getUsers();
				foreach (Models.Users item in result)
				{
					datos.Add(item.Nombre.ToString());
				}
				return datos;
			}
		}
		private void buscar()
		{
			Forms.Buscar_producto buscar = new Forms.Buscar_producto();
			buscar.ShowDialog();
			if (intercambios.Id_producto != 0)
			{
				Models.Product productos = new Models.Product();
				using (productos)
				{
					List<Models.Product> producto = productos.getProductById(Convert.ToInt16(intercambios.Id_producto));
					if (producto.Count > 0)
					{
						foreach (Models.Product item in producto)
						{
							if (item.Max_p1 < 1)
							{
								if (item.Max_p1 == 0)
								{
									txtCantidad.Text = "1";
								}
								else
								{
									txtCantidad.Text = item.Max_p1.ToString();
								}
							}
							else
							{
								txtCantidad.Text = "1";
							}
							Id_producto = item.Id.ToString();
							txtCodigo.Text = item.Code1;
							txtDescripcion.Text = item.Description;
							txtUnitario.Text = (string.Format("{0:#,0.00}", item.Price1));
							txtImporte.Text = (Convert.ToDouble(txtUnitario.Text) * Convert.ToDouble(txtCantidad.Text)).ToString();
							txtCantidad.Focus();
						}
					}
				}
			}
		}
		private void guardar_folio()
		{
			if (Recuperada == "NO")
			{
				Models.Folios folios = new Models.Folios();
				folios.saveticket();
			}
			
		}
		private void limpiar()
		{
			cancelado = false;
			txtArticulos.Text = "0";
			txtDescuento.Text = "0.00";
			dtProductos.Rows.Clear();
			txtCodigo.Text = "";
			txtCantidad.Text = "";
			txtDescripcion.Text = "";
			txtUnitario.Text = "0.00";
			txtImporte.Text = "";
			txtVendedor.Text = "";
			lbAtiende.Text = "";
			dtProductos.Rows.Clear();
			Folio_guardado = 0;
			Recuperada = "NO";
			calcula();
			cliente_default();
			get_folio();
			Listar();
			txtCodigo.Focus();
		}
		private void calcula()
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
			Models.Product prod= new Models.Product();
			Models.Configuration configuracion = new Models.Configuration();
			bool iva_producto = false;
			bool iva_venta = false;
			//double descuento = Convert.ToDouble(txtTdescuento.Text);
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				cuantos = cuantos + Convert.ToDouble(row.Cells["Cantidad"].Value.ToString());
				totales = totales + Convert.ToDouble(row.Cells["total_i"].Value.ToString());
				importe = Convert.ToDouble(row.Cells["total_i"].Value.ToString());
				switch (row.Cells["grabado"].Value.ToString())
				{
					case "EXENTO IMPUESTOS":
						break;
					case "11":
						once = once + ((importe) * 0.11);
						break;
					case "16":
						using (prod)
						{
							using (configuracion)
							{
								List<Models.Product> producto = prod.getProductById(Convert.ToInt32(row.Cells["id"].Value.ToString()));
								List<Models.Configuration> config = configuracion.getConfiguration();
								iva_producto = producto[0].Iva_incluido;
								iva_venta = config[0].Iva_incluido;
							}
							

						}
							diezyseis = diezyseis + ((importe) * 0.16);
						
						
						break;
					case "TASA CERO":
						break;
				}
				if (row.Cells["grabado"].Value.ToString() == "16" || row.Cells["grabado"].Value.ToString() == "11")
				{
					grabado = grabado + Convert.ToDouble(row.Cells["total_i"].Value.ToString());
				}
				else
				{
					sin_grabar = sin_grabar + Convert.ToDouble(row.Cells["total_i"].Value.ToString());
				}
				txtArticulos.Text = dtProductos.Rows.Count.ToString();
			}
			double descuento = (totales / 100) * Convert.ToDouble(txtDescuento.Text);
			double productos = cuantos;
			double subtotal = totales;
			double iva = excento + once + diezyseis + cero;
			double total = (subtotal + iva) - descuento;
			Siva = sin_grabar;
			Civa = grabado;
			Subtotal = subtotal;
			Iva = iva;
			Total = total;
			txtSubtotal.Text = string.Format("{0:#,0.00}", subtotal);
			txtTotal.Text = string.Format("{0:#,0.00}", total);
			txtIva.Text = string.Format("{0:#,0.00}", iva);
		}
		public void Guardar()
		{
			guardar_folio();
			Models.Product productos = new Models.Product();
			Models.Dettickets detalles = new Models.Dettickets();
			double nuevo;
			Models.Kardex kardex = new Models.Kardex();
			Models.Afecta_inv afecta = new Models.Afecta_inv();
			if (Recuperada == "SI")
			{
				using (detalles)
				{
					detalles.delete_det(Folio_guardado);
				}
			}
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				using (detalles) {
					detalles.Id_ticket = Folio_guardado;
					detalles.Id_producto = Convert.ToInt16(row.Cells["id"].Value.ToString());
					detalles.Descripcion = row.Cells["descripcion"].Value.ToString();
					detalles.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
					detalles.Descuento = Convert.ToDouble(row.Cells["descuento_i"].Value.ToString().Remove(row.Cells["descuento_i"].Value.ToString().Length-1));
					detalles.Pu = Convert.ToDouble(row.Cells["p_u"].Value.ToString());
					detalles.Total = (Convert.ToDouble(row.Cells["total_i"].Value.ToString()));
					detalles.Grabado = row.Cells["grabado"].Value.ToString();
					detalles.Costo = Convert.ToDouble(row.Cells["costo"].Value.ToString());
					detalles.CrateDetTicket();
				}
				using (productos)
				{
					List<Models.Product> produto = productos.getProductById(Convert.ToInt16(row.Cells["id"].Value.ToString()));
					if (produto[0].Grupal == true)
					{
						Models.Acumulados acumulados = new Models.Acumulados();
						using (acumulados)
						{
							List<Models.Acumulados> acumulado = acumulados.get_acumulados(produto[0].Id);
							if (acumulado.Count > 0)
							{
								foreach(Models.Acumulados inn in acumulado)
								{
									nuevo= Convert.ToDouble(row.Cells["cantidad"].Value.ToString())*inn.Cantidad;
									using (kardex)
									{
										List<Models.Product> producto3 = productos.getProductById(inn.Id_producto);
										kardex.Id_producto = inn.Id_producto;
										kardex.Tipo = "V";
										kardex.Cantidad = nuevo;
										kardex.Antes = producto3[0].Existencia;
										kardex.Id_documento = Folio_guardado;
										kardex.CreateKardex();
										List<Models.Kardex> numeracion = kardex.getidKardex(inn.Id_producto, Folio_guardado, "V");
										using (afecta)
										{
											afecta.Disminuye(numeracion[0].Id);
										}
									}
								}
							}
						}
					}
					else
					{
						nuevo = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
						while (produto[0].Parent != "0")
						{
							nuevo = nuevo * Convert.ToDouble(produto[0].C_unidad);
							produto = productos.getProductById(Convert.ToInt16(produto[0].Parent));
						}
						using (kardex)
						{
							kardex.Id_producto = produto[0].Id;
							kardex.Tipo = "V";
							kardex.Cantidad = nuevo;
							kardex.Antes = produto[0].Existencia;
							kardex.Id_documento = Folio_guardado;
							kardex.CreateKardex();
							List<Models.Kardex> numeracion = kardex.getidKardex(produto[0].Id, Folio_guardado, "V");
							using (afecta)
							{
								afecta.Disminuye(numeracion[0].Id);
							}
						}
					}
				}
			}
		}
		// fin de funciones no ancladas a eventos
		private void Caja_Load(object sender, EventArgs e)
		{
			lbAtiende.Text = "";
			dtFecha.Format = DateTimePickerFormat.Custom;
			dtFecha.CustomFormat = "yyyy-MM-dd";
			get_folio();
			cliente_default();
			txtCodigo.AutoCompleteCustomSource = cargadatos();
			txtCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;
			txtIdcliente.AutoCompleteCustomSource = carga_clientes();
			txtIdcliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtIdcliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
			txtCliente.AutoCompleteCustomSource = carga_clientes2();
			txtCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
			txtVendedor.AutoCompleteCustomSource = carga_atiende();
			txtVendedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtVendedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
			Listar();
			txtCodigo.Focus();
		}
		private void checar_produtos()
		{
			Models.Lista_precios listas = new Models.Lista_precios();
			using (listas)
			{
				foreach (DataGridViewRow row in dtProductos.Rows)
				{
					//row.Cells["id"].Value.ToString();
					List<Models.Lista_precios> lista = listas.get_listabycliente_producto(Convert.ToInt32(txtIdcliente.Text), Convert.ToInt32(row.Cells["id"].Value.ToString()));
					if (lista.Count > 0)
					{
						row.Cells["descuento_i"].Value = lista[0].Descuento;
						double p_u = Convert.ToDouble(row.Cells["p_u"].Value);
						double cantidad = Convert.ToDouble(row.Cells["Cantidad"].Value);
						double semitotal = (p_u * cantidad);
						double porcentaje = (semitotal / 100) * Convert.ToDouble(row.Cells["descuento_i"].Value.ToString().Remove(row.Cells["descuento_i"].Value.ToString().Length - 1));
						row.Cells["total_i"].Value = (semitotal - porcentaje).ToString();
						calcula();
						porcentaje_anterior = 0;
					}
				}
			}
		}
		private void txtIdcliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtIdcliente.Text != "")
				{
					Models.Client clientes = new Models.Client();
					using (clientes)
					{
						List<Models.Client> cliente = clientes.getClientbyId(Convert.ToInt16(txtIdcliente.Text));
						if (cliente.Count > 0)
						{
							txtCliente.Text = cliente[0].Name;
							txtRFC.Text = cliente[0].RFC;
							checar_produtos();
						}
					}
				}
			}
		}

		private void txtCliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCliente.Text != "")
				{
					Models.Client clientes = new Models.Client();
					using (clientes)
					{
						List<Models.Client> cliente = clientes.getClientbyName(txtCliente.Text);
						if (cliente.Count > 0)
						{
							txtIdcliente.Text = cliente[0].Id.ToString();
							txtRFC.Text = cliente[0].RFC;
						}
					}
				}
			}
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			
			if (e.KeyCode == Keys.F10)
			{
				btnTransfer.PerformClick();
			}
			if (e.KeyCode == Keys.F11)
			{
				btnGuardar.PerformClick();
			}
			if (e.KeyCode == Keys.Escape)
			{
				if (contador == 2)
				{
					contador = 0;
					limpiar();
				}
				else
				{
					contador = contador + 1;
					txtCodigo.Text = "";
					txtCantidad.Text = "";
					txtDescripcion.Text = "";
					txtUnitario.Text = "";
					txtImporte.Text = "";
					Id_producto = "";
					txtCodigo.Focus();
				}
			}
			if (e.KeyCode == Keys.F12)
			{
				btnCobrar.PerformClick();
			}
			if (e.KeyCode == Keys.F3)
			{
				buscar();
			}
			if (e.KeyCode == Keys.Right)
			{
				txtCantidad.Focus();
			}
			if (e.KeyCode == Keys.Down)
			{
				dtProductos.Focus();
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCodigo.Text != "")
				{
					Models.Product productos = new Models.Product();
					using (productos)
					{
						List<Models.Product> producto = productos.getProductByCodeAbsolute(txtCodigo.Text);
						if (producto.Count > 0)
						{
							foreach(Models.Product item in producto)
							{
								if (item.Max_p1 < 1)
								{
									if (item.Max_p1 == 0)
									{
										txtCantidad.Text = "1";
									}
									else
									{
										txtCantidad.Text = item.Max_p1.ToString();
									}
								}
								else
								{
									txtCantidad.Text = "1";
								}
								Id_producto = item.Id.ToString();
								txtCodigo.Text = item.Code1;
								txtDescripcion.Text = item.Description;
								txtUnitario.Text = (string.Format("{0:#,0.00}", item.Price1));
								txtImporte.Text = (Convert.ToDouble(txtUnitario.Text) * Convert.ToDouble(txtCantidad.Text)).ToString();
								txtCantidad.Focus();
							}
						}
					}
				}
			}
		}

		private void txtCantidad_TextChanged(object sender, EventArgs e)
		{
			if (txtCantidad.Text.Trim() != "")
			{
				if (txtCantidad.Text != ".")
				{
					if (Convert.ToDouble(txtCantidad.Text) != 0)
					{
						if (Id_producto == "" || Id_producto is null) { } else
						{
							Models.Product productos = new Models.Product();
							using (productos)
							{
								List<Models.Product> producto = productos.getProductById(Convert.ToInt16(Id_producto));
								if (producto.Count > 0)
								{
									double precio = 0;
									foreach (Models.Product item in producto)
									{
										if (item.Max_p1==0)
										{
											precio = item.Price1;
										}
										else
										{
											if (item.Max_p1 >= Convert.ToDouble(txtCantidad.Text))
											{
												precio = item.Price1;
											}
											else
											{
												if (item.Max_p2 == 0)
												{
													if (item.Price2 == 0)
													{
														precio = item.Price1;
													}
													else
													{
														precio = item.Price2;
													}
												}
												else
												{
													if (item.Max_p2 >= Convert.ToDouble(txtCantidad.Text))
													{
														precio = item.Price2;
													}
													else
													{
														if (item.Max_p3 == 0)
														{
															if (item.Price3 == 0)
															{
																precio = item.Price2;
															}
															else
															{
																precio = item.Price3;
															}
														}
														else
														{
															if (item.Max_p3 >= Convert.ToDouble(txtCantidad.Text))
															{
																precio = item.Price3;
															}
															else
															{
																if (item.Max_p4 == 0)
																{
																	if (item.Price4 == 0)
																	{
																		precio = item.Price3;
																	}
																	else
																	{
																		precio = item.Price4;
																	}
																}
																else
																{
																	if (item.Max_p4 >= Convert.ToDouble(txtCantidad.Text))
																	{
																		precio = item.Price4;
																	}
																	else
																	{
																		if (item.Price5 == 0)
																		{
																			precio = item.Price4;
																		}
																		else
																		{
																			precio = item.Price5;
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
										txtUnitario.Text = (string.Format("{0:#,0.00}", precio));
										txtImporte.Text = (Convert.ToDouble(txtUnitario.Text) * Convert.ToDouble(txtCantidad.Text)).ToString();
										txtCantidad.Focus();
									}
								}
							}
						}
					}
				}
			} 
		}

		private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				if (contador == 2)
				{
					contador = 0;
					btnLimpiar.PerformClick();
				}
				else
				{
					contador = contador + 1;
					txtCodigo.Text = "";
					txtCantidad.Text = "";
					txtDescripcion.Text = "";
					txtUnitario.Text = "";
					txtImporte.Text = "";
					Id_producto = "";
					txtCodigo.Focus();
				}
			}
			if (e.KeyCode == Keys.Left)
			{
				txtCodigo.Focus();
			}
			if (e.KeyCode == Keys.F2)
			{
				string precio = Interaction.InputBox("Ingrese nuevo precio", "Cancelar");
				Models.Product productos = new Models.Product();
				using (productos)
				{
					List<Models.Product> producto = productos.getProductById(Convert.ToInt32(Id_producto));
					if (producto.Count > 0)
					{
						if (Convert.ToDouble(precio) < producto[0].Cost)
						{
							MessageBox.Show("no es posible aceptar el nuevo precio");
						}
						else
						{
							txtUnitario.Text = precio;
						}

					}
				}
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtCantidad.Text != "")
				{
					Models.Lista_precios listas = new Models.Lista_precios();
					txtImporte.Text = (Convert.ToDouble(txtUnitario.Text) * Convert.ToDouble(txtCantidad.Text)).ToString();
					Models.Product producto = new Models.Product();
					using (producto)
					{
						List<Models.Product> prod = producto.getProductById(Convert.ToInt16(Id_producto));
						double costo = prod[0].Cost;
						string grabado = prod[0].Sale_tax;
						grabado = grabado.Replace("IVA ", "");
						if (prod[0].Iva_incluido == true)
						{
							double unit=Convert.ToDouble(txtUnitario.Text);
							double real = (unit / 1.16);
							dtProductos.Rows.Insert(0, Id_producto, Convert.ToDouble(txtCantidad.Text), txtCodigo.Text, txtDescripcion.Text, string.Format("{0:#,0.00}", real), string.Format("{0:#,0.00}" + "%", Convert.ToDouble(0)), string.Format("{0:#,0.00}", (real*Convert.ToDouble(txtCantidad.Text))), grabado, costo, "NO");
						}
						else
						{
							dtProductos.Rows.Insert(0, Id_producto, Convert.ToDouble(txtCantidad.Text), txtCodigo.Text, txtDescripcion.Text, string.Format("{0:#,0.00}", Convert.ToDouble(txtUnitario.Text)), string.Format("{0:#,0.00}" + "%", Convert.ToDouble(0)), string.Format("{0:#,0.00}", Convert.ToDouble(txtImporte.Text)), grabado, costo, "NO");
						}
						
						checar_produtos();
					}
					txtCodigo.Text = "";
					txtCantidad.Text = "";
					txtDescripcion.Text = "";
					txtUnitario.Text = "0.00";
					txtImporte.Text = "";
					Id_producto = "";
					txtCodigo.AutoCompleteCustomSource = cargadatos();
					calcula();
					txtCodigo.Focus();
				}
			}
		}

		private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsDigit(e.KeyChar))
			{
				e.Handled = false;
			}
			else if (char.IsControl(e.KeyChar))
			{
				e.Handled = false;
			}
			else if (e.KeyChar == '.' && !Convert.ToBoolean(txtCantidad.Text.IndexOf('.')))
			{
				e.Handled = true;
			}
			else if (e.KeyChar == '.')
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
			}
		}
		private void facturar()
		{
			Models.Client clientes = new Models.Client();
			using (clientes)
			{
				List<Models.Client> cliente = clientes.getClientbyId(Convert.ToInt32(txtIdcliente.Text));
				string correo = Interaction.InputBox("Confirmar correo electronico", "Correo", cliente[0].Email);
				clientes.Email = correo;
				clientes.Id = cliente[0].Id;
				clientes.update_email();

				string uso = Interaction.InputBox("Confirmar uso de CFDI", "Uso CFDI", cliente[0].Uso_cfdi);
				clientes.Uso_cfdi = uso;
				clientes.Id = cliente[0].Id;
				clientes.update_uso();



				Form_factura factura = new Form_factura();
				factura.txtIdCliente.Text = txtIdcliente.Text;
				factura.txtIdCliente_KeyDown(this, new KeyEventArgs(Keys.Enter));
				factura.txtUsoCfdi.Text = uso;
				factura.dtdocumentos.Rows.Add(Folio_guardado, "Ticket");
				factura.show_det_ticket();


				factura.button1.PerformClick();
				factura.ShowDialog();

			}

		}
		private void txtCantidad_Leave(object sender, EventArgs e)
		{
			if (txtCantidad.Text != "" && txtCodigo.Text != "")
			{
				txtImporte.Text = (Convert.ToDouble(txtUnitario.Text) * Convert.ToDouble(txtCantidad.Text)).ToString();
			}
		}

		private async void btnCobrar_Click(object sender, EventArgs e)
		{
			if (txtVendedor.Text == "")
			{
				errorProvider1.SetError(txtVendedor, "Debe de ingresar quien atendio");
				txtVendedor.Focus();
			}
			else
			{
				Cobro cobro = new Cobro();
				if (Recuperada == "NO")
				{
					Cobro.Recuperada = false;
				}
				else
				{
					Cobro.Recuperada = true;
				}
				Cobro.Id_cliente = Convert.ToInt16(txtIdcliente.Text);
				Cobro.deberia_ser = Convert.ToDouble(txtTotal.Text);
				Descuento = Convert.ToDouble(txtDescuento.Text);
				Atiende = Convert.ToInt16(txtVendedor.Text);
				cobro.ShowDialog();
				if (cancelado == false)
				{
					Guardar();
					if (Facturar==true) {
						facturar();
					}
					else
					{
						printDocument1 = new PrintDocument();
						Models.Configuration configuracion = new Models.Configuration();
						int cuantos = dtProductos.RowCount;
						int faltantes = 0;
						int valor = 0;
						using (configuracion)
						{
							faltantes = cuantos - 1;
							valor = 110 * faltantes;
							valor = valor + 1150;
							PaperSize ps = new PaperSize("Custom", 300, valor);
							List<Models.Configuration> config = configuracion.getConfiguration();
							printDocument1.DefaultPageSettings.PaperSize = ps;
							printDocument1.PrinterSettings.PrinterName = config[0].Impresora;
							printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
							printDocument1.Print();
						}
					}
					Folio_guardado = 0;
					Recuperada = "NO";
					limpiar();
					Listar();
				}
			}
		}

		private void txtVendedor_KeyDown(object sender, KeyEventArgs e)
		{
			bool error = false;
			if (e.KeyCode == Keys.Enter)
			{
				Models.Users usuarios = new Models.Users();
				using (usuarios)
				{
					List<Models.Users> usuario = usuarios.getUserbyname(txtVendedor.Text);
					if (usuario.Count > 0)
					{
						txtVendedor.Text = usuario[0].Id.ToString();
						lbAtiende.Text = usuario[0].Nombre;
						txtCodigo.Focus();
					}
					else
					{
						int temp = 0;
						if (int.TryParse(txtVendedor.Text, out temp))
						{
							usuario = usuarios.getUserbyid(Convert.ToInt16(txtVendedor.Text)); ;
							if (usuario.Count > 0)
							{
								lbAtiende.Text = usuario[0].Nombre;
								txtCodigo.Focus();
							}
							else
							{
								error = true;
							}
						}
					}
				}
			}

			if (error == true)
			{
				errorProvider1.RightToLeft = false;
				errorProvider1.SetError(txtVendedor, "No se encontro colaborador");
				lbAtiende.Text = "";
				txtVendedor.Focus();
			}
			else
			{
				errorProvider1.Clear();
			}

		}

		private void btnLimpiar_Click(object sender, EventArgs e)
		{
			limpiar();
		}

		private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
		{
			Models.Configuration configuracion = new Models.Configuration();
			Models.Dettickets detalles = new Models.Dettickets();
			Models.Tickets tickets = new Models.Tickets();
			Models.Client clientes = new Models.Client();
			using (configuracion)
			{
				List<Models.Configuration> config = configuracion.getConfiguration();
				Font font = new Font("Verdana", 8, FontStyle.Regular);
				int y = 70;
				var format = new StringFormat() { Alignment = StringAlignment.Center };
				double cambio = 0;
				double descuento = Convert.ToDouble(txtDescuento.Text);
				if (config[0].Logo_ticket != "")
				{
					if (File.Exists(config[0].Logo_ticket))
					{
						Image logo = Image.FromFile(config[0].Logo_ticket);
						e.Graphics.DrawImage(logo, new Rectangle(0, 00, 250, 70));
					}
				}
				y = y + 10;
				e.Graphics.DrawString(config[0].Razon_social, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString(config[0].RFC, font, Brushes.Black, 125, y, format);
				y = y + 10;
				string calle = config[0].Calle + " " + config[0].No_ext;
				if (config[0].No_int != "")
				{
					calle += "-" + config[0].No_int;
				}
				e.Graphics.DrawString(calle, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString(config[0].Municipio + " " + config[0].Estado, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString("Telefono" + config[0].Telefono, font, Brushes.Black, 125, y, format);
				y = y + 10;
				e.Graphics.DrawString(config[0].Razon_social, font, Brushes.Black, 125, y, format);
				format = new StringFormat() { Alignment = StringAlignment.Far };
				y = y + 10;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
				using (tickets)
				{
					List<Models.Tickets> tic = tickets.getTicketsbyFolio(Folio_guardado);
					using (clientes)
					{
						List<Models.Client> datos_cliente = clientes.getClientbyId(tic[0].Id_cliente);
						string nombre = "Cliente: [" + datos_cliente[0].Id + "] " + datos_cliente[0].Name;
						y = y + 25;
						e.Graphics.DrawString(nombre, font, Brushes.Black, 0, y);
						string rfc = "RFC: " + datos_cliente[0].RFC;
						y = y + 15;
						e.Graphics.DrawString(rfc, font, Brushes.Black, 0, y);
						y = y + 15;
						e.Graphics.DrawString(tic[0].Fecha, font, Brushes.Black, 0, y);
					}
					y = y + 15;
					e.Graphics.DrawString("Folio: " + Folio_guardado.ToString(), font, Brushes.Black, 0, y);
					y = y + 20;
					e.Graphics.DrawString("Cant.", font, Brushes.Black, 50, y, format);
					e.Graphics.DrawString("P/U.", font, Brushes.Black, 120, y, format);
					if (Convert.ToDouble(tic[0].Descuento) != 0)
					{
						e.Graphics.DrawString("Desc.", font, Brushes.Black, 150, y, format);
					}
					e.Graphics.DrawString("IMPTE.", font, Brushes.Black, 220, y, format);
					y = y + 10;
					e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
					double totali = 0;
					using (detalles)
					{
						List<Models.Dettickets> det = detalles.getDetalles(Folio_guardado);
						foreach(Models.Dettickets item in det)
						{
							y = y + 30;
							e.Graphics.DrawString(item.Descripcion, font, Brushes.Black, 10, y);
							e.Graphics.DrawString(item.Cantidad.ToString(), font, Brushes.Black, 50, y + 10, format);
							e.Graphics.DrawString(string.Format("{0:#,0.00}",item.Pu), font, Brushes.Black, 120, y + 10, format);
							if (Convert.ToDouble(item.Descuento) != 0)
							{
								e.Graphics.DrawString(string.Format("{0:#,0.00}", item.Descuento), font, Brushes.Black, 150, y + 10, format);
							}
							e.Graphics.DrawString(string.Format("{0:#,0.00}", item.Total), font, Brushes.Black, 220, y + 10, format);
							totali = totali + 1;
						}
					}
					y = y + 15;
					e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
					y = y + 15;
					e.Graphics.DrawString("VENTA C/IVA", font, Brushes.Black, 150, y + 10, format);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", tic[0].C_iva), font, Brushes.Black, 220, y + 10, format);
					y = y + 15;
					e.Graphics.DrawString("VENTA S/IVA", font, Brushes.Black, 150, y + 10, format);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", tic[0].S_iva), font, Brushes.Black, 220, y + 10, format);
					y = y + 15;
					e.Graphics.DrawString("Subtotal", font, Brushes.Black, 150, y + 10, format);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", tic[0].Subtotal), font, Brushes.Black, 220, y + 10, format);
					y = y + 15;
					e.Graphics.DrawString("Descuento", font, Brushes.Black, 150, y + 10, format);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", tic[0].Descuento) + "%" , font, Brushes.Black, 220, y + 10, format);
					y = y + 15;
					e.Graphics.DrawString("IVA", font, Brushes.Black, 150, y + 10, format);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", tic[0].Iva), font, Brushes.Black, 220, y + 10, format);
					y = y + 15;
					e.Graphics.DrawString(totali + " Articulos", font, Brushes.Black, 10, y + 10);
					e.Graphics.DrawString("Total", font, Brushes.Black, 150, y + 10, format);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", tic[0].Total), font, Brushes.Black, 220, y + 10, format);
					y = y + 15;
					e.Graphics.DrawString("_____________________________", font, Brushes.Black, 140, y + 10);
					y = y + 15;
					e.Graphics.DrawString("Recibido", font, Brushes.Black, 150, y + 10, format);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", tic[0].Recibido), font, Brushes.Black, 220, y + 10, format);
					y = y + 20;
					e.Graphics.DrawString("Cambio", font, Brushes.Black, 150, y + 10, format);
					cambio = tic[0].Recibido - Convert.ToDouble(tic[0].Total);
					e.Graphics.DrawString(string.Format("{0:#,0.00}", Convert.ToDouble(cambio.ToString())), font, Brushes.Black, 220, y + 10, format);
					y = y + 40;
					intercambios inter = new intercambios();
					e.Graphics.DrawString(inter.enletras(tic[0].Total.ToString()), font, Brushes.Black, 0, y);
				}
				y = y + 20;
				e.Graphics.DrawString(config[0].Pie_ticket, font, Brushes.Black, 0, y);
				y = y + 30;
				e.Graphics.DrawString("___________________________________________", font, Brushes.Black, 0, y);
			}
			Folio_guardado = 0;
		}

		private void dtProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			Models.Product productos = new Models.Product();
			using (productos)
			{
				List<Models.Product> producto = productos.getProductById(Convert.ToInt16(dtProductos.Rows[e.RowIndex].Cells["id"].Value.ToString()));
				if (producto[0].Code1 == dtProductos.Rows[e.RowIndex].Cells["codigo"].Value.ToString())
				{
					double p_u = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["p_u"].Value);
					double cantidad = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["Cantidad"].Value);
					double semitotal = (p_u * cantidad);
					double porcentaje = (semitotal / 100) * Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["descuento_i"].Value.ToString().Remove(dtProductos.Rows[e.RowIndex].Cells["descuento_i"].Value.ToString().Length - 1));
					double ultimo = (semitotal - porcentaje);
					if (p_u < producto[0].Cost)
					{
						MessageBox.Show("no es posible aplicar ese descuento");
						dtProductos.Rows[e.RowIndex].Cells["descuento"].Value = porcentaje_anterior.ToString();
					}
					else
					{
						dtProductos.Rows[e.RowIndex].Cells["descuento_i"].Value = dtProductos.Rows[e.RowIndex].Cells["descuento_i"].Value;
						dtProductos.Rows[e.RowIndex].Cells["total_i"].Value = (semitotal - porcentaje).ToString();
						calcula();
						porcentaje_anterior = 0;
					}
				}
				else
				{
					producto = productos.getProductByCodeAbsolute(dtProductos.Rows[e.RowIndex].Cells["Codigo"].Value.ToString());
					dtProductos.Rows[e.RowIndex].Cells["id"].Value = producto[0].Id.ToString();
					dtProductos.Rows[e.RowIndex].Cells["descripcion"].Value = producto[0].Description;
					dtProductos.Rows[e.RowIndex].Cells["p_u"].Value = producto[0].Price1.ToString();
					double p_u = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["p_u"].Value);
					double cantidad = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["Cantidad"].Value);
					double cantidad_pre = producto[0].Cost * cantidad;
					double semitotal = (p_u * cantidad);
					double porcentaje = (semitotal / 100) * Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["descuento_i"].Value.ToString().Remove(dtProductos.Rows[e.RowIndex].Cells["descuento_i"].Value.ToString().Length - 1));
					dtProductos.Rows[e.RowIndex].Cells["total_i"].Value = (semitotal - porcentaje).ToString();
					calcula();
					porcentaje_anterior = 0;
				}
			}
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			Models.Tickets tickets = new Models.Tickets();
			using (tickets)
			{
				Folio_guardado = folio();
				tickets.Folio = Folio_guardado;
				tickets.Id_cliente = Convert.ToInt16(txtIdcliente.Text);
				tickets.Subtotal = Caja.Subtotal;
				tickets.Descuento = Caja.Descuento;
				tickets.Iva = Caja.Iva;
				tickets.Total = Caja.Total;
				tickets.Status = "G";
				tickets.C_iva = Caja.Civa;
				tickets.S_iva = Caja.Siva;
				tickets.Id_usuario = Convert.ToInt16(Inicial.id_usario);
				tickets.Atienda = Convert.ToInt32(Caja.Atiende);
				tickets.A_facturar = Convert.ToInt16(false);
				tickets.Recibido = Convert.ToDouble(0);
				tickets.CreateTicket();
			}
			Guardar();
			dtProductos.Rows.Clear();
			Listar();
			MessageBox.Show("Ticket Guardado satisfactoriamente", "Ticket Guardado"); ;
		}

		private void listGuardados_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (listGuardados.SelectedItem != null)
			{
				ver_ticket(Convert.ToInt16(listGuardados.SelectedItem.ToString()));
			}
		}
		
		private void btnBuscar_Click(object sender, EventArgs e)
		{
			buscar();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string folio = Interaction.InputBox("Ingrese el folio a reimprimir", "Reimprimir");
			if (folio != "")
			{
				Folio_guardado = Convert.ToInt16(folio);
				printDocument1 = new PrintDocument();
				Models.Configuration configuracion = new Models.Configuration();
				int cuantos = dtProductos.RowCount;
				int faltantes = 0;
				int valor;
				using (configuracion)
				{
					faltantes = cuantos - 1;
					valor = 110 * faltantes;
					valor = valor + 1150;
					PaperSize ps = new PaperSize("Custom", 300, valor);
					List<Models.Configuration> config = configuracion.getConfiguration();
					printDocument1.DefaultPageSettings.PaperSize = ps;
					printDocument1.PrinterSettings.PrinterName = config[0].Impresora;
					printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
					printDocument1.Print();
				}
				limpiar();
				Listar();
			}
		}

		private void btnRetiro_Click(object sender, EventArgs e)
		{
			autorizado = false;
			Autenficiar autentifi = new Autenficiar();
			Autenficiar.origen = "retiro";
			autentifi.ShowDialog();
			if (autorizado == true)
			{
				Retiro retiro = new Retiro();
				Retiro.usuario = Quien_autorizo;
				retiro.Show();
			}
		}

		private void btnTransfer_Click(object sender, EventArgs e)
		{
			autorizado = false;
			Autenficiar autentifi = new Autenficiar();
			Autenficiar.origen = "transferencia";
			autentifi.ShowDialog();
			if (autorizado == true)
			{
				Models.Product productos = new Models.Product();
				using (productos)
				{
					foreach (DataGridViewRow row in dtProductos.Rows)
					{
						using (productos)
						{
							List<Models.Product> produto = productos.getProductById(Convert.ToInt16(row.Cells["id"].Value.ToString()));
							row.Cells["p_u"].Value = string.Format("{0:#,0.00}", produto[0].Cost);
							double sub = produto[0].Cost * Convert.ToDouble(row.Cells["cantidad"].Value);
							row.Cells["total_i"].Value = string.Format("{0:#,0.00}", sub);
						}
					}
				}
				form_transfer.id_transfer = 0;
				form_transfer Transfer = new form_transfer();
				//Sucursal sucu = new Sucursal();
				//sucu.ShowDialog();
				//Transfer.cbOficinas.SelectedValue = sucursal;
				foreach (DataGridViewRow row in dtProductos.Rows)
				{
					Transfer.dtProductos.Rows.Insert(0,row.Cells["id"].Value, row.Cells["cantidad"].Value, row.Cells["codigo"].Value, row.Cells["descripcion"].Value, row.Cells["p_u"].Value, row.Cells["total_i"].Value);
				}
				Transfer.calcula();
				Models.Folios folio = new Models.Folios();
				using (folio)
				{
					List<Models.Folios> transfer = folio.getFolios();
					Transfer.txtFolios.Text = transfer[0].Transferencia.ToString();
				}
				Transfer.ShowDialog();
				limpiar();
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			autorizado = false;
			Autenficiar autentifi = new Autenficiar();
			Autenficiar.origen = "cancelar";
			autentifi.ShowDialog();
			if (autorizado == true)
			{
				cancelar();
				
			}
		}

		private void txtFolio_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Left:
					btnAtras.PerformClick();
					break;
				case Keys.Right:
					btnAdelante.PerformClick();
					break;
				case Keys.Enter:
					ver_ticket(Convert.ToInt16(txtFolio.Text));
					break;
			}
		}

		private void btnPrimero_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Desea ir al ticket 1", "Ticket", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				ver_ticket(1);
			}
		}
		private void btnUltimo_Click(object sender, EventArgs e)
		{
			limpiar();
		}

		private void btnAdelante_Click(object sender, EventArgs e)
		{
			if (folio()== (Convert.ToInt16(txtFolio.Text) + 1) || folio()==Convert.ToInt16(txtFolio.Text))
			{
				btnUltimo.PerformClick();
			}
			else
			{
				ver_ticket((Convert.ToInt16(txtFolio.Text) + 1));
			}
		}

		private void btnAtras_Click(object sender, EventArgs e)
		{
			ver_ticket((Convert.ToInt16(txtFolio.Text) - 1));
		}

		private void dtProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			porcentaje_anterior = Convert.ToDouble(dtProductos.Rows[e.RowIndex].Cells["descuento_i"].Value.ToString().Remove(dtProductos.Rows[e.RowIndex].Cells["descuento_i"].Value.ToString().Length - 1));

		}

		private void dtProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex.ToString() == "3")
			{
				Forms.Producto.Codigo = dtProductos.Rows[e.RowIndex].Cells["id"].Value.ToString();
				Forms.Producto Producto = new Forms.Producto();
				Producto.Show(this);
			}
		}

		private void dtProductos_KeyDown(object sender, KeyEventArgs e)
		{
			if (dtProductos.Rows.Count > 0)
			{
				int valor = dtProductos.CurrentRow.Index;
				if (e.KeyCode == Keys.Up)
				{
					if (valor == 0)
					{
						txtCantidad.Focus();
					}
				}
				if (e.KeyCode == Keys.Down)
				{
					if (valor == (dtProductos.Rows.Count - 1))
					{
						txtVendedor.Focus();
					}
				}
				if (e.KeyCode == Keys.F2)
				{
					int selectedrowindex = dtProductos.SelectedCells[0].RowIndex;
					DataGridViewRow selectedRow = dtProductos.Rows[selectedrowindex];
					selectedRow.Cells["p_u"].Selected = true;
				}
			}
			else
			{
				txtVendedor.Focus();
			}
			if (e.KeyCode == Keys.Delete)
			{
				int selectedrowindex = dtProductos.SelectedCells[0].RowIndex;
				dtProductos.Rows.RemoveAt(selectedrowindex);
				calcula();
				txtCodigo.Focus();
			}
		}

		private void dtProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			calcula();
		}

		private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F12)
			{
				btnGuardar.PerformClick();
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (txtDescuento.Text == "")
				{
					txtDescuento.Text = "0";
				}
				double descuento = Convert.ToDouble(txtDescuento.Text);
				txtDescuento.Text = string.Format("{0:#,0.00}", descuento);
				calcula();
			}
		}

		private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
		{
			Models.Configuration configuracion = new Models.Configuration();
			Models.Dettickets detalles = new Models.Dettickets();
			Models.Tickets tickets = new Models.Tickets();
			Models.Client clientes = new Models.Client();
			using (configuracion)
			{

				List<Models.Configuration> config = configuracion.getConfiguration();
				Font font = new Font("Verdana", 8, FontStyle.Regular);
				int y = 70;
				var format = new StringFormat() { Alignment = StringAlignment.Center };
				double cambio = 0;
				double descuento = Convert.ToDouble(txtDescuento.Text);


				if (config[0].Logo_ticket != "")
				{
					if (File.Exists(config[0].Logo_ticket))
					{
						Image logo = Image.FromFile(config[0].Logo_ticket);
						e.Graphics.DrawImage(logo, new Rectangle(0, 00, 250, 70));
					}
				}
			}
		}
		private void default_cliente()
		{
			Models.Client cliente = new Models.Client();
			using (cliente)
			{
				List<Models.Client> clien = cliente.getClientbyRFC("XAXX010101000");
				if (clien.Count > 0)
				{
					txtCliente.Text = "Cliente: " + clien[0].Name;
					txtRFC.Text = clien[0].RFC;
					txtIdcliente.Text = clien[0].Id.ToString() ;
				}
			}



		}
		private void btnClientes_Click(object sender, EventArgs e)
		{
			Busca_cliente busca = new Busca_cliente();
			busca.ShowDialog();
			txtIdcliente.Text = id_cliente.ToString();
			if (txtIdcliente.Text == "" || txtIdcliente.Text == "0")
			{
				default_cliente();
			}
			Models.Client clientes = new Models.Client();
			using (clientes)
			{
				List<Models.Client> cliente = clientes.getClientbyId(id_cliente);
				if (cliente.Count > 0)
				{
					txtCliente.Text = "Cliente: " + cliente[0].Name;
					txtRFC.Text = cliente[0].RFC;
				}
			}
		}
	}
}
