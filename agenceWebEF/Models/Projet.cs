using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace agenceWebEF.Models
{
    [Table("projet")]
    public partial class Projet
    {
        public Projet()
        {
            Bds = new HashSet<Bd>();
            Cms = new HashSet<Cm>();
            Developpements = new HashSet<Developpement>();
            Documents = new HashSet<Document>();
            Domaines = new HashSet<Domaine>();
            Ecommerces = new HashSet<Ecommerce>();
            Hebergements = new HashSet<Hebergement>();
            Referencements = new HashSet<Referencement>();
            Webs = new HashSet<Web>();
            IdExts = new HashSet<Extension>();
            IdLgs = new HashSet<Langage>();
            IdMtns = new HashSet<Maintenance>();
            IdOs = new HashSet<O>();
            IdStrs = new HashSet<Store>();
        }

        [Key]
        [Column("id_prj")]
        [Display(Name = "Id")]
        public int IdPrj { get; set; }

        [Column("nom_prj")]
        [StringLength(50)]
        [Unicode(false)]
        [Display(Name = "Nom")]
        public string NomPrj { get; set; } = null!;
        
        [Column("type_prj")]
        [StringLength(50)]
        [Unicode(false)]
        [Display(Name = "Type de projet")]
        public string? TypePrj { get; set; }

        [Column("typeTarif_prj")]
        [StringLength(50)]
        [Unicode(false)]
        [Display(Name = "Type de tarif")]
        public string? TypeTarifPrj { get; set; }

        [Display(Name = "Tarif fixe")]
        [Column("tFixe_prj", TypeName = "decimal(10, 2)")]
        public decimal? TFixePrj { get; set; }

        [Display(Name = "Nombre d'heures")]
        [Column("nbHeure_prj")]
        public int? NbHeurePrj { get; set; }

        [Display(Name = "Tarif horaire")]
        [Column("tHoraire_prj", TypeName = "decimal(8, 2)")]
        public decimal? THorairePrj { get; set; }

        [Display(Name = "Date de début")]
        [Column("debut_prj")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DebutPrj { get; set; }

        [Display(Name = "Date de fin")]
        [Column("fin_prj")]
        [StringLength(50)]
        [Unicode(false)]
        public string? FinPrj { get; set; }

        [Display(Name = "Description")]
        [Column("descrip_prj")]
        [StringLength(500)]
        [Unicode(false)]
        public string? DescripPrj { get; set; }

        [Display(Name = "Information")]
        [Column("info_prj")]
        [StringLength(500)]
        [Unicode(false)]
        public string? InfoPrj { get; set; }

        [Column("id_etp")]
        [Display(Name = "Identifiant")]
        public int? IdEtp { get; set; }

        [Display(Name = "Id entreprise")]
        [ForeignKey("IdEtp")]
        [InverseProperty("Projets")]
        public virtual Entreprise? IdEtpNavigation { get; set; }

        [InverseProperty("IdPrjNavigation")]
        public virtual ICollection<Bd> Bds { get; set; }
        
        [InverseProperty("IdPrjNavigation")]
        public virtual ICollection<Cm> Cms { get; set; }
        
        [InverseProperty("IdPrjNavigation")]
        public virtual ICollection<Developpement> Developpements { get; set; }
        
        [InverseProperty("IdPrjNavigation")]
        public virtual ICollection<Document> Documents { get; set; }
        
        [InverseProperty("IdPrjNavigation")]
        public virtual ICollection<Domaine> Domaines { get; set; }
        
        [InverseProperty("IdPrjNavigation")]
        public virtual ICollection<Ecommerce> Ecommerces { get; set; }
        
        [InverseProperty("IdPrjNavigation")]
        public virtual ICollection<Hebergement> Hebergements { get; set; }
        
        [InverseProperty("IdPrjNavigation")]
        public virtual ICollection<Referencement> Referencements { get; set; }
        
        [InverseProperty("IdPrjNavigation")]
        public virtual ICollection<Web> Webs { get; set; }

        [ForeignKey("IdPrj")]
        [InverseProperty("IdPrjs")]
        public virtual ICollection<Extension> IdExts { get; set; }
        
        [ForeignKey("IdPrj")]
        [InverseProperty("IdPrjs")]
        public virtual ICollection<Langage> IdLgs { get; set; }
        
        [ForeignKey("IdPrj")]
        [InverseProperty("IdPrjs")]
        public virtual ICollection<Maintenance> IdMtns { get; set; }
        
        [ForeignKey("IdPrj")]
        [InverseProperty("IdPrjs")]
        public virtual ICollection<O> IdOs { get; set; }
        
        [ForeignKey("IdPrj")]
        [InverseProperty("IdPrjs")]
        public virtual ICollection<Store> IdStrs { get; set; }
    }
}
