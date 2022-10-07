using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("extension")]
    public partial class Extension
    {
        public Extension()
        {
            IdPrjs = new HashSet<Projet>();
        }

        [Key]
        [Column("id_ext")]
        public int IdExt { get; set; }
        [Column("nom_ext")]
        [StringLength(50)]
        [Unicode(false)]
        public string? NomExt { get; set; }
        [Column("version_ext", TypeName = "decimal(6, 3)")]
        public decimal? VersionExt { get; set; }
        [Column("type_ext")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TypeExt { get; set; }
        [Column("debut_ext")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DebutExt { get; set; }
        [Column("info_ext")]
        [StringLength(500)]
        [Unicode(false)]
        public string? InfoExt { get; set; }
        [Column("id_lic")]
        public int? IdLic { get; set; }

        [ForeignKey("IdLic")]
        [InverseProperty("Extensions")]
        public virtual Licence? IdLicNavigation { get; set; }

        [ForeignKey("IdExt")]
        [InverseProperty("IdExts")]
        public virtual ICollection<Projet> IdPrjs { get; set; }
    }
}
