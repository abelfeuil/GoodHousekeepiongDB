using System;

namespace GoodHousekeeping
{
    public class CustomerDb
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ServiceWorkOrderNumber { get; set; }
        public DateTime DateOfService { get; set; }
        public string Technician { get; set; }
        public string ProductServiced { get; set; }
        public string AmountOfRepair { get; set; }


    }
}