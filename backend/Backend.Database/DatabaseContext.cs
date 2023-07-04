using Backend.Common;
using Backend.Common.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Backend.Database;
    
public class DatabaseContext : DbContext 
{
    public DbSet<User> Users { get; set; }
    public DbSet<Village> Villages { get; set; }
    public DbSet<LevelMine> LevelMines { get; set; }
    public DbSet<LevelHdv> LevelHdvs { get; set; }
    public DbSet<RankupMine> RankupMines { get; set; }
    public DbSet<RankupHdv> RankupHdvs { get; set; }

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
        
        var levelMineBuilder = modelBuilder.Entity<LevelMine>();
        
        levelMineBuilder.HasKey(x => x.Id);
            
        levelMineBuilder.Property(x => x.Id).HasColumnType("integer");
        levelMineBuilder.Property(x => x.IronRate).HasColumnType("integer");
        levelMineBuilder.Property(x => x.DiamondRate).HasColumnType("integer");
        levelMineBuilder.Property(x => x.EmeraldRate).HasColumnType("integer");
        levelMineBuilder.Property(x => x.IronMaxRate).HasColumnType("integer");
        levelMineBuilder.Property(x => x.DiamondMaxRate).HasColumnType("integer");
        levelMineBuilder.Property(x => x.EmeraldMaxRate).HasColumnType("integer");
        
        var levelHdvBuilder = modelBuilder.Entity<LevelHdv>();
        
        levelHdvBuilder.HasKey(x => x.Id);
            
        levelHdvBuilder.Property(x => x.Id).HasColumnType("integer");
        levelHdvBuilder.Property(x => x.MaxGolems).HasColumnType("integer");
        levelHdvBuilder.Property(x => x.MaxTowers).HasColumnType("integer");
        levelHdvBuilder.Property(x => x.MaxWalls).HasColumnType("integer");
        
        var rankupMinesBuilder = modelBuilder.Entity<RankupMine>();
        
        rankupMinesBuilder.HasKey(x => x.Id);
            
        rankupMinesBuilder.Property(x => x.Id).HasColumnType("integer");
        rankupMinesBuilder.Property(x => x.Irons).HasColumnType("integer");
        rankupMinesBuilder.Property(x => x.Diamonds).HasColumnType("integer");
        rankupMinesBuilder.Property(x => x.Emeralds).HasColumnType("integer");
        
        var rankupHdvsBuilder = modelBuilder.Entity<RankupHdv>();
        
        rankupHdvsBuilder.HasKey(x => x.Id);
            
        rankupHdvsBuilder.Property(x => x.Id).HasColumnType("integer");
        rankupHdvsBuilder.Property(x => x.Irons).HasColumnType("integer");
        rankupHdvsBuilder.Property(x => x.Diamonds).HasColumnType("integer");
        rankupHdvsBuilder.Property(x => x.Emeralds).HasColumnType("integer");
    }
}
