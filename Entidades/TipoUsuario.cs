using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
   
    public class TipoUsuario
    {
        [JsonProperty("idTipoUsuario")]
        public int idTipoUsuario { get; set; }

        [JsonProperty("tipo")]
        public string tipo { get; set; }
    }


}
