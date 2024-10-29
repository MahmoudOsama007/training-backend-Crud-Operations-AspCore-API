using Microsoft.EntityFrameworkCore;
using training_backend.models;

namespace training_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TrainingInitiative> Trainings { get; set; }
    }
}
