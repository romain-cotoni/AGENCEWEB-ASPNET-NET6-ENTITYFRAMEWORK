using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("coordonnees")]
    public partial class Coordonnee
    {
        [Key]
        [Column("id_crd")]
        public int IdCrd { get; set; }
        [Column("tel_crd")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TelCrd { get; set; }
        [Column("email_crd")]
        [StringLength(350)]
        [Unicode(false)]
        public string? EmailCrd { get; set; }
        [Column("adresse_crd")]
        [StringLength(250)]
        [Unicode(false)]
        public string? AdresseCrd { get; set; }
        [Column("adresse2_crd")]
        [StringLength(250)]
        [Unicode(false)]
        public string? Adresse2Crd { get; set; }
        [Column("postal_crd")]
        [StringLength(50)]
        [Unicode(false)]
        public string? PostalCrd { get; set; }
        [Column("ville_crd")]
        [StringLength(50)]
        [Unicode(false)]
        public string? VilleCrd { get; set; }
        [Column("pays_crd")]
        [StringLength(50)]
        [Unicode(false)]
        public string? PaysCrd { get; set; }
        [Column("id_etp")]
        public int? IdEtp { get; set; }
        [Column("id_prs")]
        public int? IdPrs { get; set; }

        [ForeignKey("IdEtp")]
        [InverseProperty("Coordonnees")]
        public virtual Entreprise? IdEtpNavigation { get; set; }
        [ForeignKey("IdPrs")]
        [InverseProperty("Coordonnees")]
        public virtual Personne? IdPrsNavigation { get; set; }
    }
}
