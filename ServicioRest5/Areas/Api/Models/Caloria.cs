using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioRest5.Areas.Api.Models
{
    public class Caloria
    {
        public String email{ get; set; }
        public String fecha{ get; set; }
        public String tipocomida{ get; set; }
        public int codigoalimento{ get; set; }
        public int cantidad{ get; set; }

    }
}