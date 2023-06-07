namespace FamilyBudget.Model.Model;
public class User {
    [Key]
    public Guid UserId { get; set; }
    public required string UserName { get; set; }
    public required string UserPassword { get; set; }
    public required string UserEmail { get; set; }
    public required string UserSalt { get; set; }
}
