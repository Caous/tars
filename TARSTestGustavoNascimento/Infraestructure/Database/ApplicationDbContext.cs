
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
            // Config entities to tables  
            modelBuilder.Entity<UserModel>().ToTable("tb_user");
            // Config Primary Key
            modelBuilder.Entity<UserModel>().HasKey(u => u.Id).HasName("PK_Users");
            // Config Coluns
            modelBuilder.Entity<UserModel>().Property(u => u.fullname).HasColumnType("nvarchar(500)").IsRequired();
            modelBuilder.Entity<UserModel>().Property(u => u.departament).HasColumnType("nvarchar(500)").IsRequired();
            modelBuilder.Entity<UserModel>().Property(u => u.dt_inclused).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<UserModel>().Property(u => u.dt_exclused).HasColumnType("datetime");


        }

    }
}