namespace FamilyBudget.Model.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> entity) {
        entity.HasKey(x => x.UserId);

        entity.Property(x => x.UserEmail).IsRequired().HasMaxLength(100);
        entity.Property(x => x.UserPassword).IsRequired().HasMaxLength(100);
        entity.Property(x => x.UserName).IsRequired().HasMaxLength(100);

        entity.Property(x => x.UserSalt).IsRequired().HasMaxLength(1000);
    }
}
