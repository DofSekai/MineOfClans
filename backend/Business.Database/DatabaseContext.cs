using Backend.Common;
using Backend.Common.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Business.Database {
    public class DatabaseContext : DbContext {
        public DbSet<User> users { get; set; }
        public DbSet<Village> villages { get; set; }

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

            userBuilder.HasKey(x => x.Id);

            userBuilder.Property(x => x.Id).HasColumnType("integer");
            userBuilder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsUnicode(true)
                .HasColumnType("varchar");

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
            villageBuilder.Property(x => x.LastUpdate).HasColumnType("timestamp");
        }
    }
}
