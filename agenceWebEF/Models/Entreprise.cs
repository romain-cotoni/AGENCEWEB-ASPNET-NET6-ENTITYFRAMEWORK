using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("entreprise")]
    public partial class Entreprise
    {
        public Entreprise()
        {
            Coordonnees = new HashSet<Coordonnee>();
            Projets = new HashSet<Projet>();
            IdPrs = new HashSet<Personne>();
        }

        [Key]
        [Column("id_etp")]
        public int IdEtp { get; set; }

        [Column("nom_etp")]
        [StringLength(50)]
        [Unicode(false)]
        public string NomEtp { get; set; } = null!;

        [Column("siret_etp")]
        [StringLength(50)]
        [Unicode(false)]
        public string? SiretEtp { get; set; }
        [Column("activite_etp")]
        [StringLength(50)]
        [Unicode(false)]
        public string? ActiviteEtp { get; set; }

        [InverseProperty("IdEtpNavigation")]
        public virtual ICollection<Coordonnee> Coordonnees { get; set; }
        [InverseProperty("IdEtpNavigation")]
        public virtual ICollection<Projet> Projets { get; set; }

        [ForeignKey("IdEtp")]
        [InverseProperty("IdEtps")]
        public virtual ICollection<Personne> IdPrs { get; set; }
    }
}
