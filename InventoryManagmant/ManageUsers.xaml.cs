using System;
using System.Collections;
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
using System.Data.SqlClient;
using System.Data;

namespace InventoryManagmant
{
    /// <summary>
    /// Логика взаимодействия для ManageUsers.xaml
    /// </summary>
    public partial class ManageUsers : Window
    {
       DataClasses1DataContext dc = new DataClasses1DataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\diplomPro\InventoryManagmant\InventoryManagmant\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");
        public ManageUsers()
        {
            InitializeComponent();
        }

      
        void Populate()
        {
            var data = from d in dc.UserTbl select new { d.Uname, d.Ufullname, d.Upassword, d.UPhone};
            UsersGV.ItemsSource = data;
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserTbl user = new UserTbl
            {
                Uname = unameTb.Text,
                Ufullname = FnameTb.Text,
                Upassword = PasswordTb.Text,
                UPhone = PhoneTb.Text
            };
            dc.UserTbl.InsertOnSubmit(user);
            try
            {
                dc.SubmitChanges();
            }
            catch
            {
                dc.SubmitChanges();
            }
        
        }

        private void ManageUsers1_Loaded(object sender, RoutedEventArgs e)
        {
            Populate();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (PhoneTb.Text == "")
            {
                MessageBox.Show("Enter The Users Phone Number");
            }
            else {
                var data = from d in dc.UserTbl where d.UPhone == PhoneTb.Text select d;
                foreach (var d in data) {
                    dc.UserTbl.DeleteOnSubmit(d);
                }
                try
                {
                    dc.SubmitChanges();
                }
                catch
                {
                    dc.SubmitChanges();

                }
            
                MessageBox.Show("User Successfully Deleted");
                Populate();
            }
        }

        private void UsersGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                unameTb.Text = (UsersGV.SelectedCells[0].Column.GetCellContent(UsersGV.SelectedItem) as TextBlock).Text;
                FnameTb.Text = (UsersGV.SelectedCells[1].Column.GetCellContent(UsersGV.SelectedItem) as TextBlock).Text;
                PasswordTb.Text = (UsersGV.SelectedCells[2].Column.GetCellContent(UsersGV.SelectedItem) as TextBlock).Text;
                PhoneTb.Text = (UsersGV.SelectedCells[3].Column.GetCellContent(UsersGV.SelectedItem) as TextBlock).Text;
            } catch { }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var data = from d in dc.UserTbl where d.UPhone == PhoneTb.Text select d;
            foreach (UserTbl d in data) {
                d.Uname = unameTb.Text;
                d.Ufullname = FnameTb.Text;
                d.Upassword = PasswordTb.Text;

            }
            try
            {
                dc.SubmitChanges();
            }
            catch
            {
                dc.SubmitChanges();
            }
        
            MessageBox.Show("User Successfully Updated");
            Populate();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
        }

        private void CheakDollars_Click(object sender, RoutedEventArgs e)
        {
            CheackDollar cheackD = new CheackDollar();
            CheakDollars.FontSize = 17;
            CheakDollars.Content = cheackD.cheackDollar() + "$";
        }
    }
}
