namespace Cremeria.Forms
{
	partial class Form_compras
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_compras));
			this.cbProveedor = new System.Windows.Forms.ComboBox();
			this.dtVencimiento = new System.Windows.Forms.DateTimePicker();
			this.label15 = new System.Windows.Forms.Label();
			this.txtdias = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.chkContado = new System.Windows.Forms.CheckBox();
			this.label13 = new System.Windows.Forms.Label();
			this.dtFechaDoc = new System.Windows.Forms.DateTimePicker();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.txtdescuento = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.txttotal = new System.Windows.Forms.TextBox();
			this.txtiva = new System.Windows.Forms.TextBox();
			this.txtSubtotal = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.dtProductos = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.button1 = new System.Windows.Forms.Button();
			this.txtpu = new System.Windows.Forms.TextBox();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.txtCantidad = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dtFecha = new System.Windows.Forms.DateTimePicker();
			this.txtFolio = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.dtDocumentos = new System.Windows.Forms.DataGridView();
			this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.id_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.p_u = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.caducidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.impuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtDocumentos)).BeginInit();
			this.SuspendLayout();
			// 
			// cbProveedor
			// 
			this.cbProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbProveedor.FormattingEnabled = true;
			this.cbProveedor.Location = new System.Drawing.Point(74, 6);
			this.cbProveedor.Name = "cbProveedor";
			this.cbProveedor.Size = new System.Drawing.Size(401, 21);
			this.cbProveedor.TabIndex = 56;
			this.cbProveedor.SelectedIndexChanged += new System.EventHandler(this.cbProveedor_SelectedIndexChanged);
			this.cbProveedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProveedor_KeyDown);
			// 
			// dtVencimiento
			// 
			this.dtVencimiento.Location = new System.Drawing.Point(354, 82);
			this.dtVencimiento.Name = "dtVencimiento";
			this.dtVencimiento.Size = new System.Drawing.Size(139, 20);
			this.dtVencimiento.TabIndex = 55;
			this.dtVencimiento.Visible = false;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(250, 88);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(98, 13);
			this.label15.TabIndex = 54;
			this.label15.Text = "Fecha Vencimiento";
			this.label15.Visible = false;
			// 
			// txtdias
			// 
			this.txtdias.Location = new System.Drawing.Point(158, 84);
			this.txtdias.Name = "txtdias";
			this.txtdias.Size = new System.Drawing.Size(41, 20);
			this.txtdias.TabIndex = 53;
			this.txtdias.Visible = false;
			this.txtdias.TextChanged += new System.EventHandler(this.txtdias_TextChanged);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(88, 87);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 13);
			this.label14.TabIndex = 52;
			this.label14.Text = "Dias Credito";
			this.label14.Visible = false;
			// 
			// chkContado
			// 
			this.chkContado.AutoSize = true;
			this.chkContado.Checked = true;
			this.chkContado.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkContado.Location = new System.Drawing.Point(15, 87);
			this.chkContado.Name = "chkContado";
			this.chkContado.Size = new System.Drawing.Size(66, 17);
			this.chkContado.TabIndex = 51;
			this.chkContado.Text = "Contado";
			this.chkContado.UseVisualStyleBackColor = true;
			this.chkContado.CheckedChanged += new System.EventHandler(this.chkContado_CheckedChanged);
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(532, 35);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(95, 13);
			this.label13.TabIndex = 50;
			this.label13.Text = "Fecha Documento";
			// 
			// dtFechaDoc
			// 
			this.dtFechaDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtFechaDoc.Location = new System.Drawing.Point(633, 32);
			this.dtFechaDoc.Name = "dtFechaDoc";
			this.dtFechaDoc.Size = new System.Drawing.Size(128, 20);
			this.dtFechaDoc.TabIndex = 49;
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(74, 32);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(100, 20);
			this.txtNumero.TabIndex = 48;
			this.txtNumero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyDown);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(24, 35);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(44, 13);
			this.label12.TabIndex = 47;
			this.label12.Text = "Numero";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(12, 9);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(56, 13);
			this.label11.TabIndex = 46;
			this.label11.Text = "Proveedor";
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(667, 58);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(94, 23);
			this.button4.TabIndex = 45;
			this.button4.Text = "Cargar por XML";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// txtdescuento
			// 
			this.txtdescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtdescuento.Location = new System.Drawing.Point(661, 383);
			this.txtdescuento.Name = "txtdescuento";
			this.txtdescuento.Size = new System.Drawing.Size(100, 20);
			this.txtdescuento.TabIndex = 44;
			this.txtdescuento.Leave += new System.EventHandler(this.txtdescuento_Leave);
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(596, 386);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(59, 13);
			this.label10.TabIndex = 43;
			this.label10.Text = "Descuento";
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button3.Location = new System.Drawing.Point(95, 357);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 42;
			this.button3.Text = "Cerrar";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Location = new System.Drawing.Point(14, 357);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 41;
			this.button2.Text = "Guardar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txttotal
			// 
			this.txttotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txttotal.Enabled = false;
			this.txttotal.Location = new System.Drawing.Point(661, 435);
			this.txttotal.Name = "txttotal";
			this.txttotal.Size = new System.Drawing.Size(100, 20);
			this.txttotal.TabIndex = 40;
			// 
			// txtiva
			// 
			this.txtiva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtiva.Enabled = false;
			this.txtiva.Location = new System.Drawing.Point(661, 409);
			this.txtiva.Name = "txtiva";
			this.txtiva.Size = new System.Drawing.Size(100, 20);
			this.txtiva.TabIndex = 39;
			// 
			// txtSubtotal
			// 
			this.txtSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSubtotal.Enabled = false;
			this.txtSubtotal.Location = new System.Drawing.Point(661, 357);
			this.txtSubtotal.Name = "txtSubtotal";
			this.txtSubtotal.Size = new System.Drawing.Size(100, 20);
			this.txtSubtotal.TabIndex = 38;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(624, 438);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(31, 13);
			this.label9.TabIndex = 37;
			this.label9.Text = "Total";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(631, 412);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 13);
			this.label8.TabIndex = 36;
			this.label8.Text = "IVA";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(609, 360);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 13);
			this.label7.TabIndex = 35;
			this.label7.Text = "Subtotal";
			// 
			// dtProductos
			// 
			this.dtProductos.AllowUserToAddRows = false;
			this.dtProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_producto,
            this.codigo,
            this.cantidad,
            this.descripcion,
            this.p_u,
            this.total,
            this.lote,
            this.caducidad,
            this.impuesto});
			this.dtProductos.Location = new System.Drawing.Point(14, 205);
			this.dtProductos.Name = "dtProductos";
			this.dtProductos.Size = new System.Drawing.Size(747, 146);
			this.dtProductos.TabIndex = 34;
			this.dtProductos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProductos_CellEndEdit);
			this.dtProductos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtProductos_RowsRemoved);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.toolStrip1);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.txtpu);
			this.groupBox1.Controls.Add(this.txtDescripcion);
			this.groupBox1.Controls.Add(this.txtCodigo);
			this.groupBox1.Controls.Add(this.txtCantidad);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(14, 110);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(747, 89);
			this.groupBox1.TabIndex = 33;
			this.groupBox1.TabStop = false;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2});
			this.toolStrip1.Location = new System.Drawing.Point(3, 16);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.toolStrip1.Size = new System.Drawing.Size(741, 25);
			this.toolStrip1.TabIndex = 9;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(93, 22);
			this.toolStripButton1.Text = "Editar Producto";
			this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(98, 22);
			this.toolStripButton2.Text = "Nuevo producto";
			this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(666, 54);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "Agregar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtpu
			// 
			this.txtpu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtpu.Location = new System.Drawing.Point(560, 57);
			this.txtpu.Name = "txtpu";
			this.txtpu.Size = new System.Drawing.Size(100, 20);
			this.txtpu.TabIndex = 7;
			this.txtpu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpu_KeyDown);
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescripcion.Location = new System.Drawing.Point(203, 57);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(346, 20);
			this.txtDescripcion.TabIndex = 6;
			this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(97, 57);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(100, 20);
			this.txtCodigo.TabIndex = 5;
			this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
			// 
			// txtCantidad
			// 
			this.txtCantidad.Location = new System.Drawing.Point(11, 57);
			this.txtCantidad.Name = "txtCantidad";
			this.txtCantidad.Size = new System.Drawing.Size(80, 20);
			this.txtCantidad.TabIndex = 4;
			this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(557, 41);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(27, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "P/U";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(203, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Descripcion";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(97, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Codigo";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Cantidad";
			// 
			// dtFecha
			// 
			this.dtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtFecha.Enabled = false;
			this.dtFecha.Location = new System.Drawing.Point(633, 6);
			this.dtFecha.Name = "dtFecha";
			this.dtFecha.Size = new System.Drawing.Size(128, 20);
			this.dtFecha.TabIndex = 32;
			// 
			// txtFolio
			// 
			this.txtFolio.Location = new System.Drawing.Point(268, 32);
			this.txtFolio.Name = "txtFolio";
			this.txtFolio.Size = new System.Drawing.Size(100, 20);
			this.txtFolio.TabIndex = 31;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(590, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 30;
			this.label2.Text = "Fecha";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(233, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 29;
			this.label1.Text = "Folio";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(633, 84);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(128, 23);
			this.button5.TabIndex = 57;
			this.button5.Text = "Carga orden de compra";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// dtDocumentos
			// 
			this.dtDocumentos.AllowUserToAddRows = false;
			this.dtDocumentos.AllowUserToDeleteRows = false;
			this.dtDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.documento});
			this.dtDocumentos.Location = new System.Drawing.Point(14, 386);
			this.dtDocumentos.Name = "dtDocumentos";
			this.dtDocumentos.ReadOnly = true;
			this.dtDocumentos.Size = new System.Drawing.Size(156, 69);
			this.dtDocumentos.TabIndex = 58;
			this.dtDocumentos.Visible = false;
			// 
			// documento
			// 
			this.documento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.documento.HeaderText = "documento";
			this.documento.Name = "documento";
			this.documento.ReadOnly = true;
			// 
			// id_producto
			// 
			this.id_producto.HeaderText = "id";
			this.id_producto.Name = "id_producto";
			this.id_producto.Visible = false;
			// 
			// codigo
			// 
			this.codigo.HeaderText = "Codigo";
			this.codigo.Name = "codigo";
			this.codigo.ReadOnly = true;
			// 
			// cantidad
			// 
			this.cantidad.HeaderText = "Cantidad";
			this.cantidad.Name = "cantidad";
			// 
			// descripcion
			// 
			this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.descripcion.HeaderText = "Descripcion";
			this.descripcion.Name = "descripcion";
			this.descripcion.ReadOnly = true;
			// 
			// p_u
			// 
			this.p_u.HeaderText = "P/U";
			this.p_u.Name = "p_u";
			// 
			// total
			// 
			this.total.HeaderText = "Total";
			this.total.Name = "total";
			this.total.ReadOnly = true;
			// 
			// lote
			// 
			this.lote.HeaderText = "Lote";
			this.lote.Name = "lote";
			this.lote.ReadOnly = true;
			this.lote.Visible = false;
			// 
			// caducidad
			// 
			this.caducidad.HeaderText = "Caducidad";
			this.caducidad.Name = "caducidad";
			this.caducidad.Visible = false;
			// 
			// impuesto
			// 
			this.impuesto.HeaderText = "impuesto";
			this.impuesto.Name = "impuesto";
			this.impuesto.Visible = false;
			// 
			// Form_compras
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 465);
			this.Controls.Add(this.dtDocumentos);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.cbProveedor);
			this.Controls.Add(this.dtVencimiento);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.txtdias);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.chkContado);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.dtFechaDoc);
			this.Controls.Add(this.txtNumero);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.txtdescuento);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txttotal);
			this.Controls.Add(this.txtiva);
			this.Controls.Add(this.txtSubtotal);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dtProductos);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dtFecha);
			this.Controls.Add(this.txtFolio);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form_compras";
			this.Text = "Compras";
			this.Load += new System.EventHandler(this.Form_compras_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtDocumentos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbProveedor;
		private System.Windows.Forms.DateTimePicker dtVencimiento;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtdias;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.CheckBox chkContado;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.DateTimePicker dtFechaDoc;
		public System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox txtdescuento;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txttotal;
		private System.Windows.Forms.TextBox txtiva;
		private System.Windows.Forms.TextBox txtSubtotal;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DataGridView dtProductos;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtpu;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.TextBox txtCantidad;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dtFecha;
		private System.Windows.Forms.TextBox txtFolio;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button5;
		public System.Windows.Forms.DataGridView dtDocumentos;
		private System.Windows.Forms.DataGridViewTextBoxColumn documento;
		private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn p_u;
		private System.Windows.Forms.DataGridViewTextBoxColumn total;
		private System.Windows.Forms.DataGridViewTextBoxColumn lote;
		private System.Windows.Forms.DataGridViewTextBoxColumn caducidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn impuesto;
	}
}