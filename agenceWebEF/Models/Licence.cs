using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("licence")]
    public partial class Licence
    {
        public Licence()
        {
            Bds = new HashSet<Bd>();
            Extensions = new HashSet<Extension>();
            ModuleCms = new HashSet<ModuleCm>();
            Os = new HashSet<O>();
            Stores = new HashSet<Store>();
        }

        [Key]
        [Column("id_lic")]
        public int IdLic { get; set; }
        [Column("nom_lic")]
        [StringLength(50)]
        [Unicode(false)]
        public string? NomLic { get; set; }
        [Column("type_lic")]
        public byte? TypeLic { get; set; }
        [Column("typeTarif_lic")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TypeTarifLic { get; set; }
        [Column("tarif_lic", TypeName = "decimal(8, 2)")]
        public decimal? TarifLic { get; set; }
        [Column("duree_lic")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DureeLic { get; set; }

        [InverseProperty("IdLicNavigation")]
        public virtual ICollection<Bd> Bds { get; set; }
        [InverseProperty("IdLicNavigation")]
        public virtual ICollection<Extension> Extensions { get; set; }
        [InverseProperty("IdLicNavigation")]
        public virtual ICollection<ModuleCm> ModuleCms { get; set; }
        [InverseProperty("IdLicNavigation")]
        public virtual ICollection<O> Os { get; set; }
        [InverseProperty("IdLicNavigation")]
        public virtual ICollection<Store> Stores { get; set; }
    }
}
