﻿
using System;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

using Telegram.Bot;
using Telegram.Bot.Args;
namespace Cremeria.Forms
{
	public class intercambios
	{
        static ITelegramBotClient bootClient;
        public static string conector { get; set; }
		public static string Codigo { get; set; }
		public static int Id_producto { get; set; }

		public static string Lote { get; set; }
		public static string Caducidad { get; set; }
      
        public void send_telegram(string Message, string Phone)
		{
            bootClient = new TelegramBotClient("1337668982:AAFy4rwBH3VhwUCgnOZTBX2KZrQXRqUwnqs");
            var me = bootClient.GetMeAsync().Result;
            Console.WriteLine($"soy el usuario {me.Id} y mi nombre {me.FirstName}");
            bootClient.OnMessage += Bot_OnMessage;
            bootClient.StartReceiving();
		}
        public static bool my_checkInternet()
		{
			try {
                var me = bootClient.GetMeAsync().Result;
                return true;
            } 
            catch
			{
                System.Windows.Forms.MessageBox.Show("Sin coneccion a internet","Error");
                return false;
			}
		}
        public async void Bot_SendMessaeg(string id, string mensaje)
		{
            if (my_checkInternet())
			{
                /*await bootClient.SendTextMessageAsync(
                 chatId: id,
                    text: mensaje
               );*/
            }
           
		}
        static async void Bot_OnMessage(object sender, MessageEventArgs e)
		{
            if (e.Message.Text != null)
			{
                Console.WriteLine($"texto recibido en chat {e.Message.Chat.Id}");
                await bootClient.SendTextMessageAsync(
                    chatId:e.Message.Chat,
                    text: "enviaste "+ e.Message.Text
                    );
			}
		}
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public string enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try

            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " PESOS  " + decimales.ToString() + "/100 M.N.)";
            }
            else {
                dec = " PESOS  0/100 M.N.)";
            }

            res = "(" + toText(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;

        }


        public bool test_red()
        {
            try
            {
                Ping myPing = new Ping();
                String Host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(Host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void enviar_correo(string atach,string mensaje,string tema)
		{
            string origen = "reportes@cremeria-martinez.com"; //de quien procede, puede ser un alias
            string destino = "arturo.huerta@cremeria-martinez.com,rosa.martinez@cremeria-martinez.com";  //a quien vamos a enviar el mail
            //string destino = "ihernandez@colegioherbart.edu.mx";
            string Message = mensaje;  //mensaje
            string Subject = tema; //asunto
            string PASS = "Reportes2020."; //nuestro password de smtp
            MailMessage oMailmessage = new MailMessage(origen, destino, Subject, Message);
            if (atach!="")
			{
                oMailmessage.Attachments.Add(new Attachment(atach));
            }
            
            oMailmessage.IsBodyHtml = true;
            SmtpClient oSmtpclient = new SmtpClient("mail.cremeria-martinez.com");
            oSmtpclient.EnableSsl = true;
            oSmtpclient.UseDefaultCredentials = false;
            oSmtpclient.Port = 587;
            oSmtpclient.Credentials = new System.Net.NetworkCredential(origen, PASS);
            oSmtpclient.Send(oMailmessage);
            oSmtpclient.Dispose();
        }
    }
}
