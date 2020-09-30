namespace Cremeria.Forms
{
	partial class Ticket_a_factura
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ticket_a_factura));
			this.label2 = new System.Windows.Forms.Label();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.dtTickets = new System.Windows.Forms.DataGridView();
			this.txtIdCliente = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dtTickets)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Cliente";
			// 
			// txtCliente
			// 
			this.txtCliente.Location = new System.Drawing.Point(77, 32);
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.Size = new System.Drawing.Size(381, 20);
			this.txtCliente.TabIndex = 8;
			this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(517, 194);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 10;
			this.button1.Text = "Aceptar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dtTickets
			// 
			this.dtTickets.AllowUserToAddRows = false;
			this.dtTickets.AllowUserToDeleteRows = false;
			this.dtTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtTickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.folio,
            this.fecha,
            this.total,
            this.chk});
			this.dtTickets.Location = new System.Drawing.Point(12, 58);
			this.dtTickets.Name = "dtTickets";
			this.dtTickets.Size = new System.Drawing.Size(580, 130);
			this.dtTickets.TabIndex = 9;
			// 
			// txtIdCliente
			// 
			this.txtIdCliente.Location = new System.Drawing.Point(77, 6);
			this.txtIdCliente.Name = "txtIdCliente";
			this.txtIdCliente.Size = new System.Drawing.Size(100, 20);
			this.txtIdCliente.TabIndex = 7;
			this.txtIdCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdCliente_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "No. Cliente";
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Visible = false;
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
			// Ticket_a_factura
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(601, 220);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCliente);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dtTickets);
			this.Controls.Add(this.txtIdCliente);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Ticket_a_factura";
			this.Text = "Ticket";
			this.Load += new System.EventHandler(this.Ticket_a_factura_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtTickets)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCliente;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView dtTickets;
		private System.Windows.Forms.TextBox txtIdCliente;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn folio;
		private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn total;
		private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
	}
}