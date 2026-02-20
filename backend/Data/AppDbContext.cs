using DevTrackAI.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTrackAI.Api.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TaskItem> TaskItems => Set<TaskItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.ToTable("TASK_ITEMS");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            entity.Property(e => e.Title)
                .HasColumnName("TITLE")
                .HasColumnType("VARCHAR2(255)")
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.Status)
                .HasColumnName("STATUS")
                .HasColumnType("VARCHAR2(100)")
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("CLOB")
                .IsRequired();

            entity.Property(e => e.CreatedAtUtc)
                .HasColumnName("CREATED_AT_UTC")
                .HasColumnType("TIMESTAMP(7)")
                .IsRequired();
        });
    }
}
