using bookstore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using bookstore.ViewModels;


namespace bookstore.Models
{
    [MetadataType(typeof(BookMetaData))]
    public partial class Book
    {

    }

    public class BookMetaData
    {

        [Required(ErrorMessage = "Please enter book title")]
        public string title { get; set; }

        [Required(ErrorMessage = "Please input book price")]
        public int price { get; set; }

        [Required(ErrorMessage = "Please input quantity to input to stock")]
        public int quantity_in_stock { get; set; }

        [Required(ErrorMessage = "Please choose publisher")]
        public int publisher_id { get; set; }

        [Required(ErrorMessage = "Please choose category")]
        public int category_id { get; set; }

        [Required(ErrorMessage = "Please choose author")]
        public int author_id { get; set; }

        [Required(ErrorMessage = "Please write some description for this book")]
        public string description { get; set; }

        [Required(ErrorMessage = "Please choose an image for this book")]
        public string image { get; set; }

        [Required(ErrorMessage = "Please enter public date for this book")]
        public Nullable<System.DateTime> public_date { get; set; }

        [Required(ErrorMessage = "Please enter book edition")]
        public string edition { get; set; }




    }
}