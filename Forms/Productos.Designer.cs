﻿namespace Cremeria.Forms
{
	partial class Productos
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
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.existencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.precio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.precio2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button4 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cbOficina = new System.Windows.Forms.ComboBox();
			this.button5 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(370, 407);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(148, 23);
			this.button3.TabIndex = 15;
			this.button3.Text = "Todos los productos";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(524, 407);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(153, 23);
			this.button2.TabIndex = 14;
			this.button2.Text = "Productos por Caducar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(683, 407);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 13;
			this.button1.Text = "Agregar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(63, 38);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(157, 20);
			this.textBox2.TabIndex = 12;
			this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(406, 38);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(350, 20);
			this.textBox1.TabIndex = 11;
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Codigo";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(337, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Descripcion";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.codigo,
            this.codigo2,
            this.descripcion,
            this.costo,
            this.existencia,
            this.precio1,
            this.precio2});
			this.dataGridView1.Location = new System.Drawing.Point(12, 64);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(746, 337);
			this.dataGridView1.TabIndex = 8;
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Visible = false;
			// 
			// codigo
			// 
			this.codigo.HeaderText = "Codigo 1";
			this.codigo.Name = "codigo";
			this.codigo.ReadOnly = true;
			// 
			// codigo2
			// 
			this.codigo2.HeaderText = "Codigo 2";
			this.codigo2.Name = "codigo2";
			this.codigo2.ReadOnly = true;
			// 
			// descripcion
			// 
			this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.descripcion.HeaderText = "Descripcion";
			this.descripcion.Name = "descripcion";
			this.descripcion.ReadOnly = true;
			// 
			// costo
			// 
			this.costo.HeaderText = "Costo";
			this.costo.Name = "costo";
			this.costo.ReadOnly = true;
			// 
			// existencia
			// 
			this.existencia.HeaderText = "Existencia";
			this.existencia.Name = "existencia";
			this.existencia.ReadOnly = true;
			// 
			// precio1
			// 
			this.precio1.HeaderText = "Precio 1";
			this.precio1.Name = "precio1";
			this.precio1.ReadOnly = true;
			// 
			// precio2
			// 
			this.precio2.HeaderText = "Precio 2";
			this.precio2.Name = "precio2";
			this.precio2.ReadOnly = true;
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Location = new System.Drawing.Point(255, 407);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(109, 23);
			this.button4.TabIndex = 16;
			this.button4.Text = "Exportar a Excel";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 17;
			this.label3.Text = "Almacen";
			// 
			// cbOficina
			// 
			this.cbOficina.FormattingEnabled = true;
			this.cbOficina.Location = new System.Drawing.Point(63, 11);
			this.cbOficina.Name = "cbOficina";
			this.cbOficina.Size = new System.Drawing.Size(213, 21);
			this.cbOficina.TabIndex = 18;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(282, 9);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 19;
			this.button5.Text = "Consultar";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// Productos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(770, 442);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.cbOficina);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Productos";
			this.Text = "Productos";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Productos_FormClosing);
			this.Load += new System.EventHandler(this.Productos_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo2;
		private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn costo;
		private System.Windows.Forms.DataGridViewTextBoxColumn existencia;
		private System.Windows.Forms.DataGridViewTextBoxColumn precio1;
		private System.Windows.Forms.DataGridViewTextBoxColumn precio2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbOficina;
		private System.Windows.Forms.Button button5;
	}
}