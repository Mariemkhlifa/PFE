using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appPFE.Modeles
{
    public class ExamenCardHemo
    {
        [Key]
        public int id_ExCardHEmo { get; set; }
        public int Num_ExCardHEmo { get; set; }
        public int fc { get; set; }
        public string rythme { get; set; } = string.Empty;
        public string trc { get; set; } = string.Empty;
        public string ta { get; set; } = string.Empty;
        public string poulsFemoraux { get; set; } = string.Empty;
        public string poulsMS { get; set; } = string.Empty;
        public string auscultationCardiaque { get; set; } = string.Empty;
        public string direse { get; set; } = string.Empty;
        public string premierMiction { get; set; } = string.Empty;

        public int examId { get; set; }

        public ExamenClinique? ExamenClinique { get; set; }








    }
}
