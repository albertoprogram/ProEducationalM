using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProEducationalM.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(int error = 0)
        {
            switch (error)
            {
                case 505:
                    ViewBag.Title = "Ocurrió un error inesperado - 505";
                    ViewBag.Description = "Notifique al administrador de la aplicación para su revisión";
                    break;
                case 500:
                    ViewBag.Title = "Ocurrió un error inesperado - 500";
                    ViewBag.Description = "Notifique al administrador de la aplicación para su revisión";
                    break;
                case 404:
                    ViewBag.Title = "Página no encontrada - 404";
                    ViewBag.Description = "La URL a la que está intentado ingresar no existe";
                    break;
                default:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "Algo salió mal :(";
                    break;
            }
            return View("~/Views/Error/_ErrorPage.cshtml");
        }
    }
}