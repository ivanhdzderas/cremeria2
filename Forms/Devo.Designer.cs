namespace Cremeria.Forms
{
	partial class Devo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Devo));
			this.label1 = new System.Windows.Forms.Label();
			this.txtFolio = new System.Windows.Forms.TextBox();
			this.dtDevoluciones = new System.Windows.Forms.DataGridView();
			this.txtMotivo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.recibido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dtDevoluciones)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Folio";
			// 
			// txtFolio
			// 
			this.txtFolio.Enabled = false;
			this.txtFolio.Location = new System.Drawing.Point(46, 12);
			this.txtFolio.Name = "txtFolio";
			this.txtFolio.Size = new System.Drawing.Size(100, 20);
			this.txtFolio.TabIndex = 1;
			// 
			// dtDevoluciones
			// 
			this.dtDevoluciones.AllowUserToAddRows = false;
			this.dtDevoluciones.AllowUserToDeleteRows = false;
			this.dtDevoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtDevoluciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cantidad,
            this.codigo,
            this.descripcion,
            this.costo,
            this.importe,
            this.recibido});
			this.dtDevoluciones.Location = new System.Drawing.Point(12, 54);
			this.dtDevoluciones.Name = "dtDevoluciones";
			this.dtDevoluciones.Size = new System.Drawing.Size(776, 149);
			this.dtDevoluciones.TabIndex = 2;
			// 
			// txtMotivo
			// 
			this.txtMotivo.Location = new System.Drawing.Point(57, 209);
			this.txtMotivo.Name = "txtMotivo";
			this.txtMotivo.Size = new System.Drawing.Size(234, 20);
			this.txtMotivo.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 212);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Motivo";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(651, 216);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Total";
			// 
			// txtTotal
			// 
			this.txtTotal.Location = new System.Drawing.Point(688, 212);
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.ReadOnly = true;
			this.txtTotal.Size = new System.Drawing.Size(100, 20);
			this.txtTotal.TabIndex = 6;
			this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
			// costo
			// 
			this.costo.HeaderText = "P.U.";
			this.costo.Name = "costo";
			this.costo.ReadOnly = true;
			// 
			// importe
			// 
			this.importe.HeaderText = "Importe";
			this.importe.Name = "importe";
			this.importe.ReadOnly = true;
			// 
			// recibido
			// 
			this.recibido.HeaderText = "Recibido";
			this.recibido.Name = "recibido";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(713, 238);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Actualizar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Devo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 270);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtTotal);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtMotivo);
			this.Controls.Add(this.dtDevoluciones);
			this.Controls.Add(this.txtFolio);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Devo";
			this.Text = "Devoluciones";
			this.Load += new System.EventHandler(this.Devo_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtDevoluciones)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFolio;
		private System.Windows.Forms.DataGridView dtDevoluciones;
		private System.Windows.Forms.TextBox txtMotivo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTotal;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
		private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn costo;
		private System.Windows.Forms.DataGridViewTextBoxColumn importe;
		private System.Windows.Forms.DataGridViewCheckBoxColumn recibido;
		private System.Windows.Forms.Button button1;
	}
}