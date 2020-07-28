using ProEducationalM.Models;
using ProEducationalM.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProEducationalM.Controllers
{
    public class SeccionController : Controller
    {
        // GET: Seccion
        public ActionResult Index()
        {
            return View();
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seccion seccion)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    SeccionServices seccionServices = new SeccionServices();

                    short idSeccionFromSQLServer;
                    bool errorYNFromSQLServer;
                    int errorNumberFromSQLServer;
                    int errorSeverityFromSQLServer;
                    int errorStatusFromSQLServer;
                    string errorProcedureFromSQLServer;
                    int errorLineFromSQLServer;
                    string errorMessageFromSQLServer;
                    string originClass;
                    string originMethod;
                    string inputValues;

                    inputValues = "Seccion=" + seccion.NombreSeccion + " ";

                    seccionServices.InsertSeccion(seccion,
                        out idSeccionFromSQLServer,
                    out errorYNFromSQLServer,
                    out errorNumberFromSQLServer,
                    out errorSeverityFromSQLServer,
                    out errorStatusFromSQLServer,
                    out errorProcedureFromSQLServer,
                    out errorLineFromSQLServer,
                    out errorMessageFromSQLServer,
                    out originClass,
                    out originMethod);

                    if (errorYNFromSQLServer == true)
                    {
                        //TempData["ErrorMensaje"] = "Error recibido de SQL";

                        //ExceptionHandling exceptionHandling = new ExceptionHandling();

                        //// Se escribe en log del browser
                        //string msg = exceptionHandling.propTemp1.ToString().Replace("'", ""); //Prevent js parsing errors. Could also add in an escape character instead if you really want the 's.
                        //msg = msg.Replace("\\", "-");
                        //Response.Write("<script>console.log(" + "'" + msg + "'" + ");</script>");
                        //Response.Write("<script>console.log('PRUEBA');</script>");

                        //exceptionHandling.HandleSQLException(
                        //    errorNumberFromSQLServer,
                        //    errorSeverityFromSQLServer,
                        //    errorStatusFromSQLServer,
                        //    errorProcedureFromSQLServer,
                        //    errorLineFromSQLServer,
                        //    errorMessageFromSQLServer,
                        //    originClass,
                        //    originMethod,
                        //    inputValues);
                    }
                    else
                    {
                        TempData["Exito"] = "Registro insertado con éxito";
                    }

                }

                //return RedirectToAction("Index");
                //return RedirectToAction("Create");
            }

            catch (SqlException ex)
            {
                if (ex.InnerException?.InnerException is SqlException exSql &&
                    exSql.Number == 2601)
                {
                    TempData["ErrorMensaje"] = "La sección " + "'" + seccion.NombreSeccion + "'" + " ya está registrado";
                }

                else if (ex.InnerException?.InnerException is SqlException exSql2 &&
                    exSql2.Number == 208)
                {
                    TempData["ErrorMensaje"] = "La tabla destino es inválida";
                }
                else
                {
                    TempData["ErrorMensaje"] = "Error específico SQL no detectado";
                }
            }
            catch (Exception generalException)
            {

                TempData["ErrorMensaje"] = "Error general";

                //ModelState.AddModelError(string.Empty,
                //   "An error occured - please contact your system administrator.");
            }
            finally
            {

            }

            return View();
        }
    }
}