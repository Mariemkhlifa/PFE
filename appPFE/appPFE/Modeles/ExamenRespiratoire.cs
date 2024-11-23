using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appPFE.Modeles
{
    public class ExamenRespiratoire
    {
        [Key]
        public int id_examResp { get; set; }
        public int Num_ExResp { get; set; }
        public string morphplogieThoracique { get; set; } = string.Empty;
        public int amplitationThoracique { get; set; }
        public int fr { get; set; }
        public string rythme { get; set; } = string.Empty;
        public string apnee { get; set; } = string.Empty;
        public string pause { get; set; } = string.Empty;
        public string cyanose { get; set; } = string.Empty;
        public string ausclationPulmonaire { get; set; } = string.Empty;
        public string ventilation { get; set; } = string.Empty;
        public int num_Ste { get; set; }
        public string narine { get; set; } = string.Empty;
        public string repere { get; set; } = string.Empty;
        public string pic { get; set; } = string.Empty;
        public string pep { get; set; } = string.Empty;
        public string fr_ven { get; set; } = string.Empty;
        public string fiO2 { get; set; } = string.Empty;
        public string saTo2 { get; set; } = string.Empty;
        public int geignement_cot { get; set; }
        public int tirageSus_cot { get; set; }
        public int entonnoir_cot { get; set; }
        public int balancements_cot { get; set; }
        public int batements_cot { get; set; }
        public int total_cot { get; set; }



        public int respId { get; set; }
        public ExamenClinique? ExamenClinique { get; set; }









    }
}
