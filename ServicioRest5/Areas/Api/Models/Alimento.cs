using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioRest5.Areas.Api.Models
{
    public class Alimento
    {
        public int codigo{ get; set; }
        public string nombre { get; set; }
        public int calorias { get; set; }

    }
}