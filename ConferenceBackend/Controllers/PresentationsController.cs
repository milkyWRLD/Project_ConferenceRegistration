using Microsoft.AspNetCore.Mvc;
using ConferenceBackend.Data;
using ConferenceBackend.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PresentationsController : ControllerBase
{
    private readonly ConferenceDbContext _context;

    public PresentationsController(ConferenceDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Presentation>>> GetPresentations()
    {
        return await _context.Presentations.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Presentation>> GetPresentation(int id)
    {
        var presentation = await _context.Presentations.FindAsync(id);

        if (presentation == null)
        {
            return NotFound();
        }

        return presentation;
    }

    [HttpPost]
    public async Task<ActionResult<Presentation>> AddPresentation(Presentation presentation)
    {
        _context.Presentations.Add(presentation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPresentation), new { id = presentation.Id }, presentation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePresentation(int id, Presentation presentation)
    {
        if (id != presentation.Id)
        {
            return BadRequest();
        }

        _context.Entry(presentation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Presentations.Any(e => e.Id == id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePresentation(int id)
    {
        var presentation = await _context.Presentations.FindAsync(id);

        if (presentation == null)
        {
            return NotFound();
        }

        _context.Presentations.Remove(presentation);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
