using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BolsaDeTrabajoAPI.Controllers;

namespace BolsaDeTrabajoAPI.Mailing
{
    class Mail
    {

        string From = ""; //de quien procede, puede ser un alias
        string To;  //a quien vamos a enviar el mail
        string Message;  //mensaje
        string Subject; //asunto
        string DE = "bolsadetrabajoutnfrro@gmail.com"; //nuestro usuario de smtp
        string PASS = "fztrsfcejnytdwwh"; //nuestro password de smtp

        System.Net.Mail.MailMessage Email;

        public string error = "";

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="FROM">Procedencia</param>
        /// <param name="Para">Mail al cual se enviara</param>
        /// <param name="Mensaje">Mensaje del mail</param>
        /// <param name="Asunto">Asunto del mail</param>
        /// <param name="ArchivoPedido_">Archivo a adjuntar, no es obligatorio</param>
        public Mail(string FROM, string Para, string Mensaje, string Asunto)
        {
            From = FROM;
            To = Para;
            Message = Mensaje;
            Subject = Asunto;

        }

        /// <summary>
        /// metodo que envia el mail
        /// </summary>
        /// <returns></returns>
        public bool enviaMail()
        {

            //una validación básica
            if (To.Trim().Equals("") || Message.Trim().Equals("") || Subject.Trim().Equals(""))
            {
                error = "El mail, el asunto y el mensaje son obligatorios";
                return false;
            }

            //aqui comenzamos el proceso
            //comienza-------------------------------------------------------------------------
            try
            {
                //creamos un objeto tipo MailMessage
                //este objeto recibe el sujeto o persona que envia el mail,
                //la direccion de procedencia, el asunto y el mensaje
                Email = new System.Net.Mail.MailMessage(From, To, Subject, Message);



                Email.IsBodyHtml = true; //definimos si el contenido sera html
                Email.From = new MailAddress(From); //definimos la direccion de procedencia

                //aqui creamos un objeto tipo SmtpClient el cual recibe el servidor que utilizaremos como smtp
                //en este caso me colgare de gmail
                System.Net.Mail.SmtpClient smtpMail = new System.Net.Mail.SmtpClient("smtp.gmail.com");

                smtpMail.EnableSsl = true;//le definimos si es conexión ssl
                smtpMail.UseDefaultCredentials = false; //le decimos que no utilice la credencial por defecto
                smtpMail.Host = "smtp.gmail.com"; //agregamos el servidor smtp
                smtpMail.Port = 587; //le asignamos el puerto, en este caso gmail utiliza el 465
                smtpMail.Credentials = new System.Net.NetworkCredential(DE, PASS); //agregamos nuestro usuario y pass de gmail

                //enviamos el mail
                smtpMail.Send(Email);

                //eliminamos el objeto
                smtpMail.Dispose();

                //regresamos true
                return true;
            }
            catch (Exception ex)
            {
                //si ocurre un error regresamos false y el error
                error = "Ocurrio un error: " + ex.Message;
                return false;
            }

            return false;

        }
    }
}