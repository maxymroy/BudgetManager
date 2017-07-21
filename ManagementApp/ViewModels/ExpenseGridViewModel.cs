using ManagementApp.DataContext;
using ManagementApp.Models;
using ManagementApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagementApp.ViewModels
{
    public class ExpenseGridViewModel
    {
        public IList<ExpenseItem> Expenses { get; set; }
        public Users User { get; set; }

        public ExpenseGridViewModel(int user_id)
        {
            this.User = new UserRepository().GetUser(user_id);
            this.Expenses = new ExpenseRepository().GetUserExpenses(user_id);
        }
        public ExpenseGridViewModel()
        {
            this.Expenses = new List<ExpenseItem>();
        }
        public decimal BiWeeklyTotal {
            get
            {
                decimal total = 0;
                foreach(var expense in Expenses.Where(m=>m.User_Id == this.User.Id))
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
                foreach (var expense in Expenses.Where(m => m.User_Id == this.User.Id))
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
                foreach (var expense in Expenses.Where(m => m.User_Id == this.User.Id))
                {
                    total += expense.Yearly;
                }
                return total;
            }
        }
    }
}