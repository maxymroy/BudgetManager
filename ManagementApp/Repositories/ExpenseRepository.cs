using ManagementApp.Models;
using ManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManagementApp.DataContext;

namespace ManagementApp.Repositories
{
    public class ExpenseRepository
    {
        public ExpenseViewModel GetExpenses()
        {
            var allExpenses = new ExpenseViewModel();
            using (var DataContext = new Entities())
            {
                foreach (var budgetItem in DataContext.Expenses)
                {
                    allExpenses.Expenses.Expenses.Add(new ExpenseItem(id: Convert.ToInt32(budgetItem.Id), amount: Convert.ToDecimal(budgetItem.Amount), description: budgetItem.Description, frequency: Convert.ToChar(budgetItem.Frequency), user_id: budgetItem.User_Id));
                }
            }
            return allExpenses;
        }

        public IList<ExpenseItem> GetUserExpenses(int user_id)
        {
            var expenses = new List<ExpenseItem>();
            using (var DataContext = new Entities())
            {
                foreach (var expense in DataContext.Expenses.Where(m => m.User_Id == user_id))
                {
                    expenses.Add(new ExpenseItem(id: Convert.ToInt32(expense.Id), amount: Convert.ToDecimal(expense.Amount), description: expense.Description, frequency: Convert.ToChar(expense.Frequency), user_id: expense.User_Id));
                }
            }
            return expenses;
        }

        public void AddExpense(ExpenseItem item)
        {
            using (var DataContext = new Entities())
            {
                DataContext.Expenses.Add(new Expenses { Amount = item.Amount, Description = item.Description, Frequency = Convert.ToString(item.Frequency),User_Id = item.User_Id });
                DataContext.SaveChanges();
            }
        }

        public ExpenseItem FindExpense(int id)
        {
            ExpenseItem item;
            using (var DataContext = new Entities())
            {
                var budgetItem = DataContext.Expenses.Where(b => b.Id == id).FirstOrDefault();
                item = new ExpenseItem(id: Convert.ToInt32(budgetItem.Id), amount: Convert.ToDecimal(budgetItem.Amount), description: budgetItem.Description, frequency: Convert.ToChar(budgetItem.Frequency), user_id: budgetItem.User_Id);
            }
            return item;
        }

        public void DeleteExpense(int id)
        {
            using (var DataContext = new Entities())
            {
                var itemToDelete = DataContext.Expenses.Where(b => b.Id == id).FirstOrDefault();
                DataContext.Expenses.Remove(itemToDelete);
                DataContext.SaveChanges();
            }
        }

        public void EditExpense(ExpenseItem item)
        {
            using (var DataContext = new Entities())
            {
                var itemToEdit = DataContext.Expenses.Where(b => b.Id == item.ID).FirstOrDefault();
                itemToEdit.Amount = item.Amount;
                itemToEdit.Description = item.Description;
                itemToEdit.Frequency = Convert.ToString(item.Frequency);
                DataContext.SaveChanges();
            }
        }
    }
}