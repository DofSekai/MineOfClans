using Backend.Common.DAO;
using Backend.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Backend.Database {
    public class DatabaseContext : DbContext {
        public DbSet<User> users { get; set; }
        public DbSet<Village> villages { get; set; }
        public DbSet<LevelMine> levelMines { get; set; }

        private readonly string ConnectionString;
        
        public DatabaseContext(IOptions<AppSettings> options) {
            this.ConnectionString = options.Value?.ConnectionString
                                    ?? throw new ArgumentNullException(nameof(ConnectionString));
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(ConnectionString);
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            var userBuilder = modelBuilder.Entity<User>();
            var villageBuilder = modelBuilder.Entity<Village>();
            var levelMineBuilder = modelBuilder.Entity<LevelMine>();

            userBuilder.HasKey(x => x.Id);

            userBuilder.Property(x => x.Id).HasColumnType("integer");
            userBuilder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsUnicode(true)
                .HasColumnType("varchar");
            userBuilder.HasOne(x => x.Village);

            userBuilder.HasIndex(x => x.Name).IsUnique();
            
            villageBuilder.HasKey(x => x.Id);
            
            villageBuilder.Property(x => x.Id).HasColumnType("integer");
            villageBuilder.Property(x => x.Irons)
                .HasColumnType("integer")
                .HasDefaultValue(30);
            villageBuilder.Property(x => x.Diamonds)
                .HasColumnType("integer")
                .HasDefaultValue(20);
            villageBuilder.Property(x => x.Emeralds)
                .HasColumnType("integer")
                .HasDefaultValue(10);
            villageBuilder.Property(x => x.WallLevel)
                .HasColumnType("integer")
                .HasDefaultValue(0);
            villageBuilder.Property(x => x.GolemLevel)
                .HasColumnType("integer")
                .HasDefaultValue(0);
            villageBuilder.HasOne(x => x.LevelMine)
                .WithMany()
                .HasForeignKey(x => x.LevelMineId);
            villageBuilder.Property(x => x.LevelHDV)
                .HasColumnType("interger")
                .HasDefaultValue(1);
            villageBuilder.Property(x => x.LastUpdate).HasColumnType("integer");

            levelMineBuilder.HasKey(x => x.Id);
            
            levelMineBuilder.Property(x => x.Id).HasColumnType("integer");
            levelMineBuilder.Property(x => x.IronRate).HasColumnType("integer");
            levelMineBuilder.Property(x => x.DiamondRate).HasColumnType("integer");
            levelMineBuilder.Property(x => x.EmeraldRate).HasColumnType("integer");
            levelMineBuilder.Property(x => x.IronMaxRate).HasColumnType("integer");
            levelMineBuilder.Property(x => x.DiamondMaxRate).HasColumnType("integer");
            levelMineBuilder.Property(x => x.EmeraldMaxRate).HasColumnType("integer");
        }
    }
}
