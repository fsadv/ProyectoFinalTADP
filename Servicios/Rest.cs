using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Rest
    {
        public string URL { get; set; }
        public string Data { get; set; }

        public string Method { get; set; }


        /*
         Constructor de la clase REST, diseñada para consumir los servicios.
         En caso de no contar con ningún método HTTP a la hora de ser instanciado, se 
         realiza una petición de tipo GET.
         */

        public Rest(string url, string data = "",string method="GET")

        {
            URL = url;
            Data = data;
            Method = method;
        }


        /*
         Método encargado del tratamiento de la respuesta recibida para su posterior retorno.
         */
        public string CreateObject()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);

            request.Method = this.Method;

            try
            {
                var json = "";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }

                return json.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
