using appPFE.Modeles;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace appPFE.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Evolution> Evolutions { get; set; }
        public DbSet<AntecedentsFamiliaux> AntecedentFamiliaux { get; set; }

        public DbSet<Accouchement> Accouchements { get; set; }
        public DbSet<BilanBacteriologique> BilanBacteriologiques  { get; set; }
        public DbSet<BilanPrénatal> BilanPrénatal { get; set; }
        public DbSet<DdeEamenBiologique> DdeEamenBiologique { get; set; }
        public DbSet<DdeEamenExploration> DdeEamenExploration { get; set; }
        public DbSet<DdeReeducation> DdeReeducation { get; set; }
        public DbSet<EchographiesAnténatales> EchographiesAnténatales { get; set; }
        public DbSet<ExamenClinique> ExamenCliniques { get; set; }
        public DbSet<AntecedentPersonnels> AntecedentPersonnels { get; set; }
        public DbSet<Grossesse> Grossesse { get; set; }
        public DbSet<Lit> Lit { get; set; }
       public DbSet<AspectGenerale> AspectGenerale{ get; set; }
        public DbSet<BilanBacteriologique> BilanBacteriologique { get; set; }
        public DbSet<ConditionsTransfert> ConditionsTransfert { get; set; }
        public DbSet<Ordonnance> Ordonnance { get; set; }
        public DbSet<ScoreD_apgar> ScoreDapgar { get; set; }
        public DbSet<Secteur> Secteur { get; set; }
        public DbSet<StatuImmunitaire> StatuImmunitaire { get; set; }
        public DbSet<ExamenCutanePhaneres> ExamenCutanePhaneres { get; set; }
        public DbSet<ExamenCardHemo> ExamenCardHemo { get; set; }
        public DbSet<ExamenAbdominal> ExamenAbdominal { get; set; }
        public DbSet<ExamenNeurologique> ExamenNeurologique { get; set; }
        public DbSet<ExamenOphtalmologique> ExamenOphtalmologique { get; set; }
        public DbSet<ExamenOrthopedique> ExamenOrthopedique { get; set; }
        public DbSet<ExamenRespiratoire> ExamenRespiratoire { get; set; }
        public DbSet<ExamenSomatique> ExamenSomatique { get; set; }
        public DbSet<ExamenUroGenital> ExamenUroGenital { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<PatientUser> PatientUsers { get; set; }
        //public DbSet<AdmissionEvolution> AdmissionEvolution { get; set; }








        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.userId, ur.roleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.userId);


            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(ur => ur.UserRoles) // 
                .HasForeignKey(ur => ur.roleId);



            //AddRole(modelBuilder);


            modelBuilder.Entity<PatientUser>()
                 .HasKey(pu => new { pu.Ipp, pu.User_id });

            modelBuilder.Entity<PatientUser>()
                .HasOne(pu => pu.Patient)
                .WithMany(p => p.PatientUsers)
                .HasForeignKey(pu => pu.Ipp);

            modelBuilder.Entity<PatientUser>()
                .HasOne(pu => pu.User)
                .WithMany(u => u.PatientUsers)
                .HasForeignKey(pu => pu.User_id);



            /*modelBuilder.Entity<ExamenCliniqueUser>()
                .HasKey(ecu => new { ecu.ExamenCliniqueId, ecu.UserId });

            modelBuilder.Entity<ExamenCliniqueUser>()
                .HasOne(ecu => ecu.ExamenClinique)
                .WithMany(ec => ec.ExamenCliniqueUsers)
                .HasForeignKey(ecu => ecu.ExamenCliniqueId);

            modelBuilder.Entity<ExamenCliniqueUser>()
                .HasOne(ecu => ecu.User)
                .WithMany(u => u.ExamenCliniqueUsers)
                .HasForeignKey(ecu => ecu.UserId);

            */

         
            modelBuilder.Entity<Patient>()
                 .HasMany(e => e.Admissions)
                 .WithOne(e => e.Patient)
                 .HasForeignKey(e => e.AdmissionIpp);

            modelBuilder.Entity<ExamenClinique>()
          .HasOne(e => e.Patient)
          .WithMany(p => p.ExamenCliniques)
          .HasForeignKey(e => e.PatientIpp);

         

          
        
            modelBuilder.Entity<Patient>()
                .HasMany(e => e.AntecedentsFamiliaux)
                .WithOne(e => e.Patient)
                .HasForeignKey(e => e.PatientIpp);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.AntecedentPersonnels)
                .WithOne(e => e.Patient)
                .HasForeignKey(e => e.AntIpp);


            modelBuilder.Entity<AntecedentPersonnels>()
            .HasOne(e => e.accouchement)
            .WithOne(e => e.antecedentPersonnels)
            .HasForeignKey<AntecedentPersonnels>(e => e.IdAcc);

            modelBuilder.Entity<ExamenClinique>()
              .HasOne(e => e.Patient)
              .WithMany(p => p.ExamenCliniques)
              .HasForeignKey(e => e.PatientIpp);

            modelBuilder.Entity<Evolution>()
             .HasOne(e => e.Admission)
             .WithMany(p => p.Evolutions)
             .HasForeignKey(e => e.AdmissionId);

            modelBuilder.Entity<ConditionsTransfert>()
             .HasOne(e => e.Admission)
             .WithMany(p => p.ConditionsTransferts)
             .HasForeignKey(e => e.CtAdm);


            modelBuilder.Entity<Grossesse>()
               .HasMany(c => c.EchographiesAnténatales)
               .WithOne(e => e.Grossesse)
               .HasForeignKey(e => e.id_gros);

            modelBuilder.Entity<Grossesse>()
            .HasMany(c => c.StatuImmunitaire)
            .WithOne(e => e.Grossesse)
            .HasForeignKey(e => e.id_gros);

            modelBuilder.Entity<Grossesse>()
           .HasMany(c => c.BilanPrénatal)
           .WithOne(e => e.Grossesse)
           .HasForeignKey(e => e.id_gros);


            modelBuilder.Entity< ExamenClinique>()
             .HasOne(af => af.Patient)
             .WithMany(p => p.ExamenCliniques)
             .HasForeignKey(af => af.PatientIpp);

            modelBuilder.Entity<ExamenRespiratoire>()
             .HasOne(e => e.ExamenClinique)
             .WithOne(e => e.ExamenRespiratoire)
             .HasForeignKey<ExamenRespiratoire>(e => e.respId);

            modelBuilder.Entity<AspectGenerale>()
             .HasOne(er => er.ExamenClinique)
             .WithOne(ec => ec.AspectGenerale)
             .HasForeignKey<AspectGenerale>(p => p.examId);


            modelBuilder.Entity<ExamenUroGenital>()
             .HasOne(er => er.ExamenClinique)
             .WithOne(ec => ec.ExamenUroGenital)
             .HasForeignKey<ExamenUroGenital>(d => d.examId);

            modelBuilder.Entity<ExamenSomatique>()
            .HasOne(er => er.ExamenClinique)
            .WithOne(ec => ec.ExamenSomatique)
            .HasForeignKey<ExamenSomatique>(c => c.Examsom);

            modelBuilder.Entity<ExamenOphtalmologique>()
            .HasOne(er => er.ExamenClinique)
            .WithOne(ec => ec.ExamenOphtalmologique)
           .HasForeignKey<ExamenOphtalmologique>(r => r.ophtId);

            modelBuilder.Entity<ExamenOrthopedique>()
           .HasOne(er => er.ExamenClinique)
           .WithOne(ec => ec.ExamenOrthopedique)
           .HasForeignKey<ExamenOrthopedique>(t => t.ExamOrth);

            modelBuilder.Entity<ExamenNeurologique>()
           .HasOne(er => er.ExamenClinique)
           .WithOne(ec => ec.ExamenNeurologique)
           .HasForeignKey<ExamenNeurologique>(s => s.NeuroId);

            modelBuilder.Entity<ExamenCutanePhaneres>()
           .HasOne(er => er.ExamenClinique)
           .WithOne(ec => ec.ExamenCutanePhaneres)
            .HasForeignKey<ExamenCutanePhaneres>(q => q.ExamIdforginkey);

            modelBuilder.Entity<ExamenCardHemo>()
          .HasOne(er => er.ExamenClinique)
          .WithOne(ec => ec.ExamenCardHemo)
          .HasForeignKey<ExamenCardHemo>(v => v.examId);
            
            
            modelBuilder.Entity<ExamenAbdominal>()
         .HasOne(ea => ea.ExamenClinique)
          .WithOne(ec => ec.ExamenAbdominal)
          .HasForeignKey<ExamenAbdominal>(ea => ea.ExamAbdo);




            base.OnModelCreating(modelBuilder);


        }
        /* private static void AddRole(ModelBuilder modelBuilder)
             {
                 modelBuilder.Entity<Role>().HasData(
                     new Role { Role_id = 1, NomRole = "Admin" },
                     new Role { Role_id = 2, NomRole = "User", }
                 );
             }*/

    }








}

