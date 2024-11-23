using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class ExamenAbdominal
    {
        [Key]
        public int id_examA { get; set; }
        public string abdomen { get; set; } = string.Empty;
        public string ombilic { get; set; } = string.Empty;
        public string foie { get; set; } = string.Empty;
        public string rate { get; set; } = string.Empty;
        public string anus { get; set; } = string.Empty;
        public string anusHeure { get; set; } = string.Empty;


        public int ExamAbdo { get; set; }

        public ExamenClinique? ExamenClinique { get; set; }
    }
}
