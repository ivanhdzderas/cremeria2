using Cremeria.Timbrado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using XSDToXML.Utils;

namespace Cremeria.Forms
{
	public partial class Form_factura : Form
	{
		public Form_factura()
		{
			InitializeComponent();
		}
		private AutoCompleteStringCollection cargadatos()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Uso_Cfdi usos = new Models.Uso_Cfdi();
			using (usos)
			{
				List<Models.Uso_Cfdi> uso = usos.get_Usos();
				foreach (Models.Uso_Cfdi item in uso)
				{
					datos.Add(item.Descripcion);
					datos.Add(item.Clave);
				}
			}
			return datos;
		}
		private AutoCompleteStringCollection carga_cliente()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Client clientes = new Models.Client();
			using (clientes)
			{
				List<Models.Client> clie = clientes.getClients();
				foreach (Models.Client item in clie)
				{
					datos.Add(item.Name);
				}
			}
			return datos;
		}

		private AutoCompleteStringCollection carga_cliente2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Client clientes = new Models.Client();
			using (clientes)
			{
				List<Models.Client> clie = clientes.getClients();
				foreach (Models.Client item in clie)
				{
					datos.Add(item.Id.ToString());
				}
			}
			return datos;
		}
		private void timbrar()
		{
			Models.Configuration configuracion = new Models.Configuration();
			using (configuracion)
			{
				List<Models.Configuration> config = configuracion.getConfiguration();
				//Instancias del timbrado
				Timbrado.StampSOAP selloSOAP = new Timbrado.StampSOAP();
				stamp oStamp = new stamp();
				stampResponse selloResponse = new stampResponse();

				//Cargas tu archivo xml
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(config[0].Ruta_factura + txtFolio.Text + ".xml");
				
				//xmlDocument.Load(config[0].Ruta_factura + txtFolio.Text + ".xml");

				//Conviertes el archivo en byte
				byte[] byteXmlDocument = Encoding.UTF8.GetBytes(xmlDocument.OuterXml);
				//Conviertes el byte resultado en base64
				string stringByteXmlDocument = Convert.ToBase64String(byteXmlDocument);
				//Convirtes el resultado nuevamente a byte
				byteXmlDocument = Convert.FromBase64String(stringByteXmlDocument);

				//Timbras el archivo
				oStamp.xml = byteXmlDocument;

				oStamp.username = "alrashidmtze@gmail.com";
				oStamp.password = "4lR4sh1d+";

				//Generamos request
				String usuario;
				usuario = Environment.UserName;
				String url = config[0].Ruta_factura;
				StreamWriter XML = new StreamWriter(url + "SOAP_Request.xml");     //Direccion donde guardaremos el SOAP Envelope
				XmlSerializer soap = new XmlSerializer(oStamp.GetType());    //Obtenemos los datos del objeto oStamp que contiene los parámetros de envió y es de tipo stamp()
				soap.Serialize(XML, oStamp);
				XML.Close();

				//Recibes la respuesta de timbrado
				selloResponse = selloSOAP.stamp(oStamp);

				try
				{
					MessageBox.Show("No se timbro el XML" + "\nCódigo de error: " + selloResponse.stampResult.Incidencias[0].CodigoError.ToString() + "\nMensaje: " + selloResponse.stampResult.Incidencias[0].MensajeIncidencia);
				}
				catch (Exception)
				{
					MessageBox.Show(selloResponse.stampResult.CodEstatus.ToString());
					
					Models.Facturas factura = new Models.Facturas();
					using (factura)
					{
						factura.Uuid = selloResponse.stampResult.UUID.ToString();
						factura.Folio = Convert.ToInt32(txtFolio.Text);
						factura.Xml = selloResponse.stampResult.xml.ToString();
						factura.update_uuid();
					}
					StreamWriter XMLL = new StreamWriter(url + txtFolio.Text + ".xml");
					XMLL.Write(selloResponse.stampResult.xml);
					XMLL.Close();
					this.Close();
				}
			}

		}
		public sealed class StringWriterWithEncoding : StringWriter
		{
			private readonly Encoding encoding;

			public StringWriterWithEncoding() { }

			public StringWriterWithEncoding(Encoding encoding)
			{
				this.encoding = encoding;
			}

			public override Encoding Encoding
			{
				get { return encoding; }
			}
		}
		public static string DoFormat(double myNumber)
		{
			var s = string.Format("{0:0.00}", myNumber);

			if (s.EndsWith("00"))
			{
				return ((int)myNumber).ToString();
			}
			else
			{
				return s;
			}
		}
		private void xml2()
		{
			Models.Configuration configuracion = new Models.Configuration();
			Models.Client clientes = new Models.Client();
			Models.Product productos = new Models.Product();
			using (configuracion)
			{
				using (clientes)
				{
					using (productos)
					{
						List<Models.Configuration> config = configuracion.getConfiguration();
			
						DateTime dt = DateTime.Now;
						DateTime x = Convert.ToDateTime(String.Format("{0:s}", dt));

						Comprobante oComprobante = new Comprobante();
						ComprobanteEmisor oEmisor = new ComprobanteEmisor();
						ComprobanteReceptor oReceptor = new ComprobanteReceptor();

						string username = "alrashidmtze@gmail.com";
						string password = "4lR4sh1d+";
						string CertFile = config[0].Cer;
						string KeyFile = config[0].Key;
						string KeyPass = config[0].Pass;
						string Errores = "";

						string noCertificado, aa, b, c;
						
						SelloDigital.leerCER(CertFile,out aa, out b, out c,out noCertificado);
						

						oComprobante.Folio = txtFolio.Text;
						oComprobante.Version = "3.3";
						oComprobante.Fecha = x.ToString("yyyy-MM-ddTHH:mm:ss");
						oComprobante.Serie = "A";
						//oComprobante.Sello = "faltante";
						//oComprobante.Certificado = "faltante";
						oComprobante.NoCertificado = noCertificado;
						oComprobante.SubTotal = Convert.ToDecimal( DoFormat(Convert.ToDouble(txtSubtotal.Text)));
						oComprobante.Moneda = "MXN";
						oComprobante.Total = Convert.ToDecimal(DoFormat(Convert.ToDouble(txtSubtotal.Text)));
						oComprobante.TipoDeComprobante = "I";
						oComprobante.FormaPago = txtFpago.Text;
						oComprobante.CondicionesDePago = "CONTADO";
						oComprobante.MetodoPago = txtMPago.Text;
						oComprobante.LugarExpedicion = config[0].Cp;

						oEmisor.Rfc = config[0].RFC;
						oEmisor.Nombre = config[0].Razon_social;
						oEmisor.RegimenFiscal = config[0].Regimen;

						List<Models.Client> cliente = clientes.getClientbyId(Convert.ToInt16(txtIdCliente.Text));
						oReceptor.Rfc = cliente[0].RFC;
						oReceptor.UsoCFDI = txtUsoCfdi.Text;
						oReceptor.Nombre = txtCliente.Text;
						oComprobante.Emisor = oEmisor;
						oComprobante.Receptor = oReceptor;
						
						List<Models.Product> producto = null;
						List<ComprobanteConcepto> lstConceptos = new List<ComprobanteConcepto>();
						

						foreach (DataGridViewRow row in dtProductos.Rows)
						{
							ComprobanteConcepto oConcepto = new ComprobanteConcepto();
							producto = productos.getProductById(Convert.ToInt16(row.Cells["id_producto"].Value.ToString()));
							List<ComprobanteConceptoImpuestosTraslado> Ltraslados = new List<ComprobanteConceptoImpuestosTraslado>();
							ComprobanteConceptoImpuestos oConoceptoimpuesto = new ComprobanteConceptoImpuestos();
							ComprobanteConceptoImpuestosTraslado oConcepto_traslado = new ComprobanteConceptoImpuestosTraslado();

							oConcepto.ClaveProdServ = producto[0].Code_sat;
							oConcepto.Cantidad = Convert.ToDecimal(row.Cells["cantidad"].Value.ToString());
							oConcepto.ClaveUnidad = producto[0].Medida_sat;
							oConcepto.Descripcion = row.Cells["descripcion"].Value.ToString();
							oConcepto.ValorUnitario = Convert.ToDecimal(DoFormat(Convert.ToDouble(row.Cells["pu"].Value.ToString())));
							oConcepto.Importe = Convert.ToDecimal(DoFormat(Convert.ToDouble(row.Cells["total"].Value.ToString())));
							//oConcepto.Descuento = Convert.ToDecimal(0);
							oConcepto.Unidad = "PIEZA";
							oConcepto.NoIdentificacion = producto[0].Code1;

							oConcepto_traslado.Base= Convert.ToDecimal(DoFormat(Convert.ToDouble(row.Cells["total"].Value.ToString())));
							oConcepto_traslado.Impuesto = "002";
							oConcepto_traslado.TipoFactor = "Tasa";
							oConcepto_traslado.TasaOCuota = Convert.ToDecimal("0.000000");
							oConcepto_traslado.Importe = Convert.ToDecimal(DoFormat(Convert.ToDouble(row.Cells["total"].Value.ToString()))) * 0;
							oConcepto_traslado.TasaOCuotaSpecified = true;
							oConcepto_traslado.ImporteSpecified = true;

							Ltraslados.Add(oConcepto_traslado);
							oConoceptoimpuesto.Traslados = Ltraslados.ToArray();
							oConcepto.Impuestos = oConoceptoimpuesto;
							
							lstConceptos.Add(oConcepto);
						}
						oComprobante.Conceptos = lstConceptos.ToArray();


						ComprobanteImpuestos oImpuuestos = new ComprobanteImpuestos();
						List<ComprobanteImpuestos> lImpuestos = new List<ComprobanteImpuestos>();

						ComprobanteImpuestosTraslado oImpuestos_traslados = new ComprobanteImpuestosTraslado();
						List<ComprobanteImpuestosTraslado> lImpuestos_traslados = new List<ComprobanteImpuestosTraslado>();

						oImpuestos_traslados.Impuesto = "002";
						oImpuestos_traslados.TipoFactor = "Tasa";
						oImpuestos_traslados.TasaOCuota = Convert.ToDecimal("0.000000");
						oImpuestos_traslados.Importe = Convert.ToDecimal("0.00");

						lImpuestos_traslados.Add(oImpuestos_traslados);

						oImpuuestos.TotalImpuestosRetenidos = Convert.ToDecimal(0.00);
						oImpuuestos.TotalImpuestosTrasladadosSpecified = true;
						oImpuuestos.Traslados = lImpuestos_traslados.ToArray();
						oComprobante.Impuestos = oImpuuestos;

						xml(oComprobante, config[0].Ruta_factura + txtFolio.Text + ".xml");

						string CadenaOriginal = "";
						string path_cad = @"XSLT\cadenaoriginal_3_3.xslt";
						System.Xml.Xsl.XslCompiledTransform transformador = new System.Xml.Xsl.XslCompiledTransform(true);
						transformador.Load(path_cad);
						using (StringWriter sw = new StringWriter())
						{
							using (XmlWriter  xwo= XmlWriter.Create(sw,transformador.OutputSettings))
							{
								transformador.Transform(config[0].Ruta_factura + txtFolio.Text + ".xml", xwo);
								CadenaOriginal = sw.ToString();
							}
						}

						SelloDigital sellodigital = new SelloDigital();
						oComprobante.Certificado = sellodigital.Certificado(CertFile);
						oComprobante.Sello = sellodigital.Sellar(CadenaOriginal,KeyFile,KeyPass);
						xml(oComprobante, config[0].Ruta_factura + txtFolio.Text + ".xml");
						timbrar();
					}


				}

			}

		}

		private void xml(Comprobante oComprobante, string path)
		{
			XmlSerializerNamespaces xmlnamespace = new XmlSerializerNamespaces();
			xmlnamespace.Add("cfdi", "http://www.sat.gob.mx/cfd/3");
			xmlnamespace.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
			try
			{
				
				
				XmlSerializer oxmlSerializer = new XmlSerializer(typeof(Comprobante));
				string sXml;
				
				using (var sww= new StringWriterWithEncoding(Encoding.UTF8))
				{
					using (XmlWriter writter = XmlWriter.Create(sww))
					{
						oxmlSerializer.Serialize(writter, oComprobante,xmlnamespace);
						sXml = sww.ToString();

					}
				}
				System.IO.File.WriteAllText(path, sXml);

				//timbrar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private AutoCompleteStringCollection cargadatos2()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Forma_pago pagos = new Models.Forma_pago();
			using (pagos)
			{
				List<Models.Forma_pago> pago = pagos.getFpagos();
				foreach (Models.Forma_pago item in pago)
				{
					datos.Add(item.Descripcion);
					datos.Add(item.Formapago);
				}
			}
			return datos;
		}
		private void Calcula()
		{
			double subtotal = 0;
			double iva = 0;
			double total = 0;
			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				subtotal = subtotal + (Convert.ToDouble(row.Cells["cantidad"].Value) * Convert.ToDouble(row.Cells["pu"].Value));
			}
			iva = subtotal * 0.16;
			total = subtotal * 1.16;

			txtSubtotal.Text = subtotal.ToString();
			txtIVa.Text = iva.ToString();
			txtTotal.Text = total.ToString();
		}
		private AutoCompleteStringCollection cargadatos3()
		{
			AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
			Models.Payment_Form pagos = new Models.Payment_Form();
			using (pagos)
			{
				List<Models.Payment_Form> pago = pagos.get_method();
				foreach (Models.Payment_Form item in pago)
				{
					datos.Add(item.Description);
					datos.Add(item.Method);
				}
			}
			return datos;
		}
		private void Form_factura_Load(object sender, EventArgs e)
		{
			dtFecha.Format = DateTimePickerFormat.Custom;
			dtFecha.CustomFormat = "yyyy-MM-dd";
			cbTipo.Items.Add("Directa");
			cbTipo.Items.Add("Ticket");
			cbTipo.Items.Add("Traspasos");

			Models.Folios folios = new Models.Folios();
			using (folios)
			{
				List<Models.Folios> folio = folios.getFolios();
				txtFolio.Text = folio[0].Facturas.ToString();
			}


			txtUsoCfdi.AutoCompleteCustomSource = cargadatos();
			txtUsoCfdi.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtUsoCfdi.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtFpago.AutoCompleteCustomSource = cargadatos2();
			txtFpago.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtFpago.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtMPago.AutoCompleteCustomSource = cargadatos3();
			txtMPago.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtMPago.AutoCompleteSource = AutoCompleteSource.CustomSource;


			txtCliente.AutoCompleteCustomSource = carga_cliente();
			txtCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;

			txtIdCliente.AutoCompleteCustomSource = carga_cliente2();
			txtIdCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtIdCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
		}

		private void cbTipo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				if (cbTipo.SelectedItem is null)
				{
					cbTipo.SelectedIndex = 0;
				}
				Models.Product productos = new Models.Product();
				switch (cbTipo.SelectedItem.ToString())
				{
					case "Ticket":
						Ticket_a_factura tic_a_fact = new Ticket_a_factura();
						tic_a_fact.Owner = this;
						tic_a_fact.ShowDialog();



						foreach (DataGridViewRow row in dtdocumentos.Rows)
						{
							Models.Dettickets detalles = new Models.Dettickets();
							using (detalles)
							{
								List<Models.Dettickets> detalle = detalles.getDetalles(Convert.ToInt16(row.Cells["folio"].Value.ToString()));
								foreach (Models.Dettickets item in detalle)
								{
									using (productos)
									{
										List<Models.Product> producto = productos.getProductById(item.Id_producto);
										dtProductos.Rows.Add(item.Id_producto, item.Cantidad, producto[0].Code1, producto[0].Description, item.Pu, item.Total);
									}
								}
							}
						}
						Calcula();
						break;
					case "Traspasos":
						Traspasos_a_facturas traspasos = new Traspasos_a_facturas();
						traspasos.Owner = this;
						traspasos.ShowDialog();


						foreach (DataGridViewRow row in dtdocumentos.Rows)
						{
							Models.Det_transfers detalles = new Models.Det_transfers();
							using (detalles)
							{
								List<Models.Det_transfers> detalle = detalles.getDet_trans(Convert.ToInt16(row.Cells["folio"].Value.ToString()));
								foreach (Models.Det_transfers item in detalle)
								{
									using (productos)
									{
										List<Models.Product> producto = productos.getProductById(item.Id_producto);
										dtProductos.Rows.Add(item.Id_producto, item.Cantidad, producto[0].Code1, producto[0].Description, item.Precio, (item.Precio * item.Cantidad));
									}

								}
							}

						}
						Calcula();
						break;
					default:
						txtCliente.Focus();
						break;
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Models.Folios folios = new Models.Folios();
			List<Models.Folios> folio = folios.getFolios();

			Models.Facturas facturas = new Models.Facturas();
			facturas.Folio = Convert.ToInt16(txtFolio.Text);
			facturas.Serie = folio[0].Serie;
			facturas.Cliente = Convert.ToInt16(txtIdCliente.Text);
			facturas.Subtotal = Convert.ToDouble(txtSubtotal.Text);
			facturas.Total = Convert.ToDouble(txtTotal.Text);
			facturas.Pago = txtMPago.Text;
			facturas.create();

			Models.Det_facturas detalle_facturas = new Models.Det_facturas();
			detalle_facturas.Factura = Convert.ToInt16(txtFolio.Text);


			foreach (DataGridViewRow row in dtProductos.Rows)
			{
				detalle_facturas.Id_producto = Convert.ToInt16(row.Cells["id_producto"].Value.ToString());
				detalle_facturas.Cantidad = Convert.ToDouble(row.Cells["cantidad"].Value.ToString());
				detalle_facturas.P_u = Convert.ToDouble(row.Cells["pu"].Value.ToString());
				detalle_facturas.create();
			}

			switch (cbTipo.SelectedItem.ToString())
			{
				case "Ticket":
					Models.Ticket_a_facturas tic_a_fact = new Models.Ticket_a_facturas();

					foreach (DataGridViewRow row in dtdocumentos.Rows)
					{
						tic_a_fact.Factura = Convert.ToInt16(txtFolio.Text);
						tic_a_fact.Ticket = Convert.ToInt16(row.Cells["folio"].Value.ToString());
						tic_a_fact.createrelacion();
					}
					break;
				case "Traspasos":
					Models.Traspasos_a_facturas tras_a_factura = new Models.Traspasos_a_facturas();
					foreach (DataGridViewRow row in dtdocumentos.Rows)
					{
						tras_a_factura.Traspaso = Convert.ToInt16(row.Cells["folio"].Value.ToString());
						tras_a_factura.Factura = Convert.ToInt16(txtFolio.Text);
						tras_a_factura.create_relacion();
					}
					break;
			}
			
			xml2();
		}

		private void txtUsoCfdi_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Uso_Cfdi usos = new Models.Uso_Cfdi();
				using (usos)
				{
					List<Models.Uso_Cfdi> uso = usos.get_Usosbydescripcion(txtUsoCfdi.Text);
					if (uso.Count > 0)
					{
						txtUsoCfdi.Text = uso[0].Clave;
					}
				}


			}
		}

		private void txtFpago_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Forma_pago pagos = new Models.Forma_pago();
				using (pagos)
				{
					List<Models.Forma_pago> pago = pagos.getFpagosbydescripcion(txtFpago.Text);
					if (pago.Count > 0)
					{
						txtFpago.Text = pago[0].Formapago;
					}
				}


			}
		}

		private void txtMPago_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Payment_Form pagos = new Models.Payment_Form();
				using (pagos)
				{
					List<Models.Payment_Form> pago = pagos.get_methodbyDescription(txtMPago.Text);
					if (pago.Count > 0)
					{
						txtMPago.Text = pago[0].Method;
					}
				}


			}
		}

		private void txtIdCliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtIdCliente.Text != "")
				{
					Models.Client clientes = new Models.Client();
					using (clientes)
					{
						List<Models.Client> cliente = clientes.getClientbyId(Convert.ToInt32(txtIdCliente.Text));
						if (cliente.Count > 0)
						{
							txtIdCliente.Text = cliente[0].Id.ToString();
							txtCliente.Text = cliente[0].Name;
						}
					}
				}
			}
		}

		private void txtCliente_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Models.Client clientes = new Models.Client();
				using (clientes)
				{
					List<Models.Client> client = clientes.getClientbyId(Convert.ToInt16(txtIdCliente.Text));
					if (client.Count > 0)
					{
						txtCliente.Text = client[0].Name;

					}
				}
			}
		}

		
	}
}
