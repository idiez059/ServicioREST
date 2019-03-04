using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioRest5.Areas.Api.Models;

namespace ServicioRest5.Areas.Api.Controllers
{
    public class ClientesController : Controller
    {
        private ClienteManager clientesManager;

        public ClientesController()
        {
            clientesManager = new ClienteManager();
        }

        // GET /Api/Clientes
        [HttpGet]
        public JsonResult Clientes()
        {
            return Json(clientesManager.ObtenerClientes(), 
                        JsonRequestBehavior.AllowGet);
        }

        // POST    /Api/Clientes/Cliente    { Nombre:"nombre", Telefono:123456789 }
        // PUT     /Api/Clientes/Cliente/3  { Id:3, Nombre:"nombre", Telefono:123456789 }
        // GET     /Api/Clientes/Cliente/3
        // DELETE  /Api/Clientes/Cliente/3
        public JsonResult Cliente(int? id, Cliente item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(clientesManager.InsertarCliente(item));
                case "PUT":
                    return Json(clientesManager.ActualizarCliente(item));
                case "GET":
                    return Json(clientesManager.ObtenerCliente(id.GetValueOrDefault()),
                        JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(clientesManager.EliminarCliente(id.GetValueOrDefault()),
                        JsonRequestBehavior.AllowGet);
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }
    //
        // GET: /Api/Clientes/

        public ActionResult Index()
        {
            return View();
        }

    }
}
