using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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

namespace GoodHousekeeping
{
    /// <summary>
    /// Interaction logic for InventoryDatabase.xaml
    /// </summary>
    public partial class InventoryDatabase : UserControl
    {
        private ObservableCollection<InventoryDb> _InventoryDb; 
        public ObservableCollection<InventoryDb> InventoryDb
        {
            get
            {
                if (_InventoryDb != null)
                {
                    //Code to build the list

                    //For the car filtering
                    this.CustomerCollection = CollectionViewSource.GetDefaultView(_InventoryDb);
                    this.CustomerCollection.Filter = InventoryDbFilter;
                }
                return _InventoryDb;
            }
            set { _InventoryDb = value; }
        }

        private bool InventoryDbFilter(object item)
        {
            InventoryDb customer = item as InventoryDb;

            if (SearchText == null || SelectedSorting == null)
                return true;

            if (customer == null)
                return false;

            var fieldTosort = "";
            if (SelectedSorting.Contains("BrandName"))
                fieldTosort = customer.BrandName.ToLower();
            else if (SelectedSorting.Contains("SerialNumber"))
                fieldTosort = customer.SerialNumber.ToLower();
            else if (SelectedSorting.Contains("DateOrder"))
                fieldTosort = customer.DateOrder.ToString(CultureInfo.CurrentCulture).ToLower();
            else if (SelectedSorting.Contains("DateReceived"))
                fieldTosort = customer.DateReceived.ToString(CultureInfo.CurrentCulture).ToLower();
            else if (SelectedSorting.Contains("Stock"))
                fieldTosort = customer.Stock.ToLower();

            return fieldTosort.Contains(SearchText.Text.ToLower());
            //if (fieldTosort.Contains(SearchText.Text.ToLower()))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public ICollectionView CustomerCollection { get; set; }
        public InventoryDb SelectedItem { get; set; }

        public List<string> Sorting { get; set; }

        public string SelectedSorting { get; set; }

        public InventoryDatabase()
        {
            _InventoryDb = new ObservableCollection<InventoryDb>();

            var db = LocalDB.LoadInventory();
            if (db != null)
            {
                foreach (var customer in db)
                {
                    _InventoryDb.Add(customer);
                }
            }

            Singleton.ClosedFlyoutInventory += FinishedAdding;
            Singleton.SaveInventory += (sender, args) => { LocalDB.Save(_InventoryDb.ToList()); };

            Sorting = new List<string>();
            Sorting.Add("BrandName");
            Sorting.Add("SerialNumber");
            Sorting.Add("DateOrder");
            Sorting.Add("DateReceived");
            Sorting.Add("Stock");

            InitializeComponent();
        }

        private void FinishedAdding(object sender, InventoryDb e)
        {
            _InventoryDb.Add(e);
        }

        private void OnNew(object sender, RoutedEventArgs e)
        {
            Singleton.StartAddingInventory();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            LocalDB.Save(_InventoryDb.ToList());
            Singleton.DoSaveCustomer();
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            InventoryDb.Remove(SelectedItem);
        }

        private void OnSeaching(object sender, RoutedEventArgs e)
        {
            var old = InventoryDb;
            InventoryDb = null;
            InventoryDb = old;
        }

        private void OnClear(object sender, RoutedEventArgs e)
        {
            SearchText.Text = "";
            var old = InventoryDb;
            InventoryDb = null;
            InventoryDb = old;
        }
    }
}
