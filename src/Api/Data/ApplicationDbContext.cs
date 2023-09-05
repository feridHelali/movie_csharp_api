
using System.Reflection;
using Api.Entities;
using Microsoft.EntityFrameworkCore;
using Api.Entities.Seeding;

namespace Api.Data
{
    public class ApplicationDbContext: DbContext
    {
      public ApplicationDbContext(DbContextOptions options) : base(options)
      {
        
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        InitialSeeding.Seeding(modelBuilder);
      }

      public DbSet<Genre> Genres { get; set; } 
      public DbSet<Actor> Actors { get; set; }
      public DbSet<Movie> Movies { get; set; }
      public DbSet<Comment> Comments { get; set; }
      public DbSet<MovieActor> MovieActors { get; set; }
    }
}