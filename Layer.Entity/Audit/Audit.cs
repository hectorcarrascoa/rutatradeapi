using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Layer.Entity
{
    public class Audit
    {
        [Required]
        [Column("loaddate")]
        public DateTime LoadDate { get; set; }

        [Required]
        [Column("loaduser")]
        public string LoadUser { get; set; }

        [Column("upddate")]
        public DateTime? UpdDate { get; set; }

        [Column("upduser")]
        public string UpdUser { get; set; }
        
    }
}
