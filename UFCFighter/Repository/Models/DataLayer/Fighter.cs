using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models.DataLayer
{
    [Table("fighters")]
    public partial class Fighter
    {
        [Key]
        [Column("fid")]
        public int Fid { get; set; }
        [Column("name")]
        [StringLength(40)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [Column("nick")]
        [StringLength(40)]
        [Unicode(false)]
        public string? Nick { get; set; }
        [Column("birth_date", TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [Column("height", TypeName = "decimal(5, 0)")]
        public decimal? Height { get; set; }
        [Column("weight", TypeName = "decimal(6, 0)")]
        public decimal? Weight { get; set; }
        [Column("association")]
        [StringLength(40)]
        [Unicode(false)]
        public string? Association { get; set; }
        [Column("division")]
        [StringLength(40)]
        [Unicode(false)]
        public string? Division { get; set; }
        [Column("locality")]
        [StringLength(30)]
        [Unicode(false)]
        public string? Locality { get; set; }
        [Column("country")]
        [StringLength(30)]
        [Unicode(false)]
        public string? Country { get; set; }
        [Column("url")]
        [StringLength(300)]
        public string? Url { get; set; }
    }
}
