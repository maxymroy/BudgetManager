using ManagementApp.DataContext;
using ManagementApp.Models;
using ManagementApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.ViewModels
{
    public class IncomeManagingViewModel
    {
        public IEnumerable<Frequencies> Frequencies { get; set; }
        public IEnumerable<Users> Users { get; set; }
        public IncomeItem IncomeItem { get; set; }

        public IncomeManagingViewModel()
        {
            this.Frequencies = new FrequencyRepository().GetAllIndicators();
            this.Users = new UserRepository().GetAllUsers();
            this.IncomeItem = new IncomeItem();
        }

        public IncomeManagingViewModel(IncomeItem incomeItem)
        {
            this.Frequencies = new FrequencyRepository().GetAllIndicators();
            this.Users = new UserRepository().GetAllUsers();
            this.IncomeItem = incomeItem;
        }
    }
}