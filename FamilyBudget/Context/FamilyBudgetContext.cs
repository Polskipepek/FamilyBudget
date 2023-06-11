using FamilyBudget.Model.Configuration;

public class FamilyBudgetContext : DbContext {
    public FamilyBudgetContext(DbContextOptions<FamilyBudgetContext> options)
        : base(options) {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());

    }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Budget> Budgets { get; set; } = default!;
    public DbSet<Income> Incomes { get; set; } = default!;
    public DbSet<Expense> Expenses { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
}
