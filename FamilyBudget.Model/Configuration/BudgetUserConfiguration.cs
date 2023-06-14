namespace FamilyBudget.Model.Configuration;
public class BudgetUserConfiguration : IEntityTypeConfiguration<BudgetUser> {
    public void Configure(EntityTypeBuilder<BudgetUser> entity) {
        entity.HasKey(x => new { x.BudgetId, x.UserId });

        entity
            .HasOne(bu => bu.Budget)
            .WithMany(b => b.BudgetUsers)
            .HasForeignKey(bu => bu.BudgetId);

        entity
             .HasOne(bu => bu.User)
             .WithMany(u => u.BudgetUsers)
             .HasForeignKey(bu => bu.UserId);
    }
}
