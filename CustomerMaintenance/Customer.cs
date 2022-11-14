using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMaintenance
{
    /// <summary>
    /// Customer Instance representing a record in the Customer Table
    /// </summary>
    public class Customer
    {
        [DisplayName("Customer Id")]
        /// <summary>
        /// Customer ID - Unique ID for a Customer
        /// </summary>
        public int CustomerId { get; set; }

        [Browsable(false)]
        /// <summary>
        /// Represents a Type of Customer and Holds an Instance of a record
        /// from the Type Table
        /// </summary>
        public Type Type { get; set; }

        [DisplayName("Customer Type")]
        /// <summary>
        /// Customer Type that is dependent on the instances Type property.
        /// This is only being exposed for use in the DataGridView.
        /// </summary>
        public string TypeDesc { get => this.Type.TypeDesc; }

        [DisplayName("First Name")]
        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        [DisplayName("Email Address")]
        /// <summary>
        /// Email Address
        /// </summary>
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        /// <summary>
        /// Phone Number
        /// </summary>
        public string Phone { get; set; }

        [DisplayName("Company Name")]
        /// <summary>
        /// Company Name
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// No argument constructor
        /// </summary>
        public Customer()
        {
        }

        /// <summary>
        /// The All parameter constructor
        /// </summary>
        /// <param name="customerId">The Unique Id for a customer</param>
        /// <param name="type">The type object instance</param>
        /// <param name="firstName">The first name of the customer</param>
        /// <param name="lastName">The last name of the customer</param>
        /// <param name="email">The email address of the customer</param>
        /// <param name="phone">The phone number of the customer</param>
        /// <param name="company">The company name for the customer</param>
        public Customer(int customerId, Type type, string firstName, string lastName, string email, string phone, string company)
        {
            this.CustomerId = customerId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Company = company;
            this.Type = type;
        }
        /// <summary>
        /// Determines if an object that is passed in is equal to the current
        /// instance based on this current instance's properties
        /// </summary>
        /// <param name="obj">The object to check to see if it is equal</param>
        /// <returns>Returns a boolean value indicating if they are equal</returns>
        public override bool Equals(object obj)
        {
            // Is the object passed in null?  If so, it cannot be equal
            if (obj == null)
                return false;

            // Is the object passed in the same type as this class?  If not,
            // then it cannot be equal
            if (obj.GetType() != typeof(Customer))
                return false;

            // Now it is safe to cast the generic object that was passed in
            // as a Customer
            Customer customer = (Customer)obj;

            // In order to see if this instance of an object is equal to the object
            // passed in, we need to check the values.
            if (this.CustomerId == customer.CustomerId &&
                this.Type == customer.Type &&
                this.FirstName == customer.FirstName &&
                this.LastName == customer.LastName &&
                this.Email == customer.Email &&
                this.Phone == customer.Phone &&
                this.Company == customer.Company)
                return true;
            else
                return false;
        }
        public override int GetHashCode() => (CustomerId, Type, FirstName, LastName, Email, Phone, Company).GetHashCode();
      
        /// <summary>
        /// Compares to Customer objects for equivalence in a logical comparison
        /// </summary>
        /// <param name="customer1">Customer object instance 1</param>
        /// <param name="customer2">Customer object instance 2</param>
        /// <returns>Boolean indicating if the two types are equivalent</returns>
        public static bool operator ==(Customer customer1, Customer customer2)
        {
            if (Object.Equals(customer1, null))
                if (Object.Equals(customer2, null))
                    return true;
                else
                    return false;
            else
                return customer1.Equals(customer2);
        }

        /// <summary>
        /// Compares to Customer objects to determine if they are not equivalent 
        /// in a logical comparison
        /// </summary>
        /// <param name="customer1">Customer object instance 1</param>
        /// <param name="customer2">Customer object instance 2</param>
        /// <returns>Boolean indicating if the two Customers are equivalent</returns>
        public static bool operator !=(Customer customer1, Customer customer2)
        {
            // Dependent on the prior implementation of the == operator
            return !(customer1 == customer2);
        }

    }
}
