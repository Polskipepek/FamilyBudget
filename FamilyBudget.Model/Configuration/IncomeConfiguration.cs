namespace FamilyBudget.Model.Configuration;
public class IncomeConfiguration : IEntityTypeConfiguration<Income> {
    public void Configure(EntityTypeBuilder<Income> entity) {
        entity.HasKey(x => x.TransactionId);

        entity.Property(x => x.Amount).IsRequired();
        entity.Property(x => x.Date).IsRequired().HasMaxLength(100);
    }
}
