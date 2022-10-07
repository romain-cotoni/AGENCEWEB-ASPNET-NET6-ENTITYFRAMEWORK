using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("cms")]
    public partial class Cm
    {
        public Cm()
        {
            ModuleCms = new HashSet<ModuleCm>();
        }

        [Key]
        [Column("id_cms")]
        public int IdCms { get; set; }
        [Column("nom_cms")]
        [StringLength(50)]
        [Unicode(false)]
        public string NomCms { get; set; } = null!;
        [Column("version_cms", TypeName = "decimal(6, 3)")]
        public decimal? VersionCms { get; set; }
        [Column("type_cms")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TypeCms { get; set; }
        [Column("debut_cms")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DebutCms { get; set; }
        [Column("info_cms")]
        [StringLength(500)]
        [Unicode(false)]
        public string? InfoCms { get; set; }
        [Column("id_prj")]
        public int? IdPrj { get; set; }

        [ForeignKey("IdPrj")]
        [InverseProperty("Cms")]
        public virtual Projet? IdPrjNavigation { get; set; }
        [InverseProperty("IdCmsNavigation")]
        public virtual ICollection<ModuleCm> ModuleCms { get; set; }
    }
}
