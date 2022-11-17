using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {

        /*
         La entidad Usuario se encarga de realizar el mapeo de la información recibida
         desde MockApi en una clase, con fin de poder dar tratamiento a esa data 
         como un objeto.
         */

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Apellido")]
        public string Apellido { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Clave")]
        public string Clave { get; set; }

        [JsonProperty("IdTipoUsuario")]
        public long IdTipoUsuario { get; set; }

        [JsonProperty("Estado")]
        public bool Estado { get; set; }

        [JsonProperty("UrlPerfil")]
        public string UrlPerfil { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

    }

 

}
