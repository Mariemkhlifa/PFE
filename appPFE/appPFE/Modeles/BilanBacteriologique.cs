using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class BilanBacteriologique
    {
        [Key]
        public int Num_Bilan { get; set; }
        public string hemocultureMatin { get; set; } = string.Empty;
        public string hemocultureGarde { get; set; } = string.Empty;
        public string plMatin { get; set; } = string.Empty;
        public string plGarde { get; set; } = string.Empty;
        public string ecbuMatin { get; set; } = string.Empty;
        public string ecbuGarde { get; set; } = string.Empty;
        public string ptpMatin { get; set; } = string.Empty;
        public string ptpGarde { get; set; } = string.Empty;
        public string pg_ppMatin { get; set; } = string.Empty;
        public string pg_ppGarde{ get; set; } = string.Empty;
        public string culture_protheseMatin { get; set; } = string.Empty;
        public string culture_protheseGarde { get; set; } = string.Empty;
        public string autreMatin { get; set; } = string.Empty;
        public string autreGarde { get; set; } = string.Empty;





    }
}
