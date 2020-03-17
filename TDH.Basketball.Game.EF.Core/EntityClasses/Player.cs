using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TDH.Basketball.Game.EF.Core.EntityClasses
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string NickName { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Mobile { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Password { get; set; }
        public bool IsPermanent { get; set; }
        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }

    }
}
