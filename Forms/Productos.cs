using System;
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
	public partial class Productos : Form
	{
        public string connectionstring2;
		public Productos()
		{
			InitializeComponent();
		}
        private DataTable inventario_para()
        {
            DataTable inventario = new DataTable();

            inventario.Columns.Add("Codigo 1");
            inventario.Columns.Add("Codigo 2");
            inventario.Columns.Add("Descripcion");
            inventario.Columns.Add("Costo");
            inventario.Columns.Add("Precio1");
            inventario.Columns.Add("Max precio1");
            inventario.Columns.Add("Precio2");
            inventario.Columns.Add("Max precio2");
            inventario.Columns.Add("Precio3");
            inventario.Columns.Add("Max precio3");
            inventario.Columns.Add("Precio4");
            inventario.Columns.Add("Max precio4");
            inventario.Columns.Add("Precio5");
            inventario.Columns.Add("Max precio5");

            Models.Product producto = new Models.Product();
            using (producto)
            {
                List<Models.Product> productos = producto.getProducts();
               
                foreach (Models.Product item in productos)
                {
                    inventario.Rows.Add(item.Code1, item.Code2, item.Description, item.Cost,item.Price1, item.Max_p1, item.Price2, item.Max_p2, item.Price3, item.Max_p3, item.Price4, item.Max_p4, item.Price5, item.Max_p5);
                }
                return inventario;
            }
        }
        public void carga()
        {

            dataGridView1.Rows.Clear();
            Models.Product product = new Models.Product();
            using (product)
            {
                List<Models.Product> result = product.getProductNoSub();

                foreach (Models.Product item in result)
                {
                    dataGridView1.Rows.Add(item.Id, item.Code1, item.Code2, item.Description, item.Cost, (item.Existencia + item.Devoluciones), item.Price1, item.Price2);
                }
            }


        }
        private void Productos_Load(object sender, EventArgs e)
		{
			carga();

            DataTable table = new DataTable();
            DataRow row;
            table.Columns.Add("Text", typeof(string));
            table.Columns.Add("Value", typeof(string));
            row = table.NewRow();
            row["Text"] = "";
            row["Value"] = "";
            table.Rows.Add(row);
            // cboMarca.Items.Clear();
            Models.Offices oficinas = new Models.Offices();
            using (oficinas)
            {
                List<Models.Offices> result = oficinas.GetOffices();
                foreach (Models.Offices item in result)
                {
                    row = table.NewRow();
                    row["Text"] = item.Name;
                    row["Value"] = item.Id;
                    table.Rows.Add(row);
                }
            }

            cbOficina.BindingContext = new BindingContext();
            cbOficina.DataSource = table;
            cbOficina.DisplayMember = "Text";
            cbOficina.ValueMember = "Value";
            cbOficina.BindingContext = new BindingContext();


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string codigo = Convert.ToString(selectedRow.Cells["id"].Value);
            Forms.Producto.Codigo = codigo;
            Producto Producto = new Producto();
            Producto.Show(this);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "")
                {
                    carga();

                }
                else
                {
                    dataGridView1.Rows.Clear();
                    string bus_descripcion = textBox1.Text;


                    Models.Product product = new Models.Product();
                    using (product)
                    {
                        List<Models.Product> result = product.getProductByDescription(bus_descripcion);

                        foreach (Models.Product item in result)
                        {
                            dataGridView1.Rows.Add(item.Id, item.Code1, item.Code2, item.Description, item.Cost, (item.Existencia + item.Devoluciones), item.Price1, item.Price2);

                        }
                    }


                }

            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox2.Text == "")
                {
                    carga();
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    string codigo_buscar = textBox2.Text;
                    Models.Product product = new Models.Product();
                    using (product)
                    {
                        List<Models.Product> result = product.getProductByCode(codigo_buscar);

                        foreach (Models.Product item in result)
                        {
                            dataGridView1.Rows.Add(item.Id, item.Code1, item.Code2, item.Description, item.Cost, (item.Existencia + item.Devoluciones), item.Price1, item.Price2);

                        }
                    }

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string codigo_buscar = textBox2.Text;
            Models.Product product = new Models.Product();
            using (product)
            {
                List<Models.Product> result = product.getCaducProducts();

                foreach (Models.Product item in result)
                {
                    dataGridView1.Rows.Add(item.Code1, item.Code2, item.Description, item.Description, item.Cost, (item.Existencia + item.Devoluciones), item.Price1, item.Price2);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            carga();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.Producto.Codigo = "";
            Forms.Producto Producto = new Forms.Producto();

            Producto.Show(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Models.Configuration config = new Models.Configuration();
            using (config)
            {
                List<Models.Configuration> configuracion = config.getConfiguration();
                DataTable dtbl = inventario_para();
                Models.Export_excel excel = new Models.Export_excel();
                excel.ExportToExcel(dtbl, configuracion[0].Ruta_reportes + "inventario");
                MessageBox.Show("Terminado");
            }
        }

		private void button5_Click(object sender, EventArgs e)
		{
            connectionstring2 = Inicial.connectionString;
            Models.Offices oficinas = new Models.Offices();

            using (oficinas)
			{
                List<Models.Offices> lista = oficinas.GetOfficesbyid(Convert.ToInt32(cbOficina.SelectedValue.ToString()));
                if (lista[0].Connection!="")
				{
                    Inicial.connectionString = lista[0].Connection;
                    carga();
                }
				else
				{
                    MessageBox.Show("No se puede conectar con la sucursal");
				}
                
            }
		}

		private void Productos_FormClosing(object sender, FormClosingEventArgs e)
		{
            if (connectionstring2 != Inicial.connectionString)
			{
                Inicial.connectionString = connectionstring2;
			}
		}
	}
}
