namespace Cremeria.Forms
{
	partial class Alertas
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
			this.dtDocumentos = new System.Windows.Forms.DataGridView();
			this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fecha_v = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dtDocumentos)).BeginInit();
			this.SuspendLayout();
			// 
			// dtDocumentos
			// 
			this.dtDocumentos.AllowUserToAddRows = false;
			this.dtDocumentos.AllowUserToDeleteRows = false;
			this.dtDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.folio,
            this.fecha,
            this.proveedor,
            this.monto,
            this.fecha_v});
			this.dtDocumentos.Location = new System.Drawing.Point(12, 45);
			this.dtDocumentos.Name = "dtDocumentos";
			this.dtDocumentos.ReadOnly = true;
			this.dtDocumentos.Size = new System.Drawing.Size(776, 393);
			this.dtDocumentos.TabIndex = 0;
			// 
			// folio
			// 
			this.folio.HeaderText = "Folio";
			this.folio.Name = "folio";
			this.folio.ReadOnly = true;
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
			// monto
			// 
			this.monto.HeaderText = "Monto";
			this.monto.Name = "monto";
			this.monto.ReadOnly = true;
			// 
			// fecha_v
			// 
			this.fecha_v.HeaderText = "Fecha Vencimiento";
			this.fecha_v.Name = "fecha_v";
			this.fecha_v.ReadOnly = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(389, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Los siguientes documentos, están en tiempo de vencimiento o próximos a vencer";
			// 
			// Alertas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtDocumentos);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Alertas";
			this.Text = "Alertas";
			this.Load += new System.EventHandler(this.Alertas_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtDocumentos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dtDocumentos;
		private System.Windows.Forms.DataGridViewTextBoxColumn folio;
		private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
		private System.Windows.Forms.DataGridViewTextBoxColumn monto;
		private System.Windows.Forms.DataGridViewTextBoxColumn fecha_v;
		private System.Windows.Forms.Label label1;
	}
}