using FamilyBudget.Model.Configuration;

namespace FamilyBudget.Context;
public class FamilyBudgetContext : DbContext {

    public FamilyBudgetContext(DbContextOptions<FamilyBudgetContext> options)
        : base(options) {
    }

    private readonly StreamWriter _logStream = new("mylog.txt", append: true);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.LogTo(_logStream.WriteLine);

    public override void Dispose() {
        base.Dispose();
        _logStream.Dispose();
    }

    public override async ValueTask DisposeAsync() {
        await base.DisposeAsync();
        await _logStream.DisposeAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new BudgetUserConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new BudgetConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
        modelBuilder.ApplyConfiguration(new IncomeConfiguration());

    }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<BudgetUser> BudgetUsers { get; set; } = default!;
    public DbSet<Budget> Budgets { get; set; } = default!;
    public DbSet<Income> Incomes { get; set; } = default!;
    public DbSet<Expense> Expenses { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
}
