﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookstore.Models
{
    [MetadataType(typeof(AuthorMetaData))]
    public partial class Author
    {
    }

    public class AuthorMetaData
    {
        [Required(ErrorMessage = "Please enter author name")]
        public string author_name { get; set; }

        [Required(ErrorMessage = "Please write some description for this author")]
        public string description { get; set; }

        [Required(ErrorMessage = "Please enter author birth year")]
        public string birth_year { get; set; }

        [Required(ErrorMessage = "Please enter author active status")]
        public string status { get; set; }

        //[Required(ErrorMessage = "Please choose an image for this author")]
        public string image { get; set; }

    }
}