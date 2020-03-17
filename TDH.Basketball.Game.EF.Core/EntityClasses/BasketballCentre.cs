using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TDH.Basketball.Game.EF.Core.EntityClasses
{
    public class BasketballCentre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string  Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string AddressLine1 { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string AddressLine2 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Suburb { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string State { get; set; }

        [Column(TypeName = "nvarchar(4)")]
        public string Postcode { get; set; }

        public string ImageName { get; set; }
    }
}
