using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMaintenance
{
    /// <summary>
    /// Provides Database Access to the Types table
    /// </summary>
    public static class TypeDB
    {
        /// <summary>
        /// Retrieves all data from the Types table
        /// </summary>
        /// <returns>A list of Type objects</returns>
        public static List<Type> GetTypes()
        {
            List<Type> typeList = new List<Type>();
            SqlConnection dbConnection = CustomerInfoDB.GetConnection();
            string sqlStatement = "SELECT TypeId, TypeDesc FROM Types ORDER BY TypeDesc";
            SqlCommand command = new SqlCommand(sqlStatement, dbConnection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Type type = new Type();
                    type.TypeId = (int)reader["TypeId"];
                    type.TypeDesc = (string)reader["TypeDesc"];
                    typeList.Add(type);
                }

                // Must close the DataReader - just like a file
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return typeList;
        }

    }

    }




