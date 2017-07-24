using ManagementApp.DataContext;
using ManagementApp.Repositories;
using ManagementApp.ViewModels;
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
            UserManagerViewModel userViewModel = new UserManagerViewModel();
            userViewModel.Users = new UserRepository().GetAllUsers();
            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult Index(UserManagerViewModel usersViewModel)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.ModifyUsers(usersViewModel.Users);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteUser(int id)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.DeleteUser(id);
            return RedirectToAction("Index");
        }

        public ActionResult CreateUser(string txtName)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.CreateUser(new Users {Name=txtName });
            return RedirectToAction("Index");
        }
    }
}