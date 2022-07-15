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
using System.Windows.Shapes;

namespace ProjektAplikacji
{
    /// <summary>
    /// Interaction logic for WPF_MainWindow.xaml
    /// </summary>
    public partial class WPF_MainWindow : Window
    {
        public WPF_MainWindow()
        {
            InitializeComponent();

            DataBaseEntities db = new DataBaseEntities();
            var items = from d in db.magazyn_produkty
                        select new
                        {
                            ProductID = d.produkt_id,
                            ProductName = d.produkt_nazwa,
                            ProductPrice = d.cena,
                            ProductCategory = d.produkt_nazwa,
                            ProductDate = d.model_rok,
                            ProductFirm = d.firma_id,
                        };

            foreach (var item in items)
            {
                // 
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.ProductPrice);
            }
            this.gridItems.ItemsSource = items.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DataBaseEntities db = new DataBaseEntities();
            var price = 1999;

            magazyn_produkty itemObject = new magazyn_produkty()
            {
                produkt_id = 55,
                produkt_nazwa = "Iphone 25",
                firma_id = 3,
                kategoria_id = 3,
                model_rok = price.ToString(),
                cena = 1000,

            };

            db.magazyn_produkty.Add(itemObject);
            db.SaveChanges();
            btnLoadItems_Click(sender, e);
            

        }

        private void btnLoadItems_Click(object sender, RoutedEventArgs e)
        {
            DataBaseEntities db = new DataBaseEntities();
            var items = from d in db.magazyn_produkty
                        select new
                        {
                            ProductID = d.produkt_id,
                            ProductName = d.produkt_nazwa,
                            ProductPrice = d.cena,
                            ProductCategory = d.produkt_nazwa,
                            ProductDate = d.model_rok,
                            ProductFirm = d.firma_id,
                        };
            this.gridItems.ItemsSource = items.ToList();

        }
    }
}
