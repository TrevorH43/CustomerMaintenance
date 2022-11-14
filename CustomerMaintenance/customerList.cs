using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMaintenance
{/// <summary>
 /// CustomerList will be used as a data source for the DataGridView
 /// </summary>
    public class CustomerList
    {
        private List<Customer> customers;

        /// <summary>
        /// Exposing the Customers To the Outside
        /// </summary>
        public List<Customer> Customers
        {
            get { return customers; }
        }

        /// <summary>
        /// No argument constructor
        /// </summary>
        public CustomerList()
        {
            customers = new List<Customer>();
        }

        /// <summary>
        /// Add a customer to the list
        /// </summary>
        /// <param name="customer">Customer Instance</param>
        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        /// <summary>
        /// Returns the number of items in the list
        /// </summary>
        public int Count
        {
            get
            { return customers.Count; }
        }

        /// <summary>
        /// Return the customer object that exists at the specified index location
        /// </summary>
        /// <param name="index">index location</param>
        /// <returns>Customer Object</returns>
        public Customer GetCustomerByIndex(int index)
        {
            return customers[index];
        }

        /// <summary>
        /// Removes the specified customer from the list
        /// </summary>
        /// <param name="customer">Customer instance to remove</param>
        public void Remove(Customer customer)
        {
            customers.Remove(customer);
        }

        /// <summary>
        /// Provides an index into the list
        /// </summary>
        /// <param name="i">index location within the list</param>
        /// <returns>Returns the customer instance at the specified location</returns>
        public Customer this[int i]
        {
            get
            {
                if (i < 0)
                {
                    throw new ArgumentOutOfRangeException("i");
                }
                else if (i >= customers.Count)
                {
                    throw new ArgumentOutOfRangeException("i");
                }
                return customers[i];
            }
            set
            {
                customers[i] = value;
            }
        }

        /// <summary>
        /// Overload the + operator to add an item to the list
        /// </summary>
        /// <param name="customerList">Customer List</param>
        /// <param name="customer">Customer Instance to Add</param>
        /// <returns></returns>
        public static CustomerList operator +(CustomerList customerList, Customer customer)
        {
            customerList.Add(customer);
            return customerList;
        }

        /// <summary>
        /// Overload the - operator to remove an item from the list
        /// </summary>
        /// <param name="customerList">Customer List</param>
        /// <param name="customer">Customer Instance to Remove</param>
        /// <returns></returns>
        public static CustomerList operator -(CustomerList customerList, Customer customer)
        {
            customerList.Remove(customer);
            return customerList;
        }

        /// <summary>
        ///  Returns the index location where the customer was found in the list
        /// </summary>
        /// <param name="customerToFind"></param>
        /// <returns></returns>
        public int IndexOf(Customer customerToFind)
        {
            int index = -1;
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i] == customerToFind)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
