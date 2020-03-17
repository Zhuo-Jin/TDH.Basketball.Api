using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.EF.Core.SeedData
{
    public class SeedCentre : SeedTable
    {
        public SeedCentre(ModelBuilder modelBuilder) : base(modelBuilder)
        {

        }

        public override void Seed()
        {
            _modelBuilder.Entity<BasketballCentre>().HasData(
                new BasketballCentre() { 
                    Id = 1,
                    Name  = "ryde russ basketball club",
                    AddressLine1 = "724 Victoria Rd",
                    AddressLine2 = "",
                    Suburb = "Ryde",
                    State = "NSW",
                    Postcode = "2112",
                    ImageName = "1.jpg"
                },

                new BasketballCentre()
                {
                    Id = 2,
                    Name = "Auburn Basketball Centre",
                    AddressLine1 = "Church St",
                    AddressLine2 = "",
                    Suburb = "Lidcombe",
                    State = "NSW",
                    Postcode = "2141",
                    ImageName = "2.jpg"
                }
            );
        }
    }
}
