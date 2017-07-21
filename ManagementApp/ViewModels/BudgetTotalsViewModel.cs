using ManagementApp.DataContext;
using ManagementApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagementApp.ViewModels
{
    public class BudgetTotalsViewModel
    {
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal BiWeeklyTotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal MonthlyTotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal YearlyTotal { get; set; }

        public Users User { get; set; }
        public IncomeRepository incomeRepository = new IncomeRepository();
        public ExpenseRepository expenseRepository = new ExpenseRepository();


        public BudgetTotalsViewModel(int user_id)
        {
            this.User = new UserRepository().GetUser(user_id);
            this.SetBiWeeklyDifference();
            this.SetMonthlyDifference();
            this.SetYearlyDifference();
        }

        public void SetBiWeeklyDifference()
        {
            this.BiWeeklyTotal = 0;
            foreach (var userIncome in incomeRepository.GetUserIncomes(this.User.Id))
            {
                this.BiWeeklyTotal += userIncome.BiWeekly;
            }
            foreach (var userExpense in expenseRepository.GetUserExpenses(this.User.Id))
            {
                this.BiWeeklyTotal -= userExpense.BiWeekly;
            }
        }
        public void SetMonthlyDifference()
        {
            this.MonthlyTotal = 0;
            foreach (var userIncome in incomeRepository.GetUserIncomes(this.User.Id))
            {
                this.MonthlyTotal += userIncome.Monthly;
            }
            foreach (var userExpense in expenseRepository.GetUserExpenses(this.User.Id))
            {
                this.MonthlyTotal -= userExpense.Monthly;
            }
        }
        public void SetYearlyDifference()
        {
            this.YearlyTotal = 0;
            foreach (var userIncome in incomeRepository.GetUserIncomes(this.User.Id))
            {
                this.YearlyTotal += userIncome.Yearly;
            }
            foreach (var userExpense in expenseRepository.GetUserExpenses(this.User.Id))
            {
                this.YearlyTotal -= userExpense.Yearly;
            }
        }
    }
}