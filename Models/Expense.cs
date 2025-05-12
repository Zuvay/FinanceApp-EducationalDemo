using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Models;

public class Expense
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid amount.")]
    public double Amount { get; set; }
    [Required]
    public string Category { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
}