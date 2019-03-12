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

        //el GET /Api/Alimentos
        [HttpGet]
        public JsonResult Calorias()
        {
            return Json(caloriasManager.ObtenerCalorias(),
                JsonRequestBehavior.AllowGet);
        }

        // POST    /Api/Alimentos/Alimento    { Nombre:"nombre", Telefono:123456789 }
        // PUT     /Api/Alimentos/Alimento/3  { Id:3, Nombre:"nombre", Telefono:123456789 }
        // GET     /Api/Alimentos/Alimento/3
        // DELETE  /Api/Alimentos/Alimento/3
        public JsonResult Caloria(int codigo, Caloria item) //quitado string?
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(caloriasManager.InsertarCaloria(item));
                case "PUT":
                    return Json(caloriasManager.ActualizarCaloria(item));
                case "GET":
                    if (codigo != null)
                    {
                        return Json(caloriasManager.ObtenerCaloria(codigo), //quitado GetValueOrDefault()
                        JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(caloriasManager.ObtenerAlimentos(),
                        JsonRequestBehavior.AllowGet);
                    }


                case "DELETE":
                    return Json(caloriasManager.EliminarCaloria(codigo),
                        JsonRequestBehavior.AllowGet);
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }
        //
        // GET: /Api/Alimentos/

        public ActionResult Index()
        {
            return View();
        }
    }
}