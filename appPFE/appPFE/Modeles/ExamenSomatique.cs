using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appPFE.Modeles
{
    public class ExamenSomatique
    {
        [Key]
        public int id_examS { get; set; }
        public int Num_examS { get; set; }
        public int score { get; set; }
        public int calculeFarr { get; set; }
        public int calculeBallar { get; set; }
        public int agFarr { get; set; }
        public int ageBallar { get; set; }


        // Navigation property to ExamenClinique
        public int Examsom { get; set; }

        [ForeignKey("Examsom")]
        public ExamenClinique? ExamenClinique { get; set; }

    }
}
