using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMaintenance
{

    public partial class CustomerForm : Form
    {
        CustomerList customerList = new CustomerList();
        BindingSource source = new BindingSource();

        /// <summary>
        /// Customer Form Constructor
        /// </summary>
        /// <summary>
        /// Retrieves all data from the Customer table
        /// </summary>
        /// <returns>A list of Type objects</returns>
        public static List<Customer> GetCustomers()
        {
            // create the list
            List<Customer> customerList = new List<Customer>();
            SqlConnection connection = CustomerInfoDB.GetConnection();
            string sqlStatement = @"
        SELECT c.CustomerID, c.TypeID, t.TypeDesc,
            c.FirstName, c.LastName, c.Email,
            c.Phone, c.Company
        FROM Customers c, Types t
        WHERE c.TypeID = t.TypeID
        ORDER BY c.CustomerID";

            try
            {
                SqlConnection connection1 = CustomerInfoDB.GetConnection();
                SqlCommand cmd = new SqlCommand(sqlStatement, connection);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill();
                    foreach (DataRow dr in dt.Rows)
                    {
                        // Create instances of both the customer and type objects
                        Customer customer = new Customer();
                        customer.Type = new Type();

                        customer.CustomerId = (int)dr["CustomerID"];
                        customer.Type.TypeId = (int)dr["TypeID"];
                        customer.Type.TypeDesc = dr["TypeDesc"].ToString();
                        customer.FirstName = dr["FirstName"].ToString();
                        customer.LastName = dr["LastName"].ToString();
                        customer.Email = dr["Email"].ToString();
                        customer.Phone = dr["Phone"].ToString();
                        customer.Company = dr["Company"].ToString();

                        // Alternately, you could have done this as well and used the all argument constructor
                        //var customerId = (int)dr["CustomerID"];
                        //var typeId = (int)dr["TypeID"];
                        //var typeDesc = dr["TypeDesc"].ToString();
                        //var firstName = dr["FirstName"].ToString();
                        //var lastName = dr["LastName"].ToString();
                        //var email = dr["Email"].ToString();
                        //var phone = dr["Phone"].ToString();
                        //var company = dr["Company"].ToString();
                        //Type type = new Type(typeId, typeDesc);
                        //Customer customer = new Customer(customerId, type, firstName, lastName, email, phone, company);

                        customerList.Add(customer);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return customerList;
        }
    }
}
