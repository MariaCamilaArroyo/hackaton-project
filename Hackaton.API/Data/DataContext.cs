using Hackaton.shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.API.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<HackatonTable> Hackatons { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Team> Teams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}

