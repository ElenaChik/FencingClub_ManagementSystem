﻿using FancingClubManagementSystemProject.Model;
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
                fs.deleteMemberById(idBox.Text);
                MessageBox.Show("Member was deleted successfuly");
                updateMemberTables();            
            }

        /*
       * Method Updates Member by  name
       */
        private void updateMemberButton_Click_1(object sender, RoutedEventArgs e)
        {
            fs.updateMemberById(nameFirstBox.Text, nameLastBox.Text, dateBirthPicker.Text, 
                phoneBox.Text, emailBox.Text, licenseBox.Text, dateLicenceExpirePicker.Text,
                groupBox1.Text, coachBox.Text, idBox.Text);

            MessageBox.Show("Member info was updated successfuly");
            updateMemberTables();

        }

        private void membersTable1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /*
         * Method get selected Member Table from the Member List Tab by the Button SHOW info
         */
        private void showMemberInfoButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView vrow = (DataRowView)membersTable1.SelectedItem;
            //DataRow row = vrow.Row;

            Member member = DataRowViewToMember(vrow);

            MemberInfoPanel membInfo = new MemberInfoPanel(member);
            membInfo.Show();
        }

        private Member DataRowViewToMember(DataRowView vrow)
        {
            Member member = new Member();
            member.idMember = (int)vrow["idmember"];
            member.nameFirst = (string)vrow["namefirst"];
            member.nameLast = (string)vrow["namelast"];
            member.phone = (string)vrow["phone"];
            member.email = (string)vrow["email"];
            member.licenceNumber = (string)vrow["licenceNumber"];
            member.groupe = (string)vrow["groupe"];
            member.coach = (string)vrow["coach"];

            return member;
        }

        /// <summary>
        /// Get Members list by ID. Represent a table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            //Member member;

            if (string.IsNullOrEmpty(filerIdBox.Text))
            {
                MessageBox.Show("Enter valid ID");
            }
            else
            {
                membersTable.ItemsSource = fs.filterMembersById(filerIdBox.Text);
            }
        }

        /// <summary>
        /// Get one member by ID. Represent result as Member Info page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectMemberById_Click(object sender, RoutedEventArgs e)
        {
            Member member;

            if (string.IsNullOrEmpty(idBox.Text))
            {
                MessageBox.Show("Enter valid ID");
            }
            else
            {
                member = fs.getMemberInfoById(idBox.Text);
                nameFirstBox.Text = member.nameFirst;
                nameLastBox.Text = member.nameLast;
                phoneBox.Text = member.phone;
                emailBox.Text = member.email;
                licenseBox.Text = member.licenceNumber;
                groupBox1.Text = member.groupe;
                coachBox.Text = member.coach;
            }
        }

    }
    }
