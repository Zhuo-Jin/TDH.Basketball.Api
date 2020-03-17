using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDH.Basketball.Game.EF.Core.EntityClasses;


namespace TDH.Basketball.Game.EF.Core.SeedData
{
    public class SeedCourtRentFee : SeedTable
    {

        public SeedCourtRentFee(ModelBuilder modelBuilder) : base(modelBuilder)
        {

        }

        public override void Seed()
        {
            _modelBuilder.Entity<CourtRentFee>().HasData(
                new CourtRentFee()
                {
                    Id = 1,
                    CentreId = 1,
                    CourtTypeId = 1,
                    ChargeFee = 110,
                    IsCurrent = true,
                    CreateDate = new DateTime(2020, 03, 17),
                },

                new CourtRentFee()
                {
                    Id = 1,
                    CentreId = 1,
                    CourtTypeId = 2,
                    ChargeFee = 130,
                    IsCurrent = false,
                    CreateDate = new DateTime(2020, 02, 17),
                }
            );
        }
    }
}
