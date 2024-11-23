using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appPFE.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accouchements",
                columns: table => new
                {
                    id_Acc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Acc = table.Column<int>(type: "int", nullable: false),
                    date_acc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nom_Dr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    num_tel = table.Column<int>(type: "int", nullable: false),
                    date_Repture = table.Column<DateOnly>(type: "date", nullable: false),
                    duree_repture = table.Column<int>(type: "int", nullable: false),
                    type_Repture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    abondanceLiquideAmniotique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    couleurLiquideAmniotique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    odeurLiquideAmniotique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_travail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duree_travail = table.Column<int>(type: "int", nullable: false),
                    passif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rcf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mode_acc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dilatation = table.Column<int>(type: "int", nullable: false),
                    typeCesarienne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    indicationCesarienne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    instrumentale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anesthesie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_Presentation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    etat_Cordon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    preciserEtatCordon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    etat_Placenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    preciserEtatPlacenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    desobstruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    O2_debit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aspiration_laryngoscope = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ventilation_masque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    intubation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ventilation_tube = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    medicament = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pn = table.Column<int>(type: "int", nullable: false),
                    tn = table.Column<int>(type: "int", nullable: false),
                    pcn = table.Column<int>(type: "int", nullable: false),
                    type_permeabiliteOrifices = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_prelevementMere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_prelevementNN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accouchements", x => x.id_Acc);
                });

            migrationBuilder.CreateTable(
                name: "BilanBacteriologique",
                columns: table => new
                {
                    Num_Bilan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hemocultureMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hemocultureGarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plGarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ecbuMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ecbuGarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ptpMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ptpGarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pg_ppMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pg_ppGarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    culture_protheseMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    culture_protheseGarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    autreMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    autreGarde = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BilanBacteriologique", x => x.Num_Bilan);
                });

            migrationBuilder.CreateTable(
                name: "DdeEamenBiologique",
                columns: table => new
                {
                    Num_Dde = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ipp = table.Column<int>(type: "int", nullable: false),
                    dateDde = table.Column<DateOnly>(type: "date", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DdeEamenBiologique", x => x.Num_Dde);
                });

            migrationBuilder.CreateTable(
                name: "DdeEamenExploration",
                columns: table => new
                {
                    Num_Dde = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ipp = table.Column<int>(type: "int", nullable: false),
                    dateDde = table.Column<DateOnly>(type: "date", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DdeEamenExploration", x => x.Num_Dde);
                });

            migrationBuilder.CreateTable(
                name: "DdeReeducation",
                columns: table => new
                {
                    Num_Dde = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ipp = table.Column<int>(type: "int", nullable: false),
                    dateDde = table.Column<DateOnly>(type: "date", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DdeReeducation", x => x.Num_Dde);
                });

            migrationBuilder.CreateTable(
                name: "Grossesse",
                columns: table => new
                {
                    id_gros = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    num_gros = table.Column<int>(type: "int", nullable: false),
                    type_gros = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ddr = table.Column<DateOnly>(type: "date", nullable: false),
                    termeNaissance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateTransfertEmbryon = table.Column<DateOnly>(type: "date", nullable: false),
                    nbrEmbryonsCongelés = table.Column<int>(type: "int", nullable: false),
                    TermeGrossse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomDr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbrConsulPrénatal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDernierConsul = table.Column<DateOnly>(type: "date", nullable: false),
                    PathologieGrav_Ops = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTransferEmbryen = table.Column<DateOnly>(type: "date", nullable: false),
                    TypeTransfer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grossesse", x => x.id_gros);
                });

            migrationBuilder.CreateTable(
                name: "Lit",
                columns: table => new
                {
                    Num_Lit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_Dr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lit", x => x.Num_Lit);
                });

            migrationBuilder.CreateTable(
                name: "Ordonnance",
                columns: table => new
                {
                    num_Ord = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_ordonnance = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordonnance", x => x.num_Ord);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Ipp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateNaiss = table.Column<DateTime>(type: "datetime2", nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sexe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priseChargeSociale = table.Column<int>(type: "int", nullable: false),
                    tel_Mere = table.Column<int>(type: "int", nullable: false),
                    tel_Pere = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Ipp);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreDapgar",
                columns: table => new
                {
                    Num_score = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    temps = table.Column<TimeOnly>(type: "time", nullable: false),
                    val_Cri = table.Column<int>(type: "int", nullable: false),
                    respiration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coeur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    couleur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tonus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reactivite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreDapgar", x => x.Num_score);
                });

            migrationBuilder.CreateTable(
                name: "Secteur",
                columns: table => new
                {
                    Num_Sec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_Dr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secteur", x => x.Num_Sec);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_user = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    num_tel = table.Column<int>(type: "int", nullable: false),
                    prenom_user = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    situation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdby = table.Column<int>(type: "int", nullable: false),
                    createdat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedby = table.Column<int>(type: "int", nullable: false),
                    updatedat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    statut = table.Column<bool>(type: "bit", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    refreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    refreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                });

            migrationBuilder.CreateTable(
                name: "BilanPrénatal",
                columns: table => new
                {
                    Num_Bilan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateGS = table.Column<int>(type: "int", nullable: false),
                    termeGS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultatGS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateTripleTest = table.Column<int>(type: "int", nullable: false),
                    termeTripleTest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultatTripleTest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateAmniocentese = table.Column<int>(type: "int", nullable: false),
                    termeAmniocentese = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultatAmniocentese = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    terme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateDepistageDiabete = table.Column<int>(type: "int", nullable: false),
                    resultatDepistageDiabete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    termeDepistageDiabete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateECBU = table.Column<int>(type: "int", nullable: false),
                    resultatECBU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    termeECBU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateNFS = table.Column<int>(type: "int", nullable: false),
                    resultatNFS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    termeNFS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateVaccination = table.Column<int>(type: "int", nullable: false),
                    resultatVaccination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    termeVaccination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateAutre = table.Column<int>(type: "int", nullable: false),
                    resultatAutre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    termeAutre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_gros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BilanPrénatal", x => x.Num_Bilan);
                    table.ForeignKey(
                        name: "FK_BilanPrénatal_Grossesse_id_gros",
                        column: x => x.id_gros,
                        principalTable: "Grossesse",
                        principalColumn: "id_gros",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EchographiesAnténatales",
                columns: table => new
                {
                    id_eco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_eco = table.Column<int>(type: "int", nullable: false),
                    nom_opérateur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    résultat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_datation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomOp_datation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultatOp_datation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_morphologiquePrécoce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomOp_morphologiquePrécoce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultatOp_morphologiquePrécoce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_morphologiqueTardive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomOp_morphologiqueTardive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultatOp_morphologiqueTardive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_gros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EchographiesAnténatales", x => x.id_eco);
                    table.ForeignKey(
                        name: "FK_EchographiesAnténatales_Grossesse_id_gros",
                        column: x => x.id_gros,
                        principalTable: "Grossesse",
                        principalColumn: "id_gros",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatuImmunitaire",
                columns: table => new
                {
                    num_statut = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateToxoplasme = table.Column<int>(type: "int", nullable: false),
                    termeToxoplasme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultatToxoplasme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateRubecole = table.Column<int>(type: "int", nullable: false),
                    termeRubecole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultatRubecole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateSyphilis = table.Column<int>(type: "int", nullable: false),
                    termeSyphilis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultatSyphilis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateAgHBs = table.Column<int>(type: "int", nullable: false),
                    termeAgHBs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultatAgHBs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateHVC = table.Column<int>(type: "int", nullable: false),
                    termeHVC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultatHVC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateHIC = table.Column<int>(type: "int", nullable: false),
                    termeHIC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultatHIC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateCMV = table.Column<int>(type: "int", nullable: false),
                    termeCMV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resultatCMV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_gros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatuImmunitaire", x => x.num_statut);
                    table.ForeignKey(
                        name: "FK_StatuImmunitaire_Grossesse_id_gros",
                        column: x => x.id_gros,
                        principalTable: "Grossesse",
                        principalColumn: "id_gros",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    id_adm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_adm = table.Column<int>(type: "int", nullable: false),
                    dateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    auTotal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    conduiteATenir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discussionDiagnostique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pronosticImmediat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pronosticMoyenTerme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pronosticLongTerme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codePathologique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateSortie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmissionIpp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => x.id_adm);
                    table.ForeignKey(
                        name: "FK_Admissions_Patients_AdmissionIpp",
                        column: x => x.AdmissionIpp,
                        principalTable: "Patients",
                        principalColumn: "Ipp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AntecedentFamiliaux",
                columns: table => new
                {
                    Id_AntecF = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    interrogation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_interogation = table.Column<DateOnly>(type: "date", nullable: false),
                    nomPrenomPere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomPrenomMere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateMariage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nbreAnneeMariage = table.Column<int>(type: "int", nullable: false),
                    AgePere = table.Column<int>(type: "int", nullable: false),
                    AgeMere = table.Column<int>(type: "int", nullable: false),
                    dateNaissPere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateNaissMere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gouvernementPere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gouvernementMere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    poidsPere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    poidsMere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    taillePere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tailleMere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gs_rhesusPere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gs_rhesusMere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    niveauEtudeMere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    niveauEtudePere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionSocialePere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionSocialeMere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    militaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    consanguinite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addictionsSocialeP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addictionsSocialeM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    antecedentpMedicauxPere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    antecedentpMedicauxMere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    antecedentChirurgicauxPere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    antecedentChirurgicauxMere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gynecoObsetetricaux = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientIpp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentFamiliaux", x => x.Id_AntecF);
                    table.ForeignKey(
                        name: "FK_AntecedentFamiliaux_Patients_PatientIpp",
                        column: x => x.PatientIpp,
                        principalTable: "Patients",
                        principalColumn: "Ipp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AntecedentPersonnels",
                columns: table => new
                {
                    Id_AntecP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    types = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AntIpp = table.Column<int>(type: "int", nullable: false),
                    IdAcc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentPersonnels", x => x.Id_AntecP);
                    table.ForeignKey(
                        name: "FK_AntecedentPersonnels_Accouchements_IdAcc",
                        column: x => x.IdAcc,
                        principalTable: "Accouchements",
                        principalColumn: "id_Acc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AntecedentPersonnels_Patients_AntIpp",
                        column: x => x.AntIpp,
                        principalTable: "Patients",
                        principalColumn: "Ipp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamenCliniques",
                columns: table => new
                {
                    id_exam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_exam = table.Column<int>(type: "int", nullable: false),
                    nom_Dr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_Ex = table.Column<DateOnly>(type: "date", nullable: false),
                    heure_Ex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    au_Tota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    conduitAtenir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prognostic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discutionDiagnostique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age_Enfant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jourVie = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientIpp = table.Column<int>(type: "int", nullable: false),
                    id_examResp = table.Column<int>(type: "int", nullable: false),
                    id_examOrth = table.Column<int>(type: "int", nullable: false),
                    id_examUG = table.Column<int>(type: "int", nullable: false),
                    id_examS = table.Column<int>(type: "int", nullable: false),
                    id_ExOph = table.Column<int>(type: "int", nullable: false),
                    id_ExN = table.Column<int>(type: "int", nullable: false),
                    id_examCP = table.Column<int>(type: "int", nullable: false),
                    id_Aspect = table.Column<int>(type: "int", nullable: false),
                    id_ExCardHEmo = table.Column<int>(type: "int", nullable: false),
                    id_examA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenCliniques", x => x.id_exam);
                    table.ForeignKey(
                        name: "FK_ExamenCliniques_Patients_PatientIpp",
                        column: x => x.PatientIpp,
                        principalTable: "Patients",
                        principalColumn: "Ipp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LitSecteur",
                columns: table => new
                {
                    litNum_Lit = table.Column<int>(type: "int", nullable: false),
                    secteurNum_Sec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LitSecteur", x => new { x.litNum_Lit, x.secteurNum_Sec });
                    table.ForeignKey(
                        name: "FK_LitSecteur_Lit_litNum_Lit",
                        column: x => x.litNum_Lit,
                        principalTable: "Lit",
                        principalColumn: "Num_Lit",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LitSecteur_Secteur_secteurNum_Sec",
                        column: x => x.secteurNum_Sec,
                        principalTable: "Secteur",
                        principalColumn: "Num_Sec",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientUsers",
                columns: table => new
                {
                    Ipp = table.Column<int>(type: "int", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientUsers", x => new { x.Ipp, x.User_id });
                    table.ForeignKey(
                        name: "FK_PatientUsers_Patients_Ipp",
                        column: x => x.Ipp,
                        principalTable: "Patients",
                        principalColumn: "Ipp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientUsers_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.userId, x.roleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "Role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConditionsTransfert",
                columns: table => new
                {
                    Num_Condition = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_Transfert = table.Column<DateOnly>(type: "date", nullable: false),
                    medicatise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    identiteTransporteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coordonnees = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accompagnateurs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vehicule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chaudModalites = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chaudMoIncubateur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chaudRemarques = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    glucoseMVoieDabord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    glucoseMSiege = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    glucoseRSondeGastrique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    glucoseMNatureSolutes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    oxygeneMTecnique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    oxygeneRParametre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    infromationMParents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    infromationRTubeSongMere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    asepieM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pendentTransfer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    arriver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    etatGeneral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CtAdm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionsTransfert", x => x.Num_Condition);
                    table.ForeignKey(
                        name: "FK_ConditionsTransfert_Admissions_CtAdm",
                        column: x => x.CtAdm,
                        principalTable: "Admissions",
                        principalColumn: "id_adm",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evolutions",
                columns: table => new
                {
                    Num_Ev = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_evolution = table.Column<DateOnly>(type: "date", nullable: false),
                    nomsMedicins = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ictere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    braceletNaissance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    braceletAdmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    poids = table.Column<int>(type: "int", nullable: false),
                    valeur = table.Column<int>(type: "int", nullable: false),
                    sexe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    respiratoireMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    respiratoireGarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hemodynamiqueMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hemodynamiqueGarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    neurlogiqueMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    neurlogiqueGarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    septiqueMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    septiqueGarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    metaboliqueMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    metaboliqueGarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nutritionnelMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nutritionnelGarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    digestifMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    digestifGarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutreMatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutreGarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    consignes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evolutions", x => x.Num_Ev);
                    table.ForeignKey(
                        name: "FK_Evolutions_Admissions_AdmissionId",
                        column: x => x.AdmissionId,
                        principalTable: "Admissions",
                        principalColumn: "id_adm",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspectGenerale",
                columns: table => new
                {
                    id_Aspect = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Aspect = table.Column<int>(type: "int", nullable: false),
                    impressionGenerale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phototype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coloration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    malformationApparente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    poids = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ptlePoids = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    taille = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ptleTaille = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ptlePc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    temperature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dexto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    examId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspectGenerale", x => x.id_Aspect);
                    table.ForeignKey(
                        name: "FK_AspectGenerale_ExamenCliniques_examId",
                        column: x => x.examId,
                        principalTable: "ExamenCliniques",
                        principalColumn: "id_exam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamenAbdominal",
                columns: table => new
                {
                    id_examA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    abdomen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ombilic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anusHeure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamAbdo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenAbdominal", x => x.id_examA);
                    table.ForeignKey(
                        name: "FK_ExamenAbdominal_ExamenCliniques_ExamAbdo",
                        column: x => x.ExamAbdo,
                        principalTable: "ExamenCliniques",
                        principalColumn: "id_exam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamenCardHemo",
                columns: table => new
                {
                    id_ExCardHEmo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_ExCardHEmo = table.Column<int>(type: "int", nullable: false),
                    fc = table.Column<int>(type: "int", nullable: false),
                    rythme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    poulsFemoraux = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    poulsMS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    auscultationCardiaque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    premierMiction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    examId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenCardHemo", x => x.id_ExCardHEmo);
                    table.ForeignKey(
                        name: "FK_ExamenCardHemo_ExamenCliniques_examId",
                        column: x => x.examId,
                        principalTable: "ExamenCliniques",
                        principalColumn: "id_exam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamenCutanePhaneres",
                columns: table => new
                {
                    id_examCP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_examCP = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamIdforginkey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenCutanePhaneres", x => x.id_examCP);
                    table.ForeignKey(
                        name: "FK_ExamenCutanePhaneres_ExamenCliniques_ExamIdforginkey",
                        column: x => x.ExamIdforginkey,
                        principalTable: "ExamenCliniques",
                        principalColumn: "id_exam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamenNeurologique",
                columns: table => new
                {
                    id_ExN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_ExN = table.Column<int>(type: "int", nullable: false),
                    cri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vigilance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gesticulation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fontanelleAnterieure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sutures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tonusAxial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tonusPeripherique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reflexesArchaique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maturiteNeurologique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mouvementAnormaux = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NeuroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenNeurologique", x => x.id_ExN);
                    table.ForeignKey(
                        name: "FK_ExamenNeurologique_ExamenCliniques_NeuroId",
                        column: x => x.NeuroId,
                        principalTable: "ExamenCliniques",
                        principalColumn: "id_exam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamenOphtalmologique",
                columns: table => new
                {
                    id_ExOph = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_ExOph = table.Column<int>(type: "int", nullable: false),
                    globuleOculairesOeilDroit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    globuleOculairesOeilGauche = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pupillesOeilDroit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pupillesOeilGauche = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cristallinOeilDroit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cristallinOeilGauche = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reflexePhotomoteurDroit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reflexePhotomoteurOeilGauche = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ophtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenOphtalmologique", x => x.id_ExOph);
                    table.ForeignKey(
                        name: "FK_ExamenOphtalmologique_ExamenCliniques_ophtId",
                        column: x => x.ophtId,
                        principalTable: "ExamenCliniques",
                        principalColumn: "id_exam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamenOrthopedique",
                columns: table => new
                {
                    id_examOrth = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_examOrth = table.Column<int>(type: "int", nullable: false),
                    clavicules = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    membresSuperieurs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    membresInferieurs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rachis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ortolani = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hanches = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    barlow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamOrth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenOrthopedique", x => x.id_examOrth);
                    table.ForeignKey(
                        name: "FK_ExamenOrthopedique_ExamenCliniques_ExamOrth",
                        column: x => x.ExamOrth,
                        principalTable: "ExamenCliniques",
                        principalColumn: "id_exam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamenRespiratoire",
                columns: table => new
                {
                    id_examResp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_ExResp = table.Column<int>(type: "int", nullable: false),
                    morphplogieThoracique = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amplitationThoracique = table.Column<int>(type: "int", nullable: false),
                    fr = table.Column<int>(type: "int", nullable: false),
                    rythme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apnee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pause = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cyanose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ausclationPulmonaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ventilation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    num_Ste = table.Column<int>(type: "int", nullable: false),
                    narine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    repere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fr_ven = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fiO2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    saTo2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    geignement_cot = table.Column<int>(type: "int", nullable: false),
                    tirageSus_cot = table.Column<int>(type: "int", nullable: false),
                    entonnoir_cot = table.Column<int>(type: "int", nullable: false),
                    balancements_cot = table.Column<int>(type: "int", nullable: false),
                    batements_cot = table.Column<int>(type: "int", nullable: false),
                    total_cot = table.Column<int>(type: "int", nullable: false),
                    respId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenRespiratoire", x => x.id_examResp);
                    table.ForeignKey(
                        name: "FK_ExamenRespiratoire_ExamenCliniques_respId",
                        column: x => x.respId,
                        principalTable: "ExamenCliniques",
                        principalColumn: "id_exam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamenSomatique",
                columns: table => new
                {
                    id_examS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_examS = table.Column<int>(type: "int", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    calculeFarr = table.Column<int>(type: "int", nullable: false),
                    calculeBallar = table.Column<int>(type: "int", nullable: false),
                    agFarr = table.Column<int>(type: "int", nullable: false),
                    ageBallar = table.Column<int>(type: "int", nullable: false),
                    Examsom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenSomatique", x => x.id_examS);
                    table.ForeignKey(
                        name: "FK_ExamenSomatique_ExamenCliniques_Examsom",
                        column: x => x.Examsom,
                        principalTable: "ExamenCliniques",
                        principalColumn: "id_exam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamenUroGenital",
                columns: table => new
                {
                    id_examUG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_examUG = table.Column<int>(type: "int", nullable: false),
                    fosses_Lombires = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hypogastre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    oge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    differencies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    premierMiction = table.Column<int>(type: "int", nullable: false),
                    ph = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    densite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    examId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenUroGenital", x => x.id_examUG);
                    table.ForeignKey(
                        name: "FK_ExamenUroGenital_ExamenCliniques_examId",
                        column: x => x.examId,
                        principalTable: "ExamenCliniques",
                        principalColumn: "id_exam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_AdmissionIpp",
                table: "Admissions",
                column: "AdmissionIpp");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentFamiliaux_PatientIpp",
                table: "AntecedentFamiliaux",
                column: "PatientIpp");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentPersonnels_AntIpp",
                table: "AntecedentPersonnels",
                column: "AntIpp");

            migrationBuilder.CreateIndex(
                name: "IX_AntecedentPersonnels_IdAcc",
                table: "AntecedentPersonnels",
                column: "IdAcc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspectGenerale_examId",
                table: "AspectGenerale",
                column: "examId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BilanPrénatal_id_gros",
                table: "BilanPrénatal",
                column: "id_gros");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionsTransfert_CtAdm",
                table: "ConditionsTransfert",
                column: "CtAdm");

            migrationBuilder.CreateIndex(
                name: "IX_EchographiesAnténatales_id_gros",
                table: "EchographiesAnténatales",
                column: "id_gros");

            migrationBuilder.CreateIndex(
                name: "IX_Evolutions_AdmissionId",
                table: "Evolutions",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenAbdominal_ExamAbdo",
                table: "ExamenAbdominal",
                column: "ExamAbdo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamenCardHemo_examId",
                table: "ExamenCardHemo",
                column: "examId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamenCliniques_PatientIpp",
                table: "ExamenCliniques",
                column: "PatientIpp");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenCutanePhaneres_ExamIdforginkey",
                table: "ExamenCutanePhaneres",
                column: "ExamIdforginkey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamenNeurologique_NeuroId",
                table: "ExamenNeurologique",
                column: "NeuroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamenOphtalmologique_ophtId",
                table: "ExamenOphtalmologique",
                column: "ophtId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamenOrthopedique_ExamOrth",
                table: "ExamenOrthopedique",
                column: "ExamOrth",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamenRespiratoire_respId",
                table: "ExamenRespiratoire",
                column: "respId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamenSomatique_Examsom",
                table: "ExamenSomatique",
                column: "Examsom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamenUroGenital_examId",
                table: "ExamenUroGenital",
                column: "examId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LitSecteur_secteurNum_Sec",
                table: "LitSecteur",
                column: "secteurNum_Sec");

            migrationBuilder.CreateIndex(
                name: "IX_PatientUsers_User_id",
                table: "PatientUsers",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_StatuImmunitaire_id_gros",
                table: "StatuImmunitaire",
                column: "id_gros");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_roleId",
                table: "UserRoles",
                column: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AntecedentFamiliaux");

            migrationBuilder.DropTable(
                name: "AntecedentPersonnels");

            migrationBuilder.DropTable(
                name: "AspectGenerale");

            migrationBuilder.DropTable(
                name: "BilanBacteriologique");

            migrationBuilder.DropTable(
                name: "BilanPrénatal");

            migrationBuilder.DropTable(
                name: "ConditionsTransfert");

            migrationBuilder.DropTable(
                name: "DdeEamenBiologique");

            migrationBuilder.DropTable(
                name: "DdeEamenExploration");

            migrationBuilder.DropTable(
                name: "DdeReeducation");

            migrationBuilder.DropTable(
                name: "EchographiesAnténatales");

            migrationBuilder.DropTable(
                name: "Evolutions");

            migrationBuilder.DropTable(
                name: "ExamenAbdominal");

            migrationBuilder.DropTable(
                name: "ExamenCardHemo");

            migrationBuilder.DropTable(
                name: "ExamenCutanePhaneres");

            migrationBuilder.DropTable(
                name: "ExamenNeurologique");

            migrationBuilder.DropTable(
                name: "ExamenOphtalmologique");

            migrationBuilder.DropTable(
                name: "ExamenOrthopedique");

            migrationBuilder.DropTable(
                name: "ExamenRespiratoire");

            migrationBuilder.DropTable(
                name: "ExamenSomatique");

            migrationBuilder.DropTable(
                name: "ExamenUroGenital");

            migrationBuilder.DropTable(
                name: "LitSecteur");

            migrationBuilder.DropTable(
                name: "Ordonnance");

            migrationBuilder.DropTable(
                name: "PatientUsers");

            migrationBuilder.DropTable(
                name: "ScoreDapgar");

            migrationBuilder.DropTable(
                name: "StatuImmunitaire");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Accouchements");

            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "ExamenCliniques");

            migrationBuilder.DropTable(
                name: "Lit");

            migrationBuilder.DropTable(
                name: "Secteur");

            migrationBuilder.DropTable(
                name: "Grossesse");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
