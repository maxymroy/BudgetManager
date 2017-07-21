using ManagementApp.DataContext;
using ManagementApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.ViewModels
{
    public class IncomeViewModel
    {
        public IncomeGridViewModel Incomes { get; set; }
        public IEnumerable<Users> Users { get; set; }

        public IncomeViewModel()
        {
            Incomes = new IncomeGridViewModel();
            this.Users = new UserRepository().GetAllUsers();
        }
    }
}