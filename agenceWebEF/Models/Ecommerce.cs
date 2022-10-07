using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("ecommerce")]
    public partial class Ecommerce
    {
        public Ecommerce()
        {
            Connexions = new HashSet<Connexion>();
        }

        [Key]
        [Column("id_ecm")]
        public int IdEcm { get; set; }
        [Column("article_ecm")]
        [StringLength(50)]
        [Unicode(false)]
        public string? ArticleEcm { get; set; }
        [Column("nbArticle_ecm")]
        public short? NbArticleEcm { get; set; }
        [Column("vad_ecm")]
        [StringLength(50)]
        [Unicode(false)]
        public string? VadEcm { get; set; }
        [Column("typeTarifVad_ecm")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TypeTarifVadEcm { get; set; }
        [Column("fixeVad_ecm", TypeName = "decimal(8, 2)")]
        public decimal? FixeVadEcm { get; set; }
        [Column("pourcentVad_ecm", TypeName = "decimal(5, 2)")]
        public decimal? PourcentVadEcm { get; set; }
        [Column("restriction_ecm")]
        [StringLength(50)]
        [Unicode(false)]
        public string? RestrictionEcm { get; set; }
        [Column("info_ecm")]
        [StringLength(500)]
        [Unicode(false)]
        public string? InfoEcm { get; set; }
        [Column("id_prj")]
        public int? IdPrj { get; set; }

        [ForeignKey("IdPrj")]
        [InverseProperty("Ecommerces")]
        public virtual Projet? IdPrjNavigation { get; set; }
        [InverseProperty("IdEcmNavigation")]
        public virtual ICollection<Connexion> Connexions { get; set; }
    }
}
