using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appPFE.Modeles
{
    public class ExamenUroGenital
    {
        [Key]
        public int id_examUG { get; set; }
        public int Num_examUG { get; set; }
        public string fosses_Lombires { get; set; }= string.Empty;
        public string hypogastre { get; set; } = string.Empty;
        public string oge { get; set; } = string.Empty;
        public string differencies { get; set; } = string.Empty;
        public int premierMiction { get; set; } 
        public string ph { get; set; } = string.Empty;
        public string densite { get; set; } = string.Empty;


        public int examId { get; set; }
        public ExamenClinique? ExamenClinique { get; set; }


    }
}