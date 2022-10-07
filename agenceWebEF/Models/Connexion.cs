using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("connexion")]
    public partial class Connexion
    {
        public Connexion()
        {
            Personnes = new HashSet<Personne>();
        }

        [Key]
        [Column("id_con")]
        public int IdCon { get; set; }
        [Column("user_con")]
        [StringLength(50)]
        [Unicode(false)]
        public string UserCon { get; set; } = null!;
        [Column("pass_con")]
        [StringLength(50)]
        [Unicode(false)]
        public string PassCon { get; set; } = null!;
        [Column("id_bd")]
        public int? IdBd { get; set; }
        [Column("id_ecm")]
        public int? IdEcm { get; set; }
        [Column("id_drt")]
        public int IdDrt { get; set; }

        [ForeignKey("IdBd")]
        [InverseProperty("Connexions")]
        public virtual Bd? IdBdNavigation { get; set; }
        [ForeignKey("IdDrt")]
        [InverseProperty("Connexions")]
        public virtual Droit IdDrtNavigation { get; set; } = null!;
        [ForeignKey("IdEcm")]
        [InverseProperty("Connexions")]
        public virtual Ecommerce? IdEcmNavigation { get; set; }
        [InverseProperty("IdConNavigation")]
        public virtual ICollection<Personne> Personnes { get; set; }
    }
}
