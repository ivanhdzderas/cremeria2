using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Cremeria.Models
{
	class Mail
	{
        string origen = "contabilidad@cremeria-martinez.com"; //de quien procede, puede ser un alias
        string destino="ivanhdzderas@gmail.com";  //a quien vamos a enviar el mail
        string Message;  //mensaje
        string Subject; //asunto
        List<string> Archivo = new List<string>(); //lista de archivos a enviar
        string DE = "contabilidad@cremeria-martinez.com"; //nuestro usuario de smtp
        string PASS = "Cremeria2020."; //nuestro password de smtp

        //MailMessage oMialMessage = new MailMessage(origen, destino, "Reporte diario","");
    }
}
