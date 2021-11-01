using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.ViewModels.Widget
{
    public class WidgetViewModel
    {
        public WidgetViewModel()
        {
        }

        public WidgetViewModel(List<Category> categories, List<Publisher> publishers)
        {
            Categories = categories;
            Publishers = publishers;
        }

        public List<Category> Categories { get; set; }

        public List<Publisher> Publishers { get; set; }
    }
}