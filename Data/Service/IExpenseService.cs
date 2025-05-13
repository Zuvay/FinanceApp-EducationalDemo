using FinanceApp.Models;

namespace FinanceApp.Data.Service;

public interface IExpenseService
{
    Task<List<Expense>> GetAllExpenses();
    Task AddExpense(Expense expense);
}