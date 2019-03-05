using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioRest5.Areas.Api.Models;

namespace ServicioRest5.Areas.Api.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuarioManager usuariosManager;

        public UsuariosController()
        {
            usuariosManager = new UsuarioManager();
        }

        //el GET /Api/Usuarios
        [HttpGet]
        public JsonResult Usuarios()
        {
            return Json(usuariosManager.obtenerUsuarios(),
                JsonRequestBehavior.AllowGet);
        }

        // POST    /Api/Clientes/Cliente    { Nombre:"nombre", Telefono:123456789 }
        // PUT     /Api/Clientes/Cliente/3  { Id:3, Nombre:"nombre", Telefono:123456789 }
        // GET     /Api/Clientes/Cliente/3
        // DELETE  /Api/Clientes/Cliente/3
        public JsonResult Usuario(string email, Usuario item) //quitado string?
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(usuariosManager.insertarUsuario(item));
                case "PUT":
                    return Json(usuariosManager.actualizarUsuario(item));
                case "GET":
                    return Json(usuariosManager.obtenerUsuario(email), //quitado GetValueOrDefault()
                        JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(usuariosManager.eliminarUsuario(email),// "
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