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
	public partial class Cobro : Form
	{
        public static double deberia_ser;
        static int Folio;
        public static int Id_cliente;
        public static bool Recuperada;
        public int folio()
        {
            int nuevo = 0;
            Models.Folios folios = new Models.Folios();
            using (folios)
            {
                List<Models.Folios> folio = folios.getFolios();
                if (folio.Count > 0)
                {
                    nuevo = folio[0].Ticket;
                }
            }
            return nuevo;
        }
        private void calcula()
        {
            decimal restantes = 0;
            decimal total = Convert.ToDecimal(lbCobrar.Text);
            decimal recibido = 0;
            if (txtRecibido.Text != "")
            {
                recibido = Convert.ToDecimal(txtRecibido.Text);
            }


            restantes = total - recibido;
            if (restantes < total)
            {
                label5.Text = "Cambio ";
                restantes = restantes * -1;
            }
            lbResta.Text = string.Format("{0:#,0.00}", restantes);
        }
        public Cobro()
		{
			InitializeComponent();
		}
        
		private void Cobro_Load(object sender, EventArgs e)
		{
            lbResta.Text = string.Format("{0:#,0.00}", deberia_ser);

            lbCobrar.Text = lbResta.Text;
            cbMpago.Items.Add("Tarjeta de Debito");
            cbMpago.Items.Add("Tarjeta de Credito");
            cbMpago.Items.Add("Efectivo");
            cbMpago.Items.Add("Transferencia");
            cbMpago.SelectedIndex = 2;
            txtRecibido.Focus();
            if (Convert.ToDouble(lbCobrar.Text) == 0)
            {
                txtRecibido.Text = "0.00";
            }
        }

        private void txtRecibido_TextChanged(object sender, EventArgs e)
        {
            txtRecibido.Text = string.Format("{0:#,0.00}", txtRecibido.Text);
        }

        private void txtRecibido_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                calcula();
                btnCobrar.Focus();
                //btnCobrar.PerformClick();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Forms.Caja.cancelado = true;
            this.Close();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            Models.Tickets tickets = new Models.Tickets();
            Folio = folio();
            using (tickets)
            {
                if (Recuperada == false)
                {
                    tickets.Folio = Folio;
                    tickets.Id_cliente = Id_cliente;
                    tickets.Subtotal = Caja.Subtotal;
                    tickets.Descuento = Caja.Descuento;
                    tickets.Iva = Caja.Iva;
                    tickets.Total = Caja.Total;
                    tickets.Status = "A";
                    tickets.C_iva = Caja.Civa;
                    tickets.S_iva = Caja.Siva;
                    tickets.Id_usuario = Convert.ToInt16(Inicial.id_usario);
                    tickets.Atienda = Convert.ToInt32(Caja.Atiende);
                    tickets.A_facturar = Convert.ToInt16(chkFactura.Checked);
                    tickets.Recibido = Convert.ToDouble(txtRecibido.Text);
                    tickets.CreateTicket();
                    Caja.Folio_guardado = Folio;
                    Forms.Caja.cancelado = false;
                    this.Close();
                }
                else
                {
                    tickets.Folio = Caja.Folio_guardado;
                    tickets.Id_cliente = Id_cliente;
                    tickets.Subtotal = Caja.Subtotal;
                    tickets.Descuento = Caja.Descuento;
                    tickets.Iva = Caja.Iva;
                    tickets.Total = Caja.Total;
                    tickets.Status = "A";
                    tickets.C_iva = Caja.Civa;
                    tickets.S_iva = Caja.Siva;
                    tickets.Id_usuario = Convert.ToInt16(Inicial.id_usario);
                    tickets.Atienda = Convert.ToInt32(Caja.Atiende);
                    tickets.A_facturar = Convert.ToInt16(chkFactura.Checked);
                    tickets.Recibido = Convert.ToDouble(txtRecibido.Text);
                    tickets.update_ticketbyfolio();
                    Forms.Caja.cancelado = false;
                    this.Close();
                }
                
            }
        }

		private void cbMpago_SelectedIndexChanged(object sender, EventArgs e)
		{
            Models.Configuration configuracion = new Models.Configuration();
            using (configuracion)
            {
                List<Models.Configuration> config = configuracion.getConfiguration();
                switch (cbMpago.Text)
                {
                    case "Tarjeta de Debito":
                        double nuevo_total = deberia_ser + ((deberia_ser / 100) * config[0].Debito);
                        lbCobrar.Text = string.Format("{0:#,0.00}", nuevo_total);
                        calcula();
                        break;
                    case "Tarjeta de Credito":

                        double nuevo_total2 = deberia_ser + ((deberia_ser / 100) * config[0].Credito);
                        lbCobrar.Text = string.Format("{0:#,0.00}", nuevo_total2);
                        calcula();
                        break;
                    default:
                        lbCobrar.Text = string.Format("{0:#,0.00}", deberia_ser);
                        calcula();
                        break;
                }
            }
        }
	}
}
