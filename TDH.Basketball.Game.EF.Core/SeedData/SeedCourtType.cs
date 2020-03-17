using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.EF.Core.SeedData
{
    public class SeedCourtType : SeedTable
    {
        public SeedCourtType(ModelBuilder modelBuilder) : base(modelBuilder)
        {

        }

        public override void Seed()
        {
            _modelBuilder.Entity<CourtType>().HasData(
                new CourtType()
                {
                    Id = 1,
                    Type = "Full"
                    
                },

                new CourtType()
                {
                    Id = 2,
                    Type = "Half"
                }
            );
        }
    }
}
