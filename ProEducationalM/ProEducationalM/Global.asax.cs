﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProEducationalM
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;

            int error = httpException != null ? httpException.GetHttpCode() : 0;

            Server.ClearError();
            Response.Redirect(String.Format("~/Error/?error={0}", error, exception.Message));
        }

        protected void Session_Start()
        {
            // Variables de session de la view Index del controller Seccion
            Session["pagSeccion"] = 0;
            Session["cantRegpagSeccion"] = 5;
            Session["lastPageSeccionYN"] = false;
            Session["ColumnSeccionIndexSeccionOrder"] = "ASC";
            Session["TextoBusquedaColumnSeccion"] = "";
            Session["IDsEliminarSeccion"] = "";
        }
    }
}
