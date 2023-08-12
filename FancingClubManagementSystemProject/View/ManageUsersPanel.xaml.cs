using FancingClubManagementSystemProject.Model;
using FancingClubManagementSystemProject.Service;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
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
    /// Interaction logic for ManageUsersPanel.xaml
    /// </summary>
    public partial class ManageUsersPanel : Window
    {
        FensingService fs = new FensingService();

        public ManageUsersPanel()
        {
            InitializeComponent();
            updateMemberTables();
        }

        /*
         * Method Add new Member
         */
        private void addMemberButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameFirstBox.Text) && string.IsNullOrEmpty(nameLastBox.Text))
            {
                MessageBox.Show("Enter First and Last Name ");
            }
            else
            {
                fs.addMember(nameFirstBox.Text,nameLastBox.Text,dateBirthPicker.Text, phoneBox.Text,
                    emailBox.Text, licenseBox.Text, dateLicenceExpirePicker.Text);

                MessageBox.Show("Member was added successfuly");
                updateMemberTables();
            }    
        }

        /*
         * Method updates Member Tables everywhere
         */
        private void updateMemberTables()
        {
            membersTable.ItemsSource = fs.getMembersTable();
            membersTable1.ItemsSource = fs.getMembersTable();
        }

            /*
             * Method deletes Member by nameLast
             */
            
            private void deleteButton_Click_1(object sender, RoutedEventArgs e)
            {
                fs.deleteMemberById(filerIdBox.Text);
                MessageBox.Show("Member was deleted successfuly");
                updateMemberTables();            
            }


            /*
           * Method get Member by ID 
           */
        private void selectMemberById_Click(object sender, RoutedEventArgs e)
        {
            Member member;

            if (string.IsNullOrEmpty(filerIdBox.Text))
            {
                MessageBox.Show("Enter valid ID");
            }
            else
            {
                membersTable.ItemsSource = fs.getMemberById(filerIdBox.Text);
            }
               
        }


        /*
       * Method Updates Member by  name
       */
        private void updateMemberButton_Click_1(object sender, RoutedEventArgs e)
        {
            fs.updateMemberById(nameFirstBox.Text, nameLastBox.Text, dateBirthPicker.Text, 
                phoneBox.Text, emailBox.Text, licenseBox.Text, dateLicenceExpirePicker.Text,
                idBox.Text);

            MessageBox.Show("Member was added successfuly");
            updateMemberTables();

        }

        private void membersTable1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /*
         * Method updates Member Table at the Member List Tab by the Button UPDATE
         */
        private void updateMembersTableButton_Click(object sender, RoutedEventArgs e)
        {
           membersTable1.ItemsSource = fs.getMembersTable();

        }
        
        }
    }
