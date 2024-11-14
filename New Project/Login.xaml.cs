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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        SystemEntities db = new SystemEntities();

        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignUp s = new SignUp();
            this.NavigationService.Navigate(s);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var lo = db.Students.FirstOrDefault(x => x.Email == T_E.Text && x.Password == T_P.Text);
            
            if (lo == null) { MessageBox.Show("The E_mail is not found"); }
            else
            {
                if (T_P.Text == lo.Password && T_E.Text == lo.Email)
                {
                    int ID = lo.ID;
                    if (lo.DepId == 1)
                    {
                        Applicationpage A = new Applicationpage(ID);
                        this.NavigationService.Navigate(A);
                    }
                    else if (lo.DepId == 2)
                    {
                        HomePage h = new HomePage(ID);
                        this.NavigationService.Navigate(h);
                    }

                }
                else { MessageBox.Show("UnCorrect Password "); }
            }
        }
    }
}
