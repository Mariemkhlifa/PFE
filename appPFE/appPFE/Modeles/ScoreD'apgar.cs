using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class ScoreD_apgar
    {
        [Key]
        public int Num_score { get; set; }
        public TimeOnly temps { get; set; }
        public int val_Cri { get; set; }
        public string respiration { get; set; } = string.Empty;
        public string coeur { get; set; } = string.Empty;
        public string couleur { get; set; } = string.Empty;
        public string tonus { get; set; } = string.Empty;
        public string reactivite { get; set; } = string.Empty;
        public string total { get; set; } = string.Empty;


    }
}
