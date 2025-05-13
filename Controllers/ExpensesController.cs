using FinanceApp.Data.Service;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Controllers;

public class ExpensesController : Controller
{
    private readonly IExpenseService _expenseService;

    public ExpensesController(IExpenseService expenses)
    {
        _expenseService = expenses;
    }
    // GET
    public async Task<IActionResult> Index()
    {   
        var expenses = await _expenseService.GetAllExpenses();
        return View(expenses);
    }
    // POST
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Expense expense)
    {
        if (ModelState.IsValid)
        {
            await _expenseService.AddExpense(expense);
            return RedirectToAction("Index");
        }
        return View();
    }
}