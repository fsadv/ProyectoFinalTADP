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

        [JsonRequired]
        [DataType(DataType.Text)]
        [StringLength(100)]
        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonRequired]
        [DataType(DataType.Text)]
        [StringLength(100)]
        [JsonProperty("Apellido")]
        public string Apellido { get; set; }
        
        
        [JsonRequired]
        [DataType(DataType.EmailAddress)]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonRequired]
        [DataType(DataType.Password)]
        [JsonProperty("Clave")]
        public string Clave { get; set; }

        [JsonRequired]
        [Range(1, 4)]
        [JsonProperty("TipoUsuario")]
        public Enumerables.TipoUsuario TipoUsuario { get; set; }

        [JsonProperty("Estado")]
        public bool Estado { get; set; }

        [JsonRequired]
        [JsonProperty("UrlPerfil")]
        [DataType(DataType.ImageUrl)]
        public string UrlPerfil { get; set; }

        [JsonRequired]
        [DataType(DataType.Text)]
        [StringLength(10000)]
        [JsonProperty("Descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }
        }

              



    }




