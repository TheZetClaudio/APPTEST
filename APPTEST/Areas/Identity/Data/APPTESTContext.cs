using APPTEST.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APPTEST.Models;

namespace APPTEST.Data;

public class APPTESTContext : IdentityDbContext<APPTESTUser>
{
    public APPTESTContext(DbContextOptions<APPTESTContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public void Configure(EntityTypeBuilder<APPTESTUser> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(255);
        builder.Property(x => x.LastName).HasMaxLength(255);
    }

    public DbSet<APPTEST.Models.MUZ>? MUZ { get; set; }
}


