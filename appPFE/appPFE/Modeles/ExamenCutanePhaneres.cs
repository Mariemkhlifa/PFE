using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appPFE.Modeles
{
    public class ExamenCutanePhaneres
    {
        [Key]
        public int id_examCP { get; set; }
        public int Num_examCP { get; set; }
        public string description { get; set; } = string.Empty;


        public int ExamIdforginkey { get; set; }

        [ForeignKey("ExamIdforginkey")]
        public ExamenClinique? ExamenClinique { get; set; }

    }
}
