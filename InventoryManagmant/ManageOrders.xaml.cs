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
    /// Логика взаимодействия для ManageOrders.xaml
    /// </summary>
    public partial class ManageOrders : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\diplomPro\InventoryManagmant\InventoryManagmant\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");
        int num = 0;
        int uprice, totprice, qty;
        int flag = 0;
        int stock;
        int sum = 0;
        string product, dataSell = String.Empty;
        DataTable table = new DataTable();

        public ManageOrders()
        {
            InitializeComponent();
        }
        
        
        void Populate()
        {
            var data = from q in dc.CustomerTbl select new { q.CustId, q.CustName, q.CustPhone };
            CustomerGV.ItemsSource = data;

        }

        void FillCategory()
        {
            var data = from q in dc.CategoryTbl select new { q.CatName };
            foreach (var d in data) {
                SearchCombo.Items.Add(d);
            }
          
        }
               
        private void ManageOrders1_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateProduct();
            Populate();
            FillCategory();

            table.Columns.Add("Num", typeof(int));
            table.Columns.Add("Product", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("UPrice", typeof(int));
            table.Columns.Add("TotalPrice", typeof(int));

            OrderGv.ItemsSource = table.DefaultView;
        }

        private void ProductGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                product = (ProductGV.SelectedCells[1].Column.GetCellContent(ProductGV.SelectedItem) as TextBlock).Text;
               stock = Convert.ToInt32((ProductGV.SelectedCells[2].Column.GetCellContent(ProductGV.SelectedItem) as TextBlock).Text);
                uprice = Convert.ToInt32((ProductGV.SelectedCells[3].Column.GetCellContent(ProductGV.SelectedItem) as TextBlock).Text);
                flag = 1;
            } catch { }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (QtyTb.Text == "")
            {
                MessageBox.Show("Enter The Quantity of Products");
            }
            else if (flag == 0)
            {
                MessageBox.Show("Select the Product");
            }
            else if (Convert.ToInt32(QtyTb.Text) > stock)
                MessageBox.Show("No Enough Stock Available");
            else
            {
                num++;
                qty = Convert.ToInt32(QtyTb.Text);
                totprice = qty * uprice;
                
                table.Rows.Add(num, product, qty, uprice, totprice);

                OrderGv.ItemsSource = table.DefaultView;
                flag = 0;
            }
            dataSell += product + "(" + qty.ToString() + ") \n";
            sum += totprice;
            TotAmount.Text = sum.ToString();
            updateProduct();
        }

        void updateProduct() {
           int id = Convert.ToInt32((ProductGV.SelectedCells[0].Column.GetCellContent(ProductGV.SelectedItem) as TextBlock).Text);
            int newQty = stock - Convert.ToInt32(QtyTb.Text);
            if (newQty < 0)
                MessageBox.Show("Operation Failed");
            else
            {
                var data = from d in dc.ProductTbl where d.ProdId == id select d;
                foreach (ProductTbl d in data) {
                    d.ProdQty = newQty;
                }
                try
                {
                    dc.SubmitChanges();
                }
                catch
                {
                    dc.SubmitChanges();
                }
               
                PopulateProduct();

            }
        }

        void PopulateProduct()
        {
            var data = from d in dc.ProductTbl select new {d.ProdId, d.ProdName, d.ProdQty, d.ProdPrice, d.ProdDesc, d.Prodcat };
            ProductGV.ItemsSource = data;
          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (OrderIdTb.Text == "" || CustIdTb.Text == "" || CustName.Text == "" || TotAmount.Text == "")
            {
                MessageBox.Show("Fill The data Correctly");
            }
            else {
                OrdersTbl order = new OrdersTbl
                {
                    OrderId = Convert.ToInt32(OrderIdTb.Text),
                    CustId = Convert.ToInt32(CustIdTb.Text),
                    DataSell = dataSell,
                    OrderDate = Convert.ToDateTime(OrderDate.Text),
                    TotalAmt = Convert.ToInt32(TotAmount.Text)
                };
                dc.OrdersTbl.InsertOnSubmit(order);
                try
                {
                    dc.SubmitChanges();
                }
                catch
                {
            
                }
                MessageBox.Show("Order Successfully Added");
                Populate();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ViewOrders view = new ViewOrders();
            view.Show();
        }

        private void CheakDollars_Click(object sender, RoutedEventArgs e)
        {
            CheackDollar cheackD = new CheackDollar();
            CheakDollars.FontSize = 17;
            CheakDollars.Content = cheackD.cheackDollar() + "$";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
        }

        private void CustomerGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustIdTb.Text = (CustomerGV.SelectedCells[0].Column.GetCellContent(CustomerGV.SelectedItem) as TextBlock).Text;
            CustName.Text = (CustomerGV.SelectedCells[1].Column.GetCellContent(CustomerGV.SelectedItem) as TextBlock).Text;

        }

        private void SearchCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = from d in dc.ProductTbl where d.Prodcat == SearchCombo.SelectedValue.ToString() select new { d.ProdId, d.ProdName, d.ProdQty, d.ProdPrice, d.ProdDesc, d.Prodcat};
            ProductGV.ItemsSource = data;
        
        }
    }
}
