using ManagementApp.DataContext;
using ManagementApp.Models;
using ManagementApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.ViewModels
{
    public class ExpenseViewModel
    {
        public ExpenseGridViewModel Expenses { get; set; }
        public IEnumerable<Users> Users { get; set; }

        public ExpenseViewModel()
        {
            Expenses = new ExpenseGridViewModel();
            this.Users = new UserRepository().GetAllUsers();
        }
    }
}