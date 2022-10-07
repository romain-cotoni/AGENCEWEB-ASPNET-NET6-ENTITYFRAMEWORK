using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("document")]
    public partial class Document
    {
        [Key]
        [Column("id_doc")]
        public int IdDoc { get; set; }
        [Column("label_doc")]
        [StringLength(50)]
        [Unicode(false)]
        public string? LabelDoc { get; set; }
        [Column("lien_doc")]
        [StringLength(50)]
        [Unicode(false)]
        public string? LienDoc { get; set; }
        [Column("cat_doc")]
        [StringLength(50)]
        [Unicode(false)]
        public string? CatDoc { get; set; }
        [Column("id_prj")]
        public int? IdPrj { get; set; }

        [ForeignKey("IdPrj")]
        [InverseProperty("Documents")]
        public virtual Projet? IdPrjNavigation { get; set; }
    }
}
