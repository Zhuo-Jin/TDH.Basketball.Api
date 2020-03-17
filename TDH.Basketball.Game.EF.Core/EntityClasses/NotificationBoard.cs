using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TDH.Basketball.Game.EF.Core.EntityClasses
{
    public class NotificationBoard
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string NotificationText { get; set; }

        public DateTime  CreateDateTime{ get; set; }

        public DateTime ReleaseDateTime { get; set; }

        public bool IsActive { get; set; }
    }
}
