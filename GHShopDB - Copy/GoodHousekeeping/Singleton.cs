using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHousekeeping
{
    public static class Singleton
    {
        public static event EventHandler<CustomerDb> ClosedFlyout = delegate { };
        public static event EventHandler OpenFlyout = delegate { };
        public static event EventHandler StuffBroke = delegate { };
        public static event EventHandler SaveCustomer = delegate {  };
        public static event EventHandler SaveInventory = delegate { }; 

        public static event EventHandler<InventoryDb> ClosedFlyoutInventory = delegate { };
        public static event EventHandler OpenFlyoutInventory = delegate { };

        public static void DoSaveCustomer()
        {
            SaveCustomer.Invoke(null, null);
        }

        public static void DoSaveInventory()
        {
            SaveInventory.Invoke(null, null);
        }

        public static void FinishedAdding(CustomerDb customer)
        {
            ClosedFlyout.Invoke(null, customer);
        }

        public static void StartAdding()
        {
            OpenFlyout.Invoke(null, null);
        }

        public static void ManStuffBroke()
        {
            StuffBroke.Invoke(null, null);
        }

        public static void FinishedAddingInventory(InventoryDb customer)
        {
            ClosedFlyoutInventory.Invoke(null, customer);
        }

        public static void StartAddingInventory()
        {
            OpenFlyoutInventory.Invoke(null, null);
        }


    }
}
