namespace Cremeria.Forms
{
	partial class Caja
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.dtProductos = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.p_u = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descuento_i = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.total_i = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.grabado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.recupera = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.dtFecha = new System.Windows.Forms.DateTimePicker();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.txtCantidad = new System.Windows.Forms.TextBox();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.txtUnitario = new System.Windows.Forms.TextBox();
			this.txtImporte = new System.Windows.Forms.TextBox();
			this.txtFolio = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtDescuento = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtRFC = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.txtIdcliente = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtArticulos = new System.Windows.Forms.TextBox();
			this.listGuardados = new System.Windows.Forms.ListBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.txtVendedor = new System.Windows.Forms.TextBox();
			this.lbAtiende = new System.Windows.Forms.Label();
			this.btnCobrar = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.btnLimpiar = new System.Windows.Forms.Button();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.txtSubtotal = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.btnReprint = new System.Windows.Forms.Button();
			this.btnClientes = new System.Windows.Forms.Button();
			this.btnRetiro = new System.Windows.Forms.Button();
			this.btnTransfer = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btnPrimero = new System.Windows.Forms.Button();
			this.btnAtras = new System.Windows.Forms.Button();
			this.btnAdelante = new System.Windows.Forms.Button();
			this.btnUltimo = new System.Windows.Forms.Button();
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.printDocument2 = new System.Drawing.Printing.PrintDocument();
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// dtProductos
			// 
			this.dtProductos.AllowUserToAddRows = false;
			this.dtProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cantidad,
            this.codigo,
            this.descripcion,
            this.p_u,
            this.descuento_i,
            this.total_i,
            this.grabado,
            this.costo,
            this.recupera});
			this.dtProductos.Location = new System.Drawing.Point(13, 245);
			this.dtProductos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dtProductos.Name = "dtProductos";
			this.dtProductos.Size = new System.Drawing.Size(822, 132);
			this.dtProductos.TabIndex = 0;
			this.dtProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProductos_CellContentClick);
			this.dtProductos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProductos_CellContentDoubleClick);
			this.dtProductos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProductos_CellEndEdit);
			this.dtProductos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtProductos_RowsRemoved);
			this.dtProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtProductos_KeyDown);
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.Visible = false;
			// 
			// cantidad
			// 
			this.cantidad.HeaderText = "Cantidad";
			this.cantidad.Name = "cantidad";
			// 
			// codigo
			// 
			this.codigo.HeaderText = "Codigo";
			this.codigo.Name = "codigo";
			// 
			// descripcion
			// 
			this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.descripcion.HeaderText = "Descripcion";
			this.descripcion.Name = "descripcion";
			// 
			// p_u
			// 
			this.p_u.HeaderText = "Precio U.";
			this.p_u.Name = "p_u";
			// 
			// descuento_i
			// 
			this.descuento_i.HeaderText = "Descuento";
			this.descuento_i.Name = "descuento_i";
			// 
			// total_i
			// 
			this.total_i.HeaderText = "Total";
			this.total_i.Name = "total_i";
			// 
			// grabado
			// 
			this.grabado.HeaderText = "grabado";
			this.grabado.Name = "grabado";
			this.grabado.Visible = false;
			// 
			// costo
			// 
			this.costo.HeaderText = "costo";
			this.costo.Name = "costo";
			this.costo.Visible = false;
			// 
			// recupera
			// 
			this.recupera.HeaderText = "recupera";
			this.recupera.Name = "recupera";
			this.recupera.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 188);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Codigo";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(187, 188);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Cantidad";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(266, 188);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 20);
			this.label3.TabIndex = 3;
			this.label3.Text = "Producto";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(663, 188);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 20);
			this.label4.TabIndex = 4;
			this.label4.Text = "Unitario";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(771, 188);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 20);
			this.label5.TabIndex = 5;
			this.label5.Text = "Importe";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(607, 17);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(54, 20);
			this.label6.TabIndex = 6;
			this.label6.Text = "Fecha";
			// 
			// dtFecha
			// 
			this.dtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtFecha.Enabled = false;
			this.dtFecha.Location = new System.Drawing.Point(667, 12);
			this.dtFecha.Name = "dtFecha";
			this.dtFecha.Size = new System.Drawing.Size(168, 26);
			this.dtFecha.TabIndex = 7;
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(13, 211);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(145, 26);
			this.txtCodigo.TabIndex = 8;
			this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
			// 
			// txtCantidad
			// 
			this.txtCantidad.Location = new System.Drawing.Point(164, 211);
			this.txtCantidad.Name = "txtCantidad";
			this.txtCantidad.Size = new System.Drawing.Size(100, 26);
			this.txtCantidad.TabIndex = 9;
			this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
			this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
			this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
			this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescripcion.Enabled = false;
			this.txtDescripcion.Location = new System.Drawing.Point(270, 211);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(353, 26);
			this.txtDescripcion.TabIndex = 10;
			// 
			// txtUnitario
			// 
			this.txtUnitario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUnitario.Location = new System.Drawing.Point(629, 211);
			this.txtUnitario.Name = "txtUnitario";
			this.txtUnitario.Size = new System.Drawing.Size(100, 26);
			this.txtUnitario.TabIndex = 11;
			// 
			// txtImporte
			// 
			this.txtImporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImporte.Enabled = false;
			this.txtImporte.Location = new System.Drawing.Point(735, 211);
			this.txtImporte.Name = "txtImporte";
			this.txtImporte.Size = new System.Drawing.Size(100, 26);
			this.txtImporte.TabIndex = 12;
			// 
			// txtFolio
			// 
			this.txtFolio.Location = new System.Drawing.Point(119, 452);
			this.txtFolio.Name = "txtFolio";
			this.txtFolio.Size = new System.Drawing.Size(97, 26);
			this.txtFolio.TabIndex = 13;
			this.txtFolio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFolio_KeyDown);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 455);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(43, 20);
			this.label7.TabIndex = 14;
			this.label7.Text = "Folio";
			// 
			// txtDescuento
			// 
			this.txtDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescuento.Location = new System.Drawing.Point(735, 417);
			this.txtDescuento.Name = "txtDescuento";
			this.txtDescuento.Size = new System.Drawing.Size(100, 26);
			this.txtDescuento.TabIndex = 16;
			this.txtDescuento.Text = "0";
			this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDescuento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescuento_KeyDown);
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(642, 420);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(87, 20);
			this.label8.TabIndex = 18;
			this.label8.Text = "Descuento";
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(602, 452);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 31);
			this.label9.TabIndex = 19;
			this.label9.Text = "Total";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtRFC);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.txtCliente);
			this.groupBox1.Controls.Add(this.txtIdcliente);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Location = new System.Drawing.Point(13, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(425, 142);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cliente";
			// 
			// txtRFC
			// 
			this.txtRFC.Enabled = false;
			this.txtRFC.Location = new System.Drawing.Point(98, 84);
			this.txtRFC.Name = "txtRFC";
			this.txtRFC.Size = new System.Drawing.Size(171, 26);
			this.txtRFC.TabIndex = 5;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(50, 87);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(42, 20);
			this.label14.TabIndex = 4;
			this.label14.Text = "RFC";
			// 
			// txtCliente
			// 
			this.txtCliente.Location = new System.Drawing.Point(98, 52);
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.Size = new System.Drawing.Size(321, 26);
			this.txtCliente.TabIndex = 3;
			this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
			// 
			// txtIdcliente
			// 
			this.txtIdcliente.Location = new System.Drawing.Point(98, 19);
			this.txtIdcliente.Name = "txtIdcliente";
			this.txtIdcliente.Size = new System.Drawing.Size(100, 26);
			this.txtIdcliente.TabIndex = 2;
			this.txtIdcliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdcliente_KeyDown);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(27, 55);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(65, 20);
			this.label11.TabIndex = 1;
			this.label11.Text = "Nombre";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 22);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(86, 20);
			this.label10.TabIndex = 0;
			this.label10.Text = "No. Cliente";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(12, 385);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(70, 20);
			this.label12.TabIndex = 21;
			this.label12.Text = "Articulos";
			// 
			// txtArticulos
			// 
			this.txtArticulos.Enabled = false;
			this.txtArticulos.Location = new System.Drawing.Point(88, 382);
			this.txtArticulos.Name = "txtArticulos";
			this.txtArticulos.Size = new System.Drawing.Size(100, 26);
			this.txtArticulos.TabIndex = 22;
			// 
			// listGuardados
			// 
			this.listGuardados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.listGuardados.FormattingEnabled = true;
			this.listGuardados.ItemHeight = 20;
			this.listGuardados.Location = new System.Drawing.Point(611, 67);
			this.listGuardados.Name = "listGuardados";
			this.listGuardados.Size = new System.Drawing.Size(225, 104);
			this.listGuardados.TabIndex = 23;
			this.listGuardados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listGuardados_MouseDoubleClick);
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(607, 43);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(143, 20);
			this.label13.TabIndex = 24;
			this.label13.Text = "Tickets Guardados";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(15, 420);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(79, 20);
			this.label15.TabIndex = 25;
			this.label15.Text = "Vendedor";
			// 
			// txtVendedor
			// 
			this.txtVendedor.Location = new System.Drawing.Point(103, 417);
			this.txtVendedor.Name = "txtVendedor";
			this.txtVendedor.Size = new System.Drawing.Size(53, 26);
			this.txtVendedor.TabIndex = 26;
			this.txtVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVendedor_KeyDown);
			// 
			// lbAtiende
			// 
			this.lbAtiende.AutoSize = true;
			this.lbAtiende.Location = new System.Drawing.Point(162, 420);
			this.lbAtiende.Name = "lbAtiende";
			this.lbAtiende.Size = new System.Drawing.Size(60, 20);
			this.lbAtiende.TabIndex = 27;
			this.lbAtiende.Text = "label16";
			// 
			// btnCobrar
			// 
			this.btnCobrar.Image = global::Cremeria.Properties.Resources.save;
			this.btnCobrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnCobrar.Location = new System.Drawing.Point(12, 498);
			this.btnCobrar.Name = "btnCobrar";
			this.btnCobrar.Size = new System.Drawing.Size(80, 68);
			this.btnCobrar.TabIndex = 28;
			this.btnCobrar.Text = "Cobrar";
			this.btnCobrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCobrar.UseVisualStyleBackColor = true;
			this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// btnLimpiar
			// 
			this.btnLimpiar.Image = global::Cremeria.Properties.Resources.limpieza;
			this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnLimpiar.Location = new System.Drawing.Point(98, 498);
			this.btnLimpiar.Name = "btnLimpiar";
			this.btnLimpiar.Size = new System.Drawing.Size(80, 68);
			this.btnLimpiar.TabIndex = 29;
			this.btnLimpiar.Text = "Limpiar";
			this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnLimpiar.UseVisualStyleBackColor = true;
			this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// txtSubtotal
			// 
			this.txtSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSubtotal.Enabled = false;
			this.txtSubtotal.Location = new System.Drawing.Point(735, 385);
			this.txtSubtotal.Name = "txtSubtotal";
			this.txtSubtotal.Size = new System.Drawing.Size(100, 26);
			this.txtSubtotal.TabIndex = 30;
			this.txtSubtotal.Text = "0";
			this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label16
			// 
			this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(660, 388);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(69, 20);
			this.label16.TabIndex = 31;
			this.label16.Text = "Subtotal";
			// 
			// btnGuardar
			// 
			this.btnGuardar.Image = global::Cremeria.Properties.Resources.disk;
			this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnGuardar.Location = new System.Drawing.Point(184, 498);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(80, 68);
			this.btnGuardar.TabIndex = 32;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// btnBuscar
			// 
			this.btnBuscar.Image = global::Cremeria.Properties.Resources.find;
			this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnBuscar.Location = new System.Drawing.Point(270, 498);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(80, 68);
			this.btnBuscar.TabIndex = 33;
			this.btnBuscar.Text = "Buscar";
			this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// btnReprint
			// 
			this.btnReprint.Image = global::Cremeria.Properties.Resources.ink;
			this.btnReprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnReprint.Location = new System.Drawing.Point(356, 498);
			this.btnReprint.Name = "btnReprint";
			this.btnReprint.Size = new System.Drawing.Size(80, 68);
			this.btnReprint.TabIndex = 34;
			this.btnReprint.Text = "Re imprimir";
			this.btnReprint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnReprint.UseVisualStyleBackColor = true;
			this.btnReprint.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnClientes
			// 
			this.btnClientes.Image = global::Cremeria.Properties.Resources.user;
			this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnClientes.Location = new System.Drawing.Point(442, 498);
			this.btnClientes.Name = "btnClientes";
			this.btnClientes.Size = new System.Drawing.Size(80, 68);
			this.btnClientes.TabIndex = 35;
			this.btnClientes.Text = "Clientes";
			this.btnClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnClientes.UseVisualStyleBackColor = true;
			this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
			// 
			// btnRetiro
			// 
			this.btnRetiro.Image = global::Cremeria.Properties.Resources.coins;
			this.btnRetiro.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnRetiro.Location = new System.Drawing.Point(528, 498);
			this.btnRetiro.Name = "btnRetiro";
			this.btnRetiro.Size = new System.Drawing.Size(80, 68);
			this.btnRetiro.TabIndex = 36;
			this.btnRetiro.Text = "Retiro";
			this.btnRetiro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRetiro.UseVisualStyleBackColor = true;
			this.btnRetiro.Click += new System.EventHandler(this.btnRetiro_Click);
			// 
			// btnTransfer
			// 
			this.btnTransfer.Image = global::Cremeria.Properties.Resources.intercambiar;
			this.btnTransfer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnTransfer.Location = new System.Drawing.Point(614, 498);
			this.btnTransfer.Name = "btnTransfer";
			this.btnTransfer.Size = new System.Drawing.Size(80, 68);
			this.btnTransfer.TabIndex = 37;
			this.btnTransfer.Text = "Transfer.";
			this.btnTransfer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnTransfer.UseVisualStyleBackColor = true;
			this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
			// 
			// button1
			// 
			this.button1.Image = global::Cremeria.Properties.Resources.cross;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button1.Location = new System.Drawing.Point(700, 498);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 68);
			this.button1.TabIndex = 38;
			this.button1.Text = "Cancelar";
			this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// btnPrimero
			// 
			this.btnPrimero.Image = global::Cremeria.Properties.Resources.back;
			this.btnPrimero.Location = new System.Drawing.Point(57, 451);
			this.btnPrimero.Name = "btnPrimero";
			this.btnPrimero.Size = new System.Drawing.Size(25, 29);
			this.btnPrimero.TabIndex = 39;
			this.btnPrimero.UseVisualStyleBackColor = true;
			this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
			// 
			// btnAtras
			// 
			this.btnAtras.Image = global::Cremeria.Properties.Resources.previous;
			this.btnAtras.Location = new System.Drawing.Point(88, 451);
			this.btnAtras.Name = "btnAtras";
			this.btnAtras.Size = new System.Drawing.Size(25, 29);
			this.btnAtras.TabIndex = 40;
			this.btnAtras.UseVisualStyleBackColor = true;
			this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
			// 
			// btnAdelante
			// 
			this.btnAdelante.Image = global::Cremeria.Properties.Resources.next_2;
			this.btnAdelante.Location = new System.Drawing.Point(222, 451);
			this.btnAdelante.Name = "btnAdelante";
			this.btnAdelante.Size = new System.Drawing.Size(25, 29);
			this.btnAdelante.TabIndex = 41;
			this.btnAdelante.UseVisualStyleBackColor = true;
			this.btnAdelante.Click += new System.EventHandler(this.btnAdelante_Click);
			// 
			// btnUltimo
			// 
			this.btnUltimo.Image = global::Cremeria.Properties.Resources.next_1;
			this.btnUltimo.Location = new System.Drawing.Point(253, 452);
			this.btnUltimo.Name = "btnUltimo";
			this.btnUltimo.Size = new System.Drawing.Size(25, 29);
			this.btnUltimo.TabIndex = 42;
			this.btnUltimo.UseVisualStyleBackColor = true;
			this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
			// 
			// txtTotal
			// 
			this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTotal.Location = new System.Drawing.Point(688, 449);
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.ReadOnly = true;
			this.txtTotal.Size = new System.Drawing.Size(147, 38);
			this.txtTotal.TabIndex = 17;
			this.txtTotal.Text = "0";
			this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// printDocument2
			// 
			this.printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument2_PrintPage);
			// 
			// Caja
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(848, 573);
			this.Controls.Add(this.btnUltimo);
			this.Controls.Add(this.btnAdelante);
			this.Controls.Add(this.btnAtras);
			this.Controls.Add(this.btnPrimero);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnTransfer);
			this.Controls.Add(this.btnRetiro);
			this.Controls.Add(this.btnClientes);
			this.Controls.Add(this.btnReprint);
			this.Controls.Add(this.btnBuscar);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.txtSubtotal);
			this.Controls.Add(this.btnLimpiar);
			this.Controls.Add(this.btnCobrar);
			this.Controls.Add(this.lbAtiende);
			this.Controls.Add(this.txtVendedor);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.listGuardados);
			this.Controls.Add(this.txtArticulos);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtTotal);
			this.Controls.Add(this.txtDescuento);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtFolio);
			this.Controls.Add(this.txtImporte);
			this.Controls.Add(this.txtUnitario);
			this.Controls.Add(this.txtDescripcion);
			this.Controls.Add(this.txtCantidad);
			this.Controls.Add(this.txtCodigo);
			this.Controls.Add(this.dtFecha);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtProductos);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "Caja";
			this.Text = "Caja";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Caja_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dtProductos;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker dtFecha;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.TextBox txtCantidad;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.TextBox txtUnitario;
		private System.Windows.Forms.TextBox txtImporte;
		private System.Windows.Forms.TextBox txtFolio;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtDescuento;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtCliente;
		public System.Windows.Forms.TextBox txtIdcliente;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtArticulos;
		private System.Windows.Forms.ListBox listGuardados;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtRFC;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		public System.Windows.Forms.TextBox txtVendedor;
		private System.Windows.Forms.Label lbAtiende;
		private System.Windows.Forms.Button btnCobrar;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Button btnLimpiar;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtSubtotal;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn p_u;
		private System.Windows.Forms.DataGridViewTextBoxColumn descuento_i;
		private System.Windows.Forms.DataGridViewTextBoxColumn total_i;
		private System.Windows.Forms.DataGridViewTextBoxColumn grabado;
		private System.Windows.Forms.DataGridViewTextBoxColumn costo;
		private System.Windows.Forms.DataGridViewTextBoxColumn recupera;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.Button btnReprint;
		private System.Windows.Forms.Button btnClientes;
		private System.Windows.Forms.Button btnRetiro;
		private System.Windows.Forms.Button btnTransfer;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnUltimo;
		private System.Windows.Forms.Button btnAdelante;
		private System.Windows.Forms.Button btnAtras;
		private System.Windows.Forms.Button btnPrimero;
		internal System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.TextBox txtTotal;
		private System.Drawing.Printing.PrintDocument printDocument2;
	}
}