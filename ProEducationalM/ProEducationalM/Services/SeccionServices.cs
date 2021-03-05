using ProEducationalM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProEducationalM.Services
{
    public class SeccionServices
    {
        #region InsertSeccion
        public void InsertSeccion(Seccion seccion,
            out short idSeccionFromSQLServer,
            out bool errorYNFromSQLServer,
            out int errorNumberFromSQLServer,
            out int errorSeverityFromSQLServer,
            out int errorStatusFromSQLServer,
            out string errorProcedureFromSQLServer,
            out int errorLineFromSQLServer,
            out string errorMessageFromSQLServer,
            out string originClass,
            out string originMethod)
        {

            using (var db = new ProEducationalMDBContext())
            {
                var idSeccion = new SqlParameter
                {
                    ParameterName = "@idSeccion",
                    SqlDbType = SqlDbType.SmallInt,
                    Direction = ParameterDirection.Output
                };

                var errorYN = new SqlParameter
                {
                    ParameterName = "@errorYN",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };

                var errorNumber = new SqlParameter
                {
                    ParameterName = "@errorNumber",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var errorSeverity = new SqlParameter
                {
                    ParameterName = "@errorSeverity",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var errorStatus = new SqlParameter
                {
                    ParameterName = "@errorStatus",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var errorProcedure = new SqlParameter
                {
                    ParameterName = "@errorProcedure",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 250,
                    Direction = ParameterDirection.Output
                };

                var errorLine = new SqlParameter
                {
                    ParameterName = "@errorLine",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var errorMessage = new SqlParameter
                {
                    ParameterName = "@errorMessage",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 8000,
                    Direction = ParameterDirection.Output
                };

                db.Database.ExecuteSqlCommand("InsertSeccion " +
                    "@seccion," +
                    "@idSeccion OUTPUT," +
                    "@errorYN OUTPUT," +
                    "@errorNumber OUTPUT," +
                    "@errorSeverity OUTPUT," +
                    "@errorStatus OUTPUT," +
                    "@errorProcedure OUTPUT," +
                    "@errorLine OUTPUT," +
                    "@errorMessage OUTPUT",
                    new SqlParameter("@seccion", seccion.NombreSeccion),
                    idSeccion,
                    errorYN,
                    errorNumber,
                    errorSeverity,
                    errorStatus,
                    errorProcedure,
                    errorLine,
                    errorMessage
                    );

                idSeccionFromSQLServer = Convert.ToInt16(idSeccion.Value);
                errorYNFromSQLServer = Convert.ToBoolean(errorYN.Value);
                errorNumberFromSQLServer = Convert.ToInt32(errorNumber.Value);
                errorSeverityFromSQLServer = Convert.ToInt32(errorSeverity.Value);
                errorStatusFromSQLServer = Convert.ToInt32(errorStatus.Value);
                errorProcedureFromSQLServer = errorProcedure.Value.ToString();
                errorLineFromSQLServer = Convert.ToInt32(errorLine.Value);
                errorMessageFromSQLServer = errorMessage.Value.ToString();

                originClass = this.GetType().Name;
                originMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            }
        }
        #endregion

        #region GetAllSecciones
        public IEnumerable<Seccion> GetAllSecciones(
            int pagina,
            int cantidadRegistros,
            bool ultimaPaginaYN,
            string columnaSeccionOrden,
            string textoBusqueda,
            out bool errorYNFromSQLServer,
            out int errorNumberFromSQLServer,
            out int errorSeverityFromSQLServer,
            out int errorStatusFromSQLServer,
            out string errorProcedureFromSQLServer,
            out int errorLineFromSQLServer,
            out string errorMessageFromSQLServer,
            out string originClass,
            out string originMethod,
            out int countFromSQLServer,
            out int countPageFromSQLServer)
        {

            using (var db = new ProEducationalMDBContext())
            {
                var errorYN = new SqlParameter
                {
                    ParameterName = "@errorYN",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };

                var errorNumber = new SqlParameter
                {
                    ParameterName = "@errorNumber",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var errorSeverity = new SqlParameter
                {
                    ParameterName = "@errorSeverity",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var errorStatus = new SqlParameter
                {
                    ParameterName = "@errorStatus",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var errorProcedure = new SqlParameter
                {
                    ParameterName = "@errorProcedure",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 250,
                    Direction = ParameterDirection.Output
                };

                var errorLine = new SqlParameter
                {
                    ParameterName = "@errorLine",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var errorMessage = new SqlParameter
                {
                    ParameterName = "@errorMessage",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 8000,
                    Direction = ParameterDirection.Output
                };

                var count = new SqlParameter
                {
                    ParameterName = "@count",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var countPage = new SqlParameter
                {
                    ParameterName = "@countPage",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                IEnumerable<Seccion> secciones = db.Database.SqlQuery<Seccion>("GetAllSecciones " +
                    "@pagina," +
                    "@cantidadRegistros," +
                    "@ultimaPaginaYN," +
                    "@columnaSeccionOrden," +
                    "@textoBusqueda," +
                    "@errorYN OUTPUT," +
                    "@errorNumber OUTPUT," +
                    "@errorSeverity OUTPUT," +
                    "@errorStatus OUTPUT," +
                    "@errorProcedure OUTPUT," +
                    "@errorLine OUTPUT," +
                    "@errorMessage OUTPUT," +
                    "@count OUTPUT," +
                    "@countPage OUTPUT",
                    new SqlParameter("@pagina", pagina),
                    new SqlParameter("@cantidadRegistros", cantidadRegistros),
                    new SqlParameter("@ultimaPaginaYN", ultimaPaginaYN),
                    new SqlParameter("@columnaSeccionOrden", columnaSeccionOrden),
                    new SqlParameter("@textoBusqueda", textoBusqueda),
                    errorYN,
                    errorNumber,
                    errorSeverity,
                    errorStatus,
                    errorProcedure,
                    errorLine,
                    errorMessage,
                    count,
                    countPage).ToList();

                errorYNFromSQLServer = Convert.ToBoolean(errorYN.Value);
                errorNumberFromSQLServer = Convert.ToInt32(errorNumber.Value);
                errorSeverityFromSQLServer = Convert.ToInt32(errorSeverity.Value);
                errorStatusFromSQLServer = Convert.ToInt32(errorStatus.Value);
                errorProcedureFromSQLServer = errorProcedure.Value.ToString();
                errorLineFromSQLServer = Convert.ToInt32(errorLine.Value);
                errorMessageFromSQLServer = errorMessage.Value.ToString();
                countFromSQLServer = Convert.ToInt32(count.Value);
                countPageFromSQLServer = Convert.ToInt32(countPage.Value);

                originClass = this.GetType().Name;
                originMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

                return secciones;
            }
        }
        #endregion

        #region DeleteSecciones
        public void DeleteSecciones(string secciones,
            out short registrosEliminadosFromSQLServer,
            out bool errorYNFromSQLServer,
            out int errorNumberFromSQLServer,
            out int errorSeverityFromSQLServer,
            out int errorStatusFromSQLServer,
            out string errorProcedureFromSQLServer,
            out int errorLineFromSQLServer,
            out string errorMessageFromSQLServer,
            out string originClass,
            out string originMethod)
        {
            ExceptionHandling exceptionHandling = new ExceptionHandling();

            exceptionHandling.WriteMessageInLog("I entered in Method DeleteSecciones - SeccionServices.cs - Line 273");

            using (var db = new ProEducationalMDBContext())
            {
                exceptionHandling.WriteMessageInLog("I entered in using var db in DeleteSecciones - SeccionServices.cs - Line 277");

                var registrosEliminados = new SqlParameter
                {
                    ParameterName = "@registrosEliminados",
                    SqlDbType = SqlDbType.SmallInt,
                    Direction = ParameterDirection.Output
                };

                var errorYN = new SqlParameter
                {
                    ParameterName = "@errorYN",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };

                var errorNumber = new SqlParameter
                {
                    ParameterName = "@errorNumber",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var errorSeverity = new SqlParameter
                {
                    ParameterName = "@errorSeverity",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var errorStatus = new SqlParameter
                {
                    ParameterName = "@errorStatus",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var errorProcedure = new SqlParameter
                {
                    ParameterName = "@errorProcedure",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 250,
                    Direction = ParameterDirection.Output
                };

                var errorLine = new SqlParameter
                {
                    ParameterName = "@errorLine",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var errorMessage = new SqlParameter
                {
                    ParameterName = "@errorMessage",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 8000,
                    Direction = ParameterDirection.Output
                };

                exceptionHandling.WriteMessageInLog("Just before calling ExecuteSqlCommand - Data to send: " + secciones + " DeleteSecciones - SeccionServices.cs - Line 337");

                try
                {


                    db.Database.ExecuteSqlCommand("DeleteSecciones " +
                        "@secciones," +
                        "@registrosEliminados OUTPUT," +
                        "@errorYN OUTPUT," +
                        "@errorNumber OUTPUT," +
                        "@errorSeverity OUTPUT," +
                        "@errorStatus OUTPUT," +
                        "@errorProcedure OUTPUT," +
                        "@errorLine OUTPUT," +
                        "@errorMessage OUTPUT",
                        new SqlParameter("@secciones", secciones),
                        registrosEliminados,
                        errorYN,
                        errorNumber,
                        errorSeverity,
                        errorStatus,
                        errorProcedure,
                        errorLine,
                        errorMessage
                        );
                }
                catch (Exception ex)
                {
                    exceptionHandling.WriteMessageInLog("Inside the catch block - Just after calling ExecuteSqlCommand - DeleteSecciones - SeccionServices.cs - Line 366");

                    exceptionHandling.WriteMessageInLog("Error received: " + ex.Message);
                }

                exceptionHandling.WriteMessageInLog("Just after calling ExecuteSqlCommand - DeleteSecciones - SeccionServices.cs - Line 369");

                registrosEliminadosFromSQLServer = Convert.ToInt16(registrosEliminados.Value);
                errorYNFromSQLServer = Convert.ToBoolean(errorYN.Value);
                errorNumberFromSQLServer = Convert.ToInt32(errorNumber.Value);
                errorSeverityFromSQLServer = Convert.ToInt32(errorSeverity.Value);
                errorStatusFromSQLServer = Convert.ToInt32(errorStatus.Value);
                errorProcedureFromSQLServer = errorProcedure.Value.ToString();
                errorLineFromSQLServer = Convert.ToInt32(errorLine.Value);
                errorMessageFromSQLServer = errorMessage.Value.ToString();

                originClass = this.GetType().Name;
                originMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            }
        }
        #endregion
    }
}