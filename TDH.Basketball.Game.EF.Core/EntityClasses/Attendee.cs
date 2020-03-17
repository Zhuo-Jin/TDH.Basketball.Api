using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TDH.Basketball.Game.EF.Core.EntityClasses
{
    public class Attendee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        public bool IsPermanent { get; set; }
        
        [ForeignKey("Id")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        [ForeignKey("Id")]
        public int ReplacedPlayerId { get; set; }
        public Player ReplacedPlayer { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string PaymentCode { get; set; }

        public Decimal FeeShared { get; set; }

        public DateTime? PaidDateTime { get; set; }
    }
}
