using FinanceApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Controllers;

public class ExpensesController : Controller
{
    private readonly FinanceAppContext _context;

    public ExpensesController(FinanceAppContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {   
        var expenses = _context.Expenses.ToList();
        return View(expenses);
    }
}