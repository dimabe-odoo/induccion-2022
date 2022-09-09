using Microsoft.EntityFrameworkCore;

namespace WebProjects.Models.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options): base(options){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>()
            .HasIndex(x => x.ProjectName)
            .IsUnique();
    }
    
    public DbSet<Project> Projects { get; set; }

    public DbSet<ProjectTask> ProjectTasks { get; set; }
}