using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("droit")]
    public partial class Droit
    {
        public Droit()
        {
            Connexions = new HashSet<Connexion>();
        }

        [Key]
        [Column("id_drt")]
        public int IdDrt { get; set; }
        [Column("type_drt")]
        public byte TypeDrt { get; set; }

        [InverseProperty("IdDrtNavigation")]
        public virtual ICollection<Connexion> Connexions { get; set; }
    }
}
