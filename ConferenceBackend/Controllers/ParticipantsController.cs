using Microsoft.AspNetCore.Mvc;
using ConferenceBackend.Data;
using ConferenceBackend.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ParticipantsController : ControllerBase
{
    private readonly ConferenceDbContext _context;

    public ParticipantsController(ConferenceDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Participant>>> GetParticipants()
    {
        return await _context.Participants.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Participant>> GetParticipant(int id)
    {
        var participant = await _context.Participants.FindAsync(id);

        if (participant == null)
        {
            return NotFound();
        }

        return participant;
    }

    [HttpPost]
    public async Task<ActionResult<Participant>> AddParticipant(Participant participant)
    {
        if (participant == null)
        {
            return BadRequest("Invalid participant data");
        }

        _context.Participants.Add(participant);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetParticipant), new { id = participant.Id }, participant);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateParticipant(int id, Participant participant)
    {
        if (id != participant.Id)
        {
            return BadRequest();
        }

        _context.Entry(participant).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Participants.Any(e => e.Id == id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteParticipant(int id)
    {
        var participant = await _context.Participants.FindAsync(id);

        if (participant == null)
        {
            return NotFound();
        }

        _context.Participants.Remove(participant);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
