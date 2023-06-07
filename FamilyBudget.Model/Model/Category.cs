namespace FamilyBudget.Model.Model;
public class Category {
    [Key]
    public Guid CategoryId { get; set; }
    public required string CategoryName { get; set; }
}
