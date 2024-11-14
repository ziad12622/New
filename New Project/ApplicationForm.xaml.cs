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
    /// Interaction logic for ApplicationForm.xaml
    /// </summary>
    public partial class ApplicationForm : Page
    {
        SystemEntities db = new SystemEntities();
        int I;
        public ApplicationForm(int id)
        {
            InitializeComponent();
            I = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var re = db.Students.FirstOrDefault(x => x.ID == I);
            re.Name = T_N.Text;
            re.Address = T_Add.Text;
            re.Age = int.Parse(T_A.Text);
            var seit = L_D.SelectedItem as ListBoxItem;
            string de = seit.Content.ToString();
            re.Department.Name = de;
            string D_N = re.Department.Name;
            var depar = db.Departments.FirstOrDefault(x => x.Name == D_N);
            re.DepId = depar.Department_Id;
            //db.Students.AddOrUpdate(re);
            db.SaveChanges();
            HomePage ho = new HomePage(I);
            this.NavigationService.Navigate(ho);
        }
    }
}
