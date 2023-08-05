namespace FamilyBudget.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BudgetsController : ControllerBase {
    private readonly FamilyBudgetContext _context;

    public BudgetsController(FamilyBudgetContext context) {
        _context = context;
    }

    // GET: api/Budgets
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Budget>>> GetBudgets() {
        if (_context.Budgets == null) {
            return NotFound();
        }
        return await _context.Budgets.ToListAsync();
    }

    // GET: api/Budgets/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Budget>> GetBudget(Guid id) {
        if (_context.Budgets == null) {
            return NotFound();
        }
        var budget = await _context.Budgets.FindAsync(id);

        if (budget == null) {
            return NotFound();
        }

        return budget;
    }

    // PUT: api/Budgets/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBudget(Guid id, Budget budget) {
        if (id != budget.BudgetId) {
            return BadRequest();
        }

        _context.Entry(budget).State = EntityState.Modified;

        try {
            await _context.SaveChangesAsync();
        } catch (DbUpdateConcurrencyException) {
            if (!BudgetExists(id)) {
                return NotFound();
            } else {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Budgets
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Budget>> PostBudget(Budget budget) {
        if (_context.Budgets == null) {
            return Problem("Entity set 'FamilyBudgetContext.Budgets'  is null.");
        }
        _context.Budgets.Add(budget);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBudget", new { id = budget.BudgetId }, budget);
    }

    // DELETE: api/Budgets/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBudget(Guid id) {
        if (_context.Budgets == null) {
            return NotFound();
        }
        var budget = await _context.Budgets.FindAsync(id);
        if (budget == null) {
            return NotFound();
        }

        _context.Budgets.Remove(budget);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BudgetExists(Guid id) {
        return (_context.Budgets?.Any(e => e.BudgetId == id)).GetValueOrDefault();
    }
}
