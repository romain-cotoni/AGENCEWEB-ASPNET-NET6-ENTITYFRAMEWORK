using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("moduleCms")]
    public partial class ModuleCm
    {
        [Key]
        [Column("id_mdl")]
        public int IdMdl { get; set; }
        [Column("nom_mdl")]
        [StringLength(50)]
        [Unicode(false)]
        public string? NomMdl { get; set; }
        [Column("version_mdl", TypeName = "decimal(6, 3)")]
        public decimal? VersionMdl { get; set; }
        [Column("type_module")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TypeModule { get; set; }
        [Column("debut_mdl")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DebutMdl { get; set; }
        [Column("info_mdl")]
        [StringLength(500)]
        [Unicode(false)]
        public string? InfoMdl { get; set; }
        [Column("id_lic")]
        public int? IdLic { get; set; }
        [Column("id_cms")]
        public int? IdCms { get; set; }

        [ForeignKey("IdCms")]
        [InverseProperty("ModuleCms")]
        public virtual Cm? IdCmsNavigation { get; set; }
        [ForeignKey("IdLic")]
        [InverseProperty("ModuleCms")]
        public virtual Licence? IdLicNavigation { get; set; }
    }
}
