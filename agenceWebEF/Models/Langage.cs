using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("langage")]
    public partial class Langage
    {
        public Langage()
        {
            IdPrjs = new HashSet<Projet>();
        }

        [Key]
        [Column("id_lg")]
        public int IdLg { get; set; }
        [Column("nom_lg")]
        [StringLength(50)]
        [Unicode(false)]
        public string? NomLg { get; set; }
        [Column("version_lg", TypeName = "decimal(6, 3)")]
        public decimal? VersionLg { get; set; }

        [ForeignKey("IdLg")]
        [InverseProperty("IdLgs")]
        public virtual ICollection<Projet> IdPrjs { get; set; }
    }
}
