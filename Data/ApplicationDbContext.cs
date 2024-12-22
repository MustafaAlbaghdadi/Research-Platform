using aspcore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
// ReSharper disable UnusedMember.Global
#pragma warning disable 108,114

namespace aspcore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public virtual DbSet<User> Users { get; set; } = null!;

        public DbSet<ResearchMUS> ResearchMUS { get; set; }
        public DbSet<RR2tabel> RR2tabel { get; set; }
        public DbSet<TableCV> TableCV { get; set; }
        public DbSet<DepTable> DepTable { get; set; }
        public DbSet<PaymentSetting> paymentSettings { get; set; }
        public DbSet<PaymentLog> PaymentLog { get; set; }

        public DbSet<Conference> Conferences { get; set; }
        public DbSet<ConferenceResearch> ConferenceResearches { get; set; }
        public DbSet<ConferencePaymentLog> ConferencePaymentLog { get; set; }
        public DbSet<ResearcherAndCorresponding> ResearcherAndCorresponding { get; set; }
        public DbSet<ResearcherTable> ResearcherTable { get; set; }
        public DbSet<PlanView> PlanResDepView { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RR2tabel>().HasKey(vf => new { vf.ResearchId, vf.ResearcherId });
            modelBuilder.Entity<ConferenceResearch>().HasKey(vf => new { vf.ConferenceId, vf.ResearcherId });
            modelBuilder.Entity<Conference>().HasKey(vf => new { vf.ID });
            modelBuilder
         .Entity<PlanView>()
         .HasNoKey()  // Specify that the entity has no key (since it's a view)
         .ToView("PlanResDepView");  // Map to the actual view name in the database
        }

    }
}