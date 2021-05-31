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
    /// Логика взаимодействия для ManageProduct.xaml
    /// </summary>
    public partial class ManageProduct : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\diplomPro\InventoryManagmant\InventoryManagmant\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");

        public ManageProduct()
        {
            InitializeComponent();
        }

        void FillCategory() {

            var data = from d in dc.CategoryTbl select new { d.CatName};
            foreach (var d in data) {
                CatCombo.Items.Add(d);
                SearchCombo.Items.Add(d);
            }
          
        
        }

        void FilterByCategory()
        {
            var data = from d in dc.ProductTbl where d.Prodcat == SearchCombo.SelectedValue.ToString() select new { d.ProdId, d.ProdName, d.ProdQty, d.ProdPrice, d.ProdDesc, d.Prodcat};
            ProductGV.ItemsSource = data;
          
        }

        void Populate()
        {
            var data = from d in dc.ProductTbl select new { d.ProdId, d.ProdName, d.ProdQty, d.ProdPrice, d.ProdDesc, d.Prodcat };
            ProductGV.ItemsSource = data;
         
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductTbl prod = new ProductTbl
            {
                ProdId = Convert.ToInt32(ProdIdTb.Text),
                ProdName = ProdNameTb.Text,
                ProdQty = Convert.ToInt32(QtyTb.Text),
                ProdPrice = Convert.ToInt32(PriceTb.Text),
                ProdDesc = DescriptionTb.Text,
                Prodcat = CatCombo.SelectedValue.ToString()
            };
            dc.ProductTbl.InsertOnSubmit(prod);
            try
            {
                dc.SubmitChanges();
            }
            catch
            {
                dc.SubmitChanges();
            }
        
            MessageBox.Show("Product Successfully Added");
            Populate();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var data = from d in dc.ProductTbl where d.ProdId == Convert.ToInt32(ProdIdTb.Text) select d;
            foreach (ProductTbl d in data) {
                d.ProdName = ProdNameTb.Text;
                d.ProdQty = Convert.ToInt32(QtyTb.Text);
                d.ProdPrice = Convert.ToInt32(PriceTb.Text);
                d.ProdDesc = DescriptionTb.Text;
                d.Prodcat = CatCombo.SelectedValue.ToString();
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (ProdIdTb.Text == "")
            {
                MessageBox.Show("Enter The Id Product");
            }
            else
            {
                var data = from d in dc.ProductTbl where d.ProdId == Convert.ToInt32(ProdIdTb.Text) select d;
                foreach (var d in data) {
                    dc.ProductTbl.DeleteOnSubmit(d);
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

        private void ProductGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ProdIdTb.Text = (ProductGV.SelectedCells[0].Column.GetCellContent(ProductGV.SelectedItem) as TextBlock).Text;
                ProdNameTb.Text = (ProductGV.SelectedCells[1].Column.GetCellContent(ProductGV.SelectedItem) as TextBlock).Text;
                QtyTb.Text = (ProductGV.SelectedCells[2].Column.GetCellContent(ProductGV.SelectedItem) as TextBlock).Text;
                PriceTb.Text = (ProductGV.SelectedCells[3].Column.GetCellContent(ProductGV.SelectedItem) as TextBlock).Text;
                DescriptionTb.Text = (ProductGV.SelectedCells[4].Column.GetCellContent(ProductGV.SelectedItem) as TextBlock).Text;
                CatCombo.SelectedValue = (ProductGV.SelectedCells[5].Column.GetCellContent(ProductGV.SelectedItem) as TextBlock).Text;
            }
            catch { }
        }

        private void ManageProduct1_Loaded(object sender, RoutedEventArgs e)
        {
            FillCategory();
            Populate();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            FilterByCategory();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Populate();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
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
