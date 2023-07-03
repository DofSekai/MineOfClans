using Backend.Common.DAO;
using Backend.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Backend.Database;
    
public class DatabaseContext : DbContext 
{
    public DbSet<User> Users { get; set; }

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
            
    }
}
