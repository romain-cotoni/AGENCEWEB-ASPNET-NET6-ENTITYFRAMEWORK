using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("store")]
    public partial class Store
    {
        public Store()
        {
            IdPrjs = new HashSet<Projet>();
        }

        [Key]
        [Column("id_str")]
        public int IdStr { get; set; }
        [Column("nom_str")]
        [StringLength(50)]
        [Unicode(false)]
        public string? NomStr { get; set; }
        [Column("id_lic")]
        public int? IdLic { get; set; }

        [ForeignKey("IdLic")]
        [InverseProperty("Stores")]
        public virtual Licence? IdLicNavigation { get; set; }

        [ForeignKey("IdStr")]
        [InverseProperty("IdStrs")]
        public virtual ICollection<Projet> IdPrjs { get; set; }
    }
}
