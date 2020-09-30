﻿namespace Cremeria.Forms
{
	partial class Form_salida
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_salida));
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.dtProductos = new System.Windows.Forms.DataGridView();
			this.id_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.p_u = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtCosto = new System.Windows.Forms.TextBox();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.txtCantidad = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dtFecha = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFolio = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(89, 350);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 25;
			this.button3.Text = "&Cerrar";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 351);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 24;
			this.button2.Text = "&Guardar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtTotal
			// 
			this.txtTotal.Enabled = false;
			this.txtTotal.Location = new System.Drawing.Point(554, 351);
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.Size = new System.Drawing.Size(100, 20);
			this.txtTotal.TabIndex = 23;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(498, 354);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(31, 13);
			this.label7.TabIndex = 22;
			this.label7.Text = "Total";
			// 
			// dtProductos
			// 
			this.dtProductos.AllowUserToAddRows = false;
			this.dtProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_producto,
            this.codigo,
            this.cantidad,
            this.descripcion,
            this.p_u,
            this.total});
			this.dtProductos.Location = new System.Drawing.Point(8, 139);
			this.dtProductos.Name = "dtProductos";
			this.dtProductos.Size = new System.Drawing.Size(646, 206);
			this.dtProductos.TabIndex = 21;
			this.dtProductos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProductos_CellEndEdit);
			this.dtProductos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtProductos_RowsRemoved);
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
			this.descripcion.HeaderText = "Descripcion";
			this.descripcion.Name = "descripcion";
			this.descripcion.ReadOnly = true;
			// 
			// p_u
			// 
			this.p_u.HeaderText = "P/U";
			this.p_u.Name = "p_u";
			this.p_u.ReadOnly = true;
			// 
			// total
			// 
			this.total.HeaderText = "Total";
			this.total.Name = "total";
			this.total.ReadOnly = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.txtCosto);
			this.groupBox1.Controls.Add(this.txtDescripcion);
			this.groupBox1.Controls.Add(this.txtCodigo);
			this.groupBox1.Controls.Add(this.txtCantidad);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(8, 64);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(646, 69);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(565, 29);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "&Agregar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtCosto
			// 
			this.txtCosto.Enabled = false;
			this.txtCosto.Location = new System.Drawing.Point(459, 32);
			this.txtCosto.Name = "txtCosto";
			this.txtCosto.Size = new System.Drawing.Size(100, 20);
			this.txtCosto.TabIndex = 7;
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(173, 32);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(280, 20);
			this.txtDescripcion.TabIndex = 6;
			this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(67, 32);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(100, 20);
			this.txtCodigo.TabIndex = 5;
			this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
			// 
			// txtCantidad
			// 
			this.txtCantidad.Location = new System.Drawing.Point(6, 32);
			this.txtCantidad.Name = "txtCantidad";
			this.txtCantidad.Size = new System.Drawing.Size(55, 20);
			this.txtCantidad.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(525, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "Costo";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(390, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Descripcion";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(127, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Codigo";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Cantidad";
			// 
			// dtFecha
			// 
			this.dtFecha.Location = new System.Drawing.Point(55, 38);
			this.dtFecha.Name = "dtFecha";
			this.dtFecha.Size = new System.Drawing.Size(200, 20);
			this.dtFecha.TabIndex = 19;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 18;
			this.label2.Text = "Fecha";
			// 
			// txtFolio
			// 
			this.txtFolio.Enabled = false;
			this.txtFolio.Location = new System.Drawing.Point(55, 12);
			this.txtFolio.Name = "txtFolio";
			this.txtFolio.Size = new System.Drawing.Size(77, 20);
			this.txtFolio.TabIndex = 17;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Folio";
			// 
			// Form_salida
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(662, 378);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txtTotal);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dtProductos);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dtFecha);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtFolio);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form_salida";
			this.Text = "Salidas";
			this.Load += new System.EventHandler(this.Form_salida_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txtTotal;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DataGridView dtProductos;
		private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn p_u;
		private System.Windows.Forms.DataGridViewTextBoxColumn total;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtCosto;
		public System.Windows.Forms.TextBox txtDescripcion;
		public System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.TextBox txtCantidad;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dtFecha;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFolio;
		private System.Windows.Forms.Label label1;
	}
}