namespace FamilyBudget.Model.Model;
public class Budget {
    public Guid BudgetId { get; set; }
    public virtual required User User { get; set; }
    public required string BudgetName { get; set; }
}
