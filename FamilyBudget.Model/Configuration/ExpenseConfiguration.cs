namespace FamilyBudget.Model.Configuration;
public class ExpenseConfiguration : IEntityTypeConfiguration<Expense> {
    public void Configure(EntityTypeBuilder<Expense> entity) {
        entity.HasKey(x => x.TransactionId);

        entity.Property(x => x.Amount).IsRequired();
        entity.Property(x => x.Date).IsRequired().HasMaxLength(100);
    }
}
