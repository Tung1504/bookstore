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
        [Required]
        public int card_number { get; set; }
        [Required]
        public System.DateTime from_date { get; set; }
        [Required]
        public System.DateTime to_date { get; set; }
        [Required]
        public string card_type { get; set; }
        



    }
}