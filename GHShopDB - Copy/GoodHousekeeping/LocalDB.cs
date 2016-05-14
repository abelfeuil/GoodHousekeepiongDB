using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoodHousekeeping
{
    public static class LocalDB
    {
        public static void Save(List<CustomerDb> customer)
        {
            var serialized = JsonConvert.SerializeObject(customer);
            File.WriteAllText("customer.db", serialized);
        }

        public static void Save(List<InventoryDb> customer)
        {
            var serialized = JsonConvert.SerializeObject(customer);
            File.WriteAllText("inventory.db", serialized);
        }

        public static List<InventoryDb> LoadInventory()
        {
            try
            {
                var text = File.ReadAllText("inventory.db");
                return JsonConvert.DeserializeObject<List<InventoryDb>>(text);
            }
            catch { }
            return null;
        }
        public static List<CustomerDb> Load()
        {
            try
            {
                var text = File.ReadAllText("customer.db");
                return JsonConvert.DeserializeObject<List<CustomerDb>>(text);
            }
            catch { }
            return null;
        }
    }
}
