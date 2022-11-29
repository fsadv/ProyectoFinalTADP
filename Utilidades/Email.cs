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

        #region Metodos públicos
        

        public static bool EnviarEmail  
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

        #endregion

        #region Métodos privados
        
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

        #endregion


    }



}

