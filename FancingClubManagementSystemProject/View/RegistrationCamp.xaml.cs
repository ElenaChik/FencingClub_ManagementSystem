using FancingClubManagementSystemProject.Service;
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
    /// Interaction logic for RegistrationCamp.xaml
    /// </summary>
    public partial class RegistrationCamp : Window
    {
        public RegistrationCamp()
        {
            InitializeComponent();
            FensingService fs = new FensingService();
            campRegistrationTable.ItemsSource = fs.getAllRegistration();
        }

       
    }
}
