using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreCheckIn.Data.Entities
{
    public class InvoiceAddress
    {
        public int Id { get; set; }
        public string Salutation { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Company1 { get; set; }
        public string Company2 { get; set; }
        public string Contact { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Iso3 { get; set; }
        public int? IsoCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string TaxNumber { get; set; }
        public string Valid { get; set; }
        public string InvoiceComment { get; set; }
    }
}
