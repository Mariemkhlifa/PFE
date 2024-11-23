using System.ComponentModel.DataAnnotations;

namespace appPFE.Dtos
{
    public class EvolutionDto
    {
        [Key]
        public int Num_Ev { get; set; }
        public DateOnly date_evolution { get; set; }
        public string nomsMedicins { get; set; } = string.Empty;
        public string ictere { get; set; } = string.Empty;
        public string braceletNaissance { get; set; } = string.Empty;
        public string braceletAdmission { get; set; } = string.Empty;
        public int poids { get; set; }
        public int valeur { get; set; }
        public string sexe { get; set; } = string.Empty;
        public string respiratoireMatin { get; set; } = string.Empty;
        public string respiratoireGarde { get; set; } = string.Empty;
        public string hemodynamiqueMatin { get; set; } = string.Empty;
        public string hemodynamiqueGarde { get; set; } = string.Empty;
        public string neurlogiqueMatin { get; set; } = string.Empty;
        public string neurlogiqueGarde { get; set; } = string.Empty;
        public string septiqueMatin { get; set; } = string.Empty;
        public string septiqueGarde { get; set; } = string.Empty;
        public string metaboliqueMatin { get; set; } = string.Empty;
        public string metaboliqueGarde { get; set; } = string.Empty;
        public string nutritionnelMatin { get; set; } = string.Empty;
        public string nutritionnelGarde { get; set; } = string.Empty;
        public string digestifMatin { get; set; } = string.Empty;
        public string digestifGarde { get; set; } = string.Empty;
        public string AutreMatin { get; set; } = string.Empty;
        public string AutreGarde { get; set; } = string.Empty;
        public string consignes { get; set; } = string.Empty;
    }
}
