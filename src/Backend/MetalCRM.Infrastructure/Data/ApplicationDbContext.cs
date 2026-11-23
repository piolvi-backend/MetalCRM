using MetalCRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetalCRM.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FullName).IsRequired().HasMaxLength(128);
            entity.Property(e => e.PhoneOrCardNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.BankName).IsRequired().HasMaxLength(128);
            entity.Property(e => e.DocsName).IsRequired().HasMaxLength(20);
            entity.Property(e => e.DocsNumber).IsRequired().HasMaxLength(10);
            entity.Property(e => e.Description).HasMaxLength(512);
        });
    }
}