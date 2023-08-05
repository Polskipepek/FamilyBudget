namespace FamilyBudget.Model.Model;
public class Transaction {
    public Guid TransactionId { get; set; }
    public Budget Budget { get; set; }
    public Category Category { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
