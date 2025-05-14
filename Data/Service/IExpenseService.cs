using FinanceApp.Models;

namespace FinanceApp.Data.Service;

public interface IExpenseService
{
    Task<List<Expense>> GetAllExpenses();
    Task AddExpense(Expense expense);
    Task<Expense> GetExpenseById(int id);
    Task UpdateExpense(Expense expense);
    Task DeleteExpense(int id);
}