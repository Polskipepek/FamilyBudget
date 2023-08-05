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
}
