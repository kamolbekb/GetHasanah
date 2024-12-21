using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using N_Tier.Core.Common;
using N_Tier.Core.Entities;
using N_Tier.Shared.Services;

namespace N_Tier.DataAccess.Persistence;

public class DatabaseContext : DbContext
{
    private readonly IClaimService _claimService;
    
    public DatabaseContext(DbContextOptions options, IClaimService claimService) 
        : base(options)
    {
        _claimService = claimService;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }


    public DbSet<Employee> Employees { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Diary> Diaries { get; set; }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // builder.Entity<Group>(entity =>
        // {
        //     entity.HasKey(r => r.Id);
        //
        //     entity.HasOne(e => e.StudyProcess)
        //         .WithOne(o => o.Group)
        //         .HasForeignKey<Group>(o => o.StudyProcessId);
        // });
        
        
        base.OnModelCreating(builder);
    }

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = "Kamol";
                    entry.Entity.CreatedOn = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = "_claimService.GetUserId()";
                    entry.Entity.UpdatedOn = DateTime.Now;
                    break;
            }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
