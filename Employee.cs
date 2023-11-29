using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JS_ICTPRG432_AT3_PROJECT
{

    //=========================================
    //Name: Joshua Sutcliffe
    //Student ID: 20107131
    //Email: 20107131@tafe.wa.edu.au
    //Cluster - Data Driven Applications - SQL
    //Version 1.0
    //Date Submitted: 29/11/2023
    //=========================================


    //n.b. I was unable to get the Edit record method (shown in the 14-WPF-IV.ppt (Data Binding)) working.
    //I couldn't get the SearchTextBox in MainWindow.xaml.cs to link to the record when pressing Edit button,
    //and carry that record through to the Updaterecord.xaml.cs.
    //In the end I coded the Update/Edit salary function into MainWindow.xaml.cs,
    //and therefore Updaterecord.xaml.cs/.xcaml and Employee.cs are redundant.


    public class Employee
    {
        private string dbname = "js_ictprg431";
        private string dbuser = "root";
        private string dbpassword = "";
        private int dbport = 3306;
        private string dbserver = "localhost";
        private string dbsslm = "none";
        private string dbconnectionString = "";
        private MySqlConnection conn;


        public string SearchFamilyName { get; set; }
        public int ID { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public int SupervisorID { get; set; }
        public int BranchID { get; set; }

        public Employee()
        {
            dbconnectionString = String.Format("server={0};port={1};user={2};password={3};database={4};sslMode={5}", dbserver, dbport, dbuser, dbpassword, dbname, dbsslm);
            conn = new MySqlConnection(dbconnectionString);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No DB Connection");
            }
            finally
            {
                conn.Close();
            }
        }
        public void Searchrec(string searchdata)
        {

            //attempt at coding the Searchrec method, which in theory should link the family name input into the
            //SearchTextBox (in MainWindow.xaml.cs. Was unable to get it to link the records.
            try
            {
                string sqlToRun = "SELECT * FROM employee WHERE family_name = '" + searchdata + "'; ";
                SearchFamilyName = searchdata;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlToRun, conn);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ID = Convert.ToInt32(rdr["id"].ToString());
                    GivenName = rdr["given_name"].ToString();
                    FamilyName = rdr["family_name"].ToString();
                    DateOfBirth = rdr["date_of_birth"].ToString();
                    Gender = rdr["gender"].ToString();
                    Salary = int.Parse(rdr["gross_salary"].ToString());
                    SupervisorID = int.Parse(rdr["supervisor_id"].ToString());
                    BranchID = int.Parse(rdr["branch_id"].ToString());
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("No record found");
            }
        }
        public void Updaterec()
        {
            //attempt at coding the Updaterec method, but was unable to link the familyname in SearchTextBox
            //to the Updaterecord form. Ended up coding the update salary functionality into MainWindox.xaml.cs
            try
            {

                string sqlToRun = "UPDATE employee SET gross_salary= " + Salary + " WHERE family_name = '" + SearchFamilyName + "';";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlToRun, conn);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No record found");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
