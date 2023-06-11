namespace FamilyBudget.Model.Model;
public class Income {
    [Key]
    public Guid IncomeId { get; set; }
    public virtual required Budget Budget { get; set; }
    public virtual required Category Category { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
