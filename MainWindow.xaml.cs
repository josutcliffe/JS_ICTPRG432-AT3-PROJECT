using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JS_ICTPRG432_AT3_PROJECT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    //=========================================
    //Name: Joshua Sutcliffe
    //Student ID: 20107131
    //Email: 20107131@tafe.wa.edu.au
    //Cluster - Data Driven Applications - SQL
    //Version 1.0
    //Date Submitted: 29/11/2023
    //=========================================

    //Tasks to complete:
    //DONE: Show all employees information
    //DONE: Search specific employee information by his/her name. For example: show the information/Salary for Kelly Kapoor
    //DONE: Show all employees who work in the same branch. For example, user wants to see all employees in the branch number 2
    //DONE: Show all employees information who have salary more than $70000
    //DONE: Add a new employee
    //DONE: Delete an employee record
    //DONE: Show the employee sales using Works Table. For example, user want to see total sales for Michael Scott
    //DONE: Optional: If he sales to different companies show the separate total sales(optional)
    //Done: Update/Save the salary of any of the employee


    public partial class MainWindow : Window
    {
        // Define Connection Details
        private string dbName = "js_ictprg431";
        private string dbUser = "root";
        private string dbPassword = "";
        private int dbPort = 3306;
        private string dbServer = "localhost";

        // Connection String and MySQL Connection
        private string dbConnectionString = "";
        private MySqlConnection conn;

        public MainWindow()
        {
            InitializeComponent();
            dbConnectionString = $"server={dbServer}; user={dbUser}; database={dbName}; port={dbPort}; password={dbPassword}";
            conn = new MySqlConnection(dbConnectionString);
        }

        //connects to the database and pulls all records for all employees in employees table
        private void FillButton_Click(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "SELECT * FROM employees;";
            try
            {
                EmployeeListbox.Items.Clear();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeListbox.Items.Add($"{rdr[0]} : {rdr[1]} {rdr[2],5} : {rdr[3],5} : {rdr[4],5} : {rdr[5],5} : {rdr[6],5} : {rdr[7],5} : {rdr[8],5} : {rdr[9],5}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        //searches employee records based on given name or family name
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "SELECT * FROM employees WHERE given_name LIKE '%" + SearchTextbox.Text + "%' OR family_name LIKE '%" + SearchTextbox.Text + "%';";
            try
            {
                EmployeeListbox.Items.Clear();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeListbox.Items.Add($"{rdr[0]} : {rdr[1]} {rdr[2],5} : {rdr[3],5} : {rdr[4],5} : {rdr[5],5} : {rdr[6],5} : {rdr[7],5} : {rdr[8],5} : {rdr[9],5}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        //launches the add employee form
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            Addwindow op1 = new Addwindow();
            op1.ShowDialog();
        }

        //deletes employee based on family name
        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "DELETE FROM employees WHERE family_name LIKE '%" + SearchTextbox.Text + "%';";
            try
            {
                EmployeeListbox.Items.Clear();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeListbox.Items.Add($"{rdr[0]} : {rdr[1]} {rdr[2],5} : {rdr[3],5} : {rdr[4],5} : {rdr[5],5} : {rdr[6],5} : {rdr[7],5} : {rdr[8],5} : {rdr[9],5}");
                }
                MessageBox.Show("Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        //filter employee records by branch number input into textbox
        private void FilterByBranch_Click(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "SELECT * FROM employees WHERE branch_id = '" + FilterBranchTextBox.Text + "';";
            try
            {
                EmployeeListbox.Items.Clear();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeListbox.Items.Add($"{rdr[0]} : {rdr[1]} {rdr[2],5} : {rdr[3],5} : {rdr[4],5} : {rdr[5],5} : {rdr[6],5} : {rdr[7],5} : {rdr[8],5} : {rdr[9],5}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        //filter employee salaries by number input into textbox
        private void FilterBySalary_Click(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "SELECT * FROM employees WHERE gross_salary = '" + FilterSalaryTextBox.Text + "' OR gross_salary > '" + FilterSalaryTextBox.Text + "';";
            try
            {
                EmployeeListbox.Items.Clear();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeListbox.Items.Add($"{rdr[0]} : {rdr[1]} {rdr[2],5} : {rdr[3],5} : {rdr[4],5} : {rdr[5],5} : {rdr[6],5} : {rdr[7],5} : {rdr[8],5} : {rdr[9],5}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        //defines the Sales class and it's parameters. to be used in the Datagrid
        public class Sales
        {
            public string FamilyName { get; set; }
            public string GivenName { get; set; }
            public int ClientID { get; set; }
            public int Total_Sales { get; set; }
        }

        //functionality to display total sales in datagrid.
        //SQL query joins the employees table and the working_with table to show the sales for any employee with sales,
        //or employee filtered in the SearchTextBox
        private void ShowSalesButton_Click(object sender, RoutedEventArgs e)
        {
            List<Sales> list = new List<Sales>();
            string sqlQuery = "SELECT employees.given_name, employees.family_name, working_with.client_id, working_with.total_sales FROM employees " +
                "INNER JOIN working_with ON employees.id = working_with.employee_id " +
                "WHERE employees.family_name LIKE '%" + SearchTextbox.Text + "%';";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Sales sales = new Sales();
                    sales.GivenName = Convert.ToString(rdr["given_name"]);
                    sales.FamilyName = Convert.ToString(rdr["family_name"]);
                    sales.ClientID = Convert.ToInt32(rdr["client_id"]);
                    sales.Total_Sales = Convert.ToInt32(rdr["total_sales"]);
                    list.Add(sales);
                }
                Datagrid.ItemsSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        //funtionality to edit an employees' salary. attempted to code this with Updaterecord.xaml.cs but was unable
        //to get the SearchTextBox input to link to the database and show tha record when the Updaterecord window opened.
        //In the end I coded the edit salary here. It uses the FilterSalaryTextBox (from the salary filter method) for input.
        private void EditSalaryButton_Click(object sender, RoutedEventArgs e)
        {
            string sqlToRun = "UPDATE employees SET gross_salary= " + FilterSalaryTextBox.Text + " WHERE given_name = '" + SearchTextbox.Text + "' " +
                "OR family_name = '" + SearchTextbox.Text + "';";
            try
            {
                EmployeeListbox.Items.Clear();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlToRun, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeListbox.Items.Add($"{rdr[0]} : {rdr[1]} {rdr[2],5} : {rdr[3],5} : {rdr[4],5} : {rdr[5],5} : {rdr[6],5} : {rdr[7],5} : {rdr[8],5} : {rdr[9],5}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }
    }
}
