using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms
{
	public partial class Autenficiar : Form
	{
		public static string origen;
		public Autenficiar()
		{
			InitializeComponent();
		}

		private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtUsuario.Text != "")
				{
					txtContra.Focus();
				}
			}
			
		}

		private void txtContra_KeyDown(object sender, KeyEventArgs e)
		{
			if (txtContra.Text != "")
			{
				if (txtUsuario.Text != "")
				{
					button2.PerformClick();
				}
				else
				{
					txtUsuario.Focus();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (origen== "Devolucion")
			{
				Devoluciones.cancelado = true;
			}
			else
			{
				Caja.cancelado = true;
			}
			
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{

			string usuario = txtUsuario.Text;
			string contra = txtContra.Text;
			Models.Users usuarios = new Models.Users();
			Models.Permisos permisos = new Models.Permisos();
			using (usuarios)
			{
				List<Models.Users> result = usuarios.getUser(usuario);
				if (result.Count > 0)
				{
					using(MD5 md5Hash = MD5.Create())
					{
						if ((intercambios.VerifyMd5Hash(md5Hash, contra, result[0].Pass)) || (contra == result[0].Pass)){
							using (permisos)
							{
								List<Models.Permisos> permiso = permisos.getPermiso(result[0].Id);
								if (permiso.Count > 0)
								{
									switch (origen)
									{
										case "retiro":
											if (Convert.ToBoolean(permiso[0].Retiro_efectivo))
											{
												Caja.autorizado = true;
												Caja.Quien_autorizo = result[0].Id;
											}
											else
											{
												MessageBox.Show("El usuario no tiene permiso de efectuar retiro de caja", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
												Caja.autorizado = false;
											}
											break;
										case "transferencia":
											if (Convert.ToBoolean(permiso[0].Transferencias))
											{
												Caja.autorizado = true;
												Caja.Quien_autorizo = result[0].Id;
											}
											else
											{
												MessageBox.Show("El usuario no tiene permiso de efectuar transferencias", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
												Caja.autorizado = false;
											}
											break;
										case "cancelar":
											if (Convert.ToBoolean(permiso[0].Cancelar_ticket))
											{
												Caja.autorizado = true;
												Caja.Quien_autorizo = result[0].Id;
											}
											else
											{
												MessageBox.Show("El usuario no tiene permiso para cancelar Ticket", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
												Caja.autorizado = false;
											}
											break;
										case "Devolucion":
											if (Convert.ToBoolean(permiso[0].Cancelar_ticket))
											{
												Devoluciones.cancelado = false;
												Devoluciones.id_usuario = result[0].Id;
											}
											else
											{
												MessageBox.Show("El usuario no tiene permiso para devoluciones", "Usuario invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
												Devoluciones.cancelado = true;
											}
											break;
									}
									this.Close();
								}
							}
						}
					}
				}
			}
		}
	}
}
