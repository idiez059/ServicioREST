using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioRest5.Areas.Api.Models;
using ServicioRest5;

namespace ServicioRest5.Areas.Api.Controllers
{
    public class CaloriasController : Controller
    {
        private CaloriaManager caloriasManager;

        public CaloriasController()
        {
            caloriasManager = new CaloriaManager();
        }

        //el GET /Api/Calorias
        [HttpGet]
        public JsonResult Calorias()
        {
            return Json(caloriasManager.ObtenerCalorias(),
                JsonRequestBehavior.AllowGet);
        }

        // POST    /Api/Calorias/Caloria    { Nombre:"nombre", Telefono:123456789 }
        // PUT     /Api/Calorias/Caloria/3  { Id:3, Nombre:"nombre", Telefono:123456789 }
        // GET     /Api/Calorias/Caloria/3
        // DELETE  /Api/Calorias/Caloria/3
        public JsonResult Caloria(String email, Caloria item) //Habría que retocarlo si queremos pedir una en particular
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(caloriasManager.InsertarCaloria(item));
                case "PUT":
                    return Json(caloriasManager.ActualizarCaloria(item));
                case "GET":
                    if (email != null)
                    {
                        return Json(caloriasManager.ObtenerCaloria(email), //quitado GetValueOrDefault()
                        JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(caloriasManager.ObtenerCalorias(),
                        JsonRequestBehavior.AllowGet);
                    }


                case "DELETE":
                    return Json(caloriasManager.EliminarCaloria(email),
                        JsonRequestBehavior.AllowGet);
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }
        //
        // GET: /Api/Calorias/

        public ActionResult Index()
        {
            return View();
        }
    }
}