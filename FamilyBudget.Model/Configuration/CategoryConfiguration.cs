namespace FamilyBudget.Model.Configuration;
public class CategoryConfiguration : IEntityTypeConfiguration<Category> {
    public void Configure(EntityTypeBuilder<Category> entity) {
        entity.HasKey(x => x.CategoryId);

        entity.Property(x => x.CategoryName).IsRequired().HasMaxLength(100);
    }
}
