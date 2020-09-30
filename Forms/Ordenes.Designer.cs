namespace Cremeria.Forms
{
	partial class Ordenes
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
			this.dtOrdenes = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.emparejada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dtOrdenes)).BeginInit();
			this.SuspendLayout();
			// 
			// dtOrdenes
			// 
			this.dtOrdenes.AllowUserToAddRows = false;
			this.dtOrdenes.AllowUserToDeleteRows = false;
			this.dtOrdenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtOrdenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.proveedor,
            this.emparejada});
			this.dtOrdenes.Location = new System.Drawing.Point(12, 44);
			this.dtOrdenes.Name = "dtOrdenes";
			this.dtOrdenes.ReadOnly = true;
			this.dtOrdenes.Size = new System.Drawing.Size(776, 288);
			this.dtOrdenes.TabIndex = 0;
			this.dtOrdenes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(713, 338);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Nuevo";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// id
			// 
			this.id.HeaderText = "Folio";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			// 
			// proveedor
			// 
			this.proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.proveedor.HeaderText = "Proveedor";
			this.proveedor.Name = "proveedor";
			this.proveedor.ReadOnly = true;
			// 
			// emparejada
			// 
			this.emparejada.HeaderText = "Emparejada";
			this.emparejada.Name = "emparejada";
			this.emparejada.ReadOnly = true;
			// 
			// Ordenes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 373);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dtOrdenes);
			this.Name = "Ordenes";
			this.Text = "Ordenes de compra";
			this.Load += new System.EventHandler(this.Ordenes_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtOrdenes)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dtOrdenes;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
		private System.Windows.Forms.DataGridViewCheckBoxColumn emparejada;
	}
}