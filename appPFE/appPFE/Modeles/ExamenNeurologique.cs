using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appPFE.Modeles
{
    public class ExamenNeurologique
    {
        [Key]
        public int id_ExN { get; set; }
        public int Num_ExN { get; set; }
        public string cri { get; set; } = string.Empty;
        public string vigilance { get; set; } = string.Empty;
        public string gesticulation { get; set; } = string.Empty;
        public string fontanelleAnterieure { get; set; } = string.Empty;
        public string sutures { get; set; } = string.Empty;
        public string tonusAxial { get; set; } = string.Empty;
        public string tonusPeripherique { get; set; } = string.Empty;
        public string reflexesArchaique { get; set; } = string.Empty;
        public string maturiteNeurologique { get; set; } = string.Empty;
        public string mouvementAnormaux { get; set; } = string.Empty;


        public int NeuroId { get; set; }

        public ExamenClinique? ExamenClinique { get; set; }



    }
}
