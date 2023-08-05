namespace FamilyBudget.Model.Model.Database;
public class BudgetUser {
    public Guid BudgetId { get; set; }
    public virtual Budget Budget { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}