using FinanceApp.Data.Service;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Controllers;
[Route("expenses")]
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

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var expense = await _expenseService.GetExpenseById(id);
        if (expense == null) return NotFound();
        return View(expense);
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(int id, Expense expense)
    {
        if (id != expense.Id) return BadRequest();

        if (ModelState.IsValid)
        {
            await _expenseService.UpdateExpense(expense);
            return RedirectToAction("Index");
        }

        return View(expense);
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var expense = await _expenseService.GetExpenseById(id);
        if (expense == null) return NotFound();
        return View(expense);
    }

    [HttpPost("delete/{id}"), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _expenseService.DeleteExpense(id);
        return RedirectToAction("Index");
    }
}