using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioRest5.Areas.Api.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
    }
}