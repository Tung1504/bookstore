using bookstore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookstore.Models
{
    [MetadataType(typeof(AddressMetaData))]
    public partial class Address
    {
    }

    public class AddressMetaData
    {
        [Required(ErrorMessage = "Please enter your address")]
        public string address1 { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        public string city { get; set; }
        [Required(ErrorMessage = "Please enter your district")]
        public string district { get; set; }
        public int user_id { get; set; }
        [Required(ErrorMessage = "Please enter your postal code")]
        public int postal_code { get; set; }

        

    }
}