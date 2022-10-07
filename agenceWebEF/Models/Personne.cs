using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("personne")]
    public partial class Personne
    {
        public Personne()
        {
            Coordonnees = new HashSet<Coordonnee>();
            IdEtps = new HashSet<Entreprise>();
        }

        [Key]
        [Column("id_prs")]
        public int IdPrs { get; set; }
        [Column("nom_prs")]
        [StringLength(50)]
        [Unicode(false)]
        public string NomPrs { get; set; } = null!;
        [Column("prenom_prs")]
        [StringLength(50)]
        [Unicode(false)]
        public string PrenomPrs { get; set; } = null!;
        [Column("fonction_prs")]
        [StringLength(50)]
        [Unicode(false)]
        public string? FonctionPrs { get; set; }
        [Column("id_con")]
        public int? IdCon { get; set; }

        [ForeignKey("IdCon")]
        [InverseProperty("Personnes")]
        public virtual Connexion? IdConNavigation { get; set; }
        [InverseProperty("IdPrsNavigation")]
        public virtual ICollection<Coordonnee> Coordonnees { get; set; }

        [ForeignKey("IdPrs")]
        [InverseProperty("IdPrs")]
        public virtual ICollection<Entreprise> IdEtps { get; set; }
    }
}
