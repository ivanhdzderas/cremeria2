﻿namespace Cremeria.Forms
{
	partial class Form_factura
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_factura));
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.txtIVa = new System.Windows.Forms.TextBox();
			this.txtSubtotal = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtMPago = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtFpago = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtUsoCfdi = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.dtProductos = new System.Windows.Forms.DataGridView();
			this.id_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pu = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtdocumentos = new System.Windows.Forms.DataGridView();
			this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.txtIdCliente = new System.Windows.Forms.TextBox();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtFolio = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.dtFecha = new System.Windows.Forms.DateTimePicker();
			this.cbTipo = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtdocumentos)).BeginInit();
			this.SuspendLayout();
			// 
			// txtTotal
			// 
			this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtTotal.Enabled = false;
			this.txtTotal.Location = new System.Drawing.Point(686, 338);
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.Size = new System.Drawing.Size(100, 13);
			this.txtTotal.TabIndex = 39;
			// 
			// txtIVa
			// 
			this.txtIVa.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtIVa.Enabled = false;
			this.txtIVa.Location = new System.Drawing.Point(686, 312);
			this.txtIVa.Name = "txtIVa";
			this.txtIVa.Size = new System.Drawing.Size(100, 13);
			this.txtIVa.TabIndex = 38;
			// 
			// txtSubtotal
			// 
			this.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtSubtotal.Enabled = false;
			this.txtSubtotal.Location = new System.Drawing.Point(686, 286);
			this.txtSubtotal.Name = "txtSubtotal";
			this.txtSubtotal.Size = new System.Drawing.Size(100, 13);
			this.txtSubtotal.TabIndex = 37;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(649, 341);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(31, 13);
			this.label11.TabIndex = 36;
			this.label11.Text = "Total";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(656, 315);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(24, 13);
			this.label10.TabIndex = 35;
			this.label10.Text = "IVA";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(634, 289);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(46, 13);
			this.label9.TabIndex = 34;
			this.label9.Text = "Subtotal";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtMPago);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.txtFpago);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtUsoCfdi);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(495, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(291, 100);
			this.groupBox1.TabIndex = 33;
			this.groupBox1.TabStop = false;
			// 
			// txtMPago
			// 
			this.txtMPago.Location = new System.Drawing.Point(140, 73);
			this.txtMPago.Name = "txtMPago";
			this.txtMPago.Size = new System.Drawing.Size(145, 20);
			this.txtMPago.TabIndex = 6;
			this.txtMPago.Text = "PUE";
			this.txtMPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMPago_KeyDown);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(43, 78);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(86, 13);
			this.label8.TabIndex = 5;
			this.label8.Text = "Metodo de Pago";
			// 
			// txtFpago
			// 
			this.txtFpago.Location = new System.Drawing.Point(140, 47);
			this.txtFpago.Name = "txtFpago";
			this.txtFpago.Size = new System.Drawing.Size(145, 20);
			this.txtFpago.TabIndex = 4;
			this.txtFpago.Text = "01";
			this.txtFpago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFpago_KeyDown);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(55, 50);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(79, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "Forma de Pago";
			// 
			// txtUsoCfdi
			// 
			this.txtUsoCfdi.Location = new System.Drawing.Point(140, 21);
			this.txtUsoCfdi.Name = "txtUsoCfdi";
			this.txtUsoCfdi.Size = new System.Drawing.Size(145, 20);
			this.txtUsoCfdi.TabIndex = 2;
			this.txtUsoCfdi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsoCfdi_KeyDown);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(81, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Uso CFDI";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(541, 289);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 32;
			this.button1.Text = "Guardar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dtProductos
			// 
			this.dtProductos.AllowUserToAddRows = false;
			this.dtProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_producto,
            this.cantidad,
            this.codigo,
            this.descripcion,
            this.pu,
            this.total});
			this.dtProductos.Location = new System.Drawing.Point(10, 130);
			this.dtProductos.Name = "dtProductos";
			this.dtProductos.ReadOnly = true;
			this.dtProductos.Size = new System.Drawing.Size(776, 150);
			this.dtProductos.TabIndex = 31;
			// 
			// id_producto
			// 
			this.id_producto.HeaderText = "id";
			this.id_producto.Name = "id_producto";
			this.id_producto.ReadOnly = true;
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
			// pu
			// 
			this.pu.HeaderText = "P/U";
			this.pu.Name = "pu";
			this.pu.ReadOnly = true;
			// 
			// total
			// 
			this.total.HeaderText = "Total";
			this.total.Name = "total";
			this.total.ReadOnly = true;
			// 
			// dtdocumentos
			// 
			this.dtdocumentos.AllowUserToAddRows = false;
			this.dtdocumentos.AllowUserToDeleteRows = false;
			this.dtdocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtdocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.folio,
            this.tipo});
			this.dtdocumentos.Location = new System.Drawing.Point(10, 294);
			this.dtdocumentos.Name = "dtdocumentos";
			this.dtdocumentos.ReadOnly = true;
			this.dtdocumentos.Size = new System.Drawing.Size(249, 34);
			this.dtdocumentos.TabIndex = 30;
			this.dtdocumentos.Visible = false;
			// 
			// folio
			// 
			this.folio.HeaderText = "folio";
			this.folio.Name = "folio";
			this.folio.ReadOnly = true;
			// 
			// tipo
			// 
			this.tipo.HeaderText = "tipo";
			this.tipo.Name = "tipo";
			this.tipo.ReadOnly = true;
			// 
			// txtIdCliente
			// 
			this.txtIdCliente.Location = new System.Drawing.Point(72, 59);
			this.txtIdCliente.Name = "txtIdCliente";
			this.txtIdCliente.Size = new System.Drawing.Size(100, 20);
			this.txtIdCliente.TabIndex = 29;
			this.txtIdCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdCliente_KeyDown);
			// 
			// txtCliente
			// 
			this.txtCliente.Location = new System.Drawing.Point(72, 33);
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.Size = new System.Drawing.Size(406, 20);
			this.txtCliente.TabIndex = 28;
			this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 13);
			this.label5.TabIndex = 27;
			this.label5.Text = "No. Cliente";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(27, 36);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 13);
			this.label4.TabIndex = 26;
			this.label4.Text = "Cliente";
			// 
			// txtFolio
			// 
			this.txtFolio.Enabled = false;
			this.txtFolio.Location = new System.Drawing.Point(435, 6);
			this.txtFolio.Name = "txtFolio";
			this.txtFolio.Size = new System.Drawing.Size(43, 20);
			this.txtFolio.TabIndex = 25;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(400, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 24;
			this.label3.Text = "Folio";
			// 
			// dtFecha
			// 
			this.dtFecha.Location = new System.Drawing.Point(278, 6);
			this.dtFecha.Name = "dtFecha";
			this.dtFecha.Size = new System.Drawing.Size(108, 20);
			this.dtFecha.TabIndex = 23;
			// 
			// cbTipo
			// 
			this.cbTipo.FormattingEnabled = true;
			this.cbTipo.Location = new System.Drawing.Point(72, 6);
			this.cbTipo.Name = "cbTipo";
			this.cbTipo.Size = new System.Drawing.Size(121, 21);
			this.cbTipo.TabIndex = 22;
			this.cbTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTipo_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(235, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 21;
			this.label2.Text = "Fecha";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 20;
			this.label1.Text = "Factura";
			// 
			// Form_factura
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 363);
			this.Controls.Add(this.txtTotal);
			this.Controls.Add(this.txtIVa);
			this.Controls.Add(this.txtSubtotal);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dtProductos);
			this.Controls.Add(this.dtdocumentos);
			this.Controls.Add(this.txtIdCliente);
			this.Controls.Add(this.txtCliente);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtFolio);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dtFecha);
			this.Controls.Add(this.cbTipo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form_factura";
			this.Text = "Factura";
			this.Load += new System.EventHandler(this.Form_factura_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtdocumentos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtTotal;
		private System.Windows.Forms.TextBox txtIVa;
		private System.Windows.Forms.TextBox txtSubtotal;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtMPago;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtFpago;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtUsoCfdi;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView dtProductos;
		private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
		private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn pu;
		private System.Windows.Forms.DataGridViewTextBoxColumn total;
		public System.Windows.Forms.DataGridView dtdocumentos;
		private System.Windows.Forms.DataGridViewTextBoxColumn folio;
		private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
		public System.Windows.Forms.TextBox txtIdCliente;
		public System.Windows.Forms.TextBox txtCliente;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtFolio;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dtFecha;
		private System.Windows.Forms.ComboBox cbTipo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}