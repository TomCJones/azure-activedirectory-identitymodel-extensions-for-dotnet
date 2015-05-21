﻿using System;
using System.Diagnostics.Tracing;

namespace Microsoft.IdentityModel.Logging
{
    /// <summary>
    /// Helper class for logging.
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// Logs an error using the event source logger and throws an exception if the throwException is set to true.
        /// </summary>
        /// <param name="message">message to log.</param>
        /// <param name="exceptionType">Type of the exception to be thrown.</param>
        /// <param name="innerException">the inner <see cref="Exception"/> to be added to the outer exception.</param>
        /// <param name="throwException">boolean to set whether to throw exception or not. Default is true.</param>
        public static void Throw(string message, Type exceptionType, EventLevel logLevel, Exception innerException = null)
        {
            IdentityModelEventSource.Logger.Write(logLevel, message);

            if (innerException != null)
                throw (Exception)Activator.CreateInstance(exceptionType, message, innerException);
            else
                throw (Exception)Activator.CreateInstance(exceptionType, message);
        }
    }
}