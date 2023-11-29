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

namespace JS_ICTPRG432_AT3_PROJECT
{
    /// <summary>
    /// Interaction logic for Updaterecord.xaml
    /// </summary>
    /// 

    //=========================================
    //Name: Joshua Sutcliffe
    //Student ID: 20107131
    //Email: 20107131@tafe.wa.edu.au
    //Cluster - Data Driven Applications - SQL
    //Date Submitted: 30/11/2023
    //=========================================

    //n.b. I was unable to get the Edit record method (shown in the 14-WPF-IV.ppt (Data Binding)) working.
    //I couldn't get the SearchTextBox in MainWindow.xaml.cs to link to the record when pressing Edit button,
    //and carry that record through to the Updaterecord.xaml.cs.
    //In the end I coded the Update/Edit salary function into MainWindow.xaml.cs,
    //and therefore Updaterecord.xaml.cs/.xcaml and Employee.cs are redundant.

    public partial class Updaterecord : Window
    {
        Employee employee;
        public Updaterecord(String searchdata)
        {
            InitializeComponent();

            employee = new Employee();
            employee.Searchrec(searchdata);
            this.DataContext = employee;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            employee.Updaterec();
            MessageBox.Show("Saved");
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            IdText.Clear();
            GivenText.Clear();
            FamilyText.Clear();
            DOBText.Clear();
            GenderText.Clear();
            SalaryText.Clear();
            SupervisorText.Clear();
            BranchText.Clear();
        }
    }
}
