using Microsoft.EntityFrameworkCore;
using ConferenceBackend.Models;

namespace ConferenceBackend.Data
{
    public class ConferenceDbContext : DbContext
{
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Presentation> Presentations { get; set; }
    public DbSet<CoPresenter> CoPresenters { get; set; }

    public ConferenceDbContext(DbContextOptions<ConferenceDbContext> options)
        : base(options)
    {
        // Не нужно инициализировать коллекции вручную, EF сама управляет их состоянием.
    }
}
}
