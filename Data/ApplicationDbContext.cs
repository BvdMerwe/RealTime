using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealTime.Models;

namespace RealTime.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Setlist>()
            .HasKey(p => new { p.Id });
            builder.Entity<Setlist>()
                .Property(p => p.Id)
                .UseSqlServerIdentityColumn();

            builder.Entity<Question>()
            .HasKey(p => new { p.Id });
            builder.Entity<Question>()
                .Property(p => p.Id)
                .UseSqlServerIdentityColumn();

            builder.Entity<QuestionType>()
            .HasKey(p => new { p.Id });
            builder.Entity<QuestionType>()
                .Property(p => p.Id)
                .UseSqlServerIdentityColumn();

            builder.Entity<Answer>()
            .HasKey(p => new { p.Id });
            builder.Entity<Answer>()
                .Property(p => p.Id)
                .UseSqlServerIdentityColumn();
        }

        public DbSet<Setlist> Setlists {get;set;}
        public DbSet<Question> Questions {get;set;}
        public DbSet<QuestionType> QuestionTypes {get;set;}
        public DbSet<Answer> Answers {get;set;}
    }
}
