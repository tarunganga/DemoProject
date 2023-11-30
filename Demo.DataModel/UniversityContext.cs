using Microsoft.EntityFrameworkCore;

namespace Demo.DataModel
{
    public class UniversityContext(DbContextOptions<UniversityContext> options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Age).IsRequired();
                entity.Property(e => e.Grade).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.LastUpdatedAt).IsRequired();
            });



            base.OnModelCreating(modelBuilder);
        }
    }
}
