using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TDH.Basketball.Game.EF.Core.EntityClasses
{
    public class CourtRentFee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }

        [ForeignKey("Id")]
        public int CentreId { get; set; }
        public BasketballCentre Centre { get; set; }

        [ForeignKey("Id")]
        public int CourtTypeId { get; set; }
        public CourtType CourtType { get; set; }

        public Decimal ChargeFee { get; set; }
        public bool  IsCurrent { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
