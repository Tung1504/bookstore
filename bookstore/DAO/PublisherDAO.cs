using bookstore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookstore.Models
{
    [MetadataType(typeof(PublisherMetaData))]
    public partial class Publisher
    {

    }

    public class PublisherMetaData
    {

        public int id { get; set; }

        [Required(ErrorMessage = "Please enter publisher name")]
        public string publisher_name { get; set; }

        [Required(ErrorMessage = "Please write some description for publisher")]
        public string description { get; set; }

        [Required(ErrorMessage = "Please enter publisher establish date")]
        public string est_date { get; set; }

        //[Required(ErrorMessage = "Please choose a image for the publisher")]
        public string image { get; set; }


        public virtual ICollection<Book> Books { get; set; }
    }
}