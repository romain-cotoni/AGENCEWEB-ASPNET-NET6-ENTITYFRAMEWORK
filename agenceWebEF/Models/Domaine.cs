using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("domaine")]
    public partial class Domaine
    {
        [Key]
        [Column("id_dmn")]
        public int IdDmn { get; set; }
        [Column("nom_dmn")]
        [StringLength(50)]
        [Unicode(false)]
        public string NomDmn { get; set; } = null!;
        [Column("registraire_dmn")]
        [StringLength(50)]
        [Unicode(false)]
        public string RegistraireDmn { get; set; } = null!;
        [Column("debut_dmn")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DebutDmn { get; set; }
        [Column("fin_dmn")]
        [StringLength(50)]
        [Unicode(false)]
        public string? FinDmn { get; set; }
        [Column("tarif_dmn", TypeName = "decimal(8, 2)")]
        public decimal? TarifDmn { get; set; }
        [Column("info_dmn")]
        [StringLength(50)]
        [Unicode(false)]
        public string? InfoDmn { get; set; }
        [Column("id_prj")]
        public int? IdPrj { get; set; }

        [ForeignKey("IdPrj")]
        [InverseProperty("Domaines")]
        public virtual Projet? IdPrjNavigation { get; set; }
    }
}
