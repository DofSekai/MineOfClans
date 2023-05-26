using Backend.Common;
using Backend.Common.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Business.Database {
    public class DatabaseContext : DbContext {
        public DbSet<User> users { get; set; }
        
        private readonly string ConnectionString;
        
        public DatabaseContext(IOptions<AppSettings> options) {
            this.ConnectionString = options.Value?.ConnectionString
                                    ?? throw new ArgumentNullException(nameof(ConnectionString));
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(ConnectionString);
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            var userBuilder = modelBuilder.Entity<User>();

            userBuilder.HasKey(x => x.Id);

            userBuilder.Property(x => x.Id).HasColumnType("integer");
            userBuilder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsUnicode(true)
                .HasColumnType("varchar");
            userBuilder.Property(x => x.Level)
                .HasColumnType("integer")
                .HasDefaultValue(1);

            userBuilder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
