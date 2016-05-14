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
    /// Interaction logic for NewInventory.xaml
    /// </summary>
    public partial class NewInventory : UserControl
    {
        public NewInventory()
        {
            InitializeComponent();
            DateOrdered.SelectedDate = DateTime.Now;
            DateReceived.SelectedDate = DateTime.Now;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var inventory = new InventoryDb();
            inventory.BrandName = this.BrandName.Text;
            inventory.DateOrder = this.DateOrdered.SelectedDate ?? DateTime.Now;
            inventory.DateReceived = this.DateReceived.SelectedDate ?? DateTime.Now;
            inventory.Stock = this.Stock.Text;
            inventory.SerialNumber = this.SerialNumber.Text;

            Singleton.FinishedAddingInventory(inventory);

            BrandName.Text = "";
            DateOrdered.SelectedDate = DateTime.Now;
            DateReceived.SelectedDate = DateTime.Now;
            Stock.Text = "";
            SerialNumber.Text = "";
        }
    }
}
