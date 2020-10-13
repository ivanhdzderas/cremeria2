﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Cremeria.Models
{
    public class Product : ConnectDB
    {
        private string mac_query = "select id,id_parent,c_unidad,  descripcion,sku,medida_sat, codigo, codigo2, codigo3, codigo4, codigo5, cantidad,devolucion, grupo, marca, unidad, precio1, precio2, precio3, precio4, precio5, utilidad1, utilidad2, utilidad3, utilidad4, utilidad5, costo, activo, codigo_sat, impuesto_venta, impuesto_compra, descuento, monto_descuento, minimo, maximo,dias_alerta, lote, max_p1, max_p2, max_p3, max_p4, max_p5, proveedor, grupal, notas   from tbaproductos";

        public int Id { get; set; }
        public string Description { get; set; }
        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        public string Code4 { get; set; }
        public string Code5 { get; set; }
        public double Existencia { get; set; }
        public double Devoluciones { get; set; }
        public string Group { get; set; }
        public string Brand { get; set; }
        public string Unit { get; set; }

        public double Price1 { get; set; }
        public double Price2 { get; set; }
        public double Price3 { get; set; }
        public double Price4 { get; set; }
        public double Price5 { get; set; }

        public double Utility1 { get; set; }
        public double Utility2 { get; set; }
        public double Utility3 { get; set; }
        public double Utility4 { get; set; }
        public double Utility5 { get; set; }
        public double Cost { get; set; }



        public int Active { get; set; }
        public string Code_sat { get; set; }
        public string Sku { get; set; }
        public string Medida_sat { get; set; }
        public string Sale_tax { get; set; }
        public string Buy_tax { get; set; }
        public int Discount { get; set; }
        public int Mount_discount { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }

        public string Parent { get; set; }
        public string C_unidad { get; set; }
    
        public int Dias_alerta { get; set; }
        public int Lote { get; set; }
        public double Max_p1 { get; set; }
        public double Max_p2 { get; set; }
        public double Max_p3 { get; set; }
        public double Max_p4 { get; set; }
        public double Max_p5 { get; set; }
        public int Proveedor { get; set; }
        public bool Grupal { get; set; }
        public string Notas { get; set; }
        public Product(
            int id,
            string description,
            string code1,
            string code2,
            string code3,
            string code4,
            string code5,
            double existencia,
            double devoluciones,
            string group,
            string brand,
            string unit,
            double price1,
            double price2,
            double price3,
            double price4,
            double price5,
            double utility1,
            double utility2,
            double utility3,
            double utility4,
            double utility5,
            double cost,

            int active,
            string code_sat,
            string sku,
            string medida_sat,
            string sale_tax,
            string buy_tax,
            int discount,
            int mount_discount,
            double min,
            double max,
            string parent,
            string c_unidad,
            int dias_alerta,
            int lote,
            double max_p1,
            double max_p2,
            double max_p3,
            double max_p4,
            double max_p5,
            int proveedor,
            bool grupal,
            string notas
            )
        {
            Id = id;
            Description = description;
            Code1 = code1;
            Code2 = code2;
            Code3 = code3;
            Code4 = code4;
            Code5 = code5;
            Existencia = existencia;
            Devoluciones = devoluciones;
            Group = group;
            Brand = brand;
            Unit = unit;
            Price1 = price1;
            Price2 = price2;
            Price3 = price3;
            Price4 = price4;
            Price5 = price5;
            Utility1 = utility1;
            Utility2 = utility2;
            Utility3 = utility3;
            Utility4 = utility4;
            Utility5 = utility5;
            Cost = cost;

            Active = active;
            Code_sat = code_sat;
            Sku = sku;
            Medida_sat = medida_sat;
            Sale_tax = sale_tax;
            Buy_tax = buy_tax;
            Discount = discount;
            Mount_discount = mount_discount;
            Min = min;
            Max = max;

            Parent = parent;

            C_unidad = c_unidad;
            Dias_alerta = dias_alerta;
            Lote = lote;
            Max_p1 = max_p1;
            Max_p2 = max_p2;
            Max_p3 = max_p3;
            Max_p4 = max_p4;
            Max_p5 = max_p5;
            Proveedor = proveedor;
            Grupal = grupal;
            Notas = notas;
        }

        public Product() {

        }
        public void update_inventary() {
            string query = "update tbaproductos set cantidad='" + this.Existencia + "' where id='" + this.Id + "'  ";
            runQuery(query);
           
            
        }
        public void update_code2()
		{
            string query = "update tbaproductos set codigo2='" + this.Code2 + "' where id='" + this.Id + "'  ";
            runQuery(query);
        }


        public void update_code3()
        {
            string query = "update tbaproductos set codigo3='" + this.Code3 + "' where id='" + this.Id + "'  ";
            runQuery(query);
        }
        public void update_code4()
        {
            string query = "update tbaproductos set codigo4='" + this.Code4 + "' where id='" + this.Id + "'  ";
            runQuery(query);
        }
        public void update_code5()
        {
            string query = "update tbaproductos set codigo5='" + this.Code5 + "' where id='" + this.Id + "'  ";
            runQuery(query);
        }
        public void update_devoluciones()
        {
            string query = "update tbaproductos set devolucion='" + this.Devoluciones + "' where id='" + this.Id + "'  ";
            runQuery(query);

        }
        public void createProduct() {
            string query = "INSERT INTO tbaproductos (codigo, descripcion, costo, codigo2, codigo3, codigo4, codigo5, precio1, precio2, precio3, precio4, precio5, utilidad1, utilidad2, utilidad3, utilidad4, utilidad5, cantidad, devolucion, unidad, grupo, marca, activo,codigo_sat,sku,medida_sat,impuesto_venta,impuesto_compra,descuento,monto_descuento,minimo,maximo,id_parent, c_unidad,dias_alerta, lote, max_p1,max_p2, max_p3,max_p4,max_p5, proveedor, grupal,notas)";
            query += "values (";
            query += "'" + this.Code1 + "', ";
            query += "'" + this.Description + "', ";
            query += "'" + this.Cost + "', ";
            query += "'" + this.Code2 + "', ";
            query += "'" + this.Code3 + "', ";
            query += "'" + this.Code4 + "', ";
            query += "'" + this.Code5 + "', ";
            query += "'" + this.Price1 + "', ";
            query += "'" + this.Price2 + "', ";
            query += "'" + this.Price3 + "', ";
            query += "'" + this.Price4 + "', ";
            query += "'" + this.Price5 + "', ";
            query += "'" + this.Utility1 + "', ";
            query += "'" + this.Utility2 + "', ";
            query += "'" + this.Utility3 + "', ";
            query += "'" + this.Utility4 + "', ";
            query += "'" + this.Utility5 + "', ";
            query += "'0', ";
            query += "'0', ";
            query += "'" + this.Unit + "', ";
            query += "'" + this.Group + "', ";
            query += "'" + this.Brand + "', ";
            query += "'1', ";
            query += "'" + this.Code_sat + "', ";
            query += "'" + this.Sku + "', ";
            query += "'" + this.Medida_sat + "', ";
            query += "'" + this.Sale_tax + "', ";
            query += "'" + this.Buy_tax + "', ";
            query += "'" + this.Discount + "', ";
            query += "'" + this.Mount_discount + "', ";
            query += "'" + this.Min + "', ";
            query += "'" + this.Max + "', ";
            query += "'" + this.Parent + "',";
            query += "'" + this.C_unidad + "',";
            query += "'" + this.Dias_alerta + "',";
            query += "'" + this.Lote + "',";
            query += "'" + this.Max_p1 + "',";
            query += "'" + this.Max_p2 + "',";
            query += "'" + this.Max_p3 + "',";
            query += "'" + this.Max_p4 + "',";
            query += "'" + this.Max_p5 + "', ";
            query += "'" + this.Proveedor + "',";

            query += "'" + Convert.ToInt32(this.Grupal) + "', ";
            query += "'" + this.Notas + "'";
            query += ");";

            runQuery(query);




        }
        public void update_max_min()
		{
            string query = "update tbaproductos set maximo='" + this.Max +"', minimo='" + this.Min + "', precio1='" + this.Price1 + "', precio2='" + this.Price2 + "', precio3='" + this.Price3 + "' where id='" + this.Id + "'";
            object result = runQuery(query);
		}
        public void saveProduct()
        {
            string query = "update tbaproductos set ";
            query += "codigo='" + this.Code1 + "', ";
            query += "descripcion='" + this.Description + "', ";
            query += "costo='" + this.Cost + "', ";
            query += "codigo2='" + this.Code2 + "', ";
            query += "codigo3='" + this.Code3 + "', ";
            query += "codigo4='" + this.Code4 + "', ";
            query += "codigo5='" + this.Code5 + "', ";
            query += "precio1='" + this.Price1 + "', ";
            query += "precio2='" + this.Price2 + "', ";
            query += "precio3='" + this.Price3 + "', ";
            query += "precio4='" + this.Price4 + "', ";
            query += "precio5='" + this.Price5 + "', ";
            query += "utilidad1='" + this.Utility1 + "', ";
            query += "utilidad2='" + this.Utility2 + "', ";
            query += "utilidad3='" + this.Utility3 + "', ";
            query += "utilidad4='" + this.Utility4 + "', ";
            query += "utilidad5='" + this.Utility5 + "', ";
            query += "unidad='" + this.Unit + "', ";
            query += "grupo='" + this.Group + "', ";
            query += "marca='" + this.Brand + "', ";
            query += "codigo_sat='" + this.Code_sat + "', ";
            query += "sku='" + this.Sku + "', ";
            query += "medida_sat='" + this.Medida_sat + "', ";
            query += "impuesto_venta='" + this.Sale_tax + "', ";
            query += "impuesto_compra='" + this.Buy_tax + "', ";
            query += "descuento='" + this.Discount + "', ";
            query += "monto_descuento='" + this.Mount_discount + "', ";
            query += "minimo='" + this.Min + "' ,";
            query += "maximo='" + this.Max + "', ";
            query += "activo='" + this.Active + "', ";
            query += "id_parent='" + this.Parent + "', ";
            query += "c_unidad='" + this.C_unidad + "', ";
            query += "dias_alerta='" + this.Dias_alerta + "',";
            query += "lote='" + this.Lote + "', ";
            query += "max_p1='" + this.Max_p1 + "', ";
            query += "max_p2='" + this.Max_p2 + "', ";
            query += "max_p3='" + this.Max_p3 + "', ";
            query += "max_p4='" + this.Max_p4 + "', ";
            query += "max_p5='" + this.Max_p5 + "', ";
            query += "proveedor='" + this.Proveedor + "', ";
            query += "grupal='" + Convert.ToInt32(this.Grupal) + "', ";
            query += "notas='" + this.Notas + "' ";
            query += "where id='" + this.Id + "'";

            runQuery(query);

        }

        private Product buildProduct(MySqlDataReader data) {
            Product item = new Product(
                data.GetInt32("id"),
                data.GetString("descripcion"),
                data.GetString("codigo"),
                data.GetString("codigo2"),
                data.GetString("codigo3"),
                data.GetString("codigo4"),
                data.GetString("codigo5"),
                data.GetDouble("cantidad"),
                data.GetDouble("devolucion"),
                data.GetString("grupo"),
                data.GetString("marca"),
                data.GetString("unidad"),
                data.GetDouble("precio1"),
                data.GetDouble("precio2"),
                data.GetDouble("precio3"),
                data.GetDouble("precio4"),
                data.GetDouble("precio5"),
                data.GetDouble("utilidad1"),
                data.GetDouble("utilidad2"),
                data.GetDouble("utilidad3"),
                data.GetDouble("utilidad4"),
                data.GetDouble("utilidad5"),
                data.GetDouble("costo"),

                data.GetInt32("activo"),
                data.GetString("codigo_sat"),
                data.GetString("sku"),
                data.GetString("medida_sat"),
                data.GetString("impuesto_venta"),
                data.GetString("impuesto_compra"),
                data.GetInt32("descuento"),
                data.GetInt32("monto_descuento"),
                data.GetDouble("minimo"),
                data.GetDouble("maximo"),
                data.GetString("id_parent"),
                data.GetString("c_unidad"),
                data.GetInt32("dias_alerta"),
                data.GetInt32("lote"),
                data.GetDouble("max_p1"),
                data.GetDouble("max_p2"),
                data.GetDouble("max_p3"),
                data.GetDouble("max_p4"),
                data.GetDouble("max_p5"),
                data.GetInt32("proveedor"),
                Convert.ToBoolean(data.GetInt32("grupal")),
                data.GetString("notas")
            ) ;
            return item;

        }

        public List<Product> getProductBycode1(string codigo)
        {
            string query = mac_query + " where codigo = '" + codigo + "' and activo='1' order by LENGTH(codigo) , codigo";
            MySqlDataReader data = runQuery(query);
            
                List<Product> result = new List<Product>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Product item = buildProduct(data);
                        result.Add(item);
                    }
                }
                return result;
        }

        public List<Product> getProductByproveedor(string proveedor)
        {
            string query = mac_query + " where proveedor = '" + proveedor + "' and activo='1' order by LENGTH(codigo) , codigo";
            MySqlDataReader data = runQuery(query);

            List<Product> result = new List<Product>();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Product item = buildProduct(data);
                    result.Add(item);
                }
            }
            return result;
        }
        public List<Product> getProductbymarca(string marca)
        {
            string query = mac_query + " where marca = '" + marca + "' and activo='1' order by LENGTH(codigo) , codigo";
            MySqlDataReader data = runQuery(query);

            List<Product> result = new List<Product>();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Product item = buildProduct(data);
                    result.Add(item);
                }
            }
            return result;
        }
        public List<Product> getMinProduct()
        {
            string query = mac_query + " where minimo <= cantidad and activo='1' order by LENGTH(codigo) , codigo";
            MySqlDataReader data = runQuery(query);
            
                List<Product> result = new List<Product>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Product item = buildProduct(data);
                        result.Add(item);
                    }
                }
                return result;
            
        }
        public List<Product> getProductById(int id)
        {
            string query = mac_query + " where id = '" + id + "'  order by LENGTH(codigo) , codigo";
            MySqlDataReader data = runQuery(query);
            
                List<Product> result = new List<Product>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Product item = buildProduct(data);
                        result.Add(item);
                    }
                }
                return result;
            

        }
        public List<Product> getProduct(int parent) {
            string query = mac_query + " where id_parent='" + parent.ToString() + "' and activo='1' order by LENGTH(codigo) , codigo";
            MySqlDataReader data = runQuery(query);
           
                List<Product> result = new List<Product>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Product item = buildProduct(data);
                        result.Add(item);
                    }
                }
                return result;
            
        }
        public List<Product> getProductByDescription(string description)
        {
            string query = mac_query + " where descripcion like '%" + description + "%'  order by LENGTH(codigo) , codigo";
            MySqlDataReader data = runQuery(query);
            
                List<Product> result = new List<Product>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Product item = buildProduct(data);
                        result.Add(item);
                    }
                }
                return result;
            

        }
        public List<Product> getProductNoSub() {
            string query = mac_query + " where id_parent=0 order by LENGTH(codigo) , codigo";
            MySqlDataReader data = runQuery(query);
            
                List<Product> result = new List<Product>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Product item = buildProduct(data);
                        result.Add(item);
                    }
                }
                return result;
            
        }
        public List<Product> getProductByCode(string code)
        {
            string query = mac_query + " where   (codigo like '%" + code + "%' or codigo2 like '%" + code + "%' or codigo3 like '%" + code + "%' or codigo4 like '%" + code + "%' or codigo5 like '%" + code + "%' or sku like '%" + code + "%') order by LENGTH(codigo) , codigo";
            MySqlDataReader data = runQuery(query);
            
                List<Product> result = new List<Product>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Product item = buildProduct(data);
                        result.Add(item);
                    }
                }
                return result;
            
        }


        public List<Product> getProductByCodeAbsolute(string code)
        {
            string query = mac_query + " where  activo='1' and (codigo='" + code + "' or codigo2='" + code + "' or codigo3='" + code + "' or codigo4='" + code + "' or codigo5='" + code + "' or sku='" + code + "') order by LENGTH(codigo) , codigo";
            
            MySqlDataReader data = runQuery(query);
            
                List<Product> result = new List<Product>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Product item = buildProduct(data);
                        result.Add(item);
                    }
                }
                return result;
            
        }

        public List<Product> getProductByigualCode(string code)
        {
            string query = mac_query + " where activo='1' and (codigo = '" + code + "' or codigo2 = '" + code + "' or codigo3 like '%" + code + "%' or codigo4 = '" + code + "' or codigo5 = '" + code + "' or sku='" + code + "') order by LENGTH(codigo) , codigo";
            MySqlDataReader data = runQuery(query);
            
                List<Product> result = new List<Product>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Product item = buildProduct(data);
                        result.Add(item);
                    }
                }
                return result;
            
        }
        public  List<Product> getProducts() {
            string query = mac_query;
            MySqlDataReader data = runQuery(query);
            
                List<Product> result = new List<Product>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Product item = buildProduct(data);
                        result.Add(item);
                    }
                }
                return result;
            
        }

        public List<Product> getCaducProducts()
        {
            string query = "select tbaproductos.id,tbaproductos.id_parent,tbaproductos.c_unidad,  tbaproductos.descripcion,tbaproductos.sku,tbaproductos.medida_sat, tbaproductos.codigo, tbaproductos.codigo2, tbaproductos.codigo3, tbaproductos.codigo4, tbaproductos.codigo5, tbaproductos.cantidad,tbaproductos.devolucion, tbaproductos.grupo, tbaproductos.marca, tbaproductos.unidad, tbaproductos.precio1, tbaproductos.precio2, tbaproductos.precio3, tbaproductos.precio4, tbaproductos.precio5, tbaproductos.utilidad1, tbaproductos.utilidad2, tbaproductos.utilidad3, tbaproductos.utilidad4, tbaproductos.utilidad5, tbaproductos.costo, tbaproductos.activo, tbaproductos.codigo_sat, tbaproductos.impuesto_venta, tbaproductos.impuesto_compra, tbaproductos.descuento, tbaproductos.monto_descuento, tbaproductos.minimo, tbaproductos.maximo,tbaproductos.dias_alerta, tbaproductos.lote,tbaproductos.max_p1,tbaproductos.max_p2,tbaproductos.max_p3, tbaproductos.max_p4, tbaproductos.max_p5 , tbaproductos.proveedor, tbaproductos.grupal, tbaproductos.notas   from tbaproductos inner join tbacaducidad on tbaproductos.id=tbacaducidad.id_producto where TIMESTAMPDIFF(DAY, tbacaducidad.caducidad, NOW())<=tbaproductos.dias_alerta";
            MySqlDataReader data = runQuery(query);
            
                List<Product> result = new List<Product>();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Product item = buildProduct(data);
                        result.Add(item);
                    }
                }
                return result;
            
        }

    }
}
