using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("os")]
    public partial class O
    {
        public O()
        {
            IdPrjs = new HashSet<Projet>();
        }

        [Key]
        [Column("id_os")]
        public int IdOs { get; set; }
        [Column("nom_os")]
        [StringLength(50)]
        [Unicode(false)]
        public string? NomOs { get; set; }
        [Column("version_os")]
        [StringLength(50)]
        [Unicode(false)]
        public string? VersionOs { get; set; }
        [Column("id_lic")]
        public int? IdLic { get; set; }

        [ForeignKey("IdLic")]
        [InverseProperty("Os")]
        public virtual Licence? IdLicNavigation { get; set; }

        [ForeignKey("IdOs")]
        [InverseProperty("IdOs")]
        public virtual ICollection<Projet> IdPrjs { get; set; }
    }
}
