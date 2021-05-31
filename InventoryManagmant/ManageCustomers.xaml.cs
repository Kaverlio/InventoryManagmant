using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace InventoryManagmant
{
    /// <summary>
    /// Логика взаимодействия для ManageCustomers.xaml
    /// </summary>
    public partial class ManageCustomers : Window
    {
       DataClasses1DataContext dc = new DataClasses1DataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\diplomPro\InventoryManagmant\InventoryManagmant\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");

        public ManageCustomers()
        {
            InitializeComponent();
        }

        void Populate()
        {
            var data = from q in dc.CustomerTbl select new { q.CustId, q.CustName, q.CustPhone };
            CustomersGV.ItemsSource = data;
      
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CustomerTbl cust = new CustomerTbl
            {
                CustId = Convert.ToInt32(CustomerId.Text),
                CustName = CustomerNameTb.Text,
                CustPhone = CustomerPhoneTb.Text
            };

            dc.CustomerTbl.InsertOnSubmit(cust);

            try
            {
                dc.SubmitChanges();
            }
            catch
            {
                dc.SubmitChanges();
            }
            MessageBox.Show("Customer Successfully Added");
            Populate();
     
        }

        private void ManageCustomers1_Loaded(object sender, RoutedEventArgs e)
        {
            Populate();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CustomerId.Text == "")
            {
                MessageBox.Show("Enter The Custumer Id");
            }
            else
            {
                var dataDelete = from d in dc.CustomerTbl where d.CustId == Convert.ToInt32(CustomerId.Text) select d;

                foreach (var d in dataDelete)
                {
                    dc.CustomerTbl.DeleteOnSubmit(d);
                }
                try
                {
                    dc.SubmitChanges();
                }
                catch
                {
                    dc.SubmitChanges();

                }
                MessageBox.Show("Customer Successfully Deleted");
                Populate();
        
            }
        }

        private void CustomersGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CustomerId.Text = (CustomersGV.SelectedCells[0].Column.GetCellContent(CustomersGV.SelectedItem) as TextBlock).Text;
                CustomerNameTb.Text = (CustomersGV.SelectedCells[1].Column.GetCellContent(CustomersGV.SelectedItem) as TextBlock).Text;
                CustomerPhoneTb.Text = (CustomersGV.SelectedCells[2].Column.GetCellContent(CustomersGV.SelectedItem) as TextBlock).Text;

                OrderLabel.Content = (from q in dc.OrdersTbl where q.CustId == Convert.ToInt32(CustomerId.Text) select q).Count();
           
                AmountLabel.Content = (from q in dc.OrdersTbl where q.CustId == Convert.ToInt32(CustomerId.Text) select q.TotalAmt).Sum();
           
                DateLabel.Content = (from q in dc.OrdersTbl where q.CustId == Convert.ToInt32(CustomerId.Text) select q.OrderDate).Max();
            
            }
            catch { }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var data = from q in dc.CustomerTbl where q.CustId == Convert.ToInt32(CustomerId.Text) select q;
            foreach (CustomerTbl d in data)
            {
                d.CustName = CustomerNameTb.Text;
                d.CustPhone = CustomerPhoneTb.Text;
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
