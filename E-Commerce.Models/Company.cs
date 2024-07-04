using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace E_Commerce.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [DisplayName("Postal Code")]
        public int PostalCode { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
