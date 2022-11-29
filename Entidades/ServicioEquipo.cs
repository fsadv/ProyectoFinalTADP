using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ServicioEquipo
    {

        [JsonProperty("Titulo")]
        public string Titulo { get; set; }

        [JsonProperty("Descripcion")]
        public string Descripcion { get; set; }

    }
}
