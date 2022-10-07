using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("bd")]
    public partial class Bd
    {
        public Bd()
        {
            Connexions = new HashSet<Connexion>();
        }

        [Key]
        [Column("id_bd")]
        public int IdBd { get; set; }
        [Column("type_bd")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TypeBd { get; set; }
        [Column("nom_bd")]
        [StringLength(50)]
        [Unicode(false)]
        public string? NomBd { get; set; }
        [Column("typeDonnees_bd")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TypeDonneesBd { get; set; }
        [Column("donneesPrives_bd")]
        public bool? DonneesPrivesBd { get; set; }
        [Column("rgpd_bd")]
        public bool? RgpdBd { get; set; }
        [Column("info_bd")]
        [StringLength(500)]
        [Unicode(false)]
        public string? InfoBd { get; set; }
        [Column("id_lic")]
        public int? IdLic { get; set; }
        [Column("id_prj")]
        public int IdPrj { get; set; }

        [ForeignKey("IdLic")]
        [InverseProperty("Bds")]
        public virtual Licence? IdLicNavigation { get; set; }
        [ForeignKey("IdPrj")]
        [InverseProperty("Bds")]
        public virtual Projet IdPrjNavigation { get; set; } = null!;
        [InverseProperty("IdBdNavigation")]
        public virtual ICollection<Connexion> Connexions { get; set; }
    }
}
