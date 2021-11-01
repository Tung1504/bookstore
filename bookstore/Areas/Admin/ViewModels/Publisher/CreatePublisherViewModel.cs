using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookstore.Areas.Admin.ViewModels.Publisher
{
    public class CreatePublisherViewModel
    {
        [Required]
        public string PublisherName { get; set; }

        [Required]
        public string PubliserDescription { get; set; }

        [Required]
        [MaxLength(4)]
        public string EstDate { get; set; }

        public string Image { get; set; }
    }
}