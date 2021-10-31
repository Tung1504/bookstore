using bookstore.DAO;
using bookstore.ViewModels.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    public class WidgetController : Controller
    {
        CategoryDAO categoryDAO;
        PublisherDAO publisherDAO;
        

        public WidgetController(CategoryDAO categoryDAO, PublisherDAO publisherDAO)
        {
            this.categoryDAO = categoryDAO;
            this.publisherDAO = publisherDAO;
        }

        // GET: Widget
        [ChildActionOnly]
        public ActionResult Index()
        {
            WidgetViewModel categoriesPublishersViewModel = new WidgetViewModel()
            {
                Categories = categoryDAO.All(),
                Publishers = publisherDAO.All()
            };
            return PartialView("_Sidebar", categoriesPublishersViewModel);
        }
    }
}