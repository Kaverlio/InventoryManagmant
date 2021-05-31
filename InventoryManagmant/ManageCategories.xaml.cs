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
    /// Логика взаимодействия для ManageCategories.xaml
    /// </summary>
    public partial class ManageCategories : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\diplomPro\InventoryManagmant\InventoryManagmant\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");

        public ManageCategories()
        {
            InitializeComponent();
        }

        void Populate()
        {
            var data = from q in dc.CategoryTbl select new { q.CatId, q.CatName };
                CategoriesGV.ItemsSource = data;
          
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CategoryTbl cat = new CategoryTbl {
                CatId = Convert.ToInt32(CatIdTb.Text),
                CatName = CatNameTb.Text            
            };

            dc.CategoryTbl.InsertOnSubmit(cat);

            try
            {
                dc.SubmitChanges();
            }
            catch {
                dc.SubmitChanges();
            }
            MessageBox.Show("Category Successfully Added");
            Populate();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var data = from catN in dc.CategoryTbl where catN.CatId == Convert.ToInt32(CatIdTb.Text) select catN;
            foreach (CategoryTbl catN in data) {
                catN.CatName = CatNameTb.Text;
            }
            try
            {
                dc.SubmitChanges();
            }
            catch
            {
                dc.SubmitChanges();
            }
                MessageBox.Show("Category Successfully Updated");
                Populate();
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            if (CatIdTb.Text == "")
            {
                MessageBox.Show("Enter The Categorie Id");
            }
            else
            {
                var dataDelete = from d in dc.CategoryTbl where d.CatId == Convert.ToInt32(CatIdTb.Text) select d;

                foreach (var d in dataDelete) {
                    dc.CategoryTbl.DeleteOnSubmit(d);
                }
                try {
                    dc.SubmitChanges();
                } catch
                {
                    dc.SubmitChanges();

                }
                MessageBox.Show("Category Successfully Deleted");
                Populate();
               
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Populate();
        }

        private void CategoriesGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CatIdTb.Text = (CategoriesGV.SelectedCells[0].Column.GetCellContent(CategoriesGV.SelectedItem) as TextBlock).Text;
                CatNameTb.Text = (CategoriesGV.SelectedCells[1].Column.GetCellContent(CategoriesGV.SelectedItem) as TextBlock).Text;
            }
            catch { }
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
