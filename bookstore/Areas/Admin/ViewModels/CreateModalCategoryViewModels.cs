using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.Areas.Admin.ViewModels
{
    public class CreateModalCategoryViewModels
    {
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public CreateModalCategoryViewModels() { }
        public CreateModalCategoryViewModels(Category c, List<Category> categories)
        {
            this.Category = c;
            this.Categories = categories;

        }
    }
}