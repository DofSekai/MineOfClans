using Backend.Common.DAO;
using Backend.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Backend.Database {
    public class DatabaseContext : DbContext {
        public DbSet<User> users { get; set; }
        public DbSet<Village> villages { get; set; }
        public DbSet<LevelMine> levelMines { get; set; }
        public DbSet<LevelHdv> levelHdvs { get; set; }
        public DbSet<RankupMine> rankupMines { get; set; }
        public DbSet<RankupHdv> rankupHdvs { get; set; }

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
            var levelHdvBuilder = modelBuilder.Entity<LevelHdv>();
            var rankupMinesBuilder = modelBuilder.Entity<RankupMine>();
            var rankupHdvsBuilder = modelBuilder.Entity<RankupHdv>();

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
            villageBuilder.Property(x => x.Walls)
                .HasColumnType("integer")
                .HasDefaultValue(0);
            villageBuilder.Property(x => x.Golems)
                .HasColumnType("integer")
                .HasDefaultValue(0);
            villageBuilder.Property(x => x.Towers)
                .HasColumnType("integer")
                .HasDefaultValue(0);
            villageBuilder.HasOne(x => x.LevelMine)
                .WithMany()
                .HasForeignKey(x => x.LevelMineId);
            villageBuilder.HasOne(x => x.LevelHdv)
                .WithMany()
                .HasForeignKey(x => x.LevelHdvId);
            villageBuilder.Property(x => x.LastUpdate).HasColumnType("integer");

            levelMineBuilder.HasKey(x => x.Id);
            
            levelMineBuilder.Property(x => x.Id).HasColumnType("integer");
            levelMineBuilder.Property(x => x.IronRate).HasColumnType("integer");
            levelMineBuilder.Property(x => x.DiamondRate).HasColumnType("integer");
            levelMineBuilder.Property(x => x.EmeraldRate).HasColumnType("integer");
            levelMineBuilder.Property(x => x.IronMaxRate).HasColumnType("integer");
            levelMineBuilder.Property(x => x.DiamondMaxRate).HasColumnType("integer");
            levelMineBuilder.Property(x => x.EmeraldMaxRate).HasColumnType("integer");

            levelHdvBuilder.HasKey(x => x.Id);
            
            levelHdvBuilder.Property(x => x.Id).HasColumnType("integer");
            levelHdvBuilder.Property(x => x.MaxGolems).HasColumnType("integer");
            levelHdvBuilder.Property(x => x.MaxTowers).HasColumnType("integer");
            levelHdvBuilder.Property(x => x.MaxWalls).HasColumnType("integer");
            
            rankupMinesBuilder.HasKey(x => x.Id);
            
            rankupMinesBuilder.Property(x => x.Id).HasColumnType("integer");
            rankupMinesBuilder.Property(x => x.Irons).HasColumnType("integer");
            rankupMinesBuilder.Property(x => x.Diamonds).HasColumnType("integer");
            rankupMinesBuilder.Property(x => x.Emeralds).HasColumnType("integer");
            
            rankupHdvsBuilder.HasKey(x => x.Id);
            
            rankupHdvsBuilder.Property(x => x.Id).HasColumnType("integer");
            rankupHdvsBuilder.Property(x => x.Irons).HasColumnType("integer");
            rankupHdvsBuilder.Property(x => x.Diamonds).HasColumnType("integer");
            rankupHdvsBuilder.Property(x => x.Emeralds).HasColumnType("integer");
        }
    }
}
