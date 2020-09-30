﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms
{
	public partial class Usuarios : Form
	{
		public Usuarios()
		{
			InitializeComponent();
		}
		public void carga()
		{
			dtUsuarios.Rows.Clear();
			Models.Users usuario = new Models.Users();
			using (usuario)
			{
				List<Models.Users> usuarios = usuario.getUsers();
				if (usuarios.Count > 0)
				{
					foreach (Models.Users item in usuarios)
					{
						dtUsuarios.Rows.Add(item.Id, item.Nombre, item.User, item.Tipo);
					}
				}
			}

		}
		private void Usuarios_Load(object sender, EventArgs e)
		{
			carga();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form_usuario.id = 0;
			Form_usuario usu = new Form_usuario();

			usu.ShowDialog();
			carga();
		}

		private void dtUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int selectedrowindex = dtUsuarios.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dtUsuarios.Rows[selectedrowindex];
			string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
			Form_usuario.id = Convert.ToInt16(codigo);
			Form_usuario Producto = new Form_usuario();
			Producto.Show(this);
		}
	}
}
