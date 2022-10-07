using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("hebergement")]
    public partial class Hebergement
    {
        [Key]
        [Column("id_heb")]
        public int IdHeb { get; set; }
        [Column("nom_heb")]
        [StringLength(50)]
        [Unicode(false)]
        public string? NomHeb { get; set; }
        [Column("type_heb")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TypeHeb { get; set; }
        [Column("debut_heb")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DebutHeb { get; set; }
        [Column("fin_heb")]
        [StringLength(50)]
        [Unicode(false)]
        public string? FinHeb { get; set; }
        [Column("tarif_heb")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TarifHeb { get; set; }
        [Column("info_heb")]
        [StringLength(500)]
        [Unicode(false)]
        public string? InfoHeb { get; set; }
        [Column("id_prj")]
        public int? IdPrj { get; set; }

        [ForeignKey("IdPrj")]
        [InverseProperty("Hebergements")]
        public virtual Projet? IdPrjNavigation { get; set; }
    }
}
