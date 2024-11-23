using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appPFE.Modeles
{
    public class AspectGenerale
    {
        [Key]
        public int id_Aspect { get; set; }
        public int Num_Aspect { get; set; }
        public string impressionGenerale { get; set; } = string.Empty;
        public string phototype { get; set; } = string.Empty;
        public string coloration { get; set; } = string.Empty;
        public string malformationApparente { get; set; } = string.Empty;
        public string poids { get; set; } = string.Empty;
        public string ptlePoids { get; set; } = string.Empty;
        public string taille { get; set; } = string.Empty;
        public string ptleTaille { get; set; } = string.Empty;
        public string pc { get; set; } = string.Empty;
        public string ptlePc { get; set; } = string.Empty;
        public string temperature { get; set; } = string.Empty;
        public string dexto { get; set; } = string.Empty;

        public int examId { get; set; }
        public ExamenClinique? ExamenClinique { get; set; }


    }
}
