namespace FamilyBudget.Model.Model;
public class Expense {
    [Key]
    public Guid ExpenseId { get; set; }
    public required Budget Budget { get; set; }
    public required Category Category { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
