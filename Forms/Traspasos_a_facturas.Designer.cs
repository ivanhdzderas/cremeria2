namespace Cremeria.Forms
{
	partial class Traspasos_a_facturas
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Traspasos_a_facturas));
			this.button1 = new System.Windows.Forms.Button();
			this.dtTrasferencias = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.txtSucursal = new System.Windows.Forms.TextBox();
			this.txtIdSucursal = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dtTrasferencias)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(486, 214);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = "Aceptar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dtTrasferencias
			// 
			this.dtTrasferencias.AllowUserToAddRows = false;
			this.dtTrasferencias.AllowUserToDeleteRows = false;
			this.dtTrasferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtTrasferencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.folio,
            this.fecha,
            this.total,
            this.chk});
			this.dtTrasferencias.Location = new System.Drawing.Point(13, 58);
			this.dtTrasferencias.Name = "dtTrasferencias";
			this.dtTrasferencias.Size = new System.Drawing.Size(548, 150);
			this.dtTrasferencias.TabIndex = 10;
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
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
			// total
			// 
			this.total.HeaderText = "Total";
			this.total.Name = "total";
			this.total.ReadOnly = true;
			// 
			// chk
			// 
			this.chk.HeaderText = "";
			this.chk.Name = "chk";
			// 
			// txtSucursal
			// 
			this.txtSucursal.Location = new System.Drawing.Point(86, 32);
			this.txtSucursal.Name = "txtSucursal";
			this.txtSucursal.Size = new System.Drawing.Size(330, 20);
			this.txtSucursal.TabIndex = 9;
			// 
			// txtIdSucursal
			// 
			this.txtIdSucursal.Location = new System.Drawing.Point(86, 6);
			this.txtIdSucursal.Name = "txtIdSucursal";
			this.txtIdSucursal.Size = new System.Drawing.Size(100, 20);
			this.txtIdSucursal.TabIndex = 8;
			this.txtIdSucursal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdSucursal_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Sucursal";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "No. Sucursal";
			// 
			// Traspasos_a_facturas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(567, 246);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dtTrasferencias);
			this.Controls.Add(this.txtSucursal);
			this.Controls.Add(this.txtIdSucursal);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Traspasos_a_facturas";
			this.Text = "Traspasos";
			this.Load += new System.EventHandler(this.Traspasos_a_facturas_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtTrasferencias)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView dtTrasferencias;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn folio;
		private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn total;
		private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
		private System.Windows.Forms.TextBox txtSucursal;
		private System.Windows.Forms.TextBox txtIdSucursal;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}