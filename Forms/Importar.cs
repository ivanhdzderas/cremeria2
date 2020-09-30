
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cremeria.Forms
{
	public partial class Importar : Form
	{
		string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		public Importar()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				textBox1.Text = openFileDialog1.FileName;
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				textBox2.Text = openFileDialog1.FileName;
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				textBox3.Text = openFileDialog1.FileName;
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "")
			{
				MessageBox.Show("Ingrese un archivo de excel a importar","Importar");
				button1.Focus();
			}
			else
			{
				Models.Product productos = new Models.Product();
				string filePath = textBox1.Text;

				using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
				{
					using (var reader = ExcelReaderFactory.CreateReader(stream))
					{
						using (productos)
						{
							var result = reader.AsDataSet();
							DataTable table = result.Tables[0];
							for (int i = 1; i < table.Rows.Count; i++)
							{
								DataRow row = table.Rows[i];
								productos.Code1= row[0].ToString();
								productos.Description= row[1].ToString();
								if (row[2] is null || row[2].ToString()=="")
								{
									productos.Cost = 0;
								}
								else
								{
									productos.Cost = Convert.ToDouble(row[2].ToString());
								}

								if (row[3] is null || row[3].ToString() == "")
								{
									productos.Code2 = "";
								}
								else
								{
									productos.Code2 = row[3].ToString();
								}


								if (row[4] is null || row[4].ToString() == "")
								{
									productos.Code3 = "";
								}
								else
								{
									productos.Code3 = row[4].ToString();
								}




								if (row[5] is null || row[5].ToString() == "")
								{
									productos.Code4 = "";
								}
								else
								{
									productos.Code4 = row[5].ToString();
								}

								if (row[6] is null || row[6].ToString() == "")
								{
									productos.Code5 = "";
								}
								else
								{
									productos.Code5 = row[6].ToString();
								}
								
								if (row[7] is null || row[7].ToString() == "")
								{
									productos.Price1 = 0;
								}
								else
								{
									productos.Price1 = Convert.ToDouble(row[7].ToString());
								}


								if (row[8] is null || row[8].ToString() == "")
								{
									productos.Price2 = 0;
								}
								else
								{
									productos.Price2 = Convert.ToDouble(row[8].ToString());
								}

								if (row[9] is null || row[9].ToString() == "")
								{
									productos.Price3 = 0;
								}
								else
								{
									productos.Price3 = Convert.ToDouble(row[9].ToString());
								}


								if (row[10] is null || row[10].ToString() == "")
								{
									productos.Price4 = 0;
								}
								else
								{
									productos.Price4 = Convert.ToDouble(row[10].ToString());
								}


								if (row[11] is null || row[11].ToString() == "")
								{
									productos.Price5 = 0;
								}
								else
								{
									productos.Price5 = Convert.ToDouble(row[11].ToString());
								}
								
								if (row[12] is null || row[12].ToString() == "")
								{
									productos.Unit = "";
								}
								else
								{
									productos.Unit = row[12].ToString();
								}

								if (row[13] is null || row[13].ToString() == "")
								{
									productos.Group = "0";
								}
								else
								{
									productos.Group = row[13].ToString();
								}
								
								if (row[14] is null || row[14].ToString() == "")
								{
									productos.Brand = "0";
								}
								else
								{
									productos.Brand = row[14].ToString();
								}
								
								if (row[15] is null || row[15].ToString() == "")
								{
									productos.Code_sat = "";
								}
								else
								{
									productos.Code_sat = row[15].ToString();
								}

								if (row[16] is null || row[16].ToString() == "")
								{
									productos.Sku = "";
								}
								else
								{
									productos.Sku = row[16].ToString();
								}

								if (row[17] is null || row[17].ToString() == "")
								{
									productos.Medida_sat = "";
								}
								else
								{
									productos.Medida_sat = row[17].ToString();
								}
								
								if (row[18] is null || row[18].ToString() == "")
								{
									productos.Sale_tax ="";
								}
								else
								{
									productos.Sale_tax = row[18].ToString();
								}
								if (row[19] is null || row[19].ToString() == "")
								{
									productos.Buy_tax = "";
								}
								else
								{
									productos.Buy_tax = row[19].ToString();
								}
								
								if (row[20] is null || row[20].ToString() == "")
								{
									productos.Min = 0;
								}
								else
								{
									productos.Min = Convert.ToInt32(row[20].ToString());
								}
								if (row[21] is null || row[21].ToString() == "")
								{
									productos.Max = 0;
								}
								else
								{
									productos.Max = Convert.ToInt32(row[21].ToString());
								}
								
								if (row[22] is null || row[22].ToString() == "")
								{
									productos.Max_p1 = 0;
								}
								else
								{
									productos.Max_p1 = Convert.ToInt32(row[22].ToString());
								}
								if (row[23] is null || row[23].ToString() == "")
								{
									productos.Max_p2 = 0;
								}
								else
								{
									productos.Max_p2 = Convert.ToInt32(row[23].ToString());
								}
								if (row[24] is null || row[24].ToString() == "")
								{
									productos.Max_p3 = 0;
								}
								else
								{
									productos.Max_p3 = Convert.ToInt32(row[24].ToString());
								}
								
								if (row[25] is null || row[25].ToString() == "")
								{
									productos.Max_p4 = 0;
								}
								else
								{
									productos.Max_p4 = Convert.ToInt32(row[25].ToString());
								}
								
								if (row[26] is null || row[26].ToString() == "")
								{
									productos.Max_p5 = 0;
								}
								else
								{
									productos.Max_p5 = Convert.ToInt32(row[26].ToString());
								}
								
								if (row[27] is null || row[27].ToString() == "")
								{
									productos.Proveedor = 0;
								}
								else
								{
									productos.Proveedor = Convert.ToInt32(row[37].ToString());
								}
								productos.Parent = "0";
								productos.C_unidad = "0";
								productos.createProduct();
							}
						}
					}
				}
				MessageBox.Show("La importación termino satisfactoriamente");
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (textBox2.Text == "")
			{
				MessageBox.Show("Ingrese un archivo de excel a importar", "Importar");
				button4.Focus();
			}
			else
			{
				Models.Client clientes = new Models.Client();
				string filePath = textBox2.Text;

				using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
				{
					using (var reader = ExcelReaderFactory.CreateReader(stream))
					{
						using (clientes)
						{
							var result = reader.AsDataSet();
							DataTable table = result.Tables[0];
							for (int i = 1; i < table.Rows.Count; i++)
							{
								DataRow row = table.Rows[i];
								if (row[0] is null || row[0].ToString() == "")
								{
									clientes.Name = "";
								}
								else
								{
									clientes.Name = row[0].ToString();
								}



								if (row[1] is null || row[1].ToString() == "")
								{
									clientes.RFC = "";
								}
								else
								{
									clientes.RFC = row[1].ToString();
								}


								if (row[2] is null || row[2].ToString() == "")
								{
									clientes.Street = "";
								}
								else
								{
									clientes.Street = row[2].ToString();
								}


								if (row[3] is null || row[3].ToString() == "")
								{
									clientes.Int_number = "";
								}
								else
								{
									clientes.Int_number = row[3].ToString();
								}

								if (row[4] is null || row[4].ToString() == "")
								{
									clientes.Ext_number = "";
								}
								else
								{
									clientes.Ext_number = row[4].ToString();
								}

								if (row[5] is null || row[5].ToString() == "")
								{
									clientes.Cp = "";
								}
								else
								{
									clientes.Cp = row[5].ToString();
								}

								if (row[6] is null || row[6].ToString() == "")
								{
									clientes.Col = "";
								}
								else
								{
									clientes.Col = row[6].ToString();
								}

								if (row[7] is null || row[7].ToString() == "")
								{
									clientes.State = "";
								}
								else
								{
									clientes.State = row[7].ToString();
								}

								if (row[8] is null || row[8].ToString() == "")
								{
									clientes.Muni = "";
								}
								else
								{
									clientes.Muni = row[8].ToString();
								}

								if (row[9] is null || row[9].ToString() == "")
								{
									clientes.Tel = "";
								}
								else
								{
									clientes.Tel = row[9].ToString();
								}

								if (row[10] is null || row[10].ToString() == "")
								{
									clientes.Note = "";
								}
								else
								{
									clientes.Note = row[10].ToString();
								}

								if (row[11] is null || row[11].ToString() == "")
								{
									clientes.Email = "";
								}
								else
								{
									clientes.Email = row[11].ToString();
								}
								clientes.createClient();

							}
						}
					}
				}
				MessageBox.Show("La importación termino satisfactoriamente");
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			if (textBox3.Text == "")
			{
				MessageBox.Show("Ingrese un archivo de excel a importar", "Importar");
				button6.Focus();
			}
			else
			{
				Models.Providers proveedores = new Models.Providers();
				string filePath = textBox3.Text;

				using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
				{
					using (var reader = ExcelReaderFactory.CreateReader(stream))
					{
						using (proveedores)
						{
							var result = reader.AsDataSet();
							DataTable table = result.Tables[0];
							for (int i = 1; i < table.Rows.Count; i++)
							{
								DataRow row = table.Rows[i];
								if (row[0] is null || row[0].ToString() == "")
								{
									proveedores.Name = "";
								}
								else
								{
									proveedores.Name = row[0].ToString();
								}


								if (row[1] is null || row[1].ToString() == "")
								{
									proveedores.RFC = "";
								}
								else
								{
									proveedores.RFC = row[1].ToString();
								}


								if (row[2] is null || row[2].ToString() == "")
								{
									proveedores.Street = "";
								}
								else
								{
									proveedores.Street = row[2].ToString();
								}



								if (row[3] is null || row[3].ToString() == "")
								{
									proveedores.Ext_number = "";
								}
								else
								{
									proveedores.Ext_number = row[3].ToString();
								}


								if (row[4] is null || row[4].ToString() == "")
								{
									proveedores.Int_number = "";
								}
								else
								{
									proveedores.Int_number = row[4].ToString();
								}

								if (row[5] is null || row[5].ToString() == "")
								{
									proveedores.Col = "";
								}
								else
								{
									proveedores.Col = row[5].ToString();
								}
								if (row[6] is null || row[6].ToString() == "")
								{
									proveedores.State = "";
								}
								else
								{
									proveedores.State = row[6].ToString();
								}
								if (row[7] is null || row[7].ToString() == "")
								{
									proveedores.Muni = "";
								}
								else
								{
									proveedores.Muni = row[7].ToString();
								}
								if (row[8] is null || row[8].ToString() == "")
								{
									proveedores.Tel = "";
								}
								else
								{
									proveedores.Tel = row[8].ToString();
								}
								if (row[9] is null || row[9].ToString() == "")
								{
									proveedores.Note = "";
								}
								else
								{
									proveedores.Note = row[9].ToString();
								}
								if (row[10] is null || row[10].ToString() == "")
								{
									proveedores.Email = "";
								}
								else
								{
									proveedores.Email = row[10].ToString();
								}
								proveedores.createProvider();
							}
						}
					}
				}
				MessageBox.Show("La importación termino satisfactoriamente");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			File.Copy("inventario.xlsx", mdoc + @"/inventario.xlsx");
			MessageBox.Show("Se genero un formato para inventario en la carpeta de Mis Documentos con el nombre de invetnarios.xlsx","Completo");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			File.Copy("clientes.xlsx", mdoc + @"/clientes.xlsx");
			MessageBox.Show("Se genero un formato para inventario en la carpeta de Mis Documentos con el nombre de clientes.xlsx", "Completo");
		}

		private void button5_Click(object sender, EventArgs e)
		{
			File.Copy("proveedores.xlsx", mdoc + @"/proveedores.xlsx");
			MessageBox.Show("Se genero un formato para inventario en la carpeta de Mis Documentos con el nombre de proveedores.xlsx", "Completo");
		}
	}
}
