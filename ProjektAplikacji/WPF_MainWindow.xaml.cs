using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            /// <summary>
            /// Main element of WPF application
            /// Used to generate and display grid
            /// </summary>

            InitializeComponent();



            DataBaseEntities db = new DataBaseEntities();
            var items = from d in db.magazyn_produkty
                        select new
                        {
                            ID = d.produkt_id,
                            Name = d.produkt_nazwa,
                            Price = d.cena,
                            Category = d.kategoria_id,
                            Year = d.model_rok,
                            Brand = d.firma_id,
                        };

            this.gridItems.ItemsSource = items.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Button functionality for adding object to database
            /// </summary>
            /// <returns>
            /// New object to database
            /// </returns>
          
            DataBaseEntities db = new DataBaseEntities();

            Random random = new Random();
            var prodIDtemp = 0;
            if(txtItemID.Text == String.Empty)
            {
                prodIDtemp = random.Next(10, 255);
            }
            else
            {
                prodIDtemp=int.Parse(txtItemID.Text);
            }

            if (txtItemName.Text != String.Empty) {
                magazyn_produkty itemObject = new magazyn_produkty()
                {

                    produkt_id = prodIDtemp,
                    produkt_nazwa = txtItemName.Text,
                    firma_id = int.Parse(txtItemFirm.Text),
                    kategoria_id = int.Parse(txtItemCategory.Text),
                    model_rok = txtItemYear.Text,
                    cena = decimal.Parse(txtItemPrice.Text),

                };
                db.magazyn_produkty.Add(itemObject);
                db.SaveChanges();
                btnLoadItems_Click(sender, e);
            }
        }

        private void btnLoadItems_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Button functionality for loadin/reloading database
            /// </summary>
            /// <returns>
            /// Load objects from data base to grid
            /// </returns>
            DataBaseEntities db = new DataBaseEntities();

            var items = from d in db.magazyn_produkty
                        select new
                        {
                            ID = d.produkt_id,
                            Name = d.produkt_nazwa,
                            Price = d.cena,
                            Category = d.kategoria_id,
                            Year = d.model_rok,
                            Brand = d.firma_id,
                        };

            this.gridItems.ItemsSource = items.ToList();

        }

        private int updateItemID = 0;

        private void gridItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /// <summary>
            /// Grid functionality for returning active grid item
            /// </summary>
            /// <returns>
            /// Values from database to text boxes and get selected item ID
            /// </returns>

            var tmpval = "";
            int tmpID = 0;

            foreach (var item in gridItems.SelectedItems.AsQueryable())
            {
                tmpval = item.ToString();
                tmpval = tmpval.Split('=', ',')[1];
                tmpval = tmpval.Trim();
            }

            DataBaseEntities db = new DataBaseEntities();

            try
            {
                tmpID = Convert.ToInt32(tmpval);
            }
            catch
            {
                new Exception(tmpval);
            }

            var r = from d in db.magazyn_produkty
                    where d.produkt_id == tmpID
                    select d;

            if (this.gridItems.SelectedIndex >= 0)
            {
                if (this.gridItems.SelectedItems.Count >= 0)
                {

                    foreach (var mp in r)
                    {
                        this.txtItemName2.Text = mp.produkt_nazwa;
                        this.txtItemPrice2.Text = mp.cena.ToString();
                        this.txtItemID2.Text = mp.produkt_id.ToString();
                        this.txtItemYear2.Text = mp.model_rok;
                        this.txtItemCategory2.Text = mp.kategoria_id.ToString();
                        this.txtItemFirm2.Text = mp.firma_id.ToString();
                        this.updateItemID = mp.produkt_id;
                    }

                }
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Button functionality for updating selected item data
            /// </summary>
            /// <returns>
            /// Update of selected item with values type in
            /// </returns>

            DataBaseEntities db = new DataBaseEntities();

            var r = from d in db.magazyn_produkty
                    where d.produkt_id == this.updateItemID
                    select d;

            magazyn_produkty obj = r.SingleOrDefault();

            if (obj != null)
            {

                obj.produkt_nazwa = this.txtItemName2.Text;
                obj.produkt_id = Convert.ToInt32(this.txtItemID2.Text);
                obj.cena = Convert.ToDecimal(this.txtItemPrice2.Text);
                obj.model_rok = this.txtItemYear2.Text;
                obj.firma_id = Convert.ToInt32(this.txtItemFirm2.Text);
                obj.kategoria_id = Convert.ToInt32(this.txtItemCategory2.Text);

            }

            db.SaveChanges();
            btnLoadItems_Click(sender, e);

        }

        private void btnDeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Button functionality for deleting an object from database
            /// </summary> 
            /// <returns>
            /// Delete selected item from database
            /// </returns>

            MessageBoxResult msgBox = MessageBox.Show(
                "Are you sure you want to Delete this item ?",
                "Delete Item",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning,
                MessageBoxResult.No
                );

            if (msgBox == MessageBoxResult.Yes)
            {

                DataBaseEntities db = new DataBaseEntities();

                var r = from d in db.magazyn_produkty
                        where d.produkt_id == this.updateItemID
                        select d;

                magazyn_produkty obj = r.SingleOrDefault();

                if (obj != null)
                {

                    db.magazyn_produkty.Remove(obj);
                    db.SaveChanges();
                    btnLoadItems_Click(sender, e);

                }
            }
        }
    }
}
