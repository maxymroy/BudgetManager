using ManagementApp.DataContext;
using ManagementApp.Models;
using ManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.Repositories
{
    public class IncomeRepository
    {
        public IncomeViewModel GetIncomes()
        {
            var allExpenses = new IncomeViewModel();
            using (var DataContext = new Entities())
            {
                foreach (var budgetItem in DataContext.Incomes)
                {
                    allExpenses.Incomes.Incomes.Add(new IncomeItem(id: Convert.ToInt32(budgetItem.Id), amount: Convert.ToDecimal(budgetItem.Amount), description: budgetItem.Description, frequency: Convert.ToChar(budgetItem.Frequency), user_id: budgetItem.User_Id));
                }
            }
            return allExpenses;
        }

        public IList<IncomeItem> GetUserIncomes(int user_id)
        {
            var incomes = new List<IncomeItem>();
            using (var DataContext = new Entities())
            {
                foreach (var income in DataContext.Incomes.Where(m => m.User_Id == user_id))
                {
                    incomes.Add(new IncomeItem(id: Convert.ToInt32(income.Id), amount: Convert.ToDecimal(income.Amount), description: income.Description, frequency: Convert.ToChar(income.Frequency), user_id: income.User_Id));
                }
            }
            return incomes;
        }

        public void AddIncome(IncomeItem item)
        {
            using (var DataContext = new Entities())
            {
                DataContext.Incomes.Add(new Incomes { Amount = item.Amount, Description = item.Description, Frequency = Convert.ToString(item.Frequency), User_Id = item.User_Id });
                DataContext.SaveChanges();
            }
        }

        public IncomeItem FindIncome(int id)
        {
            IncomeItem item;
            using (var DataContext = new Entities())
            {
                var budgetItem = DataContext.Incomes.Where(b => b.Id == id).FirstOrDefault();
                item = new IncomeItem(id: Convert.ToInt32(budgetItem.Id), amount: Convert.ToDecimal(budgetItem.Amount), description: budgetItem.Description, frequency: Convert.ToChar(budgetItem.Frequency), user_id: budgetItem.User_Id);
            }
            return item;
        }

        public void DeleteIncome(int id)
        {
            using (var DataContext = new Entities())
            {
                var itemToDelete = DataContext.Incomes.Where(b => b.Id == id).FirstOrDefault();
                DataContext.Incomes.Remove(itemToDelete);
                DataContext.SaveChanges();
            }
        }

        public void EditIncome(IncomeItem item)
        {
            using (var DataContext = new Entities())
            {
                var itemToEdit = DataContext.Incomes.Where(b => b.Id == item.ID).FirstOrDefault();
                itemToEdit.Amount = item.Amount;
                itemToEdit.Description = item.Description;
                itemToEdit.Frequency = Convert.ToString(item.Frequency);
                DataContext.SaveChanges();
            }
        }
    }
}