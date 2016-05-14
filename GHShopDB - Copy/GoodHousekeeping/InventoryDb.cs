using System;

namespace GoodHousekeeping
{
    public class InventoryDb
    {
        public string BrandName { get; set; }
        public string SerialNumber { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateReceived { get; set; }
        public string Stock { get; set; }
    }
}