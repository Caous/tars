using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TARSTestGustavoNascimento.Models;

namespace TARSTestGustavoNascimento.Infraestructure.database
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             

            modelBuilder.Entity<UserModel>(b =>
            {
                // Config entities to tables
                b.ToTable("tb_user");
                // Config Primary Key
                b.HasKey(u => u.Id).HasName("PK_Users");
                // Config Coluns
                b.Property(u => u.fullname).HasColumnType("nvarchar(500)").IsRequired();
                b.Property(u => u.departament).HasColumnType("nvarchar(500)").IsRequired();
                b.Property(u => u.dt_inclused).HasColumnType("datetime").IsRequired();
                b.Property(u => u.dt_exclused).HasColumnType("datetime");

                b.HasMany(p => p.Claims).WithOne().HasForeignKey(p => p.UserId);

            });


        }

    }
}