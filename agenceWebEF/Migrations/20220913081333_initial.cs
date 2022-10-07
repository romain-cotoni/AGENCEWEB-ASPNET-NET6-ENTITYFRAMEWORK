using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agenceWebEF.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "droit",
                columns: table => new
                {
                    id_drt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_drt = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__droit__D5EACDEF34C503BB", x => x.id_drt);
                });

            migrationBuilder.CreateTable(
                name: "entreprise",
                columns: table => new
                {
                    id_etp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_etp = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    siret_etp = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    activite_etp = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__entrepri__D52AEFD0F81E0DB1", x => x.id_etp);
                });

            migrationBuilder.CreateTable(
                name: "EntreprisePersonne",
                columns: table => new
                {
                    IdEtp = table.Column<int>(type: "int", nullable: false),
                    IdPrs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntreprisePersonne", x => new { x.IdEtp, x.IdPrs });
                });

            migrationBuilder.CreateTable(
                name: "ExtensionProjet",
                columns: table => new
                {
                    IdExt = table.Column<int>(type: "int", nullable: false),
                    IdPrj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtensionProjet", x => new { x.IdExt, x.IdPrj });
                });

            migrationBuilder.CreateTable(
                name: "langage",
                columns: table => new
                {
                    id_lg = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_lg = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    version_lg = table.Column<decimal>(type: "decimal(6,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__langage__014883FEEA5557C5", x => x.id_lg);
                });

            migrationBuilder.CreateTable(
                name: "LangageProjet",
                columns: table => new
                {
                    IdLg = table.Column<int>(type: "int", nullable: false),
                    IdPrj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LangageProjet", x => new { x.IdLg, x.IdPrj });
                });

            migrationBuilder.CreateTable(
                name: "licence",
                columns: table => new
                {
                    id_lic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_lic = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    type_lic = table.Column<byte>(type: "tinyint", nullable: true),
                    typeTarif_lic = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    tarif_lic = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    duree_lic = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__licence__6CC822B3B7E3B77C", x => x.id_lic);
                });

            migrationBuilder.CreateTable(
                name: "maintenance",
                columns: table => new
                {
                    id_mtn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    label_mtn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    type_mtn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    employe_mtn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    descrip_mtn = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    info_mtn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    tarif_mtn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    typeTarif_mtn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    debut_mtn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fin_mtn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__maintena__6C898B5576B15EC2", x => x.id_mtn);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceProjet",
                columns: table => new
                {
                    IdMtn = table.Column<int>(type: "int", nullable: false),
                    IdPrj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceProjet", x => new { x.IdMtn, x.IdPrj });
                });

            migrationBuilder.CreateTable(
                name: "OProjet",
                columns: table => new
                {
                    IdOs = table.Column<int>(type: "int", nullable: false),
                    IdPrj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OProjet", x => new { x.IdOs, x.IdPrj });
                });

            migrationBuilder.CreateTable(
                name: "ProjetStore",
                columns: table => new
                {
                    IdPrj = table.Column<int>(type: "int", nullable: false),
                    IdStr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetStore", x => new { x.IdPrj, x.IdStr });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projet",
                columns: table => new
                {
                    id_prj = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_prj = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    type_prj = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    typeTarif_prj = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    tFixe_prj = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    nbHeure_prj = table.Column<int>(type: "int", nullable: true),
                    tHoraire_prj = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    debut_prj = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fin_prj = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    descrip_prj = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    info_prj = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    id_etp = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__projet__6FC9A853C66D09F2", x => x.id_prj);
                    table.ForeignKey(
                        name: "FK__projet__id_etp__33D4B598",
                        column: x => x.id_etp,
                        principalTable: "entreprise",
                        principalColumn: "id_etp");
                });

            migrationBuilder.CreateTable(
                name: "extension",
                columns: table => new
                {
                    id_ext = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_ext = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    version_ext = table.Column<decimal>(type: "decimal(6,3)", nullable: true),
                    type_ext = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    debut_ext = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    info_ext = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    id_lic = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__extensio__D52A8F51B8C61F01", x => x.id_ext);
                    table.ForeignKey(
                        name: "FK__extension__id_li__4316F928",
                        column: x => x.id_lic,
                        principalTable: "licence",
                        principalColumn: "id_lic");
                });

            migrationBuilder.CreateTable(
                name: "os",
                columns: table => new
                {
                    id_os = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_os = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    version_os = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    id_lic = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__os__0148BB697645A839", x => x.id_os);
                    table.ForeignKey(
                        name: "FK__os__id_lic__286302EC",
                        column: x => x.id_lic,
                        principalTable: "licence",
                        principalColumn: "id_lic");
                });

            migrationBuilder.CreateTable(
                name: "store",
                columns: table => new
                {
                    id_str = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_str = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    id_lic = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__store__6D6CDB07DD42524B", x => x.id_str);
                    table.ForeignKey(
                        name: "FK__store__id_lic__2B3F6F97",
                        column: x => x.id_lic,
                        principalTable: "licence",
                        principalColumn: "id_lic");
                });

            migrationBuilder.CreateTable(
                name: "bd",
                columns: table => new
                {
                    id_bd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_bd = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    nom_bd = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    typeDonnees_bd = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    donneesPrives_bd = table.Column<bool>(type: "bit", nullable: true),
                    rgpd_bd = table.Column<bool>(type: "bit", nullable: true),
                    info_bd = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    id_lic = table.Column<int>(type: "int", nullable: true),
                    id_prj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__bd__00B7D116028F27CF", x => x.id_bd);
                    table.ForeignKey(
                        name: "FK__bd__id_lic__45F365D3",
                        column: x => x.id_lic,
                        principalTable: "licence",
                        principalColumn: "id_lic");
                    table.ForeignKey(
                        name: "FK__bd__id_prj__46E78A0C",
                        column: x => x.id_prj,
                        principalTable: "projet",
                        principalColumn: "id_prj");
                });

            migrationBuilder.CreateTable(
                name: "cms",
                columns: table => new
                {
                    id_cms = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_cms = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    version_cms = table.Column<decimal>(type: "decimal(6,3)", nullable: true),
                    type_cms = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    debut_cms = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    info_cms = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    id_prj = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cms__D696612E9FC503F2", x => x.id_cms);
                    table.ForeignKey(
                        name: "FK__cms__id_prj__3C69FB99",
                        column: x => x.id_prj,
                        principalTable: "projet",
                        principalColumn: "id_prj");
                });

            migrationBuilder.CreateTable(
                name: "developpement",
                columns: table => new
                {
                    id_dev = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    etape_dev = table.Column<short>(type: "smallint", nullable: false),
                    label_dev = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    employe_dev = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    debut_dev = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fin_dev = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    descrip_dev = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    info_dev = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    comment_dev = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    id_prj = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__developp__D5EA6356EDCA74D0", x => x.id_dev);
                    table.ForeignKey(
                        name: "FK__developpe__id_pr__571DF1D5",
                        column: x => x.id_prj,
                        principalTable: "projet",
                        principalColumn: "id_prj");
                });

            migrationBuilder.CreateTable(
                name: "document",
                columns: table => new
                {
                    id_doc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    label_doc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    lien_doc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    cat_doc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    id_prj = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__document__D5EAB26C11DA2969", x => x.id_doc);
                    table.ForeignKey(
                        name: "FK__document__id_prj__59FA5E80",
                        column: x => x.id_prj,
                        principalTable: "projet",
                        principalColumn: "id_prj");
                });

            migrationBuilder.CreateTable(
                name: "domaine",
                columns: table => new
                {
                    id_dmn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_dmn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    registraire_dmn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    debut_dmn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fin_dmn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    tarif_dmn = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    info_dmn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    id_prj = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__domaine__D5EAA250D7727F93", x => x.id_dmn);
                    table.ForeignKey(
                        name: "FK__domaine__id_prj__4CA06362",
                        column: x => x.id_prj,
                        principalTable: "projet",
                        principalColumn: "id_prj");
                });

            migrationBuilder.CreateTable(
                name: "ecommerce",
                columns: table => new
                {
                    id_ecm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    article_ecm = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    nbArticle_ecm = table.Column<short>(type: "smallint", nullable: true),
                    vad_ecm = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    typeTarifVad_ecm = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fixeVad_ecm = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    pourcentVad_ecm = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    restriction_ecm = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    info_ecm = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    id_prj = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ecommerc__D52A45A233F26AC2", x => x.id_ecm);
                    table.ForeignKey(
                        name: "FK__ecommerce__id_pr__4F7CD00D",
                        column: x => x.id_prj,
                        principalTable: "projet",
                        principalColumn: "id_prj");
                });

            migrationBuilder.CreateTable(
                name: "hebergement",
                columns: table => new
                {
                    id_heb = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_heb = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    type_heb = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    debut_heb = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fin_heb = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    tarif_heb = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    info_heb = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    id_prj = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__hebergem__D6EA62A1D0C1E418", x => x.id_heb);
                    table.ForeignKey(
                        name: "FK__hebergeme__id_pr__49C3F6B7",
                        column: x => x.id_prj,
                        principalTable: "projet",
                        principalColumn: "id_prj");
                });

            migrationBuilder.CreateTable(
                name: "maintenir",
                columns: table => new
                {
                    id_prj = table.Column<int>(type: "int", nullable: false),
                    id_mtn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__mainteni__290130E6B689B375", x => new { x.id_prj, x.id_mtn });
                    table.ForeignKey(
                        name: "FK__maintenir__id_mt__7A672E12",
                        column: x => x.id_mtn,
                        principalTable: "maintenance",
                        principalColumn: "id_mtn");
                    table.ForeignKey(
                        name: "FK__maintenir__id_pr__797309D9",
                        column: x => x.id_prj,
                        principalTable: "projet",
                        principalColumn: "id_prj");
                });

            migrationBuilder.CreateTable(
                name: "projet_langage",
                columns: table => new
                {
                    id_prj = table.Column<int>(type: "int", nullable: false),
                    id_lg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__projet_l__9FDD206C5B865E76", x => new { x.id_prj, x.id_lg });
                    table.ForeignKey(
                        name: "FK__projet_la__id_lg__6B24EA82",
                        column: x => x.id_lg,
                        principalTable: "langage",
                        principalColumn: "id_lg");
                    table.ForeignKey(
                        name: "FK__projet_la__id_pr__6A30C649",
                        column: x => x.id_prj,
                        principalTable: "projet",
                        principalColumn: "id_prj");
                });

            migrationBuilder.CreateTable(
                name: "referencement",
                columns: table => new
                {
                    id_ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_ref = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    position_ref = table.Column<byte>(type: "tinyint", nullable: true),
                    visite_ref = table.Column<int>(type: "int", nullable: true),
                    adwords_ref = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    fin_ref = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    tarif_ref = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    typeTarif = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    debut_ref = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    info_ref = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    id_prj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__referenc__6ABE6F0D1146F1FF", x => x.id_ref);
                    table.ForeignKey(
                        name: "FK__reference__id_pr__36B12243",
                        column: x => x.id_prj,
                        principalTable: "projet",
                        principalColumn: "id_prj");
                });

            migrationBuilder.CreateTable(
                name: "web",
                columns: table => new
                {
                    id_web = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contenu_web = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    formMail_web = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    restriction_web = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    responsive_web = table.Column<bool>(type: "bit", nullable: true),
                    malvoyant_web = table.Column<bool>(type: "bit", nullable: true),
                    daltonnien_web = table.Column<bool>(type: "bit", nullable: true),
                    aria_web = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    info_web = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    id_prj = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__web__6C6DA99206071ABD", x => x.id_web);
                    table.ForeignKey(
                        name: "FK__web__id_prj__5CD6CB2B",
                        column: x => x.id_prj,
                        principalTable: "projet",
                        principalColumn: "id_prj");
                });

            migrationBuilder.CreateTable(
                name: "etendre",
                columns: table => new
                {
                    id_prj = table.Column<int>(type: "int", nullable: false),
                    id_ext = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__etendre__629B00A63654450A", x => new { x.id_prj, x.id_ext });
                    table.ForeignKey(
                        name: "FK__etendre__id_ext__6754599E",
                        column: x => x.id_ext,
                        principalTable: "extension",
                        principalColumn: "id_ext");
                    table.ForeignKey(
                        name: "FK__etendre__id_prj__66603565",
                        column: x => x.id_prj,
                        principalTable: "projet",
                        principalColumn: "id_prj");
                });

            migrationBuilder.CreateTable(
                name: "compiler",
                columns: table => new
                {
                    id_prj = table.Column<int>(type: "int", nullable: false),
                    id_os = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__compiler__EFDD23E5442BDA82", x => new { x.id_prj, x.id_os });
                    table.ForeignKey(
                        name: "FK__compiler__id_os__6EF57B66",
                        column: x => x.id_os,
                        principalTable: "os",
                        principalColumn: "id_os");
                    table.ForeignKey(
                        name: "FK__compiler__id_prj__6E01572D",
                        column: x => x.id_prj,
                        principalTable: "projet",
                        principalColumn: "id_prj");
                });

            migrationBuilder.CreateTable(
                name: "telecharger",
                columns: table => new
                {
                    id_prj = table.Column<int>(type: "int", nullable: false),
                    id_str = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__telechar__091F65E39ACE690E", x => new { x.id_prj, x.id_str });
                    table.ForeignKey(
                        name: "FK__telecharg__id_pr__71D1E811",
                        column: x => x.id_prj,
                        principalTable: "projet",
                        principalColumn: "id_prj");
                    table.ForeignKey(
                        name: "FK__telecharg__id_st__72C60C4A",
                        column: x => x.id_str,
                        principalTable: "store",
                        principalColumn: "id_str");
                });

            migrationBuilder.CreateTable(
                name: "moduleCms",
                columns: table => new
                {
                    id_mdl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_mdl = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    version_mdl = table.Column<decimal>(type: "decimal(6,3)", nullable: true),
                    type_module = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    debut_mdl = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    info_mdl = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    id_lic = table.Column<int>(type: "int", nullable: true),
                    id_cms = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__moduleCm__6C8A0CDF396AE973", x => x.id_mdl);
                    table.ForeignKey(
                        name: "FK__moduleCms__id_cm__403A8C7D",
                        column: x => x.id_cms,
                        principalTable: "cms",
                        principalColumn: "id_cms");
                    table.ForeignKey(
                        name: "FK__moduleCms__id_li__3F466844",
                        column: x => x.id_lic,
                        principalTable: "licence",
                        principalColumn: "id_lic");
                });

            migrationBuilder.CreateTable(
                name: "connexion",
                columns: table => new
                {
                    id_con = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_con = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    pass_con = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    id_bd = table.Column<int>(type: "int", nullable: true),
                    id_ecm = table.Column<int>(type: "int", nullable: true),
                    id_drt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__connexio__D696717654F99157", x => x.id_con);
                    table.ForeignKey(
                        name: "FK__connexion__id_bd__52593CB8",
                        column: x => x.id_bd,
                        principalTable: "bd",
                        principalColumn: "id_bd");
                    table.ForeignKey(
                        name: "FK__connexion__id_dr__5441852A",
                        column: x => x.id_drt,
                        principalTable: "droit",
                        principalColumn: "id_drt");
                    table.ForeignKey(
                        name: "FK__connexion__id_ec__534D60F1",
                        column: x => x.id_ecm,
                        principalTable: "ecommerce",
                        principalColumn: "id_ecm");
                });

            migrationBuilder.CreateTable(
                name: "page",
                columns: table => new
                {
                    id_pg = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_pg = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    lien_pg = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    visite_pg = table.Column<int>(type: "int", nullable: true),
                    adwords_pg = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    id_ref = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__page__0148A345C2087800", x => x.id_pg);
                    table.ForeignKey(
                        name: "FK__page__id_ref__398D8EEE",
                        column: x => x.id_ref,
                        principalTable: "referencement",
                        principalColumn: "id_ref");
                });

            migrationBuilder.CreateTable(
                name: "personne",
                columns: table => new
                {
                    id_prs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_prs = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    prenom_prs = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fonction_prs = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    id_con = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__personne__6FC9A8683CB0E41F", x => x.id_prs);
                    table.ForeignKey(
                        name: "FK__personne__id_con__5FB337D6",
                        column: x => x.id_con,
                        principalTable: "connexion",
                        principalColumn: "id_con");
                });

            migrationBuilder.CreateTable(
                name: "coordonnees",
                columns: table => new
                {
                    id_crd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tel_crd = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    email_crd = table.Column<string>(type: "varchar(350)", unicode: false, maxLength: 350, nullable: true),
                    adresse_crd = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    adresse2_crd = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    postal_crd = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ville_crd = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    pays_crd = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    id_etp = table.Column<int>(type: "int", nullable: true),
                    id_prs = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__coordonn__D69649DB7E622033", x => x.id_crd);
                    table.ForeignKey(
                        name: "FK__coordonne__id_et__628FA481",
                        column: x => x.id_etp,
                        principalTable: "entreprise",
                        principalColumn: "id_etp");
                    table.ForeignKey(
                        name: "FK__coordonne__id_pr__6383C8BA",
                        column: x => x.id_prs,
                        principalTable: "personne",
                        principalColumn: "id_prs");
                });

            migrationBuilder.CreateTable(
                name: "representer",
                columns: table => new
                {
                    id_prs = table.Column<int>(type: "int", nullable: false),
                    id_etp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__represen__729B0695D0303249", x => new { x.id_prs, x.id_etp });
                    table.ForeignKey(
                        name: "FK__represent__id_et__76969D2E",
                        column: x => x.id_etp,
                        principalTable: "entreprise",
                        principalColumn: "id_etp");
                    table.ForeignKey(
                        name: "FK__represent__id_pr__75A278F5",
                        column: x => x.id_prs,
                        principalTable: "personne",
                        principalColumn: "id_prs");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_bd_id_lic",
                table: "bd",
                column: "id_lic");

            migrationBuilder.CreateIndex(
                name: "IX_bd_id_prj",
                table: "bd",
                column: "id_prj");

            migrationBuilder.CreateIndex(
                name: "IX_cms_id_prj",
                table: "cms",
                column: "id_prj");

            migrationBuilder.CreateIndex(
                name: "IX_compiler_id_os",
                table: "compiler",
                column: "id_os");

            migrationBuilder.CreateIndex(
                name: "IX_connexion_id_bd",
                table: "connexion",
                column: "id_bd");

            migrationBuilder.CreateIndex(
                name: "IX_connexion_id_drt",
                table: "connexion",
                column: "id_drt");

            migrationBuilder.CreateIndex(
                name: "IX_connexion_id_ecm",
                table: "connexion",
                column: "id_ecm");

            migrationBuilder.CreateIndex(
                name: "IX_coordonnees_id_etp",
                table: "coordonnees",
                column: "id_etp");

            migrationBuilder.CreateIndex(
                name: "IX_coordonnees_id_prs",
                table: "coordonnees",
                column: "id_prs");

            migrationBuilder.CreateIndex(
                name: "IX_developpement_id_prj",
                table: "developpement",
                column: "id_prj");

            migrationBuilder.CreateIndex(
                name: "IX_document_id_prj",
                table: "document",
                column: "id_prj");

            migrationBuilder.CreateIndex(
                name: "IX_domaine_id_prj",
                table: "domaine",
                column: "id_prj");

            migrationBuilder.CreateIndex(
                name: "IX_ecommerce_id_prj",
                table: "ecommerce",
                column: "id_prj");

            migrationBuilder.CreateIndex(
                name: "IX_etendre_id_ext",
                table: "etendre",
                column: "id_ext");

            migrationBuilder.CreateIndex(
                name: "IX_extension_id_lic",
                table: "extension",
                column: "id_lic");

            migrationBuilder.CreateIndex(
                name: "IX_hebergement_id_prj",
                table: "hebergement",
                column: "id_prj");

            migrationBuilder.CreateIndex(
                name: "IX_maintenir_id_mtn",
                table: "maintenir",
                column: "id_mtn");

            migrationBuilder.CreateIndex(
                name: "IX_moduleCms_id_cms",
                table: "moduleCms",
                column: "id_cms");

            migrationBuilder.CreateIndex(
                name: "IX_moduleCms_id_lic",
                table: "moduleCms",
                column: "id_lic");

            migrationBuilder.CreateIndex(
                name: "IX_os_id_lic",
                table: "os",
                column: "id_lic");

            migrationBuilder.CreateIndex(
                name: "IX_page_id_ref",
                table: "page",
                column: "id_ref");

            migrationBuilder.CreateIndex(
                name: "IX_personne_id_con",
                table: "personne",
                column: "id_con");

            migrationBuilder.CreateIndex(
                name: "IX_projet_id_etp",
                table: "projet",
                column: "id_etp");

            migrationBuilder.CreateIndex(
                name: "IX_projet_langage_id_lg",
                table: "projet_langage",
                column: "id_lg");

            migrationBuilder.CreateIndex(
                name: "IX_referencement_id_prj",
                table: "referencement",
                column: "id_prj");

            migrationBuilder.CreateIndex(
                name: "IX_representer_id_etp",
                table: "representer",
                column: "id_etp");

            migrationBuilder.CreateIndex(
                name: "IX_store_id_lic",
                table: "store",
                column: "id_lic");

            migrationBuilder.CreateIndex(
                name: "IX_telecharger_id_str",
                table: "telecharger",
                column: "id_str");

            migrationBuilder.CreateIndex(
                name: "IX_web_id_prj",
                table: "web",
                column: "id_prj");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "compiler");

            migrationBuilder.DropTable(
                name: "coordonnees");

            migrationBuilder.DropTable(
                name: "developpement");

            migrationBuilder.DropTable(
                name: "document");

            migrationBuilder.DropTable(
                name: "domaine");

            migrationBuilder.DropTable(
                name: "EntreprisePersonne");

            migrationBuilder.DropTable(
                name: "etendre");

            migrationBuilder.DropTable(
                name: "ExtensionProjet");

            migrationBuilder.DropTable(
                name: "hebergement");

            migrationBuilder.DropTable(
                name: "LangageProjet");

            migrationBuilder.DropTable(
                name: "MaintenanceProjet");

            migrationBuilder.DropTable(
                name: "maintenir");

            migrationBuilder.DropTable(
                name: "moduleCms");

            migrationBuilder.DropTable(
                name: "OProjet");

            migrationBuilder.DropTable(
                name: "page");

            migrationBuilder.DropTable(
                name: "projet_langage");

            migrationBuilder.DropTable(
                name: "ProjetStore");

            migrationBuilder.DropTable(
                name: "representer");

            migrationBuilder.DropTable(
                name: "telecharger");

            migrationBuilder.DropTable(
                name: "web");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "os");

            migrationBuilder.DropTable(
                name: "extension");

            migrationBuilder.DropTable(
                name: "maintenance");

            migrationBuilder.DropTable(
                name: "cms");

            migrationBuilder.DropTable(
                name: "referencement");

            migrationBuilder.DropTable(
                name: "langage");

            migrationBuilder.DropTable(
                name: "personne");

            migrationBuilder.DropTable(
                name: "store");

            migrationBuilder.DropTable(
                name: "connexion");

            migrationBuilder.DropTable(
                name: "bd");

            migrationBuilder.DropTable(
                name: "droit");

            migrationBuilder.DropTable(
                name: "ecommerce");

            migrationBuilder.DropTable(
                name: "licence");

            migrationBuilder.DropTable(
                name: "projet");

            migrationBuilder.DropTable(
                name: "entreprise");
        }
    }
}
