namespace FamilyBudget.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IncomesController : ControllerBase {
    private readonly FamilyBudgetContext _context;

    public IncomesController(FamilyBudgetContext context) {
        _context = context;
    }

    // GET: api/Incomes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Income>>> GetIncomes() {
        if (_context.Incomes == null) {
            return NotFound();
        }
        return await _context.Incomes.ToListAsync();
    }

    // GET: api/Incomes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Income>> GetIncome(Guid id) {
        if (_context.Incomes == null) {
            return NotFound();
        }
        var income = await _context.Incomes.FindAsync(id);

        if (income == null) {
            return NotFound();
        }

        return income;
    }

    // PUT: api/Incomes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutIncome(Guid id, Income income) {
        if (id != income.TransactionId) {
            return BadRequest();
        }

        _context.Entry(income).State = EntityState.Modified;

        try {
            await _context.SaveChangesAsync();
        } catch (DbUpdateConcurrencyException) {
            if (!IncomeExists(id)) {
                return NotFound();
            } else {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Incomes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Income>> PostIncome(Income income) {
        if (_context.Incomes == null) {
            return Problem("Entity set 'FamilyBudgetContext.Incomes'  is null.");
        }
        _context.Incomes.Add(income);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetIncome", new { id = income.TransactionId }, income);
    }

    // DELETE: api/Incomes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIncome(Guid id) {
        if (_context.Incomes == null) {
            return NotFound();
        }
        var income = await _context.Incomes.FindAsync(id);
        if (income == null) {
            return NotFound();
        }

        _context.Incomes.Remove(income);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool IncomeExists(Guid id) {
        return (_context.Incomes?.Any(e => e.TransactionId == id)).GetValueOrDefault();
    }
}
