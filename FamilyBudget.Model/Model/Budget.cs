namespace FamilyBudget.Model.Model;
public class Budget {
    [Key]
    public Guid BudgetId { get; set; }
    public required User User { get; set; }
    public required string BudgetName { get; set; }
}
