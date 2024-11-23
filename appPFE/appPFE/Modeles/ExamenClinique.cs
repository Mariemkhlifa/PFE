using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appPFE.Modeles
{
    public class ExamenClinique
    {
        [Key]
        public int id_exam { get; set; }
        public int Num_exam { get; set; }
        public string nom_Dr { get; set; } = string.Empty;
        public DateOnly date_Ex { get; set; }
        public string heure_Ex { get; set; } = string.Empty;
        public string au_Tota { get; set; } = string.Empty;
        public string conduitAtenir { get; set; } = string.Empty;
        public string prognostic { get; set; } = string.Empty;
        public string discutionDiagnostique { get; set; } = string.Empty;
        public string age_Enfant { get; set; } = string.Empty;
        public int jourVie { get; set; }
        public string description { get; set; } = string.Empty;



        public int PatientIpp { get; set; }
        public Patient? Patient { get; set; }

        public int id_examResp { get; set; }
        public ExamenRespiratoire? ExamenRespiratoire { get; set; }

        public int id_examOrth { get; set; }
        public ExamenOrthopedique? ExamenOrthopedique { get; set; }

        public int id_examUG { get; set; }
        public ExamenUroGenital? ExamenUroGenital { get; set; }

        public int id_examS { get; set; }
        public ExamenSomatique? ExamenSomatique { get; set; }

        public int id_ExOph { get; set; }
        public ExamenOphtalmologique? ExamenOphtalmologique { get; set; }

        public int id_ExN { get; set; }
        public ExamenNeurologique? ExamenNeurologique { get; set; }

        public int id_examCP { get; set; }
        public ExamenCutanePhaneres? ExamenCutanePhaneres { get; set; }

        public int id_Aspect { get; set; }
        public AspectGenerale? AspectGenerale { get; set; }

        public int id_ExCardHEmo { get; set; }
        public ExamenCardHemo? ExamenCardHemo { get; set; }

        public int id_examA { get; set; }
        public ExamenAbdominal? ExamenAbdominal { get; set; }
    }
}
