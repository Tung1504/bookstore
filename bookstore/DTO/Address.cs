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
        [Required]
        public string address1 { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string district { get; set; }
        public int user_id { get; set; }
        [Required]
        public int postal_code { get; set; }

        

    }
}