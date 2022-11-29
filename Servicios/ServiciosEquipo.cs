using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServiciosEquipo
    {
        public static List<Entidades.ServicioEquipo> Listar()
        {
            string listServiciosJson = new Rest("https://63853e57beaa6458265c21fb.mockapi.io/Servicios").CreateObject();
            List<Entidades.ServicioEquipo> listServicios = JsonConvert.DeserializeObject<List<Entidades.ServicioEquipo>>(listServiciosJson);

            return listServicios;


        }

    }

}
