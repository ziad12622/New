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
    /// Interaction logic for Applicationpage.xaml
    /// </summary>
    public partial class Applicationpage : Page
    {
        SystemEntities db = new SystemEntities();

        public Applicationpage(int id)
        {
            InitializeComponent();

            D_G.ItemsSource = db.Students.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var seit = Search.SelectedItem as ComboBoxItem;
            var sede = T_D.SelectedItem as ComboBoxItem;

            if(sede != null)
            {
                if (seit != null)
                {
                    string selecteditem = seit.Content.ToString();
                    string selecteddepar = sede.Content.ToString();
                    var se = db.Departments.FirstOrDefault(x => x.Name == selecteddepar);
                    int depid = se.Department_Id;
                    if (selecteditem == "ID")
                    {
                        int id = int.Parse(T_S.Text);
                        var st = db.Students.FirstOrDefault(x => x.ID == id && x.DepId == depid);
                        if(st != null)
                        {
                            D_G.ItemsSource = new List<Student> { st };
                        }
                        else
                        {
                            MessageBox.Show("No Person ");
                        }
                    }
                    else if (selecteditem == "Name")
                    {
                        string Name = T_S.Text;
                        var st = db.Students.FirstOrDefault(x => x.Name == Name && x.DepId == depid);
                        if (st != null)
                        {
                            D_G.ItemsSource = new List<Student> { st };
                        }
                        else
                        {
                            MessageBox.Show("No Person ");
                        }
                    }
                    else if (selecteditem == "Email")
                    {
                        string E_mail = T_S.Text;
                        var st = db.Students.FirstOrDefault(x => x.Email == E_mail && x.DepId == depid);
                        if (st != null)
                        {
                            D_G.ItemsSource = new List<Student> { st };
                        }
                        else
                        {
                            MessageBox.Show("No Person ");
                        }
                    }
                    //    var st = db.Students.Find(selecteditem);
                    //    if (st != null) { D_G.ItemsSource = new List<Student> { st }; }
                    //    else { MessageBox.Show("The Student that you search on it don't found "); }
                    //}
                    else { MessageBox.Show("Please Choose The Item that you will Search on the student by it"); }

                }
            }
            else
            {
                if (seit != null)
                {
                    string selecteditem = seit.Content.ToString();
                    if (selecteditem == "ID")
                    {
                        int id = int.Parse(T_S.Text);
                        var st = db.Students.FirstOrDefault(x => x.ID == id);
                        if (st != null)
                        {
                            D_G.ItemsSource = new List<Student> { st };
                        }
                        else
                        {
                            MessageBox.Show("No Person ");
                        }
                    }
                    else if (selecteditem == "Name")
                    {
                        string Name = T_S.Text;
                        var st = db.Students.FirstOrDefault(x => x.Name == Name);
                        if (st != null)
                        {
                            D_G.ItemsSource = new List<Student> { st };
                        }
                        else
                        {
                            MessageBox.Show("No Person ");
                        }
                    }
                    else if (selecteditem == "Email")
                    {
                        string E_mail = T_S.Text;
                        var st = db.Students.FirstOrDefault(x => x.Email == E_mail);
                        if (st != null)
                        {
                            D_G.ItemsSource = new List<Student> { st };
                        }
                        else
                        {
                            MessageBox.Show("No Person ");
                        }
                    }
                    //    var st = db.Students.Find(selecteditem);
                    //    if (st != null) { D_G.ItemsSource = new List<Student> { st }; }
                    //    else { MessageBox.Show("The Student that you search on it don't found "); }
                    //}
                    else { MessageBox.Show("Please Choose The Item that you will Search on the student by it"); }

                }
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            int id = int.Parse(T_ID.Text);
            var st = db.Students.FirstOrDefault(x => x.ID == id);
            db.Students.Remove(st);
            db.SaveChanges();
            D_G.ItemsSource = db.Students.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var sede = T_D.SelectedItem as ComboBoxItem;
            int id = int.Parse(T_ID.Text);
            var st = db.Students.FirstOrDefault(x => x.ID == id);
            st.Department.Name = sede.Content.ToString();
            db.SaveChanges();
            D_G.ItemsSource = db.Students.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            this.NavigationService.Navigate(l);
        }
    }
}
