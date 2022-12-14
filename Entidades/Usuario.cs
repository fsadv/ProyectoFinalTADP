using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

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

       
        [JsonProperty("TipoUsuario")]
        public Enumerables.TipoUsuario TipoUsuario { get; set; }

        [JsonProperty("Estado")]
        public bool Estado { get; set; }

        [JsonProperty("UrlPerfil")]
        [DataType(DataType.ImageUrl)]
        public string UrlPerfil { get; set; }

        [JsonProperty("Descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
        }

              



    }




