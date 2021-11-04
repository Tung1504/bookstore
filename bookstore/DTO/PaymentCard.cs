using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookstore.Models
{
    [MetadataType(typeof(Payment_cardMetaData))]
    public partial class Payment_card
    {
    }

    public class Payment_cardMetaData
    {
        [Required(ErrorMessage = "Please enter your card number")]
        public string card_number { get; set; } 
        [Required(ErrorMessage = "Please enter your card valid from date")]
        public System.DateTime from_date { get; set; }
        [Required(ErrorMessage = "Please enter your card valid end date")]
        public System.DateTime to_date { get; set; }
        [Required(ErrorMessage = "Please enter your card type")]
        public string card_type { get; set; }
        



    }
}