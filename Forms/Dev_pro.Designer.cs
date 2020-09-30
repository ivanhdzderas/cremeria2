namespace Cremeria.Forms
{
	partial class Dev_pro
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
			this.dtDevoluciones = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dtDevoluciones)).BeginInit();
			this.SuspendLayout();
			// 
			// dtDevoluciones
			// 
			this.dtDevoluciones.AllowUserToAddRows = false;
			this.dtDevoluciones.AllowUserToDeleteRows = false;
			this.dtDevoluciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtDevoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtDevoluciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fecha,
            this.proveedor,
            this.estado});
			this.dtDevoluciones.Location = new System.Drawing.Point(12, 51);
			this.dtDevoluciones.Name = "dtDevoluciones";
			this.dtDevoluciones.ReadOnly = true;
			this.dtDevoluciones.Size = new System.Drawing.Size(776, 358);
			this.dtDevoluciones.TabIndex = 0;
			this.dtDevoluciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDevoluciones_CellDoubleClick);
			// 
			// id
			// 
			this.id.HeaderText = "Folio";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			// 
			// fecha
			// 
			this.fecha.HeaderText = "Fecha";
			this.fecha.Name = "fecha";
			this.fecha.ReadOnly = true;
			// 
			// proveedor
			// 
			this.proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.proveedor.HeaderText = "Proveedor";
			this.proveedor.Name = "proveedor";
			this.proveedor.ReadOnly = true;
			// 
			// estado
			// 
			this.estado.HeaderText = "Estado";
			this.estado.Name = "estado";
			this.estado.ReadOnly = true;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(713, 415);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Nuevo";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Dev_pro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dtDevoluciones);
			this.Name = "Dev_pro";
			this.Text = "Devoluciones Proveedores";
			this.Load += new System.EventHandler(this.Dev_pro_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtDevoluciones)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dtDevoluciones;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
		private System.Windows.Forms.DataGridViewTextBoxColumn estado;
		private System.Windows.Forms.Button button1;
	}
}