﻿using System;
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
	public partial class Form_usuario : Form
	{
        public static int id;
        public static int id_permiso;
        public Form_usuario()
		{
			InitializeComponent();
		}

		private void Form_usuario_Load(object sender, EventArgs e)
		{
            DataTable table = new DataTable();
            DataRow row;
            table.Columns.Add("Text", typeof(string));
            table.Columns.Add("Value", typeof(string));
            row = table.NewRow();
            row["Text"] = "";
            row["Value"] = "";
            table.Rows.Add(row);
            // cboMarca.Items.Clear();
            row = table.NewRow();
            row["Text"] = "Admin";
            row["Value"] = "Admin";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Text"] = "Cajero";
            row["Value"] = "Cajero";
            table.Rows.Add(row);


            row = table.NewRow();
            row["Text"] = "Promotor";
            row["Value"] = "Promotor";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Text"] = "Almacen";
            row["Value"] = "Almacen";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Text"] = "Contador";
            row["Value"] = "Conta";
            table.Rows.Add(row);


            cbTipo.BindingContext = new BindingContext();
            cbTipo.DataSource = table;
            cbTipo.DisplayMember = "Text";
            cbTipo.ValueMember = "Value";
            cbTipo.BindingContext = new BindingContext();

            if (id != 0)
            {
                Models.Permisos permi = new Models.Permisos();
                using (permi)
                {
                    List<Models.Permisos> lista = permi.getPermiso(id);
                    checkBox1.Checked = Convert.ToBoolean(lista[0].May_men);
                    checkBox2.Checked = Convert.ToBoolean(lista[0].Historia_venta);
                    checkBox3.Checked = Convert.ToBoolean(lista[0].Entrada_efectivo);
                    checkBox4.Checked = Convert.ToBoolean(lista[0].Salida_efectivo);
                    checkBox5.Checked = Convert.ToBoolean(lista[0].Cobrar_ticket);
                    checkBox6.Checked = Convert.ToBoolean(lista[0].Cancelar_ticket);
                    checkBox7.Checked = Convert.ToBoolean(lista[0].Alimina_art_venta);
                    checkBox8.Checked = Convert.ToBoolean(lista[0].Cred_cli);
                    checkBox9.Checked = Convert.ToBoolean(lista[0].Mod_cli);
                    checkBox10.Checked = Convert.ToBoolean(lista[0].Nuevo_prod);
                    checkBox11.Checked = Convert.ToBoolean(lista[0].Mod_prod);
                    checkBox12.Checked = Convert.ToBoolean(lista[0].Del_prod);
                    checkBox13.Checked = Convert.ToBoolean(lista[0].Rep_venta);
                    checkBox14.Checked = Convert.ToBoolean(lista[0].Nueva_promo);
                    checkBox15.Checked = Convert.ToBoolean(lista[0].Add_mercancia);
                    checkBox16.Checked = Convert.ToBoolean(lista[0].Ver_minimos);
                    checkBox17.Checked = Convert.ToBoolean(lista[0].Ver_mov_inv);
                    checkBox18.Checked = Convert.ToBoolean(lista[0].Ajus_inv);
                    checkBox19.Checked = Convert.ToBoolean(lista[0].Corte_caja);
                    checkBox20.Checked = Convert.ToBoolean(lista[0].Corte_todos);
                    checkBox21.Checked = Convert.ToBoolean(lista[0].Ganancias);
                    checkBox22.Checked = Convert.ToBoolean(lista[0].Reporte_ganancias);
                    checkBox23.Checked = Convert.ToBoolean(lista[0].Retiro_efectivo);
                    chkDevoluciones.Checked = Convert.ToBoolean(lista[0].Devoluciones);
                    chkPrecio.Checked = Convert.ToBoolean(lista[0].Cam_precio);
                    id_permiso = lista[0].Id;

                }

                Models.Users usuario = new Models.Users();
                using (usuario)
                {
                    List<Models.Users> item = usuario.getUserbyid(id);
                    txtNombre.Text = item[0].Nombre;
                    txtUsuario.Text = item[0].User;
                    cbTipo.SelectedValue = item[0].Tipo;

                    txtContra.Text = item[0].Pass;
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || cbTipo.Text != "")
            {

                Models.Users usuario = new Models.Users();
                string resultado = "";
                using (MD5 md5Hash = MD5.Create())
                {
                    resultado = Forms.intercambios.GetMd5Hash(md5Hash, txtContra.Text);

                }

                if (cbTipo.SelectedValue.ToString() == "Cajero")
                {
                    usuario.Id = id;
                    usuario.Tipo = cbTipo.SelectedValue.ToString();
                    usuario.Nombre = txtNombre.Text;
                    usuario.User = "";
                }
                else
                {
                    usuario.Id = id;
                    usuario.Tipo = cbTipo.SelectedValue.ToString();
                    usuario.Nombre = txtNombre.Text;
                    usuario.User = txtUsuario.Text;
                }


                if (id == 0)
                {
                    if (cbTipo.SelectedValue.ToString() == "Cajero")
                    {
                        usuario.Pass = "";
                    }
                    else
                    {
                        usuario.Pass = resultado;
                    }
                    using (usuario)
                    {
                        usuario.createUser();

                        List<Models.Users> resu = usuario.getInsertUser(txtUsuario.Text, usuario.Pass);

                        Models.Permisos permiso = new Models.Permisos();
                        using (permiso)
                        {
                            permiso.Id_usuario = resu[0].Id;
                            permiso.May_men = Convert.ToInt16(checkBox1.Checked);
                            permiso.Historia_venta = Convert.ToInt16(checkBox2.Checked);
                            permiso.Entrada_efectivo = Convert.ToInt16(checkBox3.Checked);
                            permiso.Salida_efectivo = Convert.ToInt16(checkBox4.Checked);
                            permiso.Cobrar_ticket = Convert.ToInt16(checkBox5.Checked);
                            permiso.Cancelar_ticket = Convert.ToInt16(checkBox6.Checked);
                            permiso.Alimina_art_venta = Convert.ToInt16(checkBox7.Checked);
                            permiso.Cred_cli = Convert.ToInt16(checkBox8.Checked);
                            permiso.Mod_cli = Convert.ToInt16(checkBox9.Checked);
                            permiso.Nuevo_prod = Convert.ToInt16(checkBox10.Checked);
                            permiso.Mod_prod = Convert.ToInt16(checkBox11.Checked);
                            permiso.Del_prod = Convert.ToInt16(checkBox12.Checked);
                            permiso.Rep_venta = Convert.ToInt16(checkBox13.Checked);
                            permiso.Nueva_promo = Convert.ToInt16(checkBox14.Checked);
                            permiso.Add_mercancia = Convert.ToInt16(checkBox15.Checked);
                            permiso.Ver_minimos = Convert.ToInt16(checkBox16.Checked);
                            permiso.Ver_mov_inv = Convert.ToInt16(checkBox17.Checked);
                            permiso.Ajus_inv = Convert.ToInt16(checkBox18.Checked);
                            permiso.Corte_caja = Convert.ToInt16(checkBox19.Checked);
                            permiso.Corte_todos = Convert.ToInt16(checkBox20.Checked);
                            permiso.Ganancias = Convert.ToInt16(checkBox21.Checked);
                            permiso.Reporte_ganancias = Convert.ToInt16(checkBox22.Checked);
                            permiso.Retiro_efectivo = Convert.ToInt16(checkBox23.Checked);
                            
                            permiso.Devoluciones = Convert.ToInt16(chkDevoluciones.Checked);
                            permiso.Cam_precio = Convert.ToInt32(chkPrecio.Checked);
                            permiso.createPermisos();
                        }

                    }

                }
                else
                {

                    if (cbTipo.SelectedValue.ToString() == "Cajero")
                    {
                        usuario.Pass = "";
                    }
                    else
                    {

                        List<Models.Users> get = usuario.getUserbyid(id);
                        if (get[0].Pass == txtContra.Text)
                        {
                            usuario.Pass = txtContra.Text;
                        }
                        else
                        {
                            usuario.Pass = resultado;
                        }

                    }
                    using (usuario)
                    {
                        usuario.saveUser();

                        Models.Permisos permiso = new Models.Permisos();
                        using (permiso)
                        {
                            permiso.Id_usuario = id;
                            permiso.May_men = Convert.ToInt16(checkBox1.Checked);
                            permiso.Historia_venta = Convert.ToInt16(checkBox2.Checked);
                            permiso.Entrada_efectivo = Convert.ToInt16(checkBox3.Checked);
                            permiso.Salida_efectivo = Convert.ToInt16(checkBox4.Checked);
                            permiso.Cobrar_ticket = Convert.ToInt16(checkBox5.Checked);
                            permiso.Cancelar_ticket = Convert.ToInt16(checkBox6.Checked);
                            permiso.Alimina_art_venta = Convert.ToInt16(checkBox7.Checked);
                            permiso.Cred_cli = Convert.ToInt16(checkBox8.Checked);
                            permiso.Mod_cli = Convert.ToInt16(checkBox9.Checked);
                            permiso.Nuevo_prod = Convert.ToInt16(checkBox10.Checked);
                            permiso.Mod_prod = Convert.ToInt16(checkBox11.Checked);
                            permiso.Del_prod = Convert.ToInt16(checkBox12.Checked);
                            permiso.Rep_venta = Convert.ToInt16(checkBox13.Checked);
                            permiso.Nueva_promo = Convert.ToInt16(checkBox14.Checked);
                            permiso.Add_mercancia = Convert.ToInt16(checkBox15.Checked);
                            permiso.Ver_minimos = Convert.ToInt16(checkBox16.Checked);
                            permiso.Ver_mov_inv = Convert.ToInt16(checkBox17.Checked);
                            permiso.Ajus_inv = Convert.ToInt16(checkBox18.Checked);
                            permiso.Corte_caja = Convert.ToInt16(checkBox19.Checked);
                            permiso.Corte_todos = Convert.ToInt16(checkBox20.Checked);
                            permiso.Ganancias = Convert.ToInt16(checkBox21.Checked);
                            permiso.Reporte_ganancias = Convert.ToInt16(checkBox22.Checked);
                            permiso.Retiro_efectivo = Convert.ToInt16(checkBox23.Checked);
                            permiso.Id = id_permiso;
                            permiso.Devoluciones = Convert.ToInt16(chkDevoluciones.Checked);
                            permiso.Cam_precio = Convert.ToInt32(chkPrecio.Checked);
                            permiso.savePermisos();
                        }

                    }

                }

                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
