using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appPFE.Modeles
{
    public class ExamenOrthopedique
        
    {
        [Key] 

        public int id_examOrth { get; set; }
        public int Num_examOrth { get; set; }
        public string clavicules { get; set; } = string.Empty;
        public string membresSuperieurs { get; set; } = string.Empty;
        public string membresInferieurs { get; set; } = string.Empty;
        public string rachis { get; set; } = string.Empty;
        public string ortolani { get; set; } = string.Empty;
        public string hanches { get; set; } = string.Empty;
        public string barlow { get; set; } = string.Empty;



        public int ExamOrth { get; set; }

        [ForeignKey("ExamOrth")]
        public ExamenClinique? ExamenClinique { get; set; }





    }
}
