using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace agenceWebEF.Models
{
    public partial class agencewebContext : IdentityDbContext<Utilisateur>
    {
        public agencewebContext()
        {
        }

        public agencewebContext(DbContextOptions<agencewebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bd> Bds { get; set; } = null!;
        public virtual DbSet<Cm> Cms { get; set; } = null!;
        public virtual DbSet<Connexion> Connexions { get; set; } = null!;
        public virtual DbSet<Coordonnee> Coordonnees { get; set; } = null!;
        public virtual DbSet<Developpement> Developpements { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<Domaine> Domaines { get; set; } = null!;
        public virtual DbSet<Droit> Droits { get; set; } = null!;
        public virtual DbSet<Ecommerce> Ecommerces { get; set; } = null!;
        public virtual DbSet<Entreprise> Entreprises { get; set; } = null!;
        public virtual DbSet<Extension> Extensions { get; set; } = null!;
        public virtual DbSet<Hebergement> Hebergements { get; set; } = null!;
        public virtual DbSet<Langage> Langages { get; set; } = null!;
        public virtual DbSet<Licence> Licences { get; set; } = null!;
        public virtual DbSet<Maintenance> Maintenances { get; set; } = null!;
        public virtual DbSet<ModuleCm> ModuleCms { get; set; } = null!;
        public virtual DbSet<O> Os { get; set; } = null!;
        public virtual DbSet<Page> Pages { get; set; } = null!;
        public virtual DbSet<Personne> Personnes { get; set; } = null!;
        public virtual DbSet<Projet> Projets { get; set; } = null!;
        public virtual DbSet<Referencement> Referencements { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<Web> Webs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bd>(entity =>
            {
                entity.HasKey(e => e.IdBd)
                    .HasName("PK__bd__00B7D116028F27CF");

                entity.HasOne(d => d.IdLicNavigation)
                    .WithMany(p => p.Bds)
                    .HasForeignKey(d => d.IdLic)
                    .HasConstraintName("FK__bd__id_lic__45F365D3");

                entity.HasOne(d => d.IdPrjNavigation)
                    .WithMany(p => p.Bds)
                    .HasForeignKey(d => d.IdPrj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bd__id_prj__46E78A0C");
            });

            modelBuilder.Entity<Cm>(entity =>
            {
                entity.HasKey(e => e.IdCms)
                    .HasName("PK__cms__D696612E9FC503F2");

                entity.HasOne(d => d.IdPrjNavigation)
                    .WithMany(p => p.Cms)
                    .HasForeignKey(d => d.IdPrj)
                    .HasConstraintName("FK__cms__id_prj__3C69FB99");
            });

            modelBuilder.Entity<Connexion>(entity =>
            {
                entity.HasKey(e => e.IdCon)
                    .HasName("PK__connexio__D696717654F99157");

                entity.HasOne(d => d.IdBdNavigation)
                    .WithMany(p => p.Connexions)
                    .HasForeignKey(d => d.IdBd)
                    .HasConstraintName("FK__connexion__id_bd__52593CB8");

                entity.HasOne(d => d.IdDrtNavigation)
                    .WithMany(p => p.Connexions)
                    .HasForeignKey(d => d.IdDrt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__connexion__id_dr__5441852A");

                entity.HasOne(d => d.IdEcmNavigation)
                    .WithMany(p => p.Connexions)
                    .HasForeignKey(d => d.IdEcm)
                    .HasConstraintName("FK__connexion__id_ec__534D60F1");
            });

            modelBuilder.Entity<Coordonnee>(entity =>
            {
                entity.HasKey(e => e.IdCrd)
                    .HasName("PK__coordonn__D69649DB7E622033");

                entity.HasOne(d => d.IdEtpNavigation)
                    .WithMany(p => p.Coordonnees)
                    .HasForeignKey(d => d.IdEtp)
                    .HasConstraintName("FK__coordonne__id_et__628FA481");

                entity.HasOne(d => d.IdPrsNavigation)
                    .WithMany(p => p.Coordonnees)
                    .HasForeignKey(d => d.IdPrs)
                    .HasConstraintName("FK__coordonne__id_pr__6383C8BA");
            });

            modelBuilder.Entity<Developpement>(entity =>
            {
                entity.HasKey(e => e.IdDev)
                    .HasName("PK__developp__D5EA6356EDCA74D0");

                entity.HasOne(d => d.IdPrjNavigation)
                    .WithMany(p => p.Developpements)
                    .HasForeignKey(d => d.IdPrj)
                    .HasConstraintName("FK__developpe__id_pr__571DF1D5");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.IdDoc)
                    .HasName("PK__document__D5EAB26C11DA2969");

                entity.HasOne(d => d.IdPrjNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.IdPrj)
                    .HasConstraintName("FK__document__id_prj__59FA5E80");
            });

            modelBuilder.Entity<Domaine>(entity =>
            {
                entity.HasKey(e => e.IdDmn)
                    .HasName("PK__domaine__D5EAA250D7727F93");

                entity.HasOne(d => d.IdPrjNavigation)
                    .WithMany(p => p.Domaines)
                    .HasForeignKey(d => d.IdPrj)
                    .HasConstraintName("FK__domaine__id_prj__4CA06362");
            });

            modelBuilder.Entity<Droit>(entity =>
            {
                entity.HasKey(e => e.IdDrt)
                    .HasName("PK__droit__D5EACDEF34C503BB");
            });

            modelBuilder.Entity<Ecommerce>(entity =>
            {
                entity.HasKey(e => e.IdEcm)
                    .HasName("PK__ecommerc__D52A45A233F26AC2");

                entity.HasOne(d => d.IdPrjNavigation)
                    .WithMany(p => p.Ecommerces)
                    .HasForeignKey(d => d.IdPrj)
                    .HasConstraintName("FK__ecommerce__id_pr__4F7CD00D");
            });

            modelBuilder.Entity<Entreprise>(entity =>
            {
                entity.HasKey(e => e.IdEtp)
                    .HasName("PK__entrepri__D52AEFD0F81E0DB1");
            });

            modelBuilder.Entity<Extension>(entity =>
            {
                entity.HasKey(e => e.IdExt)
                    .HasName("PK__extensio__D52A8F51B8C61F01");

                entity.HasOne(d => d.IdLicNavigation)
                    .WithMany(p => p.Extensions)
                    .HasForeignKey(d => d.IdLic)
                    .HasConstraintName("FK__extension__id_li__4316F928");
            });

            modelBuilder.Entity<Hebergement>(entity =>
            {
                entity.HasKey(e => e.IdHeb)
                    .HasName("PK__hebergem__D6EA62A1D0C1E418");

                entity.HasOne(d => d.IdPrjNavigation)
                    .WithMany(p => p.Hebergements)
                    .HasForeignKey(d => d.IdPrj)
                    .HasConstraintName("FK__hebergeme__id_pr__49C3F6B7");
            });

            modelBuilder.Entity<Langage>(entity =>
            {
                entity.HasKey(e => e.IdLg)
                    .HasName("PK__langage__014883FEEA5557C5");
            });

            modelBuilder.Entity<Licence>(entity =>
            {
                entity.HasKey(e => e.IdLic)
                    .HasName("PK__licence__6CC822B3B7E3B77C");
            });

            modelBuilder.Entity<Maintenance>(entity =>
            {
                entity.HasKey(e => e.IdMtn)
                    .HasName("PK__maintena__6C898B5576B15EC2");
            });

            modelBuilder.Entity<ModuleCm>(entity =>
            {
                entity.HasKey(e => e.IdMdl)
                    .HasName("PK__moduleCm__6C8A0CDF396AE973");

                entity.HasOne(d => d.IdCmsNavigation)
                    .WithMany(p => p.ModuleCms)
                    .HasForeignKey(d => d.IdCms)
                    .HasConstraintName("FK__moduleCms__id_cm__403A8C7D");

                entity.HasOne(d => d.IdLicNavigation)
                    .WithMany(p => p.ModuleCms)
                    .HasForeignKey(d => d.IdLic)
                    .HasConstraintName("FK__moduleCms__id_li__3F466844");
            });

            modelBuilder.Entity<O>(entity =>
            {
                entity.HasKey(e => e.IdOs)
                    .HasName("PK__os__0148BB697645A839");

                entity.HasOne(d => d.IdLicNavigation)
                    .WithMany(p => p.Os)
                    .HasForeignKey(d => d.IdLic)
                    .HasConstraintName("FK__os__id_lic__286302EC");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.HasKey(e => e.IdPg)
                    .HasName("PK__page__0148A345C2087800");

                entity.HasOne(d => d.IdRefNavigation)
                    .WithMany(p => p.Pages)
                    .HasForeignKey(d => d.IdRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__page__id_ref__398D8EEE");
            });

            modelBuilder.Entity<Personne>(entity =>
            {
                entity.HasKey(e => e.IdPrs)
                    .HasName("PK__personne__6FC9A8683CB0E41F");

                entity.HasOne(d => d.IdConNavigation)
                    .WithMany(p => p.Personnes)
                    .HasForeignKey(d => d.IdCon)
                    .HasConstraintName("FK__personne__id_con__5FB337D6");

                entity.HasMany(d => d.IdEtps)
                    .WithMany(p => p.IdPrs)
                    .UsingEntity<Dictionary<string, object>>(
                        "Representer",
                        l => l.HasOne<Entreprise>().WithMany().HasForeignKey("IdEtp").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__represent__id_et__76969D2E"),
                        r => r.HasOne<Personne>().WithMany().HasForeignKey("IdPrs").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__represent__id_pr__75A278F5"),
                        j =>
                        {
                            j.HasKey("IdPrs", "IdEtp").HasName("PK__represen__729B0695D0303249");

                            j.ToTable("representer");

                            j.IndexerProperty<int>("IdPrs").HasColumnName("id_prs");

                            j.IndexerProperty<int>("IdEtp").HasColumnName("id_etp");
                        });
            });

            modelBuilder.Entity<Projet>(entity =>
            {
                entity.HasKey(e => e.IdPrj)
                    .HasName("PK__projet__6FC9A853C66D09F2");

                entity.HasOne(d => d.IdEtpNavigation)
                    .WithMany(p => p.Projets)
                    .HasForeignKey(d => d.IdEtp)
                    .HasConstraintName("FK__projet__id_etp__33D4B598");

                entity.HasMany(d => d.IdExts)
                    .WithMany(p => p.IdPrjs)
                    .UsingEntity<Dictionary<string, object>>(
                        "Etendre",
                        l => l.HasOne<Extension>().WithMany().HasForeignKey("IdExt").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__etendre__id_ext__6754599E"),
                        r => r.HasOne<Projet>().WithMany().HasForeignKey("IdPrj").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__etendre__id_prj__66603565"),
                        j =>
                        {
                            j.HasKey("IdPrj", "IdExt").HasName("PK__etendre__629B00A63654450A");

                            j.ToTable("etendre");

                            j.IndexerProperty<int>("IdPrj").HasColumnName("id_prj");

                            j.IndexerProperty<int>("IdExt").HasColumnName("id_ext");
                        });

                entity.HasMany(d => d.IdLgs)
                    .WithMany(p => p.IdPrjs)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjetLangage",
                        l => l.HasOne<Langage>().WithMany().HasForeignKey("IdLg").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__projet_la__id_lg__6B24EA82"),
                        r => r.HasOne<Projet>().WithMany().HasForeignKey("IdPrj").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__projet_la__id_pr__6A30C649"),
                        j =>
                        {
                            j.HasKey("IdPrj", "IdLg").HasName("PK__projet_l__9FDD206C5B865E76");

                            j.ToTable("projet_langage");

                            j.IndexerProperty<int>("IdPrj").HasColumnName("id_prj");

                            j.IndexerProperty<int>("IdLg").HasColumnName("id_lg");
                        });

                entity.HasMany(d => d.IdMtns)
                    .WithMany(p => p.IdPrjs)
                    .UsingEntity<Dictionary<string, object>>(
                        "Maintenir",
                        l => l.HasOne<Maintenance>().WithMany().HasForeignKey("IdMtn").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__maintenir__id_mt__7A672E12"),
                        r => r.HasOne<Projet>().WithMany().HasForeignKey("IdPrj").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__maintenir__id_pr__797309D9"),
                        j =>
                        {
                            j.HasKey("IdPrj", "IdMtn").HasName("PK__mainteni__290130E6B689B375");

                            j.ToTable("maintenir");

                            j.IndexerProperty<int>("IdPrj").HasColumnName("id_prj");

                            j.IndexerProperty<int>("IdMtn").HasColumnName("id_mtn");
                        });

                entity.HasMany(d => d.IdOs)
                    .WithMany(p => p.IdPrjs)
                    .UsingEntity<Dictionary<string, object>>(
                        "Compiler",
                        l => l.HasOne<O>().WithMany().HasForeignKey("IdOs").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__compiler__id_os__6EF57B66"),
                        r => r.HasOne<Projet>().WithMany().HasForeignKey("IdPrj").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__compiler__id_prj__6E01572D"),
                        j =>
                        {
                            j.HasKey("IdPrj", "IdOs").HasName("PK__compiler__EFDD23E5442BDA82");

                            j.ToTable("compiler");

                            j.IndexerProperty<int>("IdPrj").HasColumnName("id_prj");

                            j.IndexerProperty<int>("IdOs").HasColumnName("id_os");
                        });

                entity.HasMany(d => d.IdStrs)
                    .WithMany(p => p.IdPrjs)
                    .UsingEntity<Dictionary<string, object>>(
                        "Telecharger",
                        l => l.HasOne<Store>().WithMany().HasForeignKey("IdStr").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__telecharg__id_st__72C60C4A"),
                        r => r.HasOne<Projet>().WithMany().HasForeignKey("IdPrj").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__telecharg__id_pr__71D1E811"),
                        j =>
                        {
                            j.HasKey("IdPrj", "IdStr").HasName("PK__telechar__091F65E39ACE690E");

                            j.ToTable("telecharger");

                            j.IndexerProperty<int>("IdPrj").HasColumnName("id_prj");

                            j.IndexerProperty<int>("IdStr").HasColumnName("id_str");
                        });
            });

            modelBuilder.Entity<Referencement>(entity =>
            {
                entity.HasKey(e => e.IdRef)
                    .HasName("PK__referenc__6ABE6F0D1146F1FF");

                entity.HasOne(d => d.IdPrjNavigation)
                    .WithMany(p => p.Referencements)
                    .HasForeignKey(d => d.IdPrj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__reference__id_pr__36B12243");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.IdStr)
                    .HasName("PK__store__6D6CDB07DD42524B");

                entity.HasOne(d => d.IdLicNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.IdLic)
                    .HasConstraintName("FK__store__id_lic__2B3F6F97");
            });

            modelBuilder.Entity<Web>(entity =>
            {
                entity.HasKey(e => e.IdWeb)
                    .HasName("PK__web__6C6DA99206071ABD");

                entity.HasOne(d => d.IdPrjNavigation)
                    .WithMany(p => p.Webs)
                    .HasForeignKey(d => d.IdPrj)
                    .HasConstraintName("FK__web__id_prj__5CD6CB2B");
            });

            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
