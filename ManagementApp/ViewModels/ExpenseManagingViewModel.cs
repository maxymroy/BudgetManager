using ManagementApp.DataContext;
using ManagementApp.Models;
using ManagementApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.ViewModels
{
    public class ExpenseManagingViewModel
    {
        public IEnumerable<Frequencies> Frequencies { get; set; }
        public IEnumerable<Users> Users { get; set; }
        public ExpenseItem ExpenseItem { get; set; }

        public ExpenseManagingViewModel()
        {
            this.Frequencies = new FrequencyRepository().GetAllIndicators();
            this.Users = new UserRepository().GetAllUsers();
            this.ExpenseItem = new ExpenseItem();
        }

        public ExpenseManagingViewModel(ExpenseItem expenseItem)
        {
            this.Frequencies = new FrequencyRepository().GetAllIndicators();
            this.Users = new UserRepository().GetAllUsers();
            this.ExpenseItem = expenseItem;
        }
    }
}