namespace FamilyBudget.Model.Configuration;
public class BudgetConfiguration : IEntityTypeConfiguration<Budget> {
    public void Configure(EntityTypeBuilder<Budget> entity) {
        entity.HasKey(x => x.BudgetId);

        entity.Property(x => x.BudgetName).IsRequired().HasMaxLength(100);

        entity
            .HasOne(x => x.Owner)
            .WithMany(x => x.BudgetsWhereOwner)
            .HasForeignKey(x => x.OwnerId);
    }
}
