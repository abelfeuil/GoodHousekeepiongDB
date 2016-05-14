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
    /// Interaction logic for CustomerDatabase.xaml
    /// </summary>
    public partial class CustomerDatabase : UserControl
    {
        private ObservableCollection<CustomerDb> _customerDb; 
        public ObservableCollection<CustomerDb> CustomerDb
        {
            get
            {
                if (_customerDb != null)
                {
                    //Code to build the list

                    //For the car filtering
                    this.CustomerCollection = CollectionViewSource.GetDefaultView(_customerDb);
                    this.CustomerCollection.Filter = CustomerDbFilter;
                }
                return _customerDb;
            }
            set { _customerDb = value; }
        }

        private bool CustomerDbFilter(object item)
        {
            CustomerDb customer = item as CustomerDb;

            if (SearchText == null || SelectedSorting == null)
                return true;

            if (customer == null)
                return false;

            var fieldTosort = "";
            if (SelectedSorting.Contains("LastName"))
                fieldTosort = customer.LastName.ToLower();
            else if (SelectedSorting.Contains("FirstName"))
                fieldTosort = customer.FirstName.ToLower();
            else if (SelectedSorting.Contains("PhoneNumber"))
                fieldTosort = customer.PhoneNumber.ToLower();
            else if (SelectedSorting.Contains("Address"))
                fieldTosort = customer.Address.ToLower();
            else if (SelectedSorting.Contains("ServiceWorkOrderNumber"))
                fieldTosort = customer.ServiceWorkOrderNumber.ToLower();
            else if (SelectedSorting.Contains("DateOfService"))
                fieldTosort = customer.DateOfService.ToString(CultureInfo.CurrentCulture).ToLower();
            else if (SelectedSorting.Contains("Technician"))
                fieldTosort = customer.Technician.ToLower();
            else if (SelectedSorting.Contains("ProductServiced"))
                fieldTosort = customer.ProductServiced.ToLower();
            else if (SelectedSorting.Contains("AmountOfRepair"))
                fieldTosort = customer.AmountOfRepair.ToLower();

            if (fieldTosort.Contains(SearchText.Text.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICollectionView CustomerCollection { get; set; }
        public CustomerDb SelectedItem { get; set; }

        public List<string> Sorting { get; set; }

        public string SelectedSorting { get; set; }

        public CustomerDatabase()
        {
            _customerDb = new ObservableCollection<CustomerDb>();

            var db = LocalDB.Load();
            if (db != null)
            {
                foreach (var customer in db)
                {
                    _customerDb.Add(customer);
                }
            }

            Singleton.ClosedFlyout += FinishedAdding;
            Singleton.SaveCustomer += (sender, args) => { LocalDB.Save(_customerDb.ToList()); };

            Sorting = new List<string>();
            Sorting.Add("FirstName");
            Sorting.Add("LastName");
            Sorting.Add("PhoneNumber");
            Sorting.Add("Address");
            Sorting.Add("ServiceWorkOrderNumber");
            Sorting.Add("DateOfService");
            Sorting.Add("Technician");
            Sorting.Add("ProductServiced");
            Sorting.Add("AmountOfRepair");


            InitializeComponent();
        }

        private void FinishedAdding(object sender, CustomerDb e)
        {
            _customerDb.Add(e);
        }

        private void OnNew(object sender, RoutedEventArgs e)
        {
            Singleton.StartAdding();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            LocalDB.Save(_customerDb.ToList());
            Singleton.DoSaveInventory();
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            CustomerDb.Remove(SelectedItem);
        }

        private void OnSeaching(object sender, RoutedEventArgs e)
        {
            var old = CustomerDb;
            CustomerDb = null;
            CustomerDb = old;
        }

        private void OnClear(object sender, RoutedEventArgs e)
        {
            SearchText.Text = "";
            var old = CustomerDb;
            CustomerDb = null;
            CustomerDb = old;
        }
    }
}
