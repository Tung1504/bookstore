using bookstore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookstore.Areas.Admin.ViewModel
{
    public class QuantityValidate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Book book = (Book)validationContext.ObjectInstance;

            if (book.quantity_in_stock <= 0)
            {
                return new ValidationResult("Quantity in stock must be greater than 0");
            }
            return null;
        }

    }

    public class PriceValidate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Book book = (Book)validationContext.ObjectInstance;

            if (book.price <= 0)
            {
                return new ValidationResult("Quantity in stock must be greater than 0");
            }
            return null;
        }

    }

   
}