using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDH.Basketball.Game.EF.Core.SeedData
{
    public abstract class SeedTable
    {
        protected readonly ModelBuilder _modelBuilder;
        public SeedTable(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public virtual void Seed()
        { 
        
        }
    }
}
