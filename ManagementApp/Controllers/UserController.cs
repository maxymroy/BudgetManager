using ManagementApp.DataContext;
using ManagementApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            IEnumerable<Users> users = new UserRepository().GetAllUsers();
            return View(users);
        }
    }
}