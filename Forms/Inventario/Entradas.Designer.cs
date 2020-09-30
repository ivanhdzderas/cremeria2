﻿namespace Cremeria.Forms.Inventario
{
	partial class Entradas
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
			this.txtFolio = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.dgvEntradas = new System.Windows.Forms.DataGridView();
			this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvEntradas)).BeginInit();
			this.SuspendLayout();
			// 
			// txtFolio
			// 
			this.txtFolio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtFolio.Location = new System.Drawing.Point(47, 6);
			this.txtFolio.Name = "txtFolio";
			this.txtFolio.Size = new System.Drawing.Size(168, 20);
			this.txtFolio.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Folio";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(688, 415);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "&Nuevo";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dgvEntradas
			// 
			this.dgvEntradas.AllowUserToAddRows = false;
			this.dgvEntradas.AllowUserToDeleteRows = false;
			this.dgvEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvEntradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvEntradas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecha,
            this.folio,
            this.status});
			this.dgvEntradas.Location = new System.Drawing.Point(12, 32);
			this.dgvEntradas.Name = "dgvEntradas";
			this.dgvEntradas.ReadOnly = true;
			this.dgvEntradas.Size = new System.Drawing.Size(776, 377);
			this.dgvEntradas.TabIndex = 5;
			this.dgvEntradas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEntradas_CellDoubleClick);
			this.dgvEntradas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvEntradas_KeyDown);
			// 
			// fecha
			// 
			this.fecha.HeaderText = "Fecha";
			this.fecha.Name = "fecha";
			this.fecha.ReadOnly = true;
			// 
			// folio
			// 
			this.folio.HeaderText = "Folio";
			this.folio.Name = "folio";
			this.folio.ReadOnly = true;
			// 
			// status
			// 
			this.status.HeaderText = "Status";
			this.status.Name = "status";
			this.status.ReadOnly = true;
			// 
			// Entradas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.txtFolio);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dgvEntradas);
			this.Name = "Entradas";
			this.Text = "Entradas";
			this.Load += new System.EventHandler(this.Entradas_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvEntradas)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtFolio;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView dgvEntradas;
		private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn folio;
		private System.Windows.Forms.DataGridViewTextBoxColumn status;
	}
}