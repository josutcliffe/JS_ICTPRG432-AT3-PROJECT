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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace JS_ICTPRG432_AT3_PROJECT
{
    /// <summary>
    /// Interaction logic for Addwindow.xaml
    /// </summary>
    /// 

    //=========================================
    //Name: Joshua Sutcliffe
    //Student ID: 20107131
    //Email: 20107131@tafe.wa.edu.au
    //Cluster - Data Driven Applications - SQL
    //Version 1.0
    //Date Submitted: 29/11/2023
    //=========================================

    public partial class Addwindow : Window
    {
        public Addwindow()
        {
            InitializeComponent();
        }

        string dbconnectionString = "datasource=localhost; port=3306; database=js_ictprg431; username=root; password='';";

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            addemployee();
        }

        public void addemployee()
        {
            MySqlConnection conn = new MySqlConnection(dbconnectionString);

            //all fields qre required to INSERT new employee record. created_at and updated_at are default NULL e.g., current timestamp

            string sqlQuery = "INSERT INTO employees VALUES ('" + this.IdText.Text + "','" + this.GivenText.Text + "','" + this.FamilyText.Text + "','" +
                this.DOBText.Text + "','" + this.GenderText.Text + "','" + this.SalaryText.Text + "','" + this.SupervisorText.Text + "','" + this.BranchText.Text + "', NOW(), NOW())";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            try
            {
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand(sqlQuery, conn);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Added");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            cleardata();
        }

        public void cleardata()
        {

            //clears the form

            IdText.Clear();
            GivenText.Clear();
            FamilyText.Clear();
            DOBText.Clear();
            GenderText.Clear();
            GenderText.Clear();
            SalaryText.Clear();
            SupervisorText.Clear();
            BranchText.Clear();
        }
    }
}
