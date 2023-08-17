using FancingClubManagementSystemProject.Model;
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
    /// Interaction logic for MemberInfoPanel.xaml
    /// </summary>
    public partial class MemberInfoPanel : Window
    {
        private Member member;

        public MemberInfoPanel(Member member)
        {
            InitializeComponent();
            this.member = member;
            showMemberInfo();
        }

      public void showMemberInfo()
        {
            idBox.Text = member.idMember.ToString();
            nameFirstBox.Text = member.nameFirst;
            nameLastBox.Text = member.nameLast;
            phoneBox.Text = member.phone;
            emailBox.Text = member.email;
            licenseBox.Text = member.licenceNumber;
            groupBox1.Text = member.groupe;
            coachBox.Text = member.coach;
        }

        private void closeInfoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
