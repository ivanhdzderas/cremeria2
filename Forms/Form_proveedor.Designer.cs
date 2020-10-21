namespace Cremeria.Forms
{
	partial class Form_proveedor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_proveedor));
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.cbTiempo = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtTelefono = new System.Windows.Forms.MaskedTextBox();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtNotas = new System.Windows.Forms.TextBox();
			this.txtMunicipio = new System.Windows.Forms.TextBox();
			this.txtEstado = new System.Windows.Forms.TextBox();
			this.txtCp = new System.Windows.Forms.TextBox();
			this.txtColonia = new System.Windows.Forms.TextBox();
			this.txtNumInt = new System.Windows.Forms.TextBox();
			this.txtNumExt = new System.Windows.Forms.TextBox();
			this.txtCalle = new System.Windows.Forms.TextBox();
			this.txtRFC = new System.Windows.Forms.TextBox();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.dtProductos = new System.Windows.Forms.DataGridView();
			this.id_registro = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cbproducto = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label15 = new System.Windows.Forms.Label();
			this.txtComercial = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(209, 550);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 78;
			this.button2.Text = "Cancelar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(58, 550);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 77;
			this.button1.Text = "Guardar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(456, 532);
			this.tabControl1.TabIndex = 81;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtComercial);
			this.tabPage1.Controls.Add(this.label15);
			this.tabPage1.Controls.Add(this.cbTiempo);
			this.tabPage1.Controls.Add(this.label14);
			this.tabPage1.Controls.Add(this.checkedListBox1);
			this.tabPage1.Controls.Add(this.label13);
			this.tabPage1.Controls.Add(this.txtTelefono);
			this.tabPage1.Controls.Add(this.txtEmail);
			this.tabPage1.Controls.Add(this.txtNotas);
			this.tabPage1.Controls.Add(this.txtMunicipio);
			this.tabPage1.Controls.Add(this.txtEstado);
			this.tabPage1.Controls.Add(this.txtCp);
			this.tabPage1.Controls.Add(this.txtColonia);
			this.tabPage1.Controls.Add(this.txtNumInt);
			this.tabPage1.Controls.Add(this.txtNumExt);
			this.tabPage1.Controls.Add(this.txtCalle);
			this.tabPage1.Controls.Add(this.txtRFC);
			this.tabPage1.Controls.Add(this.txtNombre);
			this.tabPage1.Controls.Add(this.label12);
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(448, 506);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Generales";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// cbTiempo
			// 
			this.cbTiempo.FormattingEnabled = true;
			this.cbTiempo.Location = new System.Drawing.Point(113, 449);
			this.cbTiempo.Name = "cbTiempo";
			this.cbTiempo.Size = new System.Drawing.Size(311, 21);
			this.cbTiempo.TabIndex = 133;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(7, 449);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(100, 40);
			this.label14.TabIndex = 133;
			this.label14.Text = "A partir de cuando inicia tiempo para pago";
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes"});
			this.checkedListBox1.Location = new System.Drawing.Point(113, 394);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(129, 49);
			this.checkedListBox1.TabIndex = 132;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(51, 394);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 13);
			this.label13.TabIndex = 131;
			this.label13.Text = "Dias Pago";
			// 
			// txtTelefono
			// 
			this.txtTelefono.Location = new System.Drawing.Point(113, 273);
			this.txtTelefono.Mask = "(999)000-0000";
			this.txtTelefono.Name = "txtTelefono";
			this.txtTelefono.Size = new System.Drawing.Size(100, 20);
			this.txtTelefono.TabIndex = 130;
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(113, 368);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(311, 20);
			this.txtEmail.TabIndex = 132;
			// 
			// txtNotas
			// 
			this.txtNotas.Location = new System.Drawing.Point(113, 299);
			this.txtNotas.Multiline = true;
			this.txtNotas.Name = "txtNotas";
			this.txtNotas.Size = new System.Drawing.Size(311, 63);
			this.txtNotas.TabIndex = 131;
			// 
			// txtMunicipio
			// 
			this.txtMunicipio.Location = new System.Drawing.Point(113, 247);
			this.txtMunicipio.Name = "txtMunicipio";
			this.txtMunicipio.Size = new System.Drawing.Size(311, 20);
			this.txtMunicipio.TabIndex = 129;
			// 
			// txtEstado
			// 
			this.txtEstado.Location = new System.Drawing.Point(113, 221);
			this.txtEstado.Name = "txtEstado";
			this.txtEstado.Size = new System.Drawing.Size(311, 20);
			this.txtEstado.TabIndex = 128;
			// 
			// txtCp
			// 
			this.txtCp.Location = new System.Drawing.Point(113, 195);
			this.txtCp.Name = "txtCp";
			this.txtCp.Size = new System.Drawing.Size(100, 20);
			this.txtCp.TabIndex = 127;
			// 
			// txtColonia
			// 
			this.txtColonia.Location = new System.Drawing.Point(113, 169);
			this.txtColonia.Name = "txtColonia";
			this.txtColonia.Size = new System.Drawing.Size(311, 20);
			this.txtColonia.TabIndex = 126;
			// 
			// txtNumInt
			// 
			this.txtNumInt.Location = new System.Drawing.Point(113, 143);
			this.txtNumInt.Name = "txtNumInt";
			this.txtNumInt.Size = new System.Drawing.Size(100, 20);
			this.txtNumInt.TabIndex = 125;
			// 
			// txtNumExt
			// 
			this.txtNumExt.Location = new System.Drawing.Point(113, 117);
			this.txtNumExt.Name = "txtNumExt";
			this.txtNumExt.Size = new System.Drawing.Size(100, 20);
			this.txtNumExt.TabIndex = 124;
			// 
			// txtCalle
			// 
			this.txtCalle.Location = new System.Drawing.Point(113, 91);
			this.txtCalle.Name = "txtCalle";
			this.txtCalle.Size = new System.Drawing.Size(311, 20);
			this.txtCalle.TabIndex = 123;
			// 
			// txtRFC
			// 
			this.txtRFC.Location = new System.Drawing.Point(113, 65);
			this.txtRFC.Name = "txtRFC";
			this.txtRFC.Size = new System.Drawing.Size(179, 20);
			this.txtRFC.TabIndex = 122;
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(113, 13);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(311, 20);
			this.txtNombre.TabIndex = 119;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(69, 371);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(38, 13);
			this.label12.TabIndex = 118;
			this.label12.Text = "Correo";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(72, 302);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(35, 13);
			this.label11.TabIndex = 117;
			this.label11.Text = "Notas";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(58, 276);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(49, 13);
			this.label10.TabIndex = 116;
			this.label10.Text = "Telefono";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(55, 250);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(52, 13);
			this.label9.TabIndex = 115;
			this.label9.Text = "Municipio";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(67, 224);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 114;
			this.label8.Text = "Estado";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(80, 198);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(27, 13);
			this.label7.TabIndex = 113;
			this.label7.Text = "C.P.";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(65, 172);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 13);
			this.label6.TabIndex = 112;
			this.label6.Text = "Colonia";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(25, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 13);
			this.label5.TabIndex = 111;
			this.label5.Text = "Numero Exterior";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(29, 146);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 13);
			this.label4.TabIndex = 110;
			this.label4.Text = "Numero interior";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(77, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 13);
			this.label3.TabIndex = 109;
			this.label3.Text = "Calle";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(79, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 108;
			this.label2.Text = "RFC";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(63, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 107;
			this.label1.Text = "Nombre";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.dtProductos);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(448, 479);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Productos";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// dtProductos
			// 
			this.dtProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_registro,
            this.cbproducto,
            this.descripcion});
			this.dtProductos.Location = new System.Drawing.Point(6, 6);
			this.dtProductos.Name = "dtProductos";
			this.dtProductos.Size = new System.Drawing.Size(436, 418);
			this.dtProductos.TabIndex = 0;
			this.dtProductos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtProductos_EditingControlShowing);
			// 
			// id_registro
			// 
			this.id_registro.HeaderText = "id";
			this.id_registro.Name = "id_registro";
			this.id_registro.Visible = false;
			// 
			// cbproducto
			// 
			this.cbproducto.HeaderText = "Producto";
			this.cbproducto.Name = "cbproducto";
			this.cbproducto.Width = 293;
			// 
			// descripcion
			// 
			this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.descripcion.HeaderText = "Descripcion";
			this.descripcion.Name = "descripcion";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(14, 42);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(93, 13);
			this.label15.TabIndex = 135;
			this.label15.Text = "Nombre Comercial";
			// 
			// txtComercial
			// 
			this.txtComercial.Location = new System.Drawing.Point(113, 39);
			this.txtComercial.Name = "txtComercial";
			this.txtComercial.Size = new System.Drawing.Size(311, 20);
			this.txtComercial.TabIndex = 120;
			// 
			// Form_proveedor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(486, 585);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form_proveedor";
			this.Text = "Proveedores";
			this.Load += new System.EventHandler(this.Form_proveedor_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtProductos)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.MaskedTextBox txtTelefono;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtNotas;
		private System.Windows.Forms.TextBox txtMunicipio;
		private System.Windows.Forms.TextBox txtEstado;
		private System.Windows.Forms.TextBox txtCp;
		private System.Windows.Forms.TextBox txtColonia;
		private System.Windows.Forms.TextBox txtNumInt;
		private System.Windows.Forms.TextBox txtNumExt;
		private System.Windows.Forms.TextBox txtCalle;
		private System.Windows.Forms.TextBox txtRFC;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataGridView dtProductos;
		private System.Windows.Forms.DataGridViewTextBoxColumn id_registro;
		private System.Windows.Forms.DataGridViewComboBoxColumn cbproducto;
		private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
		private System.Windows.Forms.ComboBox cbTiempo;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtComercial;
		private System.Windows.Forms.Label label15;
	}
}