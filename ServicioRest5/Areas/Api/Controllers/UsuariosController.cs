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
            return Json(usuariosManager.ObtenerUsuarios(),
                JsonRequestBehavior.AllowGet);
        }

        // POST    /Api/Usuarios/Usuario    { email:"email", password:"password"}
        // PUT     /Api/Usuarios/Usuario/email  { email:"email", password:"password"}
        // GET     /Api/Usuarios/Usuario/email  ...
        // DELETE  /Api/Usuarios/Usuario/email
        public JsonResult Usuario(string email, Usuario item) //quitado string?
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(usuariosManager.InsertarUsuario(item));
                case "PUT":
                    return Json(usuariosManager.ActualizarUsuario(item));
                case "GET":
                    if(email != null)
                    {
                        return Json(usuariosManager.ObtenerUsuario(email), //quitado GetValueOrDefault()
                          JsonRequestBehavior.AllowGet);
                    }
                    else
                    {                        
                        return Json(usuariosManager.ObtenerUsuarios(),
                        JsonRequestBehavior.AllowGet);
                    }

                    
                case "DELETE":
                    return Json(usuariosManager.EliminarUsuario(email),// "
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