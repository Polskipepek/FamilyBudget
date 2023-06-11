namespace FamilyBudget.Model.Configuration;
public class BudgetConfiguration : IEntityTypeConfiguration<Budget> {
    public void Configure(EntityTypeBuilder<Budget> entity) {
        entity.HasKey(x => x.BudgetId);

        entity.Property(x => x.BudgetName).IsRequired().HasMaxLength(100);

        entity.Property(x => x.User).IsRequired().HasMaxLength(1000);
    }
}
