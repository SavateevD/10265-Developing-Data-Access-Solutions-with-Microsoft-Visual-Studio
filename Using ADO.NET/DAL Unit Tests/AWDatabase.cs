using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DAL
{


    internal class AWDatabase
    {
        /// <summary>
        /// The connection string for the AdventureWorks Database
        /// </summary>
        internal static string DatabaseConnectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;

        /// <summary>
        /// Prevent object construction
        /// </summary>
        private AWDatabase() { }
    }

}
