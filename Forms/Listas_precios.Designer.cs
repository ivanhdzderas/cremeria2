namespace Cremeria.Forms
{
	partial class Listas_precios
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
			this.dtListas = new System.Windows.Forms.DataGridView();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dtListas)).BeginInit();
			this.SuspendLayout();
			// 
			// dtListas
			// 
			this.dtListas.AllowUserToAddRows = false;
			this.dtListas.AllowUserToDeleteRows = false;
			this.dtListas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtListas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cliente,
            this.producto,
            this.descuento});
			this.dtListas.Location = new System.Drawing.Point(12, 45);
			this.dtListas.Name = "dtListas";
			this.dtListas.ReadOnly = true;
			this.dtListas.Size = new System.Drawing.Size(776, 364);
			this.dtListas.TabIndex = 0;
			this.dtListas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtListas_CellDoubleClick);
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Visible = false;
			// 
			// cliente
			// 
			this.cliente.HeaderText = "Cliente";
			this.cliente.Name = "cliente";
			this.cliente.ReadOnly = true;
			// 
			// producto
			// 
			this.producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.producto.HeaderText = "Producto";
			this.producto.Name = "producto";
			this.producto.ReadOnly = true;
			// 
			// descuento
			// 
			this.descuento.HeaderText = "Descuento";
			this.descuento.Name = "descuento";
			this.descuento.ReadOnly = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(713, 415);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Nuevo";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Listas_precios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dtListas);
			this.Name = "Listas_precios";
			this.Text = "Listas de precios";
			this.Load += new System.EventHandler(this.Listas_precios_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtListas)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dtListas;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
		private System.Windows.Forms.DataGridViewTextBoxColumn producto;
		private System.Windows.Forms.DataGridViewTextBoxColumn descuento;
		private System.Windows.Forms.Button button1;
	}
}