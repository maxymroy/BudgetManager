using ManagementApp.DataContext;
using ManagementApp.Models;
using ManagementApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.ViewModels
{
    public class IncomeGridViewModel
    {
        public IList<IncomeItem> Incomes { get; set; }
        public Users User { get; set; }

        public IncomeGridViewModel(int user_id)
        {
            this.User = new UserRepository().GetUser(user_id);
            this.Incomes = new IncomeRepository().GetUserIncomes(user_id);
        }
        public IncomeGridViewModel()
        {
            this.Incomes = new List<IncomeItem>();
        }
        public decimal BiWeeklyTotal
        {
            get
            {
                decimal total = 0;
                foreach (var expense in Incomes.Where(m => m.User_Id == this.User.Id))
                {
                    total += expense.BiWeekly;
                }
                return total;
            }
        }
        public decimal MonthlyTotal
        {
            get
            {
                decimal total = 0;
                foreach (var expense in Incomes.Where(m => m.User_Id == this.User.Id))
                {
                    total += expense.Monthly;
                }
                return total;
            }
        }
        public decimal YearlyTotal
        {
            get
            {
                decimal total = 0;
                foreach (var expense in Incomes.Where(m => m.User_Id == this.User.Id))
                {
                    total += expense.Yearly;
                }
                return total;
            }
        }
    }
}