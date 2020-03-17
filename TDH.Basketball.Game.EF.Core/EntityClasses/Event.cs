using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TDH.Basketball.Game.EF.Core.EntityClasses
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }

        [ForeignKey("Id")]
        public int TermId { get; set; }
        public Term Term { get; set; }
        public string  EventName { get; set; }

        public DateTime EventDate { get; set; }

        public bool IsActive { get; set; }
    }
}
