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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoodHousekeeping
{
    /// <summary>
    /// Interaction logic for NewCustomer.xaml
    /// </summary>
    public partial class NewCustomer : UserControl
    {
        public NewCustomer()
        {
            InitializeComponent();
            DatePicker.SelectedDate = DateTime.Now;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var customer = new CustomerDb();
            customer.Address = this.Address.Text;
            customer.AmountOfRepair = this.AmountofRepair.Text;
            customer.LastName = this.Customer.Text;
            customer.DateOfService = this.DatePicker.SelectedDate ?? DateTime.Now;
            customer.PhoneNumber = this.PhoneNumber.Text;
            customer.ProductServiced = this.ProServ.Text;
            customer.ServiceWorkOrderNumber = this.ServiceWork.Text;
            customer.Technician = this.Tech.Text;
            customer.FirstName = this.FirstName.Text;

            Singleton.FinishedAdding(customer);

            Address.Text = "";
            AmountofRepair.Text = "";
            Customer.Text = "";
            DatePicker.SelectedDate = DateTime.Now;
            PhoneNumber.Text = "";
            ServiceWork.Text = "";
            Tech.Text = "";
            FirstName.Text = "";
        }
    }
}
