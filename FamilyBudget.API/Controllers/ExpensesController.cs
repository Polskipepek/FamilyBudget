﻿namespace FamilyBudget.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase {
    private readonly FamilyBudgetContext _context;

    public ExpensesController(FamilyBudgetContext context) {
        _context = context;
    }

    // GET: api/Expenses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses() {
        if (_context.Expenses == null) {
            return NotFound();
        }
        return await _context.Expenses.ToListAsync();
    }

    // GET: api/Expenses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Expense>> GetExpense(Guid id) {
        if (_context.Expenses == null) {
            return NotFound();
        }
        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null) {
            return NotFound();
        }

        return expense;
    }

    // PUT: api/Expenses/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutExpense(Guid id, Expense expense) {
        if (id != expense.TransactionId) {
            return BadRequest();
        }

        _context.Entry(expense).State = EntityState.Modified;

        try {
            await _context.SaveChangesAsync();
        } catch (DbUpdateConcurrencyException) {
            if (!ExpenseExists(id)) {
                return NotFound();
            } else {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Expenses
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Expense>> PostExpense(Expense expense) {
        if (_context.Expenses == null) {
            return Problem("Entity set 'FamilyBudgetContext.Expenses'  is null.");
        }
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetExpense", new { id = expense.TransactionId }, expense);
    }

    // DELETE: api/Expenses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(Guid id) {
        if (_context.Expenses == null) {
            return NotFound();
        }
        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null) {
            return NotFound();
        }

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ExpenseExists(Guid id) {
        return (_context.Expenses?.Any(e => e.TransactionId == id)).GetValueOrDefault();
    }
}
