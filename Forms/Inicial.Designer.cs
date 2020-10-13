namespace Cremeria
{
	partial class Inicial
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicial));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.facturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.catalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sucursalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listasDePreciosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.movimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.almacenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.entradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.salidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ajustesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.traspasosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enviosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.levantarInventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.proveedoresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.devolucionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ordenDeCompraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.liberarDocuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ImportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ventasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.cXPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cXCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listasDePreciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.alertaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.Bienvenido = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.modificacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem,
            this.catalogoToolStripMenuItem,
            this.movimientosToolStripMenuItem,
            this.ImportarToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.configuracionToolStripMenuItem,
            this.salirToolStripMenuItem,
            this.alertaToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(746, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "MenuStrip";
			// 
			// ventasToolStripMenuItem
			// 
			this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturasToolStripMenuItem,
            this.cajaToolStripMenuItem});
			this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
			this.ventasToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.ventasToolStripMenuItem.Text = "Ventas";
			// 
			// facturasToolStripMenuItem
			// 
			this.facturasToolStripMenuItem.Name = "facturasToolStripMenuItem";
			this.facturasToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.facturasToolStripMenuItem.Text = "Facturas";
			this.facturasToolStripMenuItem.Click += new System.EventHandler(this.facturasToolStripMenuItem_Click);
			// 
			// cajaToolStripMenuItem
			// 
			this.cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
			this.cajaToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.cajaToolStripMenuItem.Text = "Caja";
			this.cajaToolStripMenuItem.Click += new System.EventHandler(this.cajaToolStripMenuItem_Click);
			// 
			// catalogoToolStripMenuItem
			// 
			this.catalogoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.sucursalesToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.listasDePreciosToolStripMenuItem1});
			this.catalogoToolStripMenuItem.Name = "catalogoToolStripMenuItem";
			this.catalogoToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.catalogoToolStripMenuItem.Text = "Catalogo";
			// 
			// clientesToolStripMenuItem
			// 
			this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
			this.clientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.clientesToolStripMenuItem.Text = "Clientes";
			this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
			// 
			// proveedoresToolStripMenuItem
			// 
			this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
			this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.proveedoresToolStripMenuItem.Text = "Proveedores";
			this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
			// 
			// sucursalesToolStripMenuItem
			// 
			this.sucursalesToolStripMenuItem.Name = "sucursalesToolStripMenuItem";
			this.sucursalesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.sucursalesToolStripMenuItem.Text = "Sucursales";
			this.sucursalesToolStripMenuItem.Click += new System.EventHandler(this.sucursalesToolStripMenuItem_Click);
			// 
			// productosToolStripMenuItem
			// 
			this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
			this.productosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.productosToolStripMenuItem.Text = "Productos";
			this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
			// 
			// usuariosToolStripMenuItem
			// 
			this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
			this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.usuariosToolStripMenuItem.Text = "Usuarios";
			this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
			// 
			// listasDePreciosToolStripMenuItem1
			// 
			this.listasDePreciosToolStripMenuItem1.Name = "listasDePreciosToolStripMenuItem1";
			this.listasDePreciosToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
			this.listasDePreciosToolStripMenuItem1.Text = "Listas de precios";
			this.listasDePreciosToolStripMenuItem1.Click += new System.EventHandler(this.listasDePreciosToolStripMenuItem1_Click);
			// 
			// movimientosToolStripMenuItem
			// 
			this.movimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.almacenToolStripMenuItem,
            this.proveedoresToolStripMenuItem1,
            this.liberarDocuToolStripMenuItem});
			this.movimientosToolStripMenuItem.Name = "movimientosToolStripMenuItem";
			this.movimientosToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
			this.movimientosToolStripMenuItem.Text = "Movimientos";
			// 
			// almacenToolStripMenuItem
			// 
			this.almacenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entradasToolStripMenuItem,
            this.salidasToolStripMenuItem,
            this.ajustesToolStripMenuItem,
            this.traspasosToolStripMenuItem,
            this.levantarInventarioToolStripMenuItem,
            this.modificacionesToolStripMenuItem});
			this.almacenToolStripMenuItem.Name = "almacenToolStripMenuItem";
			this.almacenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.almacenToolStripMenuItem.Text = "Almacen";
			// 
			// entradasToolStripMenuItem
			// 
			this.entradasToolStripMenuItem.Name = "entradasToolStripMenuItem";
			this.entradasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.entradasToolStripMenuItem.Text = "Entradas";
			this.entradasToolStripMenuItem.Click += new System.EventHandler(this.entradasToolStripMenuItem_Click);
			// 
			// salidasToolStripMenuItem
			// 
			this.salidasToolStripMenuItem.Name = "salidasToolStripMenuItem";
			this.salidasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.salidasToolStripMenuItem.Text = "Salidas";
			this.salidasToolStripMenuItem.Click += new System.EventHandler(this.salidasToolStripMenuItem_Click);
			// 
			// ajustesToolStripMenuItem
			// 
			this.ajustesToolStripMenuItem.Name = "ajustesToolStripMenuItem";
			this.ajustesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.ajustesToolStripMenuItem.Text = "Ajustes";
			this.ajustesToolStripMenuItem.Click += new System.EventHandler(this.ajustesToolStripMenuItem_Click);
			// 
			// traspasosToolStripMenuItem
			// 
			this.traspasosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviosToolStripMenuItem});
			this.traspasosToolStripMenuItem.Name = "traspasosToolStripMenuItem";
			this.traspasosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.traspasosToolStripMenuItem.Text = "Traspasos";
			// 
			// enviosToolStripMenuItem
			// 
			this.enviosToolStripMenuItem.Name = "enviosToolStripMenuItem";
			this.enviosToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.enviosToolStripMenuItem.Text = "Envios";
			this.enviosToolStripMenuItem.Click += new System.EventHandler(this.enviosToolStripMenuItem_Click);
			// 
			// levantarInventarioToolStripMenuItem
			// 
			this.levantarInventarioToolStripMenuItem.Name = "levantarInventarioToolStripMenuItem";
			this.levantarInventarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.levantarInventarioToolStripMenuItem.Text = "Levantar inventario";
			this.levantarInventarioToolStripMenuItem.Click += new System.EventHandler(this.levantarInventarioToolStripMenuItem_Click);
			// 
			// proveedoresToolStripMenuItem1
			// 
			this.proveedoresToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprasToolStripMenuItem,
            this.pagosToolStripMenuItem,
            this.devolucionesToolStripMenuItem,
            this.ordenDeCompraToolStripMenuItem});
			this.proveedoresToolStripMenuItem1.Name = "proveedoresToolStripMenuItem1";
			this.proveedoresToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
			this.proveedoresToolStripMenuItem1.Text = "Proveedores";
			// 
			// comprasToolStripMenuItem
			// 
			this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
			this.comprasToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.comprasToolStripMenuItem.Text = "Compras";
			this.comprasToolStripMenuItem.Click += new System.EventHandler(this.comprasToolStripMenuItem_Click);
			// 
			// pagosToolStripMenuItem
			// 
			this.pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
			this.pagosToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.pagosToolStripMenuItem.Text = "Pagos";
			this.pagosToolStripMenuItem.Click += new System.EventHandler(this.pagosToolStripMenuItem_Click);
			// 
			// devolucionesToolStripMenuItem
			// 
			this.devolucionesToolStripMenuItem.Name = "devolucionesToolStripMenuItem";
			this.devolucionesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.devolucionesToolStripMenuItem.Text = "Devoluciones";
			this.devolucionesToolStripMenuItem.Click += new System.EventHandler(this.devolucionesToolStripMenuItem_Click);
			// 
			// ordenDeCompraToolStripMenuItem
			// 
			this.ordenDeCompraToolStripMenuItem.Name = "ordenDeCompraToolStripMenuItem";
			this.ordenDeCompraToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.ordenDeCompraToolStripMenuItem.Text = "Orden de compra";
			this.ordenDeCompraToolStripMenuItem.Click += new System.EventHandler(this.ordenDeCompraToolStripMenuItem_Click);
			// 
			// liberarDocuToolStripMenuItem
			// 
			this.liberarDocuToolStripMenuItem.Enabled = false;
			this.liberarDocuToolStripMenuItem.Name = "liberarDocuToolStripMenuItem";
			this.liberarDocuToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.liberarDocuToolStripMenuItem.Text = "Liberar documento";
			// 
			// ImportarToolStripMenuItem
			// 
			this.ImportarToolStripMenuItem.Name = "ImportarToolStripMenuItem";
			this.ImportarToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.ImportarToolStripMenuItem.Text = "Importar";
			this.ImportarToolStripMenuItem.Click += new System.EventHandler(this.ImportarToolStripMenuItem_Click);
			// 
			// reportesToolStripMenuItem
			// 
			this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem1,
            this.cXPToolStripMenuItem,
            this.inventarioToolStripMenuItem,
            this.cXCToolStripMenuItem,
            this.listasDePreciosToolStripMenuItem});
			this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
			this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.reportesToolStripMenuItem.Text = "Reportes";
			// 
			// ventasToolStripMenuItem1
			// 
			this.ventasToolStripMenuItem1.Name = "ventasToolStripMenuItem1";
			this.ventasToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
			this.ventasToolStripMenuItem1.Text = "Ventas";
			this.ventasToolStripMenuItem1.Click += new System.EventHandler(this.ventasToolStripMenuItem1_Click);
			// 
			// cXPToolStripMenuItem
			// 
			this.cXPToolStripMenuItem.Name = "cXPToolStripMenuItem";
			this.cXPToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.cXPToolStripMenuItem.Text = "CXP";
			// 
			// inventarioToolStripMenuItem
			// 
			this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
			this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.inventarioToolStripMenuItem.Text = "Inventario";
			this.inventarioToolStripMenuItem.Click += new System.EventHandler(this.inventarioToolStripMenuItem_Click);
			// 
			// cXCToolStripMenuItem
			// 
			this.cXCToolStripMenuItem.Name = "cXCToolStripMenuItem";
			this.cXCToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.cXCToolStripMenuItem.Text = "CXC";
			// 
			// listasDePreciosToolStripMenuItem
			// 
			this.listasDePreciosToolStripMenuItem.Name = "listasDePreciosToolStripMenuItem";
			this.listasDePreciosToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.listasDePreciosToolStripMenuItem.Text = "Listas de precios";
			this.listasDePreciosToolStripMenuItem.Click += new System.EventHandler(this.listasDePreciosToolStripMenuItem_Click);
			// 
			// configuracionToolStripMenuItem
			// 
			this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
			this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
			this.configuracionToolStripMenuItem.Text = "Configuracion";
			this.configuracionToolStripMenuItem.Click += new System.EventHandler(this.configuracionToolStripMenuItem_Click);
			// 
			// salirToolStripMenuItem
			// 
			this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
			this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.salirToolStripMenuItem.Text = "Salir";
			this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
			// 
			// alertaToolStripMenuItem
			// 
			this.alertaToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.alertaToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.alertaToolStripMenuItem.Image = global::Cremeria.Properties.Resources.campana;
			this.alertaToolStripMenuItem.Name = "alertaToolStripMenuItem";
			this.alertaToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
			this.alertaToolStripMenuItem.Text = "alerta";
			this.alertaToolStripMenuItem.Click += new System.EventHandler(this.alertaToolStripMenuItem_Click);
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8});
			this.toolStrip.Location = new System.Drawing.Point(0, 24);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(746, 25);
			this.toolStrip.TabIndex = 1;
			this.toolStrip.Text = "ToolStrip";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = global::Cremeria.Properties.Resources.cart;
			this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(61, 22);
			this.toolStripButton1.Text = "Ventas";
			this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.Image = global::Cremeria.Properties.Resources.basket_error;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(98, 22);
			this.toolStripButton2.Text = "Devoluciones";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.Image = global::Cremeria.Properties.Resources.group;
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(69, 22);
			this.toolStripButton3.Text = "Clientes";
			this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.Image = global::Cremeria.Properties.Resources.application_form;
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(80, 22);
			this.toolStripButton4.Text = "Inventario";
			this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.Image = global::Cremeria.Properties.Resources.box;
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(75, 22);
			this.toolStripButton5.Text = "Compras";
			this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
			// 
			// toolStripButton6
			// 
			this.toolStripButton6.Image = global::Cremeria.Properties.Resources.money_dollar;
			this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(98, 22);
			this.toolStripButton6.Text = "Corte de Caja";
			this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
			// 
			// toolStripButton7
			// 
			this.toolStripButton7.Image = global::Cremeria.Properties.Resources.calculator;
			this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton7.Name = "toolStripButton7";
			this.toolStripButton7.Size = new System.Drawing.Size(90, 22);
			this.toolStripButton7.Text = "Calculadora";
			this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
			// 
			// toolStripButton8
			// 
			this.toolStripButton8.Image = global::Cremeria.Properties.Resources.door_in;
			this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton8.Name = "toolStripButton8";
			this.toolStripButton8.Size = new System.Drawing.Size(49, 22);
			this.toolStripButton8.Text = "Salir";
			this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Bienvenido,
            this.toolStripProgressBar1});
			this.statusStrip.Location = new System.Drawing.Point(0, 431);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(746, 22);
			this.statusStrip.TabIndex = 2;
			this.statusStrip.Text = "StatusStrip";
			// 
			// Bienvenido
			// 
			this.Bienvenido.Name = "Bienvenido";
			this.Bienvenido.Size = new System.Drawing.Size(42, 17);
			this.Bienvenido.Text = "Estado";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			this.toolStripProgressBar1.Visible = false;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			// 
			// timer1
			// 
			this.timer1.Interval = 59000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// modificacionesToolStripMenuItem
			// 
			this.modificacionesToolStripMenuItem.Name = "modificacionesToolStripMenuItem";
			this.modificacionesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.modificacionesToolStripMenuItem.Text = "Modificaciones";
			this.modificacionesToolStripMenuItem.Click += new System.EventHandler(this.modificacionesToolStripMenuItem_Click);
			// 
			// Inicial
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(746, 453);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "Inicial";
			this.Text = "Cremeria Martinez";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inicial_FormClosing);
			this.Load += new System.EventHandler(this.Inicial_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion


		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel Bienvenido;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem facturasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cajaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem catalogoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sucursalesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem movimientosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem almacenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem entradasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem salidasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ajustesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem traspasosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem enviosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pagosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem liberarDocuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ImportarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem cXPToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cXCToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ToolStripButton toolStripButton5;
		private System.Windows.Forms.ToolStripButton toolStripButton6;
		private System.Windows.Forms.ToolStripButton toolStripButton7;
		private System.Windows.Forms.ToolStripButton toolStripButton8;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripMenuItem levantarInventarioToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ToolStripMenuItem listasDePreciosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem devolucionesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ordenDeCompraToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listasDePreciosToolStripMenuItem1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ToolStripMenuItem alertaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem modificacionesToolStripMenuItem;
	}
}



