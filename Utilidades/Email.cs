using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class Email
    {
        /// <summary>
        /// Enviar correo generico
        /// </summary>
        /// <param name="from">De</param>
        /// <param name="to">Para</param>
        /// <param name="fromName">Nombre de la persona que envia el correo </param>
        /// <param name="toName">Nombre de la persona que recibe el correo</param>
        /// <param name="fromUser">email del usuario que se va a autenticar con el server</param>
        /// <param name="fromPassword">clave del usuario que se va autenticar con el server</param>
        /// <param name="subject">Asunto del mensaje</param>
        /// <param name="body">Cuerpo del mensaje (Pede ser html)</param>
        /// <param name="html">Formato Html </param>
        /// <param name="host">host del servidor de correo </param>
        /// <param name="Port">Puerto del servidor de correo</param>
        /// <param name="enableSsl">habilitado el SSL</param>
        /// <returns></returns>
        /// 



        public static bool EnviarEmail   //Metodo de envío de email
            (
                string from,
                string to,
                string fromName,
                string toName,
                string fromUser,
                string fromPassword,
                string subject,
                string body,
                bool html,
                string host,
                int port,
                bool enableSsl = false
            )

        {

            try
            {
                if (ValidarEmail(from, to, fromName, toName, fromPassword, subject, body)) 
                {
                    MailAddress fromAddress = new MailAddress(from, fromName);
                    MailAddress toAddress = new MailAddress(to, toName);

                    SmtpClient smtp = new SmtpClient
                    {
                        Host = host,
                        Port = port,
                        EnableSsl = enableSsl,
                        Credentials = new NetworkCredential(fromUser, fromPassword),
                    };

                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = html
                    })
                    {
                        smtp.Send(message);
                    }

                    return true;
                }
                else
                {
                    throw new Exception("Alguno de los datos solicitados no fueron ingresados");
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /*
         * El metodo ValidarEmail comprueba que ningun campo del mismo esté vacío, 
         * con fin de evitar errores en su procesamiento.
         */

        private static bool ValidarEmail(string from, string to, string fromName, string toName, string fromPassword, string subject, string body)
        {
            if (String.IsNullOrEmpty(from))
                return false;
            if (String.IsNullOrEmpty(to))
                return false;
            if (String.IsNullOrEmpty(fromName))
                return false;
            if (String.IsNullOrEmpty(toName))
                return false;
            if (String.IsNullOrEmpty(fromPassword))
                return false;
            if (String.IsNullOrEmpty(subject))
                return false;
            if (String.IsNullOrEmpty(body))
                return false;

            return true;

        }
    }


}

