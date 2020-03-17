using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TDH.Basketball.Game.EF.Core.EntityClasses
{
    public class Transaction
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }

        public bool InOrOut { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }

        [ForeignKey("Id")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal TransactionFee { get; set; }

        public decimal Balance { get; set; }


    }
}
