using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.EF.Core.SeedData
{
    public class SeedPlayer : SeedTable
    {
        public SeedPlayer(ModelBuilder modelBuilder) : base (modelBuilder)
        {
            
        }

        public override void Seed() {
            _modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 1,
                    FirstName = "Zhuo",
                    LastName = "Jin",
                    NickName = "帮主",
                    Mobile = "0413100244",
                    Email = "jinzhuo1783@gmail.com",
                    Password = "1",
                    IsAdmin = true,
                    IsActive = true,

                },

                new Player
                {
                    Id = 2,
                    FirstName = "Hai",
                    LastName = "SU",
                    NickName = "海海",
                    Mobile = "0423233456",
                    Email = "xxxx@gmail.com",
                    Password = "1",
                    IsAdmin = true,
                    IsActive = true,

                }
            );

        }
    }
}
