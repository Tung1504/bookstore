using bookstore.DAO;
using bookstore.Filters.AuthorizeFilters;
using bookstore.Helpers;
using bookstore.Models;
using bookstore.ViewModels.Customer;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    [Authenticated]
    public class CustomerController : BaseController
    {
        UserDAO UserDAO;

        public CustomerController(UserDAO userDAO)
        {
            UserDAO = userDAO;
        }

        // GET: User
        public ActionResult Index()
        {
            if (AuthUser.GetLogin() != null) {
                User user = AuthUser.GetLogin();
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        public ActionResult UpdateInformation()
        {
            int authId = AuthUser.GetLogin().id;
            User u = UserDAO.FirstOrDefault(p => p.id == authId);
            CustomerUpdateInformationViewModel customerUpdateInformationViewModel = new CustomerUpdateInformationViewModel()
            {
                Username = u.username,
                Phone = u.phone,
                Name = u.name,
                Dob = u.dob,
                Email = u.email
            };
            return View(customerUpdateInformationViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateInformation(CustomerUpdateInformationViewModel customerUpdateInformationViewModel)
        {
            if (ModelState.IsValid)
            {
               // db.Entry(user).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(customerUpdateInformationViewModel);
        }
    }
}