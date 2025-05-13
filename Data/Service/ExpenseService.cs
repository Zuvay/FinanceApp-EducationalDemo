using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Service;

public class ExpenseService : IExpenseService
{
    private readonly FinanceAppContext _context;
    public ExpenseService(FinanceAppContext context)
    {
        _context = context;
    }
    public async Task<List<Expense>> GetAllExpenses()
    {
        var expenses = await _context.Expenses.ToListAsync();
        return expenses;
    }

    public async Task AddExpense(Expense expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();    
    }
}