using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("referencement")]
    public partial class Referencement
    {
        public Referencement()
        {
            Pages = new HashSet<Page>();
        }

        [Key]
        [Column("id_ref")]
        public int IdRef { get; set; }
        [Column("nom_ref")]
        [StringLength(50)]
        [Unicode(false)]
        public string? NomRef { get; set; }
        [Column("position_ref")]
        public byte? PositionRef { get; set; }
        [Column("visite_ref")]
        public int? VisiteRef { get; set; }
        [Column("adwords_ref")]
        [StringLength(500)]
        [Unicode(false)]
        public string? AdwordsRef { get; set; }
        [Column("fin_ref")]
        [StringLength(50)]
        [Unicode(false)]
        public string? FinRef { get; set; }
        [Column("tarif_ref", TypeName = "decimal(8, 2)")]
        public decimal? TarifRef { get; set; }
        [Column("typeTarif")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TypeTarif { get; set; }
        [Column("debut_ref")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DebutRef { get; set; }
        [Column("info_ref")]
        [StringLength(500)]
        [Unicode(false)]
        public string? InfoRef { get; set; }
        [Column("id_prj")]
        public int IdPrj { get; set; }

        [ForeignKey("IdPrj")]
        [InverseProperty("Referencements")]
        public virtual Projet IdPrjNavigation { get; set; } = null!;
        [InverseProperty("IdRefNavigation")]
        public virtual ICollection<Page> Pages { get; set; }
    }
}
