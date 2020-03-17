using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.EF.Core
{
    public class TDHDBContext : DbContext
    {
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<BasketballCentre> BasketballCentres { get; set; }
        public DbSet<CourtRentFee> CourtRentFees { get; set; }
        public DbSet<CourtType> CourtTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<NotificationBoard> NotificationBoards { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        

        public TDHDBContext(DbContextOptions<TDHDBContext> Option) : base(Option)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            new SeedData.SeedCourtType(modelBuilder).Seed();
            new SeedData.SeedPlayer(modelBuilder).Seed();
            new SeedData.SeedCentre(modelBuilder).Seed();

        }

    }
}
