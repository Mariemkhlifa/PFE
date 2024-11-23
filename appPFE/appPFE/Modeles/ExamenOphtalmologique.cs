using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appPFE.Modeles
{
    public class ExamenOphtalmologique
    {
        [Key]
        public int id_ExOph { get; set; }
        public int Num_ExOph { get; set; }
        public string globuleOculairesOeilDroit { get; set; } = string.Empty;
        public string globuleOculairesOeilGauche { get; set; } = string.Empty;
        public string pupillesOeilDroit { get; set; } = string.Empty;
        public string pupillesOeilGauche { get; set; } = string.Empty;
        public string cristallinOeilDroit { get; set; } = string.Empty;
        public string cristallinOeilGauche { get; set; } = string.Empty;
        public string reflexePhotomoteurDroit { get; set; } = string.Empty;
        public string reflexePhotomoteurOeilGauche { get; set; } = string.Empty;

        public int ophtId { get; set; }

        [ForeignKey("ophtId")]
        public ExamenClinique? ExamenClinique { get; set; }


    }
}
