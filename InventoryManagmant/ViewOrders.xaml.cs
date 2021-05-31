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
    /// Логика взаимодействия для ViewOrders.xaml
    /// </summary>
    public partial class ViewOrders : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\diplomPro\InventoryManagmant\InventoryManagmant\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");
       
        CheackDollar cheackD = new CheackDollar();

        public ViewOrders()
        {
            InitializeComponent();
        }
        void PopulateOrder()
        {
         
                var data = from d in dc.OrdersTbl select new { d.OrderId, d.CustId, d.DataSell, d.OrderDate, d.TotalAmt };//
            OrderGV.ItemsSource = data;
            
          
        }

        private void ViewOrders1_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateOrder();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CheakDollars.FontSize = 17;
            CheakDollars.Content = cheackD.cheackDollar() + "$";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//Delete Order
        {
            var data = from d in dc.OrdersTbl where d.OrderId == Convert.ToInt32((OrderGV.SelectedCells[0].Column.GetCellContent(OrderGV.SelectedItem) as TextBlock).Text) select d;
            foreach (var d in data) {
                dc.OrdersTbl.DeleteOnSubmit(d);
            }
            try
            {
                dc.SubmitChanges();
            }
            catch
            {
                dc.SubmitChanges();

            }
            MessageBox.Show("Order Successfully Deleted");
            PopulateOrder();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//Deteil order
        {
            int custId = Convert.ToInt32((OrderGV.SelectedCells[1].Column.GetCellContent(OrderGV.SelectedItem) as TextBlock).Text);
            var data = from d in dc.CustomerTbl where d.CustId == custId select new { d.CustName, d.CustPhone};
            string content = "";
            foreach (var d in data) {
                content += "Name: " + d.CustName + "\nPhone: " + d.CustPhone + "\nDollars:" + cheackD.countAmount(Convert.ToInt32((OrderGV.SelectedCells[4].Column.GetCellContent(OrderGV.SelectedItem) as TextBlock).Text));
            }
            MessageBox.Show(content);
        }
    }
}
