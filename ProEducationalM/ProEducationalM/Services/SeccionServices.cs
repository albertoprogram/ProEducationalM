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
        #region InsertCapitalPhase1
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

        public IEnumerable<Seccion> GetAllSecciones(
            int pagina,
            int cantidadRegistros,
            out bool errorYNFromSQLServer,
            out int errorNumberFromSQLServer,
            out int errorSeverityFromSQLServer,
            out int errorStatusFromSQLServer,
            out string errorProcedureFromSQLServer,
            out int errorLineFromSQLServer,
            out string errorMessageFromSQLServer,
            out string originClass,
            out string originMethod,
            out int countFromSQLServer)
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

                //string storedProcedure = "DECLARE " +
                //    "@pagina INT," +
                //    "@cantidadRegistros INT," +
                //    "@errorYN BIT," +
                //    "@errorNumber INT," +
                //    "@errorSeverity INT," +
                //    "@errorStatus INT," +
                //    "@errorProcedure VARCHAR(250)," +
                //    "@errorLine INT," +
                //    "@errorMessage VARCHAR(8000) " +
                //    "EXEC GetAllSecciones " +
                //    pagina + "," +
                //    cantidadRegistros + "," +
                //    "@errorYN OUTPUT," +
                //    "@errorNumber OUTPUT," +
                //    "@errorSeverity OUTPUT," +
                //    "@errorStatus OUTPUT," +
                //    "@errorProcedure OUTPUT," +
                //    "@errorLine OUTPUT," +
                //    "@errorMessage OUTPUT";

                IEnumerable<Seccion> secciones = db.Database.SqlQuery<Seccion>("GetAllSecciones " +
                    "@pagina," +
                    "@cantidadRegistros," +
                    "@errorYN OUTPUT," +
                    "@errorNumber OUTPUT," +
                    "@errorSeverity OUTPUT," +
                    "@errorStatus OUTPUT," +
                    "@errorProcedure OUTPUT," +
                    "@errorLine OUTPUT," +
                    "@errorMessage OUTPUT," +
                    "@count OUTPUT",
                    new SqlParameter("@pagina", pagina),
                    new SqlParameter("@cantidadRegistros", cantidadRegistros),
                    errorYN,
                    errorNumber,
                    errorSeverity,
                    errorStatus,
                    errorProcedure,
                    errorLine,
                    errorMessage,
                    count).ToList();

                errorYNFromSQLServer = Convert.ToBoolean(errorYN.Value);
                errorNumberFromSQLServer = Convert.ToInt32(errorNumber.Value);
                errorSeverityFromSQLServer = Convert.ToInt32(errorSeverity.Value);
                errorStatusFromSQLServer = Convert.ToInt32(errorStatus.Value);
                errorProcedureFromSQLServer = errorProcedure.Value.ToString();
                errorLineFromSQLServer = Convert.ToInt32(errorLine.Value);
                errorMessageFromSQLServer = errorMessage.Value.ToString();
                countFromSQLServer = Convert.ToInt32(count.Value);

                originClass = this.GetType().Name;
                originMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

                return secciones;
            }
        }
    }
}