using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMaintenance
{
    /// <summary>
    /// CustomerInfoDB class is responsible for connecting to the Customer Info Database
    /// </summary>
    public static class CustomerInfoDB
    {
        /// <summary>
        /// Represents the database connection
        /// </summary>
        public static SqlConnection DBConnection { get; private set; }

        /// <summary>
        /// Establishes and returns a database connection.  If the connection is already established,
        /// then the current connection is returned.
        /// </summary>
        /// <returns>Database Connection</returns>
        public static SqlConnection GetConnection()
        {
        }
        /// <summary>
        /// Establishes and returns a database connection.  If the connection is already established,
        /// then the current connection is returned.
        /// </summary>
        /// <returns>Database Connection</returns>
        public static SqlConnection GetConnection()
        {
            if (DBConnection == null)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["CustomerInfoDB"].ConnectionString;
            }
            return DBConnection;

        }
        /// <summary>
        /// Establishes and returns a database connection.  If the connection is already established,
        /// then the current connection is returned.
        /// </summary>
        /// <returns>Database Connection</returns>
        public static SqlConnection GetConnection()
        {
            if (DBConnection == null)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["CustomerInfoDB"].ConnectionString;
                DBConnection = new SqlConnection(connectionString);
                DBConnection.Open();
            }
            return DBConnection;
        }


    }
}
