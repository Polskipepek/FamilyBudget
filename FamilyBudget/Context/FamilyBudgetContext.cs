namespace FamilyBudget.Context;
public class FamilyBudgetContext : DbContext {
    public FamilyBudgetContext(DbContextOptions<FamilyBudgetContext> options)
        : base(options) {
    }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Budget> Budgets { get; set; } = default!;
    public DbSet<Income> Incomes { get; set; } = default!;
    public DbSet<Expense> Expenses { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
}
