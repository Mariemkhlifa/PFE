using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class BilanPrénatal
    {
        [Key]
        public int Num_Bilan { get; set; }
        public DataType dateGS { get; set; }
        public string termeGS { get; set; } = string.Empty;
        public string resultatGS { get; set; } = string.Empty;
        public DataType dateTripleTest { get; set; }
        public string termeTripleTest { get; set; } = string.Empty;
        public string resultatTripleTest { get; set; } = string.Empty;
        public DataType dateAmniocentese { get; set; }
        public string termeAmniocentese { get; set; } = string.Empty;
        public string resultatAmniocentese { get; set; } = string.Empty; 
        public string terme { get; set; } = string.Empty;
        public DataType dateDepistageDiabete { get; set; }
        public string resultatDepistageDiabete { get; set; } = string.Empty; 
        public string termeDepistageDiabete { get; set; } = string.Empty;
        public DataType dateECBU { get; set; }
        public string resultatECBU { get; set; } = string.Empty;
        public string termeECBU { get; set; } = string.Empty;
        public DataType dateNFS { get; set; }
        public string resultatNFS { get; set; } = string.Empty; 
        public string termeNFS { get; set; } = string.Empty;
        public DataType dateVaccination { get; set; }
        public string resultatVaccination { get; set; } = string.Empty; 
        public string termeVaccination { get; set; } = string.Empty;
        public DataType dateAutre { get; set; }
        public string resultatAutre { get; set; } = string.Empty;
        public string termeAutre { get; set; } = string.Empty;

        public int id_gros { get; set; }
        public Grossesse? Grossesse { get; set; }
    }
}
