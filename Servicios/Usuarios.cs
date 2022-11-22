using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
   public class Usuarios
    {

        public static List<Entidades.Usuario> Listar()
        {
            string listUsuariosJson = new Rest(ConfigurationManager.AppSettings["UrlServicios"] + "/Usuarios").CreateObject();

            List<Entidades.Usuario> listUsuarios = JsonConvert.DeserializeObject<List<Entidades.Usuario>>(listUsuariosJson);

            return listUsuarios;


        }

    }


}
