using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public partial class CustomerForm : Form
    {
        CustomerList customerList = new CustomerList();
        BindingSource source = new BindingSource();
        Customer currentCustomer = new Customer();
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            typeComboBox.SelectedIndex = -1;
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            emailTextBox.Clear();
            phoneTextBox.Clear();
            companyTextBox.Clear();

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {
                List<Type> typeList = new List<Type>();
                try
                {
                    typeList = TypeDB.GetTypes();
                    typeComboBox.DataSource = typeList;
                    typeComboBox.DisplayMember = "TypeDesc";
                    typeComboBox.ValueMember = "TypeId";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }

                // Populate the Customer's List by executing the sql statement
                customerList.Fill();

                customerDataGridView.DataSource = source;

                HandleChange(customerList);

                // Register the method to execute when the CustomerList instance raises a "Changed" event
                customerList.Changed += new CustomerList.ChangeHandler(HandleChange);
            }
        
        /// <summary>
        /// Adds a Customer to the Database
        /// </summary>
        /// <param name="customer">Customer Object used to Add record to database</param>
        /// <returns></returns>        
        public static int AddCustomer(Customer customer)
        {
            string sqlStatement = @"
        INSERT INTO Customers
        (TypeId, FirstName, LastName, Email, Phone, Company)
        VALUES(@1, @2, @3, @4, @5, @6)";

            try
            {
                SqlConnection connection = CustomerInfoDB.GetConnection();
                SqlCommand cmd = new SqlCommand(sqlStatement, connection);
                cmd.Parameters.AddWithValue("@1", customer.Type.TypeId);
                cmd.Parameters.AddWithValue("@2", customer.FirstName);
                cmd.Parameters.AddWithValue("@3", customer.LastName);
                cmd.Parameters.AddWithValue("@4", customer.Email);
                cmd.Parameters.AddWithValue("@5", customer.Phone);
                cmd.Parameters.AddWithValue("@6", customer.Company);
                cmd.ExecuteNonQuery();

                // IDENT_CURRENT returns the last identity value generated for a specific table
                sqlStatement = @"
            SELECT IDENT_CURRENT('dbo.Customer') AS Result";

                cmd = new SqlCommand(sqlStatement, connection);
                int customerID = Convert.ToInt32(cmd.ExecuteScalar());
                return customerID;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Add a customer to the list
        /// </summary>
        /// <param name="customer">Customer Instance</param>

        private void addButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Type = (Type)typeComboBox.SelectedItem;
            customer.FirstName = firstNameTextBox.Text;
            customer.LastName = lastNameTextBox.Text;
            customer.Email = emailTextBox.Text;
            customer.Phone = phoneTextBox.Text;
            customer.Company = companyTextBox.Text;

            customerList += customer;
            clearButton.PerformClick();
        }
        public class CustomerList
        {
            private List<Customer> customers;

            /// <summary>
            /// Define a delegate
            /// </summary>
            /// <param name="customers"></param>
            public delegate void ChangeHandler(CustomerList customers);

            /// <summary>
            /// Declaring a Changed Event
            /// </summary>
            public event ChangeHandler Changed;
        }
        private void HandleChange(CustomerList customers)
        {
            // Update the customer list
            customerList = customers;
            source.DataSource = customerList.Customers;
            customerDataGridView.DataSource = null;
            customerDataGridView.DataSource = source;
        }

        private void customerDataGridView_SelectionChanged(object sender, CancelEventArgs e)
        {
            var rowsCount = customerDataGridView.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1) return;
            var currentIndex = customerDataGridView.CurrentCell.RowIndex;
            currentCustomer = customerList.Customers[currentIndex];
            FillCustomerFields(currentCustomer);
        }
        private void FillCustomerFields(Customer customer)
        {
            typeComboBox.SelectedValue = customer.Type.TypeId;
            firstNameTextBox.Text = customer.FirstName;
            lastNameTextBox.Text = customer.LastName;
            emailTextBox.Text = customer.Email;
            phoneTextBox.Text = customer.Phone;
            companyTextBox.Text = customer.Company;

            typeComboBox.Focus();
        }
    }
}
