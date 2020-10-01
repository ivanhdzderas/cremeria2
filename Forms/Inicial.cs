using Cremeria.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Cremeria
{
	public partial class Inicial : Form
	{
		private int childFormNumber = 0;

	
		public static Boolean exit;
		public static Boolean cajero;
		public static string nombre;
		public static string id_usario;
		public static string tipo_usuario;
		public static Boolean cancelado = false;

		private void nueva_tarea()
		{
			Models.Reports.nuevo_db nuevo = new Models.Reports.nuevo_db();
			using (nuevo)
			{
				//nuevo.ejecuta("ALTER TABLE `tbaproductos` ADD `grupal` TINYINT(1) NOT NULL DEFAULT '0' AFTER `proveedor`;");
			}
		}
		public void busca_minimo()
		{
			Models.Product produtos = new Models.Product();
			using (produtos)
			{
				List<Models.Product> producto = produtos.getMinProduct();
				if (producto.Count > 0)
				{
					noticacion("Produtos en el minimo", "Minimos");
				}
			}
		}
		public void busca_pagos()
		{
			Models.Compras compras = new Models.Compras();
			using (compras)
			{
				List<Models.Compras> compra = compras.getCompras_sin_pagar();
				if (compra.Count > 0)
				{
					noticacion("Proximos pagos a proveedores", "Tiene pagos por caducar");
				}
			}



		}
		public void busca_caducos()
		{

			Models.Product producto = new Models.Product();
			using (producto)
			{
				List<Models.Product> cad = producto.getCaducProducts();
				if (cad.Count > 0)
				{
					noticacion("Proximos productos caducos", "Tiene produtos por caducar");
				}
			}




		}
		public void noticacion(string Titulo, string texto)
		{
			notifyIcon1.Text = "Notificaciones";
			notifyIcon1.BalloonTipTitle = Titulo;
			notifyIcon1.BalloonTipText = texto;
			notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
			notifyIcon1.Visible = true;
			notifyIcon1.ShowBalloonTip(3000);
		}
		public Inicial()
		{
			InitializeComponent();
		}


		private void Inicial_Load(object sender, EventArgs e)
		{
			timer1.Start();
			
			
			

			if (System.IO.File.Exists(@"nueva.txt"))
			{
				nueva_tarea();
				System.IO.File.Delete(@"nueva.txt");
			}

			Forms.Login login = new Forms.Login();
			login.ShowDialog();
			if (exit == true)
			{
				Application.Exit();
			}
			else
			{
				Models.Cortes cort = new Models.Cortes();
				using (cort)
				{
					List<Models.Cortes> existe = cort.getnoclose(Convert.ToInt16(id_usario));

					if (cajero == true)
					{
						if (existe.Count > 0)
						{

						}
						else
						{
							Forms.AbreCaja caja = new Forms.AbreCaja();
							caja.Owner = this;
							caja.ShowDialog();
						}

					}
				}

				Models.Permisos permiso = new Models.Permisos();
				using (permiso)
				{
					List<Models.Permisos> permisos = permiso.getPermiso(Convert.ToInt16(id_usario));




					Bienvenido.Text = "Bienvenido: " + nombre;
				}
				busca_caducos();
				busca_pagos();
				busca_minimo();
			}

			
		}

		private void salirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
				if (cajero == true)
				{
					Forms.CerrarCaja cerr = new Forms.CerrarCaja();
					cerr.Owner = this;
					cerr.ShowDialog();
					if (exit == true)
					{
						this.Close();
					}

				}
				if (cancelado == false)
				{
					this.Close();
				}
			
		}

		private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Caja caja_form = new Forms.Caja();
			caja_form.MdiParent = this;
			caja_form.Dock = DockStyle.Fill;
			caja_form.Show();
		}

		private void enviosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Traspasos_e transfer_e = new Forms.Traspasos_e();
			transfer_e.MdiParent = this;
			transfer_e.Dock = DockStyle.Fill;
			transfer_e.Show();
		}

		private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Clientes clientes = new Forms.Clientes();
			clientes.MdiParent = this;
			clientes.Dock = DockStyle.Fill;
			clientes.Show();
		}

		private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Proveedores proveedores = new Forms.Proveedores();
			proveedores.MdiParent = this;
			proveedores.Dock = DockStyle.Fill;
			proveedores.Show();
		}

		private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Sucursales sucursales = new Forms.Sucursales();
			sucursales.MdiParent = this;
			sucursales.Dock = DockStyle.Fill;
			sucursales.Show();
		}

		private void productosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Productos productos = new Forms.Productos();
			productos.MdiParent = this;
			productos.Dock = DockStyle.Fill;
			productos.Show();
		}

		private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Usuarios usuarios = new Forms.Usuarios();
			usuarios.MdiParent = this;
			usuarios.Dock = DockStyle.Fill;
			usuarios.Show();
		}

		private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Inventario.Entradas entradas = new Forms.Inventario.Entradas();
			entradas.MdiParent = this;
			entradas.Dock = DockStyle.Fill;
			entradas.Show();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			Forms.Caja caja_form = new Forms.Caja();
			caja_form.MdiParent = this;
			caja_form.Dock = DockStyle.Fill;
			caja_form.Show();
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			Forms.Clientes clientes = new Forms.Clientes();
			clientes.MdiParent = this;
			clientes.Dock = DockStyle.Fill;
			clientes.Show();
		}

		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			Forms.Productos productos = new Forms.Productos();
			productos.MdiParent = this;
			productos.Dock = DockStyle.Fill;
			productos.Show();
		}

		private void toolStripButton7_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process calc = new System.Diagnostics.Process { StartInfo = { FileName = @"calc.exe" } };
			calc.Start();
			calc.WaitForExit();
		}

		private void toolStripButton8_Click(object sender, EventArgs e)
		{
			

				if (cajero == true)
				{
					Forms.CerrarCaja cerr = new Forms.CerrarCaja();
					cerr.Owner = this;
					cerr.ShowDialog();
					if (exit == true)
					{
						this.Close();
					}

				}
				if (cancelado == false)
				{
					this.Close();
				}
			
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			Forms.Devoluciones devoluciones = new Forms.Devoluciones();
			devoluciones.MdiParent = this;
			devoluciones.Dock = DockStyle.Fill;
			devoluciones.Show();
		}

		private void toolStripButton5_Click(object sender, EventArgs e)
		{
			Forms.Compras compras = new Forms.Compras();
			compras.MdiParent = this;
			compras.Dock = DockStyle.Fill;
			compras.Show();
		}

		private void salidasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Salidas salidas = new Forms.Salidas();
			salidas.MdiParent = this;
			salidas.Dock = DockStyle.Fill;
			salidas.Show();
		}

		private void ajustesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Ajustes ajustes = new Forms.Ajustes();
			ajustes.MdiParent = this;
			ajustes.Dock = DockStyle.Fill;
			ajustes.Show();
		}

		private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Compras compras = new Forms.Compras();
			compras.MdiParent = this;
			compras.Dock = DockStyle.Fill;
			compras.Show();
		}

		private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Pagos_proveedores pagos = new Forms.Pagos_proveedores();
			pagos.MdiParent = this;
			pagos.Dock = DockStyle.Fill;
			pagos.Show();
		}

		

		private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Forms.Reportes.Reporte_ventas venta = new Forms.Reportes.Reporte_ventas();
			venta.MdiParent = this;
			venta.Show();
		}

		private void toolStripButton6_Click(object sender, EventArgs e)
		{
			switch (tipo_usuario)
			{
				case "Admin":
					Forms.Reportes.ventas pagos = new Forms.Reportes.ventas();
					pagos.MdiParent = this;
					pagos.Dock = DockStyle.Fill;
					pagos.Show();
					break;
				case "Conta":
					Forms.Reportes.ventas_detallado pagos2 = new Forms.Reportes.ventas_detallado();
					pagos2.MdiParent = this;
					pagos2.Dock = DockStyle.Fill;
					pagos2.Show();
					break;
			}
			
		}

		private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Configuracion configura = new Forms.Configuracion();
			configura.MdiParent = this;
			configura.Show();
		}

		private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Reportes.Inventario report = new Forms.Reportes.Inventario();
			report.MdiParent = this;
			report.Dock = DockStyle.Fill;
			report.Show();
		}

		private void levantarInventarioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Levantar_inventario levantar = new Forms.Levantar_inventario();
			levantar.MdiParent = this;
			levantar.Dock = DockStyle.Fill;
			levantar.Show();

		}

		private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Facturas facturas = new Forms.Facturas();
			facturas.MdiParent = this;
			facturas.Dock = DockStyle.Fill;
			facturas.Show();
		}

		private void Inicial_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (exit == false)
			{
				DialogResult dialogo = MessageBox.Show("¿Desea cerrar el programa?",
			   "Cerrar el programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogo == DialogResult.No)
				{
					e.Cancel = true;
				}
				else
				{
					e.Cancel = false;
				}
			}
			
		}

		private void listasDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Forms.Listas listas = new Forms.Listas();
			listas.MdiParent = this;
			listas.Show();
		}

		private void devolucionesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Dev_pro devo = new Dev_pro();
			devo.MdiParent = this;
			devo.Show();
		}

		private void ImportarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Importar impo = new Importar();
			impo.MdiParent = this;
			impo.Show();
		}

		private void ordenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Ordenes ordenes = new Ordenes();
			ordenes.MdiParent = this;
			ordenes.Show();
		}

		private void listasDePreciosToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Listas_precios listas = new Listas_precios();
			listas.MdiParent = this;
			listas.Show();

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Models.Reports.nuevo_db nuevo = new Models.Reports.nuevo_db();
			using (nuevo)
			{
				nuevo.ejecuta("select now();");
			}
		}

		private void alertaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Alertas alertas = new Alertas();
			alertas.MdiParent = this;
			alertas.Show();
		}
	}
}
