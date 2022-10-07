using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("maintenance")]
    public partial class Maintenance
    {
        public Maintenance()
        {
            IdPrjs = new HashSet<Projet>();
        }

        [Key]
        [Column("id_mtn")]
        public int IdMtn { get; set; }
        [Column("label_mtn")]
        [StringLength(50)]
        [Unicode(false)]
        public string? LabelMtn { get; set; }
        [Column("type_mtn")]
        [StringLength(50)]
        [Unicode(false)]
        public string TypeMtn { get; set; } = null!;
        [Column("employe_mtn")]
        [StringLength(50)]
        [Unicode(false)]
        public string? EmployeMtn { get; set; }
        [Column("descrip_mtn")]
        [StringLength(500)]
        [Unicode(false)]
        public string? DescripMtn { get; set; }
        [Column("info_mtn")]
        [StringLength(50)]
        [Unicode(false)]
        public string? InfoMtn { get; set; }
        [Column("tarif_mtn")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TarifMtn { get; set; }
        [Column("typeTarif_mtn")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TypeTarifMtn { get; set; }
        [Column("debut_mtn")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DebutMtn { get; set; }
        [Column("fin_mtn")]
        [StringLength(50)]
        [Unicode(false)]
        public string? FinMtn { get; set; }

        [ForeignKey("IdMtn")]
        [InverseProperty("IdMtns")]
        public virtual ICollection<Projet> IdPrjs { get; set; }
    }
}
