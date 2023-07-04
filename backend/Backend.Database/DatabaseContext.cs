using Backend.Common;
using Backend.Common.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using User = Backend.Common.DAO.User;
using Village = Backend.Common.DAO.Village;

namespace Backend.Database;
    
public class DatabaseContext : DbContext 
{
    public DbSet<User> Users { get; set; }
    public DbSet<Village> Villages { get; set; }

    private readonly string _connectionString;
        
    public DatabaseContext(IOptions<AppSettings> options) 
    {
        _connectionString = options.Value?.ConnectionString
                            ?? throw new ArgumentNullException(nameof(_connectionString));
    }
        
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_connectionString);
        
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        var userBuilder = modelBuilder.Entity<User>();

        userBuilder.HasKey(x => x.Id);

        userBuilder.Property(x => x.Id).HasColumnType("integer");
        userBuilder.Property(x => x.Name)
            .HasMaxLength(255)
            .IsUnicode(true)
            .HasColumnType("varchar");
        userBuilder.HasMany(x => x.Villages)
            .WithOne(x => x.User);
            
        var villageBuilder = modelBuilder.Entity<Village>();
        
        villageBuilder.HasKey(x => x.Id);
        
        villageBuilder.Property(x => x.Id).HasColumnType("integer");
        villageBuilder.Property(x => x.Name)
            .HasMaxLength(255)
            .IsUnicode(true)
            .HasColumnType("varchar");
        villageBuilder.HasOne(x => x.User)  
            .WithMany(x => x.Villages)
            .HasForeignKey(x => x.UserId);
        villageBuilder.Property(x => x.Irons).HasColumnType("integer")
            .HasDefaultValue(30);
        villageBuilder.Property(x => x.Diamonds).HasColumnType("integer")
            .HasDefaultValue(20);
        villageBuilder.Property(x => x.Emeralds).HasColumnType("integer")
            .HasDefaultValue(10);
        villageBuilder.Property(x => x.Golems).HasColumnType("integer")
            .HasDefaultValue(0);
        villageBuilder.Property(x => x.Walls).HasColumnType("integer")
            .HasDefaultValue(0);
        villageBuilder.Property(x => x.Towers).HasColumnType("integer")
            .HasDefaultValue(0);
        villageBuilder.Property(x => x.LastUpdate).HasColumnType("integer");
    }
}
