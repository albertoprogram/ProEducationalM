﻿using ProEducationalM.Models;
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
        #region GET Index
        // GET: Seccion
        public ActionResult Index(string button, string maximoPagina, string ColumnaSeccionOrden, string busqueda)
        {

            if (busqueda != null)
            {
                Session["TextoBusquedaColumnSeccion"] = busqueda.Trim();
            }

            if (ColumnaSeccionOrden != null && button == "ColumnHeaderSeccion")
            {
                if (Session["ColumnSeccionIndexSeccionOrder"].ToString() == "ASC")
                {
                    Session["ColumnSeccionIndexSeccionOrder"] = "DESC";
                }
                else if (Session["ColumnSeccionIndexSeccionOrder"].ToString() == "DESC")
                {
                    Session["ColumnSeccionIndexSeccionOrder"] = "ASC";
                }
                else
                {
                    Session["ColumnSeccionIndexSeccionOrder"] = "ASC";
                }
            }

            Session["lastPageSeccionYN"] = false;

            if (maximoPagina != null && maximoPagina.Trim() != "")
            {
                Session["cantRegpagSeccion"] = Convert.ToInt32(maximoPagina);
            }

            switch (button)
            {
                case "FirstPage":
                case "UFirstPage":
                    Session["pagSeccion"] = 0;
                    break;
                case "PreviousPage":
                case "UPreviousPage":
                    if ((int)Session["pagSeccion"] >= 1)
                    {
                        Session["pagSeccion"] = (int)Session["pagSeccion"] - 1;
                    }
                    break;
                case "NextPage":
                case "UNextPage":
                    Session["pagSeccion"] = (int)Session["pagSeccion"] + 1;
                    break;
                case "LastPage":
                case "ULastPage":
                    //Session["pagSeccion"] = Convert.ToInt32(TempData["ultimaPagina"]) - 1;
                    Session["lastPageSeccionYN"] = true;
                    break;
                default:
                    Session["pagSeccion"] = 0;
                    break;
            }

            SeccionServices seccionServices = new SeccionServices();

            ExceptionHandling exceptionHandling = new ExceptionHandling();

            string inputValues = "ValoresPaginado:Pagina=" + Session["pagSeccion"].ToString() + "," +
                "CantidadRegistros=" + Session["cantRegpagSeccion"].ToString();

            try
            {
                bool errorYNFromSQLServer;
                int errorNumberFromSQLServer;
                int errorSeverityFromSQLServer;
                int errorStatusFromSQLServer;
                string errorProcedureFromSQLServer;
                int errorLineFromSQLServer;
                string errorMessageFromSQLServer;
                string originClass;
                string originMethod;
                int countFromSQLServer;
                int countPageFromSQLServer;



                var SeccionModel = seccionServices.GetAllSecciones((int)Session["pagSeccion"],
                    (int)Session["cantRegpagSeccion"],
                    (bool)Session["lastPageSeccionYN"],
                    Session["ColumnSeccionIndexSeccionOrder"].ToString(),
                    Session["TextoBusquedaColumnSeccion"].ToString(),
                    out errorYNFromSQLServer,
                    out errorNumberFromSQLServer,
                    out errorSeverityFromSQLServer,
                    out errorStatusFromSQLServer,
                    out errorProcedureFromSQLServer,
                    out errorLineFromSQLServer,
                    out errorMessageFromSQLServer,
                    out originClass,
                    out originMethod,
                    out countFromSQLServer,
                    out countPageFromSQLServer);

                if (errorYNFromSQLServer == true)
                {
                    exceptionHandling.HandleSQLException(
                        errorNumberFromSQLServer,
                        errorSeverityFromSQLServer,
                        errorStatusFromSQLServer,
                        errorProcedureFromSQLServer,
                        errorLineFromSQLServer,
                        errorMessageFromSQLServer,
                        originClass,
                        originMethod,
                        inputValues);

                    TempData["ErrorMensaje_Index_Seccion"] = "Error al intentar obtener datos";

                }
                else
                {
                    if (SeccionModel.Count() > 0)
                    {
                        TempData["countSecciones"] = countFromSQLServer;

                        TempData["countPageSecciones"] = countPageFromSQLServer;

                        TempData["ultimaPagina"] = (int)TempData["countSecciones"] / (int)Session["cantRegpagSeccion"];

                        if ((int)TempData["ultimaPagina"] == 0)
                        {
                            TempData["ultimaPagina"] = 1;
                        }
                        else if ((int)TempData["ultimaPagina"] >= 1)
                        {

                            if ((int)TempData["countSecciones"] % (int)Session["cantRegpagSeccion"] > 0)
                            {
                                TempData["ultimaPagina"] = (int)TempData["ultimaPagina"] + 1;
                            }
                            else if ((int)TempData["countSecciones"] % (int)Session["cantRegpagSeccion"] == 0)
                            {
                                TempData["ultimaPagina"] = (int)TempData["ultimaPagina"];
                            }

                        }

                        if ((bool)Session["lastPageSeccionYN"] == true)
                        {
                            TempData["paginaActual"] = (int)TempData["ultimaPagina"];
                            Session["pagSeccion"] = (int)TempData["ultimaPagina"] - 1;
                        }
                        else
                        {
                            TempData["paginaActual"] = (int)Session["pagSeccion"] + 1;
                        }

                        TempData["maximoPagina"] = (int)Session["cantRegpagSeccion"];
                    }
                    else
                    {
                        TempData["countSecciones"] = 0;
                        TempData["countPageSecciones"] = 0;
                        TempData["paginaActual"] = 0;
                        TempData["ultimaPagina"] = 0;
                        TempData["maximoPagina"] = Session["cantRegpagSeccion"].ToString();
                    }

                    TempData["Exito_Index_Seccion"] = "Devolución de datos con éxito";
                }

                return View(SeccionModel);

            }

            catch (Exception generalException)
            {
                exceptionHandling.HandleGeneralException(
                    generalException.Message,
                    generalException.InnerException.ToString(),
                    this.GetType().Name,
                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                    inputValues);

                TempData["ErrorMensaje_Index_Seccion"] = "Error general";

                return View();
            }
            finally
            {

            }

        }
        #endregion

        #region POST Delete
        // POST
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(string[] data)
        {
            ExceptionHandling exceptionHandling = new ExceptionHandling();

            exceptionHandling.WriteMessageInLog("I entered in ActionResult Delete HTTP POST - Controller Seccion - Line 215");

            Session["IDsEliminarSeccion"] = string.Join(",", data);

            Session["IDsEliminarSeccion"] = Session["IDsEliminarSeccion"].ToString().Replace("on,", "");

            SeccionServices seccionServices = new SeccionServices();

            short registrosEliminadosFromSQLServer;
            bool errorYNFromSQLServer;
            int errorNumberFromSQLServer;
            int errorSeverityFromSQLServer;
            int errorStatusFromSQLServer;
            string errorProcedureFromSQLServer;
            int errorLineFromSQLServer;
            string errorMessageFromSQLServer;
            string originClass;
            string originMethod;

            exceptionHandling.WriteMessageInLog("Just before calling seccionServices.DeleteSecciones - Controller Seccion - Line 234");

            seccionServices.DeleteSecciones(Session["IDsEliminarSeccion"].ToString(),
                out registrosEliminadosFromSQLServer,
            out errorYNFromSQLServer,
            out errorNumberFromSQLServer,
            out errorSeverityFromSQLServer,
            out errorStatusFromSQLServer,
            out errorProcedureFromSQLServer,
            out errorLineFromSQLServer,
            out errorMessageFromSQLServer,
            out originClass,
            out originMethod);

            exceptionHandling.WriteMessageInLog("Just after calling seccionServices.DeleteSecciones - Controller Seccion - Line 248");

            if (errorYNFromSQLServer == true)
            {
                exceptionHandling.WriteMessageInLog("I entered in errorYNFromSQLServer == true - Controller Seccion - Line 252");

                exceptionHandling.HandleSQLException(
                            errorNumberFromSQLServer,
                            errorSeverityFromSQLServer,
                            errorStatusFromSQLServer,
                            errorProcedureFromSQLServer,
                            errorLineFromSQLServer,
                            errorMessageFromSQLServer,
                            originClass,
                            originMethod,
                            Session["IDsEliminarSeccion"].ToString());

                TempData["ErrorMensaje"] = "Error al intentar eliminar la información.";

            }
            else
            {
                exceptionHandling.WriteMessageInLog("I entered in errorYNFromSQLServer == false - Controller Seccion - Line 270");

                TempData["Exito"] = "Se ha eliminado la información con éxito";
            }

            exceptionHandling.WriteMessageInLog("Just before calling return View() - Controller Seccion - Line 275");
            return View();
        }
        #endregion

        #region GET Create
        // GET
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region POST Create
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seccion seccion)
        {
            //System.Threading.Thread.Sleep(3000);

            ExceptionHandling exceptionHandling = new ExceptionHandling();

            string inputValues = "Seccion=" + seccion.NombreSeccion + " ";

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
                        //// Se escribe en log del browser
                        //string msg = exceptionHandling.propTemp1.ToString().Replace("'", ""); //Prevent js parsing errors. Could also add in an escape character instead if you really want the 's.
                        //msg = msg.Replace("\\", "-");
                        //Response.Write("<script>console.log(" + "'" + msg + "'" + ");</script>");
                        //Response.Write("<script>console.log('PRUEBA');</script>");

                        exceptionHandling.HandleSQLException(
                            errorNumberFromSQLServer,
                            errorSeverityFromSQLServer,
                            errorStatusFromSQLServer,
                            errorProcedureFromSQLServer,
                            errorLineFromSQLServer,
                            errorMessageFromSQLServer,
                            originClass,
                            originMethod,
                            inputValues);

                        Session["errorUniqueSeccion"] = errorMessageFromSQLServer.IndexOf("UNIQUE KEY");

                        if (Convert.ToInt16(Session["errorUniqueSeccion"]) >= 0)
                        {
                            TempData["ErrorMensaje"] = "El Paralelo '" + seccion.NombreSeccion + "' ya existe";
                        }
                        else
                        {
                            TempData["ErrorMensaje"] = "Error recibido desde la base de datos";
                        }

                    }
                    else
                    {
                        TempData["Exito"] = "El Paralelo '" + seccion.NombreSeccion + "' ha sido insertado con éxito";
                    }

                }

                //return RedirectToAction("Index");
                //return RedirectToAction("Create");
            }

            //catch (SqlException ex)
            //{
            //    //if (ex.InnerException?.InnerException is SqlException exSql &&
            //    //    exSql.Number == 2601)
            //    //{
            //    //    TempData["ErrorMensaje"] = "La sección " + "'" + seccion.NombreSeccion + "'" + " ya está registrado";
            //    //}

            //    //else if (ex.InnerException?.InnerException is SqlException exSql2 &&
            //    //    exSql2.Number == 208)
            //    //{
            //    //    TempData["ErrorMensaje"] = "La tabla destino es inválida";
            //    //}
            //    //else
            //    //{
            //    //    TempData["ErrorMensaje"] = "Error específico SQL no detectado";
            //    //}
            //}
            catch (Exception generalException)
            {
                exceptionHandling.HandleGeneralException(
                    generalException.Message,
                    generalException.InnerException.ToString(),
                    this.GetType().Name,
                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                    inputValues);

                TempData["ErrorMensaje"] = "Error general";
            }
            finally
            {

            }

            return View();
        }
        #endregion

        #region GET Edit
        public ActionResult Edit(Int16 ID, string nombreSeccion)
        {
            Seccion seccion = new Seccion();

            seccion.ID = ID;
            seccion.NombreSeccion = nombreSeccion;

            return View(seccion);
        }
        #endregion
    }
}