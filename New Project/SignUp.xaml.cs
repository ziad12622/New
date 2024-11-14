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

namespace New_Project
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        SystemEntities db = new SystemEntities();
        public SignUp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            this.NavigationService.Navigate(l);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var ne = db.Students.First();
            ne.Name = T_N.Text;
            ne.Email = T_E.Text;
            if (T_P.Text == T_R_P.Text) { 
                ne.Password = T_P.Text;
                int id = ne.ID;
                db.Students.Add(ne);
                ApplicationForm applicationForm = new ApplicationForm(id);
                this.NavigationService.Navigate(applicationForm);
            }
            else { MessageBox.Show("The Password Feild and Return Password Feild are not Equal"); }
           
        }
    }
}
