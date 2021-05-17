using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity;

namespace PASC.Models
{
    public class PascContext : DbContext
    {
        public PascContext(DbContextOptions<PascContext> options)
                : base(options)
        { }

        public DbSet<Acceptance> Acceptance { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Building> Building { get; set; }
        public DbSet<Campi> Campi { get; set; }
        public DbSet<Center> Center { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Option> Option { get; set; }
        public DbSet<Pass> Pass { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionCategory> QuestionCategory { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Sector> Sector { get; set; }
        public DbSet<Unity> Unity { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserAcceptance> UserAcceptance { get; set; }
        public DbSet<UserBuilding> UserBuilding { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserSector> UserSector { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Gender>().HasData(new Gender() { GenderId = 1, Name = "Masculine" });
            modelBuilder.Entity<Gender>().HasData(new Gender() { GenderId = 2, Name = "Feminine" });
            modelBuilder.Entity<Gender>().HasData(new Gender() { GenderId = 3, Name = "Other" });

            modelBuilder.Entity<User>()
                .HasOne(e => e.Gender)
                .WithMany(c => c.users).OnDelete(DeleteBehavior.Restrict);









            //modelBuilder.Entity<University>().HasData(new University() { UniversityId = 1, Abbreviation = "UFRJ", Name = "Universidade Federal do Rio de Janeiro" });
            //modelBuilder.Entity<University>().HasData(new University() { UniversityId = 2, Abbreviation = "UFF", Name = "Universidade Federal Fluminense" });

            //modelBuilder.Entity<Domain>().HasData(new Domain() { DomainId = 1, Name = "@poli.ufrj.br", UniversityId = 1 });
            //modelBuilder.Entity<Domain>().HasData(new Domain() { DomainId = 2, Name = "@ufrj.br", UniversityId = 1 });
            //modelBuilder.Entity<Domain>().HasData(new Domain() { DomainId = 3, Name = "@id.uff.br", UniversityId = 2 });

            //modelBuilder.Entity<IdentityProvider>().HasData(new IdentityProvider() { IdentityProviderId = 1, Name = "Active Directory", Code="AD"}, 
            //                                                new IdentityProvider() { IdentityProviderId = 2, Name = "Microsoft", Code= "live.com" },
            //                                                new IdentityProvider() { IdentityProviderId = 3, Name = "Facebook", Code = "facebook.com" },
            //                                                new IdentityProvider() { IdentityProviderId = 4, Name = "E-MAIL", Code = "E-MAIL" });

            //modelBuilder.Entity<Gender>().HasData(new Gender() { GenderId = 1, Name = "Masculine" });
            //modelBuilder.Entity<Gender>().HasData(new Gender() { GenderId = 2, Name = "Feminine" });
            //modelBuilder.Entity<Gender>().HasData(new Gender() { GenderId = 3, Name = "Other" });


            //modelBuilder.Entity<User>().Property(x => x.Guid).HasDefaultValueSql("NEWID()");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Method intentionally left empty.
        }

    }
}
