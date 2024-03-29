﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProEducationalM.Services
{
    public class ExceptionHandling
    {
        #region HandleSQLException
        public void HandleSQLException(
            int errorNumberFromSQLServer,
            int errorSeverityFromSQLServer,
            int errorStatusFromSQLServer,
            string errorProcedureFromSQLServer,
            int errorLineFromSQLServer,
            string errorMessageFromSQLServer,
            string originClass,
            string originMethod,
            string inputValues)
        {
            string applicationPath;

            applicationPath = AppDomain.CurrentDomain.BaseDirectory;

            applicationPath = applicationPath + "ErrorsLogsPEM" + @"\";

            string fileNameLog = "ProEducationalMLogSQL_" +
                DateTime.Now.ToString("yyyy-MM-dd") +
                ".log";

            string fullPathLog = applicationPath + fileNameLog;

            string errorText;

            errorText = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + " " +
                "ErrorNumber:" + errorNumberFromSQLServer.ToString() + " " +
                "ErrorSeverity:" + errorSeverityFromSQLServer.ToString() + " " +
                "ErrorStatus:" + errorStatusFromSQLServer.ToString() + " " +
                "ErrorProcedure:" + errorProcedureFromSQLServer + " " +
                "ErrorLine:" + errorLineFromSQLServer.ToString() + " " +
                "ErrorMessage:" + errorMessageFromSQLServer + " " +
                "OriginClass:" + originClass + " " +
                "OriginMethod:" + originMethod + " " +
                "InputValues:" + inputValues;

            using (StreamWriter file = new StreamWriter(fullPathLog, true))
            {
                file.WriteLine(errorText);
                file.Close();
            }
        }
        #endregion

        #region HandleGeneralException
        public void HandleGeneralException(
            string errorMessage,
            string errorInnerException,
            string originClass,
            string originMethod,
            string inputValues)
        {
            string applicationPath;

            applicationPath = AppDomain.CurrentDomain.BaseDirectory;

            applicationPath = applicationPath + "ErrorsLogsPEM" + @"\";

            string fileNameLog = "ProEducationalMGenLog_" +
                DateTime.Now.ToString("yyyy-MM-dd") +
                ".log";

            string fullPathLog = applicationPath + fileNameLog;

            string errorText;

            errorText = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + " " +
                "ErrorMessage:" + errorMessage + " " +
                "InnerException:" + errorInnerException + " " +
                "OriginClass:" + originClass + " " +
                "OriginMethod:" + originMethod + " " +
                "InputValues:" + inputValues;

            using (StreamWriter file = new StreamWriter(fullPathLog, true))
            {
                file.WriteLine(errorText);
                file.Close();
            }

        }
        #endregion

        #region WriteMessageInLog
        public void WriteMessageInLog(string message)
        {
            string applicationPath;

            applicationPath = AppDomain.CurrentDomain.BaseDirectory;

            applicationPath = applicationPath + "Messages" + @"\";

            string fileNameLog = "ProEduMessageLog_" +
                DateTime.Now.ToString("yyyy-MM-dd") +
                ".log";

            string fullPathLog = applicationPath + fileNameLog;

            message = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + " " + message;

            using (StreamWriter file = new StreamWriter(fullPathLog, true))
            {
                file.WriteLine(message);
                file.Close();
            }
        }
        #endregion
    }
}