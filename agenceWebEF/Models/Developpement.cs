using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("developpement")]
    public partial class Developpement
    {
        [Key]
        [Column("id_dev")]
        public int IdDev { get; set; }
        [Column("etape_dev")]
        public short EtapeDev { get; set; }
        [Column("label_dev")]
        [StringLength(50)]
        [Unicode(false)]
        public string? LabelDev { get; set; }
        [Column("employe_dev")]
        [StringLength(50)]
        [Unicode(false)]
        public string? EmployeDev { get; set; }
        [Column("debut_dev")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DebutDev { get; set; }
        [Column("fin_dev")]
        [StringLength(50)]
        [Unicode(false)]
        public string? FinDev { get; set; }
        [Column("descrip_dev")]
        [StringLength(500)]
        [Unicode(false)]
        public string? DescripDev { get; set; }
        [Column("info_dev")]
        [StringLength(500)]
        [Unicode(false)]
        public string? InfoDev { get; set; }
        [Column("comment_dev")]
        [StringLength(500)]
        [Unicode(false)]
        public string? CommentDev { get; set; }
        [Column("id_prj")]
        public int? IdPrj { get; set; }

        [ForeignKey("IdPrj")]
        [InverseProperty("Developpements")]
        public virtual Projet? IdPrjNavigation { get; set; }
    }
}
