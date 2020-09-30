namespace Cremeria.Forms
{
	partial class form_transfer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_transfer));
			this.lbFecha = new System.Windows.Forms.Label();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.txtSubtotal = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.dtProductos = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.p_u = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nuCantidad = new System.Windows.Forms.NumericUpDown();
			this.txtPrecio = new System.Windows.Forms.TextBox();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFolios = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbOficinas = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nuCantidad)).BeginInit();
			this.SuspendLayout();
			// 
			// lbFecha
			// 
			this.lbFecha.AutoSize = true;
			this.lbFecha.Location = new System.Drawing.Point(269, 9);
			this.lbFecha.Name = "lbFecha";
			this.lbFecha.Size = new System.Drawing.Size(41, 13);
			this.lbFecha.TabIndex = 40;
			this.lbFecha.Text = "label10";
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(90, 311);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 39;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(12, 311);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(75, 23);
			this.btnGuardar.TabIndex = 38;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// txtSubtotal
			// 
			this.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtSubtotal.Enabled = false;
			this.txtSubtotal.Location = new System.Drawing.Point(626, 311);
			this.txtSubtotal.Name = "txtSubtotal";
			this.txtSubtotal.Size = new System.Drawing.Size(100, 13);
			this.txtSubtotal.TabIndex = 37;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(574, 314);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 13);
			this.label7.TabIndex = 36;
			this.label7.Text = "Subtotal";
			// 
			// dtProductos
			// 
			this.dtProductos.AllowUserToAddRows = false;
			this.dtProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cantidad,
            this.codigo,
            this.descripcion,
            this.p_u,
            this.Importe});
			this.dtProductos.Location = new System.Drawing.Point(12, 81);
			this.dtProductos.Name = "dtProductos";
			this.dtProductos.ReadOnly = true;
			this.dtProductos.Size = new System.Drawing.Size(714, 224);
			this.dtProductos.TabIndex = 35;
			this.dtProductos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtProductos_RowsRemoved);
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Visible = false;
			// 
			// cantidad
			// 
			this.cantidad.HeaderText = "Cantidad";
			this.cantidad.Name = "cantidad";
			this.cantidad.ReadOnly = true;
			// 
			// codigo
			// 
			this.codigo.HeaderText = "Codigo";
			this.codigo.Name = "codigo";
			this.codigo.ReadOnly = true;
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
			this.p_u.HeaderText = "Costo U";
			this.p_u.Name = "p_u";
			this.p_u.ReadOnly = true;
			// 
			// Importe
			// 
			this.Importe.HeaderText = "Importe";
			this.Importe.Name = "Importe";
			this.Importe.ReadOnly = true;
			// 
			// nuCantidad
			// 
			this.nuCantidad.Location = new System.Drawing.Point(15, 55);
			this.nuCantidad.Name = "nuCantidad";
			this.nuCantidad.Size = new System.Drawing.Size(69, 20);
			this.nuCantidad.TabIndex = 34;
			// 
			// txtPrecio
			// 
			this.txtPrecio.Location = new System.Drawing.Point(626, 54);
			this.txtPrecio.Name = "txtPrecio";
			this.txtPrecio.Size = new System.Drawing.Size(100, 20);
			this.txtPrecio.TabIndex = 33;
			this.txtPrecio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrecio_KeyDown);
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(196, 55);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(424, 20);
			this.txtDescripcion.TabIndex = 32;
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(90, 55);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(100, 20);
			this.txtCodigo.TabIndex = 31;
			this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(623, 38);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 13);
			this.label6.TabIndex = 30;
			this.label6.Text = "Precio";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(417, 38);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 29;
			this.label5.Text = "Descripcion";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(150, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 28;
			this.label4.Text = "Codigo";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(35, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 27;
			this.label3.Text = "Cantidad";
			// 
			// txtFolios
			// 
			this.txtFolios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFolios.Location = new System.Drawing.Point(645, 7);
			this.txtFolios.Name = "txtFolios";
			this.txtFolios.Size = new System.Drawing.Size(81, 20);
			this.txtFolios.TabIndex = 26;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(610, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 25;
			this.label2.Text = "Folio";
			// 
			// cbOficinas
			// 
			this.cbOficinas.FormattingEnabled = true;
			this.cbOficinas.Location = new System.Drawing.Point(66, 6);
			this.cbOficinas.Name = "cbOficinas";
			this.cbOficinas.Size = new System.Drawing.Size(197, 21);
			this.cbOficinas.TabIndex = 24;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Sucursal";
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// form_transfer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(738, 340);
			this.Controls.Add(this.lbFecha);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.txtSubtotal);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dtProductos);
			this.Controls.Add(this.nuCantidad);
			this.Controls.Add(this.txtPrecio);
			this.Controls.Add(this.txtDescripcion);
			this.Controls.Add(this.txtCodigo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtFolios);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbOficinas);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "form_transfer";
			this.Text = "Traspasos";
			this.Load += new System.EventHandler(this.form_transfer_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nuCantidad)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Label lbFecha;
		public System.Windows.Forms.Button btnCancelar;
		public System.Windows.Forms.Button btnGuardar;
		public System.Windows.Forms.TextBox txtSubtotal;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.DataGridView dtProductos;
		public System.Windows.Forms.DataGridViewTextBoxColumn id;
		public System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
		public System.Windows.Forms.DataGridViewTextBoxColumn codigo;
		public System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
		public System.Windows.Forms.DataGridViewTextBoxColumn p_u;
		public System.Windows.Forms.DataGridViewTextBoxColumn Importe;
		public System.Windows.Forms.NumericUpDown nuCantidad;
		public System.Windows.Forms.TextBox txtPrecio;
		public System.Windows.Forms.TextBox txtDescripcion;
		public System.Windows.Forms.TextBox txtCodigo;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox txtFolios;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.ComboBox cbOficinas;
		public System.Windows.Forms.Label label1;
		private System.Drawing.Printing.PrintDocument printDocument1;
	}
}