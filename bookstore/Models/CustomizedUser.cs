using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookstore.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class CustomizedUser
    {

    }

    public class UserMetaData
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Input Name")]
        public string name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Input UserName")]
        public string username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Input Password")]
        public string password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Input Role")]
        public string role { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Input Date of birth")]
        public System.DateTime dob { get; set; }
    }
}