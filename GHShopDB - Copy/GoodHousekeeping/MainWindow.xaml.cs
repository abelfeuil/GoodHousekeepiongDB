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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace GoodHousekeeping
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Singleton.ClosedFlyout += (sender, args) => { NewCustomerFlyout.IsOpen = false; };
            Singleton.OpenFlyout += (sender, args) => { NewCustomerFlyout.IsOpen = true; };

            Singleton.ClosedFlyoutInventory += (sender, args) => { NewInventoryFlyout.IsOpen = false; };
            Singleton.OpenFlyoutInventory += (sender, args) => { NewInventoryFlyout.IsOpen = true; };
        }

        private void MetroWindow_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
