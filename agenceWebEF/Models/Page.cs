using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("page")]
    public partial class Page
    {
        [Key]
        [Column("id_pg")]
        public int IdPg { get; set; }
        [Column("nom_pg")]
        [StringLength(50)]
        [Unicode(false)]
        public string? NomPg { get; set; }
        [Column("lien_pg")]
        [StringLength(100)]
        [Unicode(false)]
        public string? LienPg { get; set; }
        [Column("visite_pg")]
        public int? VisitePg { get; set; }
        [Column("adwords_pg")]
        [StringLength(500)]
        [Unicode(false)]
        public string? AdwordsPg { get; set; }
        [Column("id_ref")]
        public int IdRef { get; set; }

        [ForeignKey("IdRef")]
        [InverseProperty("Pages")]
        public virtual Referencement IdRefNavigation { get; set; } = null!;
    }
}
