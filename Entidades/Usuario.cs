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
              
        
            [JsonProperty("Nombre")]
            public string Nombre { get; set; }

            [JsonProperty("Apellido")]
            public string Apellido { get; set; }

            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("Clave")]
            public string Clave { get; set; }

            [JsonProperty("TipoUsuario")]
            public Enumerables.TipoUsuario TipoUsuario { get; set; }

            [JsonProperty("Estado")]
            public bool Estado { get; set; }

            [JsonProperty("UrlPerfil")]
            public string UrlPerfil { get; set; }

            [JsonProperty("Descripcion")]
            public string Descripcion { get; set; }

            [JsonProperty("Id")]
            public string Id { get; set; }
        }

              



    }




