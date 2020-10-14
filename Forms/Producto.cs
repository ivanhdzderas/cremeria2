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
	public partial class Producto : Form
	{
        public static string connectionstring2;
        public static int Id_productos;
		public static string Codigo;
		public static string SubProducto;
		public static string SubSubProducto;
        static bool cambio_precio = true;
        private static double precio1, precio2, precio3, precio4, precio5;
		public Producto()
		{
			InitializeComponent();
		}
        private void carga_costos()
		{
            dtCostos.Rows.Clear();
            Models.prov_prod costo = new Models.prov_prod();
			using (costo)
			{
                List<Models.prov_prod> cot = costo.get_costo(Convert.ToInt32(Codigo));
                if (cot.Count>0) {
                    foreach(Models.prov_prod item in cot)
					{
                        dtCostos.Rows.Add(item.Id,item.Id_proveedor,item.Costo, item.Cantidad);
					}
                }
			}
		}
        private void carga_kardex()
        {
            if (connectionstring2 != "")
			{
                Models.Kardex historia = new Models.Kardex();
                using (historia)
                {
                    List<Models.Kardex> result = historia.getKardex(Convert.ToInt16(Codigo));
                    foreach (Models.Kardex item in result)
                    {
                        string id = item.Id.ToString();
                        string fecha = item.Fecha;
                        string folio_documento = item.Id_documento.ToString();
                        string antes = item.Antes.ToString();
                        string cantidad = item.Cantidad.ToString();
                        string tipo = "";
                        switch (item.Tipo)
                        {
                            case "E":
                                tipo = "Entrada";
                                break;
                            case "S":
                                tipo = "Salida";
                                break;
                            case "A":
                                tipo = "Ajuste";
                                break;
                            case "V":
                                tipo = "Venta";
                                break;
                            case "T":
                                tipo = "Traspaso";
                                break;
                            case "C":
                                tipo = "Compra";
                                break;
                            case "D":
                                tipo = "Ticket";
                                break;
                        }
                        dtKardex.Rows.Insert(0, id, fecha, tipo, folio_documento, antes, cantidad);
                    }
                }
			}
			else
			{
                intercambios.conector = connectionstring2;
                Models.Kardex_suc historia = new Models.Kardex_suc();
                using (historia)
                {
                    List<Models.Kardex_suc> result = historia.getKardex(Convert.ToInt16(Codigo));
                    foreach (Models.Kardex_suc item in result)
                    {
                        string id = item.Id.ToString();
                        string fecha = item.Fecha;
                        string folio_documento = item.Id_documento.ToString();
                        string antes = item.Antes.ToString();
                        string cantidad = item.Cantidad.ToString();
                        string tipo = "";
                        switch (item.Tipo)
                        {
                            case "E":
                                tipo = "Entrada";
                                break;
                            case "S":
                                tipo = "Salida";
                                break;
                            case "A":
                                tipo = "Ajuste";
                                break;
                            case "V":
                                tipo = "Venta";
                                break;
                            case "T":
                                tipo = "Traspaso";
                                break;
                            case "C":
                                tipo = "Compra";
                                break;
                            case "D":
                                tipo = "Ticket";
                                break;
                        }
                        dtKardex.Rows.Add(id, fecha, tipo, folio_documento, antes, cantidad);
                    }
                }
            }
            

        }
        public void carga_pack(int id)
        {
            if (connectionstring2 != "")
			{
                Models.Product sub = new Models.Product();
                using (sub)
                {
                    List<Models.Product> item = sub.getProduct(id);
                    if (item.Any() == true)
                    {
                        chkCaja.Checked = true;
                        foreach (Models.Product prod in item)
                        {
                            SubProducto = prod.Id.ToString();
                            txtCodigoCaja.Text = prod.Code1;
                            txtSkuCaja.Text = prod.Sku;
                            txtDescripcionCaja.Text = prod.Description;
                            txtCostoCaja.Text = prod.Cost.ToString();
                            txtUtilidad1C.Text = prod.Utility1.ToString();
                            txtUtilidad2C.Text = prod.Utility2.ToString();
                            txtUtilidad3C.Text = prod.Utility3.ToString();

                            txtPrecio1C.Text = prod.Price1.ToString();
                            txtPrecio2C.Text = prod.Price2.ToString();
                            txtPrecio3C.Text = prod.Price3.ToString();
                            max_p1c.Value = Convert.ToDecimal(prod.Max_p1);
                            max_p2c.Value = Convert.ToDecimal(prod.Max_p2);
                            max_p3c.Value = Convert.ToDecimal(prod.Max_p3);

                            txtPCaja.Text = prod.C_unidad;
                        }
                    }
                }
			}
			else
			{
                intercambios.conector = connectionstring2;
                Models.Produc_suc sub = new Models.Produc_suc();
                using (sub)
                {
                    List<Models.Produc_suc> item = sub.getProduct(id);
                    if (item.Any() == true)
                    {
                        chkCaja.Checked = true;
                        foreach (Models.Produc_suc prod in item)
                        {
                            SubProducto = prod.Id.ToString();
                            txtCodigoCaja.Text = prod.Code1;
                            txtSkuCaja.Text = prod.Sku;
                            txtDescripcionCaja.Text = prod.Description;
                            txtCostoCaja.Text = prod.Cost.ToString();
                            txtUtilidad1C.Text = prod.Utility1.ToString();
                            txtUtilidad2C.Text = prod.Utility2.ToString();
                            txtUtilidad3C.Text = prod.Utility3.ToString();

                            txtPrecio1C.Text = prod.Price1.ToString();
                            txtPrecio2C.Text = prod.Price2.ToString();
                            txtPrecio3C.Text = prod.Price3.ToString();
                            max_p1c.Value = Convert.ToDecimal(prod.Max_p1);
                            max_p2c.Value = Convert.ToDecimal(prod.Max_p2);
                            max_p3c.Value = Convert.ToDecimal(prod.Max_p3);

                            txtPCaja.Text = prod.C_unidad;
                        }
                    }
                }
            }
            


        }
        private void CallRecursive(TreeView treeView, string selector)
        {
            // Print each node recursively.  
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                PrintRecursive(n, selector);
            }
        }
        private void PrintRecursive(TreeNode treeNode, string selector)
        {
            // Print the node.  
            System.Diagnostics.Debug.WriteLine(treeNode.Text);
            if (treeNode.Tag.ToString() == selector)
            {
                tvGrupos.SelectedNode = treeNode;
            }
            //MessageBox.Show(treeNode.Text);
            // Print each node recursively.  
            foreach (TreeNode tn in treeNode.Nodes)
            {
                PrintRecursive(tn, selector);
            }
        }
        public void carga_marcas()
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
            Models.Marcas marca = new Models.Marcas();
            using (marca)
            {
                List<Models.Marcas> result = marca.getMarcas();
                foreach (Models.Marcas item in result)
                {
                    row = table.NewRow();
                    row["Text"] = item.Marca;
                    row["Value"] = item.Id;
                    table.Rows.Add(row);
                }
            }

            cboMarca.BindingContext = new BindingContext();
            cboMarca.DataSource = table;
            cboMarca.DisplayMember = "Text";
            cboMarca.ValueMember = "Value";
            cboMarca.BindingContext = new BindingContext();
        }
        public void generarNodes(int parentId, TreeNode parentNode)
        {
            Models.Groups grupo = new Models.Groups();
            using (grupo)
            {
                List<Models.Groups> sub = grupo.getSubgrups(parentId);
                TreeNode childNode;
                foreach (Models.Groups item in sub)
                {
                    if (parentNode == null)
                    {
                        childNode = tvGrupos.Nodes.Add(item.Group);
                        childNode.Tag = item.Id.ToString();
                        childNode.ImageIndex = 0;
                    }
                    else
                    {
                        childNode = parentNode.Nodes.Add(item.Group);
                        childNode.Tag = item.Id.ToString();
                        childNode.ImageIndex = 0;
                        generarNodes(item.Id, childNode);
                    }
                }
            }

        }
        public void carga_grupos()
        {
            tvGrupos.Nodes.Clear();
            tvGrupos.ImageList = imageList1;
            tvGrupos.SelectedImageIndex = 1;

            Models.Groups grupos = new Models.Groups();
            using (grupos)
            {
                List<Models.Groups> grupo = grupos.getGroupsonly();
                foreach (Models.Groups item in grupo)
                {
                    TreeNode nodo = new TreeNode(item.Group.ToString());
                    nodo.Tag = item.Id.ToString();
                    nodo.ImageIndex = 0;
                    tvGrupos.Nodes.Add(nodo);

                    generarNodes(item.Id, nodo);
                }
            }

            tvGrupos.ExpandAll();
        }
        private bool validar()
        {
            bool validador = true;
            if (txtUbicacion.Text == "")
			{
                validador = false;
                errorProvider1.SetError(txtUbicacion, "Ingrese ubicacion del producto");
            }
            if (txtDescripcion.Text == "")
            {
                validador = false;
                errorProvider1.SetError(txtDescripcion, "Ingrese descripcion del producto");
            }
            if (txtCodigo1.Text == "")
            {
                validador = false;
                errorProvider1.SetError(txtCodigo1, "Ingrese codigo del producto");
            }
            if (txtPrice1.Text == "" || txtPrice1.Text == "0.00")
            {
                validador = false;
                errorProvider1.SetError(txtPrice1, "Ingrese precio del producto");
            }
            if (txtPercentPrice1.Text == "0.00")
            {
                validador = false;
                errorProvider1.SetError(txtPercentPrice1, "Ingrese porcentaje de utilidad del producto");
            }

            if (txtCosto.Text == "" || txtCosto.Text == "0.00")
            {
				validador = false;
                errorProvider1.SetError(txtCosto, "Ingrese costo del producto");
            }
            if (txtdias.Text == "")
            {
                validador = false;
                errorProvider1.SetError(txtdias, "Ingrese dias de alerta del producto");
            }
            if (txtProveedor.Text == "")
			{
                validador= false;
                errorProvider1.SetError(txtProveedor, "Ingrese a que proveedor pertecene el producto");
            }
            if (chkCaja.Checked == true)
            {
                if (txtCodigoCaja.Text == "")
                {
                    validador = false;
                    errorProvider1.SetError(txtCodigoCaja, "Ingrese codigo de caja del producto");
                }
                if (txtDescripcionCaja.Text == "")
                {
                    validador = false;
                    errorProvider1.SetError(txtDescripcionCaja, "Ingrese descripcion de caja del producto");
                }
                if (txtPCaja.Text == "" || txtPCaja.Text == "0.00")
                {
                    validador = false;
                    errorProvider1.SetError(txtPCaja, "Ingrese precio de caja del producto");
                }
                if (txtCostoCaja.Text == "" || txtCostoCaja.Text == "0.00")
                {
                    validador = false;
                    errorProvider1.SetError(txtCostoCaja, "Ingrese costo de caja del producto");
                }
                if (txtUtilidad1C.Text == "0.00")
                {
                    validador = false;
                    errorProvider1.SetError(txtUtilidad1C, "Ingrese utilidad de caja del producto");
                }
                if (txtPrecio1C.Text == "0.00")
                {
                    validador = false;
                    errorProvider1.SetError(txtPrecio1C, "Ingrese precio de caja del producto");
                }
                if (max_p1.Value == 0)
                {
                    validador = false;
                    errorProvider1.SetError(max_p1, "Ingrese maximo de precio de caja del producto");
                }
            }
            if (chkCarton.Checked == true)
            {
                if (txtCodigoCarton.Text == "")
                {
                    validador = false;
                    errorProvider1.SetError(txtCodigoCarton, "Ingrese codigo de carton del producto");
                }
                if (txtDescripcionCarton.Text == "")
                {
                    validador = false;
                    errorProvider1.SetError(txtDescripcionCarton, "Ingrese descripcion de carton del producto");
                }
                if (txtp_carton.Text == "" || txtp_carton.Text == "0.00")
                {
                    validador = false;
                    errorProvider1.SetError(txtp_carton, "Ingrese precio de carton del producto");
                }
                if (txtCostoCarton.Text == "" || txtCostoCarton.Text == "0.00")
                {
                    validador = false;
                    errorProvider1.SetError(txtCostoCarton, "Ingrese costo de carton del producto");
                }
                if (txtUtilidad1Ct.Text == "0.00")
                {
                    validador = false;
                    errorProvider1.SetError(txtUtilidad1Ct, "Ingrese utilidad de carton del producto");
                }
                if (txtPrecio1Ct.Text == "0.00")
                {
                    validador = false;
                    errorProvider1.SetError(txtPrecio1Ct, "Ingrese precio de carton del producto");
                }
                if (max_p1ct.Value == 0)
                {
                    validador = false;
                    errorProvider1.SetError(max_p1ct, "Ingrese maximo de precio de carton del producto");
                }
            }
            return validador;
        }
        public void carga_box()
        {

            if (SubProducto != null)
            {
                if (connectionstring2 != "")
				{
                    Models.Product sub = new Models.Product();
                    using (sub)
                    {
                        List<Models.Product> item = sub.getProduct(Convert.ToInt32(SubProducto));
                        if (item.Any() == true)
                        {
                            chkCarton.Checked = true;
                            foreach (Models.Product prod in item)
                            {
                                SubSubProducto = prod.Id.ToString();
                                txtCodigoCarton.Text = prod.Code1;
                                txtSkuCarton.Text = prod.Sku;
                                txtDescripcionCarton.Text = prod.Description;
                                txtCostoCarton.Text = prod.Cost.ToString();
                                txtUtilidad1Ct.Text = prod.Utility1.ToString();
                                txtUtilidad2Ct.Text = prod.Utility2.ToString();
                                txtUtilidad3Ct.Text = prod.Utility3.ToString();

                                txtPrecio1Ct.Text = prod.Price1.ToString();
                                txtPrecio2Ct.Text = prod.Price2.ToString();
                                txtPrecio3Ct.Text = prod.Price3.ToString();
                                max_p1ct.Value = Convert.ToDecimal(prod.Max_p1);
                                max_p2ct.Value = Convert.ToDecimal(prod.Max_p2);
                                max_p3ct.Value = Convert.ToDecimal(prod.Max_p3);
                                txtp_carton.Text = prod.C_unidad;
                            }
                        }
                    }
				}
				else
				{
                    intercambios.conector = connectionstring2;
                    Models.Produc_suc sub = new Models.Produc_suc();
                    using (sub)
                    {
                        List<Models.Produc_suc> item = sub.getProduct(Convert.ToInt32(SubProducto));
                        if (item.Any() == true)
                        {
                            chkCarton.Checked = true;
                            foreach (Models.Produc_suc prod in item)
                            {
                                SubSubProducto = prod.Id.ToString();
                                txtCodigoCarton.Text = prod.Code1;
                                txtSkuCarton.Text = prod.Sku;
                                txtDescripcionCarton.Text = prod.Description;
                                txtCostoCarton.Text = prod.Cost.ToString();
                                txtUtilidad1Ct.Text = prod.Utility1.ToString();
                                txtUtilidad2Ct.Text = prod.Utility2.ToString();
                                txtUtilidad3Ct.Text = prod.Utility3.ToString();

                                txtPrecio1Ct.Text = prod.Price1.ToString();
                                txtPrecio2Ct.Text = prod.Price2.ToString();
                                txtPrecio3Ct.Text = prod.Price3.ToString();
                                max_p1ct.Value = Convert.ToDecimal(prod.Max_p1);
                                max_p2ct.Value = Convert.ToDecimal(prod.Max_p2);
                                max_p3ct.Value = Convert.ToDecimal(prod.Max_p3);
                                txtp_carton.Text = prod.C_unidad;
                            }
                        }
                    }
                }
            }
        }

        private void combobox_popular()
		{
            
            Models.Providers proveedores = new Models.Providers();
			using (proveedores)
			{
                int i = 1;
                List<Models.Providers> proveedor = proveedores.getProviders();
                cbproveedor.ValueMember = "Id";
                cbproveedor.DisplayMember = "Name";
                cbproveedor.DataSource = proveedor;
            }
        }
        private void Producto_Load(object sender, EventArgs e)
		{

            Models.Permisos permisos = new Models.Permisos();
			using (permisos)
			{
                List<Models.Permisos> permiso = permisos.getPermiso(Convert.ToInt32(Inicial.id_usario));
                if (Convert.ToBoolean(permiso[0].Cam_precio) == false)
				{
                    groupBox1.Enabled = false;
                }
			}
            


            combobox_popular();
            txtCodigo.AutoCompleteCustomSource = cargadatos();
            txtCodigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCodigo.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtDes.AutoCompleteCustomSource = cargadatos2();
            txtDes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtDes.AutoCompleteSource = AutoCompleteSource.CustomSource;


            max_p1.DecimalPlaces = 2;
            max_p1.ThousandsSeparator = true;

            max_p2.DecimalPlaces = 2;
            max_p2.ThousandsSeparator = true;

            max_p3.DecimalPlaces = 2;
            max_p3.ThousandsSeparator = true;


            max_p4.DecimalPlaces = 2;
            max_p4.ThousandsSeparator = true;

            max_p5.DecimalPlaces = 2;
            max_p5.ThousandsSeparator = true;



            max_p1c.DecimalPlaces = 2;
            max_p1c.ThousandsSeparator = true;

            max_p2c.DecimalPlaces = 2;
            max_p2c.ThousandsSeparator = true;

            max_p3c.DecimalPlaces = 2;
            max_p3c.ThousandsSeparator = true;


            max_p1ct.DecimalPlaces = 2;
            max_p1ct.ThousandsSeparator = true;


            max_p2ct.DecimalPlaces = 2;
            max_p2ct.ThousandsSeparator = true;

            max_p3ct.DecimalPlaces = 2;
            max_p3ct.ThousandsSeparator = true;
            carga_marcas();
            carga_grupos();

           

            DataTable table = new DataTable();
            DataRow row;

            table.Columns.Add("Text", typeof(string));
            table.Columns.Add("Value", typeof(string));

            row = table.NewRow();
            row["Text"] = "";
            row["Value"] = "";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Text"] = "Pieza";
            row["Value"] = "PZAS";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Text"] = "Kilogramo";
            row["Value"] = "KG";
            table.Rows.Add(row);

            cboUnidad.BindingContext = new BindingContext();

            cboUnidad.DataSource = table;

            cboUnidad.DisplayMember = "Text";

            cboUnidad.ValueMember = "Value";
            cboUnidad.BindingContext = new BindingContext();



            cboVenta.Items.Add("EXENTO IMPUESTOS");
            cboVenta.Items.Add("IVA 11");
            cboVenta.Items.Add("IVA 16");
            cboVenta.Items.Add("IVA TASA CERO");


            cboCompra.Items.Add("EXENTO IMPUESTOS");
            cboCompra.Items.Add("IVA 11");
            cboCompra.Items.Add("IVA 16");
            cboCompra.Items.Add("IVA TASA CERO");




            cboVenta.SelectedIndex = 2;
            cboCompra.SelectedIndex = 2;
            if (Codigo != "")
            {
                if (connectionstring2 != "")
				{
                    Models.Product product = new Models.Product();

                    List<Models.Product> result = product.getProductById(Convert.ToInt32(Codigo));

                    foreach (Models.Product item in result)
                    {
                        txtCodigo1.Text = item.Code1;
                        txtCodigo2.Text = item.Code2;
                        txtCodigo3.Text = item.Code3;
                        txtCodigo4.Text = item.Code4;
                        txtCodigo5.Text = item.Code5;
                        txtDescripcion.Text = item.Description;
                        txtCosto.Text = item.Cost.ToString();
                        txtPercentPrice1.Text = item.Utility1.ToString();
                        txtPercentPrice2.Text = item.Utility2.ToString();
                        txtPercentPrice3.Text = item.Utility3.ToString();
                        txtPercentPrice4.Text = item.Utility4.ToString();
                        txtPercentPrice5.Text = item.Utility5.ToString();
                        txtPrice1.Text = item.Price1.ToString();
                        txtPrice2.Text = item.Price2.ToString();
                        txtPrice3.Text = item.Price3.ToString();
                        txtPrice4.Text = item.Price4.ToString();
                        txtPrice5.Text = item.Price5.ToString();
                        precio1 = item.Price1;
                        precio2 = item.Price2;
                        precio3 = item.Price3;
                        precio4 = item.Price4;
                        precio5 = item.Price5;


                        txtExistencia.Text = item.Existencia.ToString();
                        txtDevoluciones.Text = item.Devoluciones.ToString();
                        cboMarca.SelectedValue = item.Brand;
                        chkActivo.Checked = Convert.ToBoolean(item.Active);
                        CallRecursive(tvGrupos, item.Group);


                        cboUnidad.SelectedValue = item.Unit;
                        txtSAT.Text = item.Code_sat;
                        txtUnidadSat.Text = item.Medida_sat;
                        txtMinimo.Text = item.Min.ToString();
                        txtMaximo.Text = item.Max.ToString();
                        chkDescuento.Checked = Convert.ToBoolean(item.Discount);
                        txtDescuento.Text = item.Mount_discount.ToString();

                        if (Convert.ToBoolean(item.Discount) == true)
                        {
                            txtDescuento.Enabled = false;
                        }
                        else
                        {
                            txtDescuento.Enabled = true;
                        }
                        chkLote.Checked = Convert.ToBoolean(item.Lote);
                        max_p1.Value = Convert.ToDecimal(item.Max_p1);
                        max_p2.Value = Convert.ToDecimal(item.Max_p2);
                        max_p3.Value = Convert.ToDecimal(item.Max_p3);
                        max_p4.Value = Convert.ToDecimal(item.Max_p4);
                        max_p5.Value = Convert.ToDecimal(item.Max_p5);
                        txtdias.Text = item.Dias_alerta.ToString();
                        txtProveedor.Text = item.Proveedor.ToString();
                        chkGrupal.Checked = item.Grupal;



                        switch (item.Buy_tax)
                        {
                            case "EXENTO IMPUESTOS":
                                cboCompra.SelectedIndex = 0;
                                break;
                            case "IVA 11":
                                cboCompra.SelectedIndex = 1;
                                break;

                            case "IVA 16":
                                cboCompra.SelectedIndex = 2;
                                break;
                            case "IVA TASA CERO":
                                cboCompra.SelectedIndex = 3;
                                break;
                        }


                        switch (item.Sale_tax)
                        {
                            case "EXENTO IMPUESTOS":
                                cboVenta.SelectedIndex = 0;
                                break;
                            case "IVA 11":
                                cboVenta.SelectedIndex = 1;
                                break;

                            case "IVA 16":
                                cboVenta.SelectedIndex = 2;
                                break;
                            case "IVA TASA CERO":
                                cboVenta.SelectedIndex = 3;
                                break;
                        }
                        txtNotas.Text = item.Notas;
                        carga_pack(Convert.ToUInt16(Codigo));
                        carga_box();
                        carga_kardex();
                        carga_costos();
                        txtUbicacion.Text = item.Ubicacion;
                        chkIva.Checked = item.Iva_incluido;

                        if (item.Grupal == true)
                        {
                            Models.Acumulados acumulados = new Models.Acumulados();

                            using (acumulados)
                            {
                                List<Models.Acumulados> acumulado = acumulados.get_acumulados(item.Id);
                                foreach (Models.Acumulados it in acumulado)
                                {
                                    List<Models.Product> productos2 = product.getProductById(it.Id_producto);
                                    dtProducto.Rows.Add(it.Id_producto, productos2[0].Code1, it.Cantidad, productos2[0].Description);
                                }

                            }
                        }
                    }
				}
				else
				{
                    intercambios.conector = connectionstring2;
                    Models.Produc_suc product = new Models.Produc_suc();

                    List<Models.Produc_suc> result = product.getProductById(Convert.ToInt32(Codigo));

                    foreach (Models.Produc_suc item in result)
                    {
                        txtCodigo1.Text = item.Code1;
                        txtCodigo2.Text = item.Code2;
                        txtCodigo3.Text = item.Code3;
                        txtCodigo4.Text = item.Code4;
                        txtCodigo5.Text = item.Code5;
                        txtDescripcion.Text = item.Description;
                        txtCosto.Text = item.Cost.ToString();
                        txtPercentPrice1.Text = item.Utility1.ToString();
                        txtPercentPrice2.Text = item.Utility2.ToString();
                        txtPercentPrice3.Text = item.Utility3.ToString();
                        txtPercentPrice4.Text = item.Utility4.ToString();
                        txtPercentPrice5.Text = item.Utility5.ToString();
                        txtPrice1.Text = item.Price1.ToString();
                        txtPrice2.Text = item.Price2.ToString();
                        txtPrice3.Text = item.Price3.ToString();
                        txtPrice4.Text = item.Price4.ToString();
                        txtPrice5.Text = item.Price5.ToString();
                        txtExistencia.Text = item.Existencia.ToString();
                        txtDevoluciones.Text = item.Devoluciones.ToString();
                        cboMarca.SelectedValue = item.Brand;
                        chkActivo.Checked = Convert.ToBoolean(item.Active);
                        CallRecursive(tvGrupos, item.Group);


                        cboUnidad.SelectedValue = item.Unit;
                        txtSAT.Text = item.Code_sat;
                        txtUnidadSat.Text = item.Medida_sat;
                        txtMinimo.Text = item.Min.ToString();
                        txtMaximo.Text = item.Max.ToString();
                        chkDescuento.Checked = Convert.ToBoolean(item.Discount);
                        txtDescuento.Text = item.Mount_discount.ToString();

                        if (Convert.ToBoolean(item.Discount) == true)
                        {
                            txtDescuento.Enabled = false;
                        }
                        else
                        {
                            txtDescuento.Enabled = true;
                        }
                        chkLote.Checked = Convert.ToBoolean(item.Lote);
                        max_p1.Value = Convert.ToDecimal(item.Max_p1);
                        max_p2.Value = Convert.ToDecimal(item.Max_p2);
                        max_p3.Value = Convert.ToDecimal(item.Max_p3);
                        max_p4.Value = Convert.ToDecimal(item.Max_p4);
                        max_p5.Value = Convert.ToDecimal(item.Max_p5);
                        txtdias.Text = item.Dias_alerta.ToString();
                        txtProveedor.Text = item.Proveedor.ToString();
                        chkGrupal.Checked = item.Grupal;



                        switch (item.Buy_tax)
                        {
                            case "EXENTO IMPUESTOS":
                                cboCompra.SelectedIndex = 0;
                                break;
                            case "IVA 11":
                                cboCompra.SelectedIndex = 1;
                                break;

                            case "IVA 16":
                                cboCompra.SelectedIndex = 2;
                                break;
                            case "IVA TASA CERO":
                                cboCompra.SelectedIndex = 3;
                                break;
                        }


                        switch (item.Sale_tax)
                        {
                            case "EXENTO IMPUESTOS":
                                cboVenta.SelectedIndex = 0;
                                break;
                            case "IVA 11":
                                cboVenta.SelectedIndex = 1;
                                break;

                            case "IVA 16":
                                cboVenta.SelectedIndex = 2;
                                break;
                            case "IVA TASA CERO":
                                cboVenta.SelectedIndex = 3;
                                break;
                        }
                        carga_pack(Convert.ToUInt16(Codigo));
                        carga_box();
                        carga_kardex();


                        if (item.Grupal == true)
                        {
                            Models.Acumulados acumulados = new Models.Acumulados();

                            using (acumulados)
                            {
                                List<Models.Acumulados> acumulado = acumulados.get_acumulados(item.Id);
                                foreach (Models.Acumulados it in acumulado)
                                {
                                    List<Models.Produc_suc> productos2 = product.getProductById(it.Id_producto);
                                    dtProducto.Rows.Add(it.Id_producto, productos2[0].Code1, it.Cantidad, productos2[0].Description);
                                }

                            }
                        }
                    }
                }
                


            }
        }

		private AutoCompleteStringCollection cargadatos2()
		{
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            Models.Product producto = new Models.Product();
            using (producto)
            {
                List<Models.Product> result = producto.getProducts();
                foreach (Models.Product item in result)
                {
                    datos.Add(item.Description);
                }
                return datos;
            }
        }

		private AutoCompleteStringCollection cargadatos()
		{
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            Models.Product producto = new Models.Product();
            using (producto)
            {
                List<Models.Product> result = producto.getProducts();
                foreach (Models.Product item in result)
                {
                    datos.Add(item.Code1);
                }
                return datos;
            }
        }

		private void butSave_Click(object sender, EventArgs e)
        {
            string grupo = "";
            if (tvGrupos.SelectedNode != null)
            {
                grupo = tvGrupos.SelectedNode.Tag.ToString();
            }
            if (validar() == false)
            {
                MessageBox.Show("debe de ingresar los datos minimos para guardar un produto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string marca;
                string unidad;



                if (cboMarca.SelectedIndex != 0 && cboMarca.SelectedValue != null)
                {
                    marca = cboMarca.SelectedValue.ToString();
                }
                else
                {
                    marca = "";
                }

                if (cboUnidad.SelectedIndex != 0)
                {
                    unidad = cboUnidad.SelectedValue.ToString();
                }
                else
                {
                    unidad = "";
                }

                if (connectionstring2 != "")
				{
                    Models.Product product = new Models.Product(
                0,
                txtDescripcion.Text,
                txtCodigo1.Text,
                txtCodigo2.Text,
                txtCodigo3.Text,
                txtCodigo4.Text,
                txtCodigo5.Text,
                0,
                0,
                grupo,
                marca,
                unidad,
                Convert.ToDouble(txtPrice1.Text),
                Convert.ToDouble(txtPrice2.Text),
                Convert.ToDouble(txtPrice3.Text),
                Convert.ToDouble(txtPrice4.Text),
                Convert.ToDouble(txtPrice5.Text),
                Convert.ToDouble(txtPercentPrice1.Text),
                Convert.ToDouble(txtPercentPrice2.Text),
                Convert.ToDouble(txtPercentPrice3.Text),
                Convert.ToDouble(txtPercentPrice4.Text),
                Convert.ToDouble(txtPercentPrice5.Text),
                Convert.ToDouble(txtCosto.Text),
                Convert.ToUInt16(true),
                txtSAT.Text,
                txtSKU.Text,
                txtUnidadSat.Text,
                cboVenta.SelectedItem.ToString(),
                cboCompra.SelectedItem.ToString(),
                Convert.ToUInt16(chkDescuento.Checked),
                Convert.ToUInt16(txtDescuento.Text),
                Convert.ToUInt16(txtMinimo.Text),
                Convert.ToUInt16(txtMaximo.Text),
                "0",
                "0",
                Convert.ToUInt16(txtdias.Text),
                Convert.ToUInt16(chkLote.Checked),
                Convert.ToDouble(max_p1.Value),
                Convert.ToDouble(max_p2.Value),
                Convert.ToDouble(max_p3.Value),
                Convert.ToDouble(max_p4.Value),
                Convert.ToDouble(max_p5.Value),
                Convert.ToInt16(txtProveedor.Text),
                chkGrupal.Checked,
                txtNotas.Text,
                txtUbicacion.Text,
                chkIva.Checked
                ) ;
                    product.Active = Convert.ToInt16(chkActivo.Checked);
                    if (Codigo == "")
                    {

                        product.createProduct();
                        if (precio1 != Convert.ToDouble(txtPrice1.Text) || precio2 != Convert.ToDouble(txtPrice2.Text) || precio3 != Convert.ToDouble(txtPrice3.Text) || precio4 != Convert.ToDouble(txtPrice4.Text)  || precio5 != Convert.ToDouble(txtPrice5.Text))
						{
                            Models.Log historia = new Models.Log();
                            using (historia)
                            {

                                historia.Id_usuario = Convert.ToInt32(Inicial.id_usario);
                                if (precio1 != Convert.ToDouble(txtPrice1.Text))
                                {
                                    historia.Descripcion = "cambio de precio en el producto " + txtDescripcion.Text + " con clave " + txtCodigo1.Text + ",  de $" + precio1 +" a $"+txtPrice1.Text;
                                    historia.createLog();
                                }
                                if (precio2 != Convert.ToDouble(txtPrice2.Text))
                                {
                                    historia.Descripcion = "cambio de precio en el producto " + txtDescripcion.Text + " con clave " + txtCodigo1.Text + ",  de $" + precio2 + " a $" + txtPrice2.Text;
                                    historia.createLog();
                                }
                                if (precio3 != Convert.ToDouble(txtPrice3.Text))
                                {
                                    historia.Descripcion = "cambio de precio en el producto " + txtDescripcion.Text + " con clave " + txtCodigo1.Text + ",  de $" + precio3 + " a $" + txtPrice3.Text;
                                    historia.createLog();
                                }
                                if (precio4 != Convert.ToDouble(txtPrice4.Text))
                                {
                                    historia.Descripcion = "cambio de precio en el producto " + txtDescripcion.Text + " con clave " + txtCodigo1.Text + ",  de $" + precio4 + " a $" + txtPrice4.Text;
                                    historia.createLog();
                                }
                                if (precio5 != Convert.ToDouble(txtPrice5.Text))
                                {
                                    historia.Descripcion = "cambio de precio en el producto " + txtDescripcion.Text + " con clave " + txtCodigo1.Text + ",  de $" + precio5 + " a $" + txtPrice5.Text;
                                    historia.createLog();
                                }
                            }
                        }
                       

                        List<Models.Product> result = product.getProductByCode(txtCodigo1.Text);
                        foreach (Models.Product item in result)
                        {
                            Codigo = item.Id.ToString();
                        }

                        Models.prov_prod relacion = new Models.prov_prod();
						using (relacion)
						{
                            foreach(DataGridViewRow row in dtCostos.Rows)
							{
                                if (row.Cells["cbproveedor"].Value is null)
                                {

                                }
                                else
                                {
                                    relacion.Id_producto = Convert.ToInt32(Codigo);
                                    relacion.Id_proveedor = Convert.ToInt32(row.Cells["cbproveedor"].Value.ToString());
                                    relacion.Costo = Convert.ToDouble(row.Cells["costo"].Value.ToString());
                                    relacion.Cantidad = 0;
                                    relacion.create();
                                }

                            }
						}


                    }
                    else
                    {

                        product.Id = Convert.ToInt32(Codigo);
                        product.saveProduct();

                        Models.prov_prod relacion = new Models.prov_prod();
                        using (relacion)
                        {
                            relacion.Id_producto = Convert.ToInt32(Codigo);
                            relacion.delete();
                            foreach (DataGridViewRow row in dtCostos.Rows)
                            {
                                if (row.Cells["cbproveedor"].Value is null)
								{

								}
								else
								{
                                    relacion.Id_producto = Convert.ToInt32(Codigo);
                                    relacion.Id_proveedor = Convert.ToInt32(row.Cells["cbproveedor"].Value.ToString());
                                    relacion.Costo = Convert.ToDouble(row.Cells["costo"].Value.ToString());
                                    relacion.Cantidad = 0;
                                    relacion.create();
                                }
                                

                            }
                        }

                    }

                    if (chkCaja.Checked == true)
                    {

                        Models.Product subproduct = new Models.Product(
                        0,
                        txtDescripcionCaja.Text,
                        txtCodigoCaja.Text,
                        "",
                        "",
                        "",
                        "",
                        0,
                        0,
                        tvGrupos.SelectedNode.Tag.ToString(),
                        cboMarca.SelectedValue.ToString(),
                        cboUnidad.SelectedValue.ToString(),
                        Convert.ToDouble(txtPrecio1C.Text),
                        Convert.ToDouble(txtPrecio2C.Text),
                        Convert.ToDouble(txtPrecio3C.Text),
                        Convert.ToDouble("0"),
                        Convert.ToDouble("0"),
                        Convert.ToDouble(txtUtilidad1C.Text),
                        Convert.ToDouble(txtUtilidad2C.Text),
                        Convert.ToDouble(txtUtilidad3C.Text),
                        Convert.ToDouble("0"),
                        Convert.ToDouble("0"),
                        Convert.ToDouble(txtCostoCaja.Text),
                        Convert.ToUInt16(true),
                        txtSAT.Text,
                        txtSkuCaja.Text,
                        txtUnidadSat.Text,
                        cboVenta.SelectedItem.ToString(),
                        cboCompra.SelectedItem.ToString(),
                        Convert.ToUInt16("0"),
                        Convert.ToUInt16("0"),
                        Convert.ToUInt16("0"),
                        Convert.ToUInt16("0"),
                        Codigo.ToString(),
                        txtPCaja.Text,
                        Convert.ToUInt16(txtdias.Text),
                        Convert.ToUInt16(chkLote.Checked),
                        Convert.ToDouble(max_p1c.Value),
                        Convert.ToDouble(max_p2c.Value),
                        Convert.ToDouble(max_p3c.Value),
                        0,
                        0,
                        Convert.ToInt16(txtProveedor.Text),
                        false,
                        "",
                        txtUbicacion.Text,
                        chkIva.Checked
                        );
                        subproduct.Active = Convert.ToInt16(chkActivo.Checked);
                        if (Codigo == "")
                        {

                            subproduct.createProduct();
                            List<Models.Product> result = product.getProductByCode(txtCodigo1.Text);
                            foreach (Models.Product item in result)
                            {
                                SubProducto = item.Id.ToString();
                            }


                        }
                        else
                        {

                            subproduct.Id = Convert.ToInt16(SubProducto);
                            subproduct.saveProduct();


                        }




                    }
                    if (chkCarton.Checked == true)
                    {
                        Models.Product subsub = new Models.Product(
                           0,
                           txtDescripcionCarton.Text,
                           txtCodigoCarton.Text,
                           "",
                           "",
                           "",
                           "",
                           0,
                           0,
                           grupo,
                           cboMarca.SelectedValue.ToString(),
                           cboUnidad.SelectedValue.ToString(),
                           Convert.ToDouble(txtPrecio1Ct.Text),
                           Convert.ToDouble(txtPrecio2Ct.Text),
                           Convert.ToDouble(txtPrecio3Ct.Text),
                           Convert.ToDouble("0"),
                           Convert.ToDouble("0"),
                           Convert.ToDouble(txtUtilidad1Ct.Text),
                           Convert.ToDouble(txtUtilidad2Ct.Text),
                           Convert.ToDouble(txtUtilidad3Ct.Text),
                           Convert.ToDouble("0"),
                           Convert.ToDouble("0"),
                           Convert.ToDouble(txtCostoCarton.Text),
                           Convert.ToUInt16(true),
                           txtSAT.Text,
                           txtSkuCarton.Text,
                           txtUnidadSat.Text,
                           cboVenta.SelectedItem.ToString(),
                           cboCompra.SelectedItem.ToString(),
                           Convert.ToUInt16("0"),
                           Convert.ToUInt16("0"),
                           Convert.ToUInt16("0"),
                           Convert.ToUInt16("0"),
                           SubProducto.ToString(),
                           txtp_carton.Text,
                           Convert.ToUInt16(txtdias.Text),
                           Convert.ToUInt16(chkLote.Checked),
                           Convert.ToDouble(max_p1ct.Value),
                           Convert.ToDouble(max_p2ct.Value),
                           Convert.ToDouble(max_p3ct.Value),
                           0,
                           0,
                           Convert.ToInt16(txtProveedor.Text),
                           false,
                           "",
                           txtUbicacion.Text,
                           chkIva.Checked
                           );
                        subsub.Active = Convert.ToInt16(chkActivo.Checked);
                        if (Codigo == "")
                        {

                            subsub.createProduct();


                        }
                        else
                        {

                            subsub.Id = Convert.ToInt16(SubSubProducto);
                            subsub.saveProduct();


                        }

                    }


                    List<Models.Product> result2 = product.getProductByCode(txtCodigo1.Text);
                    Models.Acumulados acumulados = new Models.Acumulados();
                    using (acumulados)
                    {

                        acumulados.Id_master_product = result2[0].Id;
                        acumulados.delete_acumulados();
                        foreach (DataGridViewRow row in dtProducto.Rows)
                        {
                            acumulados.Id_producto = Convert.ToInt32(row.Cells["id_producto"].Value.ToString());
                            acumulados.Cantidad = Convert.ToDouble(row.Cells["cantidad_producto"].Value.ToString());
                            acumulados.create_acumulado();
                        }

                    }
                }
				else
				{
                    intercambios.conector = connectionstring2;
                    Models.Produc_suc product = new Models.Produc_suc(
                0,
                txtDescripcion.Text,
                txtCodigo1.Text,
                txtCodigo2.Text,
                txtCodigo3.Text,
                txtCodigo4.Text,
                txtCodigo5.Text,
                0,
                0,
                grupo,
                marca,
                unidad,
                Convert.ToDouble(txtPrice1.Text),
                Convert.ToDouble(txtPrice2.Text),
                Convert.ToDouble(txtPrice3.Text),
                Convert.ToDouble(txtPrice4.Text),
                Convert.ToDouble(txtPrice5.Text),
                Convert.ToDouble(txtPercentPrice1.Text),
                Convert.ToDouble(txtPercentPrice2.Text),
                Convert.ToDouble(txtPercentPrice3.Text),
                Convert.ToDouble(txtPercentPrice4.Text),
                Convert.ToDouble(txtPercentPrice5.Text),
                Convert.ToDouble(txtCosto.Text),
                Convert.ToUInt16(true),
                txtSAT.Text,
                txtSKU.Text,
                txtUnidadSat.Text,
                cboVenta.SelectedItem.ToString(),
                cboCompra.SelectedItem.ToString(),
                Convert.ToUInt16(chkDescuento.Checked),
                Convert.ToUInt16(txtDescuento.Text),
                Convert.ToUInt16(txtMinimo.Text),
                Convert.ToUInt16(txtMaximo.Text),
                "0",
                "0",
                Convert.ToUInt16(txtdias.Text),
                Convert.ToUInt16(chkLote.Checked),
                Convert.ToDouble(max_p1.Value),
                Convert.ToDouble(max_p2.Value),
                Convert.ToDouble(max_p3.Value),
                Convert.ToDouble(max_p4.Value),
                Convert.ToDouble(max_p5.Value),
                Convert.ToInt16(txtProveedor.Text),
                chkGrupal.Checked
                );
                    product.Active = Convert.ToInt16(chkActivo.Checked);
                    if (Codigo == "")
                    {

                        product.createProduct();
                        List<Models.Produc_suc> result = product.getProductByCode(txtCodigo1.Text);
                        foreach (Models.Produc_suc item in result)
                        {
                            Codigo = item.Id.ToString();
                        }


                    }
                    else
                    {

                        product.Id = Convert.ToInt32(Codigo);
                        product.saveProduct();


                    }

                    if (chkCaja.Checked == true)
                    {

                        Models.Produc_suc subproduct = new Models.Produc_suc(
                        0,
                        txtDescripcionCaja.Text,
                        txtCodigoCaja.Text,
                        "",
                        "",
                        "",
                        "",
                        0,
                        0,
                        tvGrupos.SelectedNode.Tag.ToString(),
                        cboMarca.SelectedValue.ToString(),
                        cboUnidad.SelectedValue.ToString(),
                        Convert.ToDouble(txtPrecio1C.Text),
                        Convert.ToDouble(txtPrecio2C.Text),
                        Convert.ToDouble(txtPrecio3C.Text),
                        Convert.ToDouble("0"),
                        Convert.ToDouble("0"),
                        Convert.ToDouble(txtUtilidad1C.Text),
                        Convert.ToDouble(txtUtilidad2C.Text),
                        Convert.ToDouble(txtUtilidad3C.Text),
                        Convert.ToDouble("0"),
                        Convert.ToDouble("0"),
                        Convert.ToDouble(txtCostoCaja.Text),
                        Convert.ToUInt16(true),
                        txtSAT.Text,
                        txtSkuCaja.Text,
                        txtUnidadSat.Text,
                        cboVenta.SelectedItem.ToString(),
                        cboCompra.SelectedItem.ToString(),
                        Convert.ToUInt16("0"),
                        Convert.ToUInt16("0"),
                        Convert.ToUInt16("0"),
                        Convert.ToUInt16("0"),
                        Codigo.ToString(),
                        txtPCaja.Text,
                        Convert.ToUInt16(txtdias.Text),
                        Convert.ToUInt16(chkLote.Checked),
                        Convert.ToDouble(max_p1c.Value),
                        Convert.ToDouble(max_p2c.Value),
                        Convert.ToDouble(max_p3c.Value),
                        0,
                        0,
                        Convert.ToInt16(txtProveedor.Text),
                        false
                        );
                        subproduct.Active = Convert.ToInt16(chkActivo.Checked);
                        if (Codigo == "")
                        {

                            subproduct.createProduct();
                            List<Models.Produc_suc> result = product.getProductByCode(txtCodigo1.Text);
                            foreach (Models.Produc_suc item in result)
                            {
                                SubProducto = item.Id.ToString();
                            }


                        }
                        else
                        {

                            subproduct.Id = Convert.ToInt16(SubProducto);
                            subproduct.saveProduct();


                        }




                    }
                    if (chkCarton.Checked == true)
                    {
                        Models.Produc_suc subsub = new Models.Produc_suc(
                           0,
                           txtDescripcionCarton.Text,
                           txtCodigoCarton.Text,
                           "",
                           "",
                           "",
                           "",
                           0,
                           0,
                           grupo,
                           cboMarca.SelectedValue.ToString(),
                           cboUnidad.SelectedValue.ToString(),
                           Convert.ToDouble(txtPrecio1Ct.Text),
                           Convert.ToDouble(txtPrecio2Ct.Text),
                           Convert.ToDouble(txtPrecio3Ct.Text),
                           Convert.ToDouble("0"),
                           Convert.ToDouble("0"),
                           Convert.ToDouble(txtUtilidad1Ct.Text),
                           Convert.ToDouble(txtUtilidad2Ct.Text),
                           Convert.ToDouble(txtUtilidad3Ct.Text),
                           Convert.ToDouble("0"),
                           Convert.ToDouble("0"),
                           Convert.ToDouble(txtCostoCarton.Text),
                           Convert.ToUInt16(true),
                           txtSAT.Text,
                           txtSkuCarton.Text,
                           txtUnidadSat.Text,
                           cboVenta.SelectedItem.ToString(),
                           cboCompra.SelectedItem.ToString(),
                           Convert.ToUInt16("0"),
                           Convert.ToUInt16("0"),
                           Convert.ToUInt16("0"),
                           Convert.ToUInt16("0"),
                           SubProducto.ToString(),
                           txtp_carton.Text,
                           Convert.ToUInt16(txtdias.Text),
                           Convert.ToUInt16(chkLote.Checked),
                           Convert.ToDouble(max_p1ct.Value),
                           Convert.ToDouble(max_p2ct.Value),
                           Convert.ToDouble(max_p3ct.Value),
                           0,
                           0,
                           Convert.ToInt16(txtProveedor.Text),
                           false
                           );
                        subsub.Active = Convert.ToInt16(chkActivo.Checked);
                        if (Codigo == "")
                        {

                            subsub.createProduct();


                        }
                        else
                        {

                            subsub.Id = Convert.ToInt16(SubSubProducto);
                            subsub.saveProduct();


                        }

                    }


                    List<Models.Produc_suc> result2 = product.getProductByCode(txtCodigo1.Text);
                    Models.Acumulados_suc acumulados = new Models.Acumulados_suc();
                    using (acumulados)
                    {

                        acumulados.Id_master_product = result2[0].Id;
                        acumulados.delete_acumulados();
                        foreach (DataGridViewRow row in dtProducto.Rows)
                        {
                            acumulados.Id_producto = Convert.ToInt32(row.Cells["id_producto"].Value.ToString());
                            acumulados.Cantidad = Convert.ToDouble(row.Cells["cantidad_producto"].Value.ToString());
                            acumulados.create_acumulado();
                        }

                    }
                }

                
                this.Close();
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPercentPrice1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPercentPrice1.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPercentPrice1_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPercentPrice1.Text) == 0.00)
            {
                txtPrice1.Text = "0.00";
                txtPercentPrice1.Text = "0.00";
            }
            else
            {
                double porcentaje = (1 - (Convert.ToDouble(txtPercentPrice1.Text) / 100));
                txtPrice1.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) / porcentaje));
            }
        }

        private void txtPrice1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrice1.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void txtPrice1_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrice1.Text) == 0.00)
            {
                txtPrice1.Text = "0.00";
                txtPercentPrice1.Text = "0.00";
            }
            else
            {

                /*double porcentaje = (1 - (Convert.ToDouble(txtPercentPrice1.Text) / 100));
                txtPrice1.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) / porcentaje));
                */

                double diferencia = (1 - (Convert.ToDouble(txtCosto.Text) / Convert.ToDouble(txtPrice1.Text))) * 100;
                txtPercentPrice1.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void txtPercentPrice2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPercentPrice2.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPercentPrice2_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPercentPrice2.Text) == 0.00)
            {
                txtPrice2.Text = "0.00";
                txtPercentPrice2.Text = "0.00";
            }
            else
            {
                double porcentaje = (1 - (Convert.ToDouble(txtPercentPrice2.Text) / 100));
                txtPrice2.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) / porcentaje));
            }
        }

        private void txtPrice2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrice2.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrice2_Leave(object sender, EventArgs e)
        {
            if (txtPrice2.Text == "")
            {
                txtPrice2.Text = "0.00";
            }
            if (Convert.ToDouble(txtPrice2.Text) == 0.00)
            {
                txtPrice2.Text = "0.00";
                txtPercentPrice2.Text = "0.00";
            }
            else
            {
                double diferencia = (1 - (Convert.ToDouble(txtCosto.Text) / Convert.ToDouble(txtPrice2.Text))) * 100;
                txtPercentPrice2.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void txtPercentPrice3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPercentPrice3.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPercentPrice3_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPercentPrice3.Text) == 0.00)
            {
                txtPrice3.Text = "0.00";
                txtPercentPrice3.Text = "0.00";
            }
            else
            {
                double porcentaje = (1 - (Convert.ToDouble(txtPercentPrice3.Text) / 100));
                txtPrice3.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) / porcentaje));
            }
        }

        private void txtPrice3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrice3.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrice3_Leave(object sender, EventArgs e)
        {
            if (txtPrice3.Text == "")
            {
                txtPrice2.Text = "0.00";
            }
            if (Convert.ToDouble(txtPrice3.Text) == 0.00)
            {
                txtPrice3.Text = "0.00";
                txtPercentPrice3.Text = "0.00";
            }
            else
            {
                double diferencia = (1 - (Convert.ToDouble(txtCosto.Text) / Convert.ToDouble(txtPrice3.Text))) * 100;
                txtPercentPrice3.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void txtPercentPrice4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPercentPrice4.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPercentPrice4_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPercentPrice4.Text) == 0.00)
            {
                txtPrice4.Text = "0.00";
                txtPercentPrice4.Text = "0.00";
            }
            else
            {
                double porcentaje = (1 - (Convert.ToDouble(txtPercentPrice4.Text) / 100));
                txtPrice4.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) / porcentaje));
            }
        }

        private void txtPrice4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrice4.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrice4_Leave(object sender, EventArgs e)
        {
            if (txtPrice4.Text == "")
            {
                txtPrice4.Text = "0.00";
            }
            if (Convert.ToDouble(txtPrice4.Text) == 0.00)
            {
                txtPrice4.Text = "0.00";
                txtPercentPrice4.Text = "0.00";
            }
            else
            {
                double diferencia = (1 - (Convert.ToDouble(txtCosto.Text) / Convert.ToDouble(txtPrice4.Text))) * 100;
                txtPercentPrice4.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void txtPercentPrice5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPercentPrice5.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPercentPrice5_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPercentPrice5.Text) == 0.00)
            {
                txtPrice5.Text = "0.00";
                txtPercentPrice5.Text = "0.00";
            }
            else
            {
                double porcentaje = (1 - (Convert.ToDouble(txtPercentPrice5.Text) / 100));
                txtPrice5.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) / porcentaje));
            }
        }

        private void txtPrice5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrice5.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrice5_Leave(object sender, EventArgs e)
        {
            if (txtPrice5.Text == "")
            {
                txtPrice5.Text = "0.00";
            }
            if (Convert.ToDouble(txtPrice5.Text) == 0.00)
            {
                txtPrice5.Text = "0.00";
                txtPercentPrice5.Text = "0.00";
            }
            else
            {
                double diferencia = (1 - (Convert.ToDouble(txtCosto.Text) / Convert.ToDouble(txtPrice5.Text))) * 100;
                txtPercentPrice5.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void txtSAT_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Busca_clave_SAT clave_sat = new Busca_clave_SAT();
            clave_sat.Owner = this;
            clave_sat.Show();
        }

        private void txtUnidadSat_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Busca_unidad_SAT unidad_Sat = new Busca_unidad_SAT();
            unidad_Sat.Owner = this;
            unidad_Sat.Show();
        }

        private void chkCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCaja.Checked == true)
            {
                txtCodigoCaja.Enabled = true;
                txtDescripcionCaja.Enabled = true;
                txtSkuCaja.Enabled = true;
                txtPCaja.Enabled = true;
                txtCostoCaja.Enabled = true;
                txtUtilidad1C.Enabled = true;
                txtUtilidad2C.Enabled = true;
                txtUtilidad3C.Enabled = true;
                txtPrecio1C.Enabled = true;
                txtPrecio2C.Enabled = true;
                txtPrecio3C.Enabled = true;
                max_p1c.Enabled = true;
                max_p2c.Enabled = true;
                max_p3c.Enabled = true;
            }
            else
            {
                txtCodigoCaja.Enabled = false;
                txtDescripcionCaja.Enabled = false;
                txtSkuCaja.Enabled = false;
                txtPCaja.Enabled = false;
                txtCostoCaja.Enabled = false;
                txtUtilidad1C.Enabled = false;
                txtUtilidad2C.Enabled = false;
                txtUtilidad3C.Enabled = false;
                txtPrecio1C.Enabled = false;
                txtPrecio2C.Enabled = false;
                txtPrecio3C.Enabled = false;
                max_p1c.Enabled = false;
                max_p2c.Enabled = false;
                max_p3c.Enabled = false;
            }
        }

        private void txtUtilidad1C_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtUtilidad1C.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtUtilidad1C_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtUtilidad1C.Text) == 0.00)
            {
                txtPrecio1C.Text = "0.00";
                txtUtilidad1C.Text = "0.00";
            }
            else
            {



                double porcentaje = (1 - (Convert.ToDouble(txtUtilidad1C.Text) / 100));
                txtPrecio1C.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCostoCaja.Text) / porcentaje));
            }
        }

        private void txtPrecio1C_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrecio1C.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecio1C_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrecio1C.Text) == 0.00)
            {
                txtPrecio1C.Text = "0.00";
                txtUtilidad1C.Text = "0.00";
            }
            else
            {



                double diferencia = (1 - (Convert.ToDouble(txtCostoCaja.Text) / Convert.ToDouble(txtPrecio1C.Text))) * 100;
                txtUtilidad1C.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void txtUtilidad2C_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtUtilidad2C.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtUtilidad2C_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtUtilidad2C.Text) == 0.00)
            {
                txtPrecio2C.Text = "0.00";
                txtUtilidad2C.Text = "0.00";
            }
            else
            {
                double porcentaje = (1 - (Convert.ToDouble(txtUtilidad2C.Text) / 100));
                txtPrecio2C.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCostoCaja.Text) / porcentaje));
            }
        }

        private void txtPrecio2C_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrecio2C.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecio2C_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrecio2C.Text) == 0.00)
            {
                txtPrecio2C.Text = "0.00";
                txtUtilidad2C.Text = "0.00";
            }
            else
            {
                double diferencia = (1 - (Convert.ToDouble(txtCostoCaja.Text) / Convert.ToDouble(txtPrecio2C.Text))) * 100;
                txtUtilidad2C.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void txtUtilidad3C_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtUtilidad3C.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtUtilidad3C_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtUtilidad3C.Text) == 0.00)
            {
                txtPrecio3C.Text = "0.00";
                txtUtilidad3C.Text = "0.00";
            }
            else
            {
                double porcentaje = (1 - (Convert.ToDouble(txtUtilidad3C.Text) / 100));
                txtPrecio3C.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCostoCaja.Text) / porcentaje));
            }
        }

        private void txtPrecio3C_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrecio3C.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecio3C_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrecio3C.Text) == 0.00)
            {
                txtPrecio3C.Text = "0.00";
                txtUtilidad3C.Text = "0.00";
            }
            else
            {
                double diferencia = (1 - (Convert.ToDouble(txtCostoCaja.Text) / Convert.ToDouble(txtPrecio3C.Text))) * 100;
                txtUtilidad3C.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void chkCarton_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCarton.Checked == true)
            {
                txtCodigoCarton.Enabled = true;
                txtSkuCarton.Enabled = true;
                txtp_carton.Enabled = true;
                txtDescripcionCarton.Enabled = true;
                txtCostoCarton.Enabled = true;
                txtUtilidad1Ct.Enabled = true;
                txtUtilidad2Ct.Enabled = true;
                txtUtilidad3Ct.Enabled = true;
                txtPrecio1Ct.Enabled = true;
                txtPrecio2Ct.Enabled = true;
                txtPrecio3Ct.Enabled = true;
                max_p1ct.Enabled = true;
                max_p2ct.Enabled = true;
                max_p3ct.Enabled = true;
            }
            else
            {
                txtCodigoCarton.Enabled = false;
                txtSkuCarton.Enabled = false;
                txtp_carton.Enabled = false;
                txtDescripcionCarton.Enabled = false;
                txtCostoCarton.Enabled = false;
                txtUtilidad1Ct.Enabled = false;
                txtUtilidad2Ct.Enabled = false;
                txtUtilidad3Ct.Enabled = false;
                txtPrecio1Ct.Enabled = false;
                txtPrecio2Ct.Enabled = false;
                txtPrecio3Ct.Enabled = false;
                max_p1ct.Enabled = false;
                max_p2ct.Enabled = false;
                max_p3ct.Enabled = false;
            }
        }

        private void txtUtilidad1Ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtUtilidad1Ct.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtUtilidad1Ct_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtUtilidad1Ct.Text) == 0.00)
            {
                txtPrecio1Ct.Text = "0.00";
                txtUtilidad1Ct.Text = "0.00";
            }
            else
            {
                double porcentaje = (1 - (Convert.ToDouble(txtUtilidad1Ct.Text) / 100));
                txtPrecio1Ct.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCostoCarton.Text) / porcentaje));
            }
        }

        private void txtPrecio1Ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrecio1Ct.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecio1Ct_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrecio1Ct.Text) == 0.00)
            {
                txtPrecio1Ct.Text = "0.00";
                txtUtilidad1Ct.Text = "0.00";
            }
            else
            {


                double diferencia = (1 - (Convert.ToDouble(txtCostoCarton.Text) / Convert.ToDouble(txtPrecio1Ct.Text))) * 100;
                txtUtilidad1Ct.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void txtUtilidad2Ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtUtilidad2Ct.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtUtilidad2Ct_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtUtilidad2Ct.Text) == 0.00)
            {
                txtPrecio2Ct.Text = "0.00";
                txtUtilidad2Ct.Text = "0.00";
            }
            else
            {
                double porcentaje = (1 - (Convert.ToDouble(txtUtilidad2Ct.Text) / 100));
                txtPrecio2Ct.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCostoCarton.Text) / porcentaje));
            }
        }

        private void txtPrecio2Ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrecio2Ct.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecio2Ct_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrecio2Ct.Text) == 0.00)
            {
                txtPrecio2Ct.Text = "0.00";
                txtUtilidad2Ct.Text = "0.00";
            }
            else
            {
                double diferencia = (1 - (Convert.ToDouble(txtCostoCarton.Text) / Convert.ToDouble(txtPrecio2Ct.Text))) * 100;
                txtUtilidad2Ct.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void txtUtilidad3Ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtUtilidad3Ct.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtUtilidad3Ct_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtUtilidad3Ct.Text) == 0.00)
            {
                txtPrecio3Ct.Text = "0.00";
                txtUtilidad3Ct.Text = "0.00";
            }
            else
            {
                double porcentaje = (1 - (Convert.ToDouble(txtUtilidad3Ct.Text) / 100));
                txtPrecio3Ct.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCostoCarton.Text) / porcentaje));
            }
        }

        private void txtPrecio3Ct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && !Convert.ToBoolean(txtPrecio3Ct.Text.IndexOf('.')))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecio3Ct_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtPrecio3Ct.Text) == 0.00)
            {
                txtPrecio3Ct.Text = "0.00";
                txtUtilidad3Ct.Text = "0.00";
            }
            else
            {
                double diferencia = (1 - (Convert.ToDouble(txtCostoCarton.Text) / Convert.ToDouble(txtPrecio3Ct.Text))) * 100;
                txtUtilidad3Ct.Text = string.Format("{0:#,0.00}", diferencia);
            }
        }

        private void txtProveedor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Busca_proveedor busca = new Busca_proveedor();
            busca.Owner = this;
            busca.Show();
        }

		private void txtPrice1_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
			{
                if (Convert.ToDouble(txtPrice1.Text) == 0.00)
                {
                    txtPrice1.Text = "0.00";
                    txtPercentPrice1.Text = "0.00";
                }
                else
                {

                    /*double porcentaje = (1 - (Convert.ToDouble(txtPercentPrice1.Text) / 100));
                    txtPrice1.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) / porcentaje));
                    */

                    double diferencia = (1 - (Convert.ToDouble(txtCosto.Text) / Convert.ToDouble(txtPrice1.Text))) * 100;
                    txtPercentPrice1.Text = string.Format("{0:#,0.00}", diferencia);
                }
            }
		}

		private void txtPrice2_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
			{
                if (txtPrice2.Text == "")
                {
                    txtPrice2.Text = "0.00";
                }
                if (Convert.ToDouble(txtPrice2.Text) == 0.00)
                {
                    txtPrice2.Text = "0.00";
                    txtPercentPrice2.Text = "0.00";
                }
                else
                {
                    double diferencia = (1 - (Convert.ToDouble(txtCosto.Text) / Convert.ToDouble(txtPrice2.Text))) * 100;
                    txtPercentPrice2.Text = string.Format("{0:#,0.00}", diferencia);
                }
            }
		}

		private void txtPrice3_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
			{
                if (txtPrice3.Text == "")
                {
                    txtPrice2.Text = "0.00";
                }
                if (Convert.ToDouble(txtPrice3.Text) == 0.00)
                {
                    txtPrice3.Text = "0.00";
                    txtPercentPrice3.Text = "0.00";
                }
                else
                {
                    double diferencia = (1 - (Convert.ToDouble(txtCosto.Text) / Convert.ToDouble(txtPrice3.Text))) * 100;
                    txtPercentPrice3.Text = string.Format("{0:#,0.00}", diferencia);
                }
            }
		}

		private void txtPrice4_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
			{
                if (txtPrice4.Text == "")
                {
                    txtPrice4.Text = "0.00";
                }
                if (Convert.ToDouble(txtPrice4.Text) == 0.00)
                {
                    txtPrice4.Text = "0.00";
                    txtPercentPrice4.Text = "0.00";
                }
                else
                {
                    double diferencia = (1 - (Convert.ToDouble(txtCosto.Text) / Convert.ToDouble(txtPrice4.Text))) * 100;
                    txtPercentPrice4.Text = string.Format("{0:#,0.00}", diferencia);
                }
            }
		}

		private void txtPrice5_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
			{
                if (txtPrice5.Text == "")
                {
                    txtPrice5.Text = "0.00";
                }
                if (Convert.ToDouble(txtPrice5.Text) == 0.00)
                {
                    txtPrice5.Text = "0.00";
                    txtPercentPrice5.Text = "0.00";
                }
                else
                {
                    double diferencia = (1 - (Convert.ToDouble(txtCosto.Text) / Convert.ToDouble(txtPrice5.Text))) * 100;
                    txtPercentPrice5.Text = string.Format("{0:#,0.00}", diferencia);
                }
            }
		}

		private void txtPercentPrice1_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
			{
                if (Convert.ToDouble(txtPercentPrice1.Text) == 0.00)
                {
                    txtPrice1.Text = "0.00";
                    txtPercentPrice1.Text = "0.00";
                }
                else
                {
                    double porcentaje = (1 - (Convert.ToDouble(txtPercentPrice1.Text) / 100));
                    txtPrice1.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) / porcentaje));
                }
            }
		}

		private void txtPercentPrice2_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
			{
                if (Convert.ToDouble(txtPercentPrice2.Text) == 0.00)
                {
                    txtPrice2.Text = "0.00";
                    txtPercentPrice2.Text = "0.00";
                }
                else
                {
                    double porcentaje = (1 - (Convert.ToDouble(txtPercentPrice2.Text) / 100));
                    txtPrice2.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) / porcentaje));
                }
            }
		}

		private void txtPercentPrice3_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
			{
                if (Convert.ToDouble(txtPercentPrice3.Text) == 0.00)
                {
                    txtPrice3.Text = "0.00";
                    txtPercentPrice3.Text = "0.00";
                }
                else
                {
                    double porcentaje = (1 - (Convert.ToDouble(txtPercentPrice3.Text) / 100));
                    txtPrice3.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) / porcentaje));
                }
            }
		}

		private void txtPercentPrice4_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
			{
                if (Convert.ToDouble(txtPercentPrice4.Text) == 0.00)
                {
                    txtPrice4.Text = "0.00";
                    txtPercentPrice4.Text = "0.00";
                }
                else
                {
                    double porcentaje = (1 - (Convert.ToDouble(txtPercentPrice4.Text) / 100));
                    txtPrice4.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) / porcentaje));
                }
            }
		}

		private void txtPercentPrice5_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
			{
                if (Convert.ToDouble(txtPercentPrice5.Text) == 0.00)
                {
                    txtPrice5.Text = "0.00";
                    txtPercentPrice5.Text = "0.00";
                }
                else
                {
                    double porcentaje = (1 - (Convert.ToDouble(txtPercentPrice5.Text) / 100));
                    txtPrice5.Text = string.Format("{0:#,0.00}", (Convert.ToDouble(txtCosto.Text) / porcentaje));
                }
            }
		}

		private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
		{
            

			switch (e.KeyCode)
			{
                case Keys.F3:

                    break;
                case Keys.Enter:
                    Models.Product producto = new Models.Product();
                    using (producto)
                    {
                        List<Models.Product> result = producto.getProductBycode1(txtCodigo.Text);
                        txtDes.Text = result[0].Description;
                        txtCodigo.Text = result[0].Code1;
                        Id_productos = result[0].Id;

                        txtCantidad.Focus();
                    }
                    break;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
            dtProducto.Rows.Insert(0, Id_productos, txtCodigo.Text, txtCantidad.Text, txtDes.Text);
            txtCodigo.Text = "";
            txtCantidad.Text = "";
            txtDes.Text = "";
            Id_productos = 0;
            txtCodigo.Focus();
		}

		private void txtDes_KeyDown(object sender, KeyEventArgs e)
		{
            switch (e.KeyCode)
            {
                case Keys.F3:

                    break;
                case Keys.Enter:
                    Models.Product producto = new Models.Product();
                    using (producto)
                    {
                        List<Models.Product> result = producto.getProductByDescription(txtDes.Text);
                        txtCodigo.Text = result[0].Code1;
                        txtDes.Text = result[0].Description;
                        Id_productos = result[0].Id;
                        txtCantidad.Focus();
                    }
                    break;
            }
        }

		private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
			{
                if (txtCantidad.Text!="" && txtDes.Text != "")
				{
                    button1.PerformClick();
				}
			}
		}
	}
}
