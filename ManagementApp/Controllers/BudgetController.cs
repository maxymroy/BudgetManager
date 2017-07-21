using ManagementApp.Models;
using ManagementApp.Repositories;
using ManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace ManagementApp.Controllers
{
    public class BudgetController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Your expense manager page.";
            var expenseRepository = new ExpenseRepository();
            var expenses = expenseRepository.GetExpenses();

            return View(expenses);
        }

        //Add new expense
        [HttpPost]
        public ActionResult Index(ExpenseManagingViewModel item)
        {
            if (ModelState.IsValid)
            {
                var expenseRepository = new ExpenseRepository();
                expenseRepository.AddExpense(item.ExpenseItem);
            }
            return RedirectToAction("Index");
        }

        //Add new income
        [HttpPost]
        public ActionResult AddNewIncome(IncomeManagingViewModel item)
        {
            if(ModelState.IsValid)
            {
                var incomeRepository = new IncomeRepository();
                incomeRepository.AddIncome(item.IncomeItem);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteExpense(string id)
        {
            var expenseRepository = new ExpenseRepository();
            expenseRepository.DeleteExpense(Convert.ToInt32(id));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteIncome(string id)
        {
            var incomeRepository = new IncomeRepository();
            incomeRepository.DeleteIncome(Convert.ToInt32(id));

            return RedirectToAction("Index");
        }


        public ActionResult EditExpense(int id)
        {
            var expenseRepository = new ExpenseRepository();
            var expenseItem = expenseRepository.FindExpense(id);
            var viewModel = new ExpenseManagingViewModel(expenseItem);
            return View(viewModel);
        }
        [HttpPost]
        [ActionName("EditExpense")]
        [ValidateAntiForgeryToken]
        public ActionResult EditExpense(ExpenseManagingViewModel item)
        {
            if (ModelState.IsValid)
            {
                var expenseRepository = new ExpenseRepository();
                expenseRepository.EditExpense(item.ExpenseItem);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public ActionResult EditIncome(int id)
        {
            var incomeRepository = new IncomeRepository();
            var incomeItem = incomeRepository.FindIncome(id);
            var viewModel = new IncomeManagingViewModel(incomeItem);
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("EditIncome")]
        [ValidateAntiForgeryToken]
        public ActionResult EditIncome(IncomeManagingViewModel item)
        {
            if(ModelState.IsValid)
            {
                var incomeRepository = new IncomeRepository();
                incomeRepository.EditIncome(item.IncomeItem);
                return RedirectToAction("Index");
            }
            return View(item);
        }
    }
}