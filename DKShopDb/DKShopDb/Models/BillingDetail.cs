using System;
using System.Collections.Generic;

#nullable disable

namespace dkshopDb.Models
{
    public partial class BillingDetail
    {
        public int BillingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal? Postcode { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public string OrderNotes { get; set; }
    }
}
