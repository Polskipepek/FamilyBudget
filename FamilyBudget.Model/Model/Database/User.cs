using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyBudget.Model.Model.Database;
public class User {
    public User() {
        BudgetUsers = new HashSet<BudgetUser>();
        BudgetsWhereOwner = new HashSet<Budget>();
    }

    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public string UserEmail { get; set; }
    public string UserSalt { get; set; }
    public virtual ICollection<BudgetUser> BudgetUsers { get; set; }
    [NotMapped] public virtual ICollection<Budget> BudgetsWhereOwner { get; set; }
}
