using FancingClubManagementSystemProject.Model;
using FancingClubManagementSystemProject.Service;
using SharedLogic.Model;
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

namespace FancingClubManagementSystemProject.View
{
    /// <summary>
    /// Interaction logic for Attendance.xaml
    /// </summary>
    public partial class Attendance : Window
    {
        FensingService fs = new FensingService();
        public Attendance()
        {
            InitializeComponent();
            FensingService fs = new FensingService();
            membersTable.ItemsSource = fs.getMembersTable();
        }

        /// <summary>
        /// Add one member attendance 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void presentButton_Click(object sender, RoutedEventArgs e) //......
        {
            ClassAttendance newAtt = new ClassAttendance();
            fs.addAttendance(classDatePicker.Text, groupList.SelectedValue.ToString(), coachList.SelectedValue.ToString(), "10"); //.......
        }
    }
}
