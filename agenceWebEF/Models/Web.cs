using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("web")]
    public partial class Web
    {
        [Key]
        [Column("id_web")]
        public int IdWeb { get; set; }
        [Column("contenu_web")]
        [StringLength(50)]
        [Unicode(false)]
        public string? ContenuWeb { get; set; }
        [Column("formMail_web")]
        [StringLength(50)]
        [Unicode(false)]
        public string? FormMailWeb { get; set; }
        [Column("restriction_web")]
        [StringLength(50)]
        [Unicode(false)]
        public string? RestrictionWeb { get; set; }
        [Column("responsive_web")]
        public bool? ResponsiveWeb { get; set; }
        [Column("malvoyant_web")]
        public bool? MalvoyantWeb { get; set; }
        [Column("daltonnien_web")]
        public bool? DaltonnienWeb { get; set; }
        [Column("aria_web")]
        [StringLength(500)]
        [Unicode(false)]
        public string? AriaWeb { get; set; }
        [Column("info_web")]
        [StringLength(500)]
        [Unicode(false)]
        public string? InfoWeb { get; set; }
        [Column("id_prj")]
        public int? IdPrj { get; set; }

        [ForeignKey("IdPrj")]
        [InverseProperty("Webs")]
        public virtual Projet? IdPrjNavigation { get; set; }
    }
}
