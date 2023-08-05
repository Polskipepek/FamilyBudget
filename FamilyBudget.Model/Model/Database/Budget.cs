using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyBudget.Model.Model.Database;
public class Budget {
    public Budget() {
        BudgetUsers = new HashSet<BudgetUser>();
        Expenses = new HashSet<Transaction>();
        Incomes = new HashSet<Transaction>();
    }

    public Guid BudgetId { get; set; }
    public virtual User Owner { get; set; }
    public virtual Guid OwnerId { get; set; }
    public string BudgetName { get; set; }
    public virtual ICollection<BudgetUser> BudgetUsers { get; set; }
    [NotMapped] public virtual ICollection<Transaction> Expenses { get; set; }
    [NotMapped] public virtual ICollection<Transaction> Incomes { get; set; }
    [NotMapped] public virtual ICollection<Transaction> Transactions => Expenses.Concat(Incomes).ToList();
}
